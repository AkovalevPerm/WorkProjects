namespace SyncAdapterService.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.Audit.Objects;
    using ICSSoft.STORMNET.KeyGen;
    using ICSSoft.STORMNET.UserDataTypes;
    using IIS.University.Tools;

    public static class AuditTools
    {
        private const string OperationCreateType = "Создание";

        private static readonly View ViewForField = new View(
            new ViewAttribute("ViewForField", new[]
            {
                nameof(AuditField.Field),
                nameof(AuditField.AuditEntity),
                nameof(AuditField.OldValue),
                nameof(AuditField.NewValue),
                nameof(AuditField.MainChange)
            }),
            typeof(AuditField));

        /// <summary>
        /// Получить список изменившихся полей по ключу изменения аудита - AuditEntity.
        /// </summary>
        /// <param name="changeAuditPK">Гуид AuditEntity</param>
        /// <returns></returns>
        public static List<string> GetChangeFieldFromAuditEntityByPK(Guid changeAuditPK)
        {
            var auditEntityObj = PKHelper.CreateDataObject<AuditEntity>(changeAuditPK);
            try
            {
                DataServiceFactory.AppDataService.LoadObject(AuditEntity.Views.AuditEntityE, auditEntityObj, false,
                    true);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Ошибка при попытке загрузить операцию изменения {nameof(AuditEntity)}({changeAuditPK}). {ex.Message}");
            }

            var auditFieldsLcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditField), ViewForField);
            List<AuditField> changedFields;
            try
            {
                // Загружаем набор изменившихся полей из аудита
                auditFieldsLcs.LimitFunction =
                    FunctionBuilder.BuildEquals<AuditField>(x => x.AuditEntity, auditEntityObj);
                changedFields = DataServiceFactory.AppDataService.LoadObjects(auditFieldsLcs).Cast<AuditField>()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Произошла ошибка при попытке получить набор изменений полей для операции аудита:{PKHelper.GetGuidByObject(auditEntityObj)}. {ex.Message}");
            }

            var changedFieldList = changedFields.Where(y => y.MainChange == null).Select(x =>
            {
                var fieldName = x.Field;
                var separateIndex = fieldName.IndexOf(" ", StringComparison.Ordinal);
                if (separateIndex > 0)
                {
                    fieldName = fieldName.Substring(0, separateIndex);
                }

                return fieldName;
            }).ToList();

            return changedFieldList;
        }

        /// <summary>
        /// Получить объект на заданную дату.
        /// </summary>
        /// <param name="date">Дата на которую следует откатить состояние объекта</param>
        /// <param name="obj">Объект, который откатываем на заданную дату.</param>
        /// <param name="onlySelfObj">Откатывать только сам объект, т.е. в обратное состояния вернутся все собственные поля объекта и все собственные ссылочные объекты(мастра и детейлы) только ключи</param>
        /// <param name="forceNullAgregator">Объект вернётся в состояние сразу после заданной даты.
        ///  Если откатываем создание объекта, то возвращаем путой объект с первичным ключом.
        ///  Если объект был удалён и ведётся аудит удаления, то он будет восстановлен со всеми своими собственными полями, иначе если аудит удаления отключен, у удаленного объекта будет проинициализирован только первичный ключ.
        /// </param>
        public static void GetObjForDate(DateTime date, ref DataObject obj, bool onlySelfObj = true,
            bool forceNullAgregator = false)
        {
            if (obj != null)
            {
                var objType = obj.GetType();
                try
                {
                    obj.DisableInitDataCopy();
                    // Не кидается исключение о не существовании объекта, если объект был удалён и ведётся аудит удаления, то он будет восстановлен со всеми своими собственными полями, иначе если аудит удаления отключен, у удаленного объекта будет проинициализирован только первичный ключ.
                    DataServiceFactory.AppDataService.LoadObject(new View(objType, View.ReadType.WithRelated), obj,
                        true, false);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ошибка при попытке вычитать изменнённый объект из БД. {ex.Message}");
                }

                List<AuditEntity> changedAuditEntity;
                try
                {
                    var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditEntity),
                        AuditEntity.Views.AuditEntityE);
                    lcs.LimitFunction = FunctionBuilder.BuildAnd(
                        #pragma warning disable CS0618 // Используем не дженерик вариант, иначе не работает вычитка
                        FunctionBuilder.BuildEquals(nameof(AuditEntity.ObjectPrimaryKey), obj.__PrimaryKey),
                        #pragma warning restore CS0618 // Тип или член устарел
                        FunctionBuilder.BuildGreater<AuditEntity>(x => x.OperationTime, date));
                    // Загружаем изменения строго больше даты на которую хотим откатить => получаем объект в состоянии сразу после этой даты.
                    lcs.ColumnsSort = new[] {new ColumnsSortDef(nameof(AuditEntity.OperationTime), SortOrder.Desc)};
                    changedAuditEntity =
                        DataServiceFactory.AppDataService.LoadObjects(lcs).Cast<AuditEntity>().ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        $"Ошибка при попытке загрузить операции изменения {nameof(AuditEntity)} для объекта({obj.__PrimaryKey}). {ex.Message}");
                }

                var auditFieldsLcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditField), ViewForField);
                foreach (var changeEntity in changedAuditEntity)
                {
                    if (changeEntity.OperationType != OperationCreateType)
                    {
                        List<AuditField> changedFields;
                        try
                        {
                            // Загружаем набор изменившихся полей из аудита
                            auditFieldsLcs.LimitFunction =
                                FunctionBuilder.BuildEquals<AuditField>(x => x.AuditEntity, changeEntity);
                            changedFields = DataServiceFactory.AppDataService.LoadObjects(auditFieldsLcs)
                                .Cast<AuditField>().ToList();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(
                                $"Произошла ошибка при попытке получить набор изменений полей для операции аудита:{PKHelper.GetGuidByObject(changeEntity)}. {ex.Message}");
                        }

                        //Берём только изменения, вспомогательные объекты LinkedPrimaryKey остаются в основном списке.
                        var onlySelfChangedFields = changedFields.Where(y => y.MainChange == null);
                        foreach (var changedField in onlySelfChangedFields)
                        {
                            var mainChange =
                                changedFields.FirstOrDefault(x => PKHelper.EQPK(x.MainChange, changedField));
                            if (mainChange == null)
                            {
                                //Если основного изменения нет, то это обычное поле
                                var propertyInfo = objType.GetProperty(changedField.Field);
                                if (propertyInfo != null)
                                {
                                    var typeprop = propertyInfo.PropertyType;
                                    object value = null;
                                    try
                                    {
                                        if (changedField.OldValue != null)
                                        {
                                            if (typeprop.IsEnum)
                                            {
                                                value = EnumCaption.GetValueFor(changedField.OldValue, typeprop);
                                            }
                                            else if (typeprop == typeof(NullableDateTime))
                                            {
                                                value = NullableDateTime.Parse(changedField.OldValue);
                                            }
                                            else if (typeprop == typeof(NullableInt))
                                            {
                                                value = NullableInt.Parse(changedField.OldValue);
                                            }
                                            else
                                            {
                                                value = Convert.ChangeType(changedField.OldValue, typeprop, CultureInfo.InvariantCulture);
                                            }
                                        }

                                        propertyInfo.SetValue(obj, value);
                                    }
                                    catch (Exception ex)
                                    {
                                        var errorText = value != null
                                            ? $"AuditField:{PKHelper.GetGuidByObject(changedField)} Ошибка при попытке установить значение поля {value} в объект {objType.Name}:{PKHelper.GetGuidByObject(obj)} поле {changedField.Field}"
                                            : $"AuditField:{PKHelper.GetGuidByObject(changedField)} Ошибка при попытке преобразовать значение поля {changedField.OldValue} в тип {typeprop.Name}";
                                        throw new Exception($"{errorText}. {ex.Message}");
                                    }
                                }
                                else
                                {
                                    throw new Exception(
                                        $"Ошибка - не найдено поле {changedField.Field} в объекте {objType.Name}.");
                                }
                            }
                            else
                            {
                                // Есть основное изменение, значит это изменение ссылочного объекта.
                                // Только если изменилась ссылка
                                if (mainChange.OldValue != mainChange.NewValue)
                                {
                                    // В аудите детейл отличается от мастера тем, что у него приписывается в скобках позиция
                                    if (Regex.IsMatch(changedField.Field, "[ ][(][0-9]+[)]$"))
                                    {
                                        // Это изменение детейла объекта.
                                        var separateIndex = changedField.Field.IndexOf(" ", StringComparison.Ordinal);
                                        var detailNameFromField = changedField.Field.Substring(0, separateIndex);
                                        var propertyInfo = objType.GetProperty(detailNameFromField);
                                        if (propertyInfo != null)
                                        {
                                            if (propertyInfo.GetValue(obj) is DetailArray detailValue)
                                            {
                                                if (changedField.OldValue == "-NULL-")
                                                {
                                                    var key = new KeyGuid(mainChange.NewValue);
                                                    try
                                                    {
                                                        detailValue.RemoveByKey(key);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        throw new Exception(
                                                            $"Ошибка при попытке удалить объект с ключом {key} из детейла {detailNameFromField} в объекте {objType.Name}. {ex.Message}");
                                                    }
                                                }
                                                else
                                                {
                                                    var detailItemType = detailValue.ItemType;
                                                    var oldDetailObj = Helper.CreateDataObject(detailItemType,
                                                        mainChange.OldValue);
                                                    try
                                                    {
                                                        detailValue.AddObject(oldDetailObj);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        throw new Exception(
                                                            $"Ошибка при добавить объект с ключом {PKHelper.GetGuidByObject(oldDetailObj)} в детейл {detailNameFromField} в объекте {objType.Name}. {ex.Message}");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception(
                                                $"Ошибка - не найден детейл {detailNameFromField} в объекте {objType.Name}.");
                                        }
                                    }
                                    else
                                    {
                                        // Это изменение мастера объекта.
                                        var propertyInfo = objType.GetProperty(changedField.Field);
                                        if (propertyInfo != null)
                                        {
                                            //Это свойство является агрегатором, для детейла
                                            var itIsAgregator =
                                                propertyInfo.GetCustomAttribute<AgregatorAttribute>() != null;
                                            if (changedField.OldValue == "-NULL-" ||
                                                forceNullAgregator && itIsAgregator)
                                            {
                                                //Если свойство является агрегатором для детейла, то в последующих витках рекурсии всегда возвращаем нулл для такого поля, во избежание циклических ссылок.
                                                propertyInfo.SetValue(obj, null);
                                            }
                                            else
                                            {
                                                var typeprop = propertyInfo.PropertyType;
                                                var oldMasterObj =
                                                    Helper.CreateDataObject(typeprop, mainChange.OldValue);
                                                try
                                                {
                                                    propertyInfo.SetValue(obj, oldMasterObj);
                                                }
                                                catch (Exception ex)
                                                {
                                                    throw new Exception(
                                                        $"Ошибка при попытке установить свойство мастера {changedField.Field} в объекте {objType.Name}. {ex.Message}");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception(
                                                $"Ошибка - не найден мастер {changedField.Field} в объекте {objType.Name}.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Если откатываем создание объекта, то возвращаем путой объект с первичным ключом.
                        obj = Helper.CreateDataObject(objType, obj.__PrimaryKey);
                    }
                }

                // На этом этапе основной объект и все его собственные поля и зависимые сущности возвращены на дату
                // Получаем мастера и откатываем их поля, рекурсивно вызывая этот метод
                // Получаем детейлы объекта и откатываем их поля, рекурсивно вызывая этот метод
                if (!onlySelfObj && changedAuditEntity.Any())
                {
                    var objProperties = objType.GetProperties();
                    foreach (var property in objProperties)
                    {
                        var typeprop = property.PropertyType;
                        if (typeprop.IsSubclassOf(typeof(DataObject)))
                        {
                            //Перебираем все мастера
                            var masterValue = property.GetValue(obj) as DataObject;
                            GetObjForDate(date, ref masterValue, false, true);
                        }
                        else if (typeprop.IsSubclassOf(typeof(DetailArray)))
                        {
                            //Перебираем все детейлы
                            if (property.GetValue(obj) is DetailArray detailValue)
                            {
                                var detailObjects = detailValue.GetAllObjects();
                                foreach (var dataObject in detailObjects)
                                {
                                    var currentObj = dataObject;
                                    GetObjForDate(date, ref currentObj, false, true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}