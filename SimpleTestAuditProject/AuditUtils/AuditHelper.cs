namespace AuditUtils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.Audit.Objects;
    using ICSSoft.STORMNET.KeyGen;
    using IIS.University.Tools;

    public static class AuditHelper
    {
        private static readonly View ViewForKey = new View(
            new ViewAttribute("ViewForKey", new[]
            {
                nameof(AuditEntity.ObjectPrimaryKey),
                nameof(AuditEntity.OperationTime),
                nameof(AuditEntity.ObjectType),
                Information.ExtractPropertyPath<AuditEntity>(x => x.ObjectType.Name)
            }),
            typeof(AuditEntity));

        private static readonly View ViewForType = new View(
            new ViewAttribute("ViewForType", new[]
            {
                nameof(AuditEntity.ObjectPrimaryKey),
                nameof(AuditEntity.ObjectType),
                Information.ExtractPropertyPath<AuditEntity>(x => x.ObjectType.Name)
            }),
            typeof(AuditEntity));

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

        private static IDataService _dataService;

        public static IDataService DataService
        {
            get { return _dataService ?? DataServiceProvider.DataService; }
            set { _dataService = value; }
        }

        private const string operationCreateType = "Создание";

        /// <summary>
        ///     Получить изменения объектов по типу за период.
        /// </summary>
        /// <param name="from"> Начало периода.</param>
        /// <param name="until"> Конец периода.</param>
        /// <param name="typeName"> Название типа(поиск по like '&typename&').</param>
        /// <param name="getFullChildChanges"> Получить полные изменения связанных мастеров и детейлов.</param>
        /// <returns></returns>
        public static List<AuditChange> GetChangesByPeriodByType(DateTime from, DateTime until, string typeName,
            bool getFullChildChanges = false)
        {
            var списокВсехИзмененийЗаПериод = new List<AuditChange>();
            var наборКлючейОбъектовИзменившихсяЗапериодериод = GetObjKeyChangesByPeriod(from, until, typeName);
            // Для каждого ключа, получаем набор соответствующих ему изменений.
            foreach (var ключ in наборКлючейОбъектовИзменившихсяЗапериодериод)
            {
                var изменениеПоКлючу = GetChangesByPeriodByPK(from, until, ключ, getFullChildChanges);
                if (изменениеПоКлючу != null)
                {
                    списокВсехИзмененийЗаПериод.Add(изменениеПоКлючу);
                }
            }

            return списокВсехИзмененийЗаПериод;
        }

        /// <summary>
        ///     Получить изменеия объекта по ключу за период.
        /// </summary>
        /// <param name="from"> Начало периода.</param>
        /// <param name="until"> Конец периода.</param>
        /// <param name="objPk"> Ключ объекта.</param>
        /// <param name="getFullChildChanges"> Получить полные изменения связанных мастеров и детейлов.</param>
        /// <returns></returns>
        public static AuditChange GetChangesByPeriodByPK(DateTime from, DateTime until, string objPk,
            bool getFullChildChanges = false)
        {
            var mainChanges = GetChangesByPeriodByPK(from, until, objPk, true, false);
            if (getFullChildChanges)
            {
                GetFullChildPropertyChanges(mainChanges, from, until);
            }

            return mainChanges;
        }

        private static List<string> GetObjKeyChangesByPeriod(DateTime from, DateTime until, string typeName)
        {
            var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditEntity), ViewForKey);
            lcs.LimitFunction = FunctionBuilder.BuildAnd(
                FunctionBuilder.BuildLike<AuditEntity>(x => x.ObjectType.Name, $"%{typeName}%"),
                FunctionBuilder.BuildBetween<AuditEntity>(x => x.OperationTime, from, until));
            var операцииПоТипуЗаВремя = DataService.LoadObjects(lcs).Cast<AuditEntity>().ToList();
            return операцииПоТипуЗаВремя.Select(x => x.ObjectPrimaryKey.ToString()).Distinct().ToList();
        }

        private static void GetFullChildPropertyChanges(AuditChange mainChange, DateTime from, DateTime until)
        {
            if (mainChange != null)
            {
                var mastersKeys = new List<string>();
                mastersKeys.AddRange(mainChange.MastersChanges.Keys);
                foreach (var masterChangeKey in mastersKeys)
                {
                    var objKey = mainChange.MastersChanges[masterChangeKey].ObjPrimaryKey;
                    mainChange.MastersChanges[masterChangeKey] =
                        GetChangesByPeriodByPK(from, until, objKey, true, true);
                }

                var detailsKeys = new List<string>();
                detailsKeys.AddRange(mainChange.DetailsChanges.Keys);
                foreach (var detailChangeKey in detailsKeys)
                {
                    var objKey = mainChange.DetailsChanges[detailChangeKey].ObjPrimaryKey;
                    mainChange.DetailsChanges[detailChangeKey] =
                        GetChangesByPeriodByPK(from, until, objKey, true, true);
                }
            }
        }

        private static tAuditOperation GetAuditOperationType(List<AuditEntity> операцииЗаВремя)
        {
            tAuditOperation итоговаяОперация;
            if (операцииЗаВремя.Any())
            {
                var былоСоздание = операцииЗаВремя.Exists(x => x.OperationType == "Создание");
                var былоУдаление = операцииЗаВремя.Exists(x => x.OperationType == "Удаление");
                if (былоСоздание && былоУдаление)
                {
                    итоговаяОперация = tAuditOperation.CreateAndDelete;
                }
                else if (былоСоздание)
                {
                    итоговаяОперация = tAuditOperation.Create;
                }
                else if (былоУдаление)
                {
                    итоговаяОперация = tAuditOperation.Delete;
                }
                else
                {
                    итоговаяОперация = tAuditOperation.Edited;
                }
            }
            else
            {
                итоговаяОперация = tAuditOperation.NoChange;
            }

            return итоговаяОперация;
        }

        private static string GetObjTypeByPK(string objPk)
        {
            var тип = "";
            var messageError = "";

            try
            {
                var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditEntity), ViewForType);
                lcs.LimitFunction = FunctionBuilder.BuildEquals(nameof(AuditEntity.ObjectPrimaryKey), objPk);
                lcs.ReturnTop = 1;
                тип = DataService.LoadObjects(lcs).Cast<AuditEntity>().FirstOrDefault()?.ObjectTypeQualifiedName ?? "";
                if (string.IsNullOrEmpty(тип))
                {
                    messageError = "Не удалось вычислить поле AuditEntity.ObjectTypeQualifiedName";
                }
            }
            catch (Exception ex)
            {
                messageError = ex.Message;
            }

            if (string.IsNullOrEmpty(тип))
            {
                LogService.LogError(
                    $@"Произошла ошибка при попытке получить тип для объекта с ключом {objPk}.{Environment.NewLine}{
                            messageError
                        }");
                тип = "!Error!";
            }

            return тип;
        }

        private static AuditChange GetChangesByPeriodByPK(DateTime from, DateTime until, string objPk, bool firstLoop,
            bool recursive)
        {
            var операцииЗаПериод = new List<AuditEntity>();
            try
            {
                var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditEntity),
                    AuditEntity.Views.AuditEntityE);
                lcs.LimitFunction = FunctionBuilder.BuildAnd(
                    FunctionBuilder.BuildEquals(nameof(AuditEntity.ObjectPrimaryKey), objPk),
                    FunctionBuilder.BuildBetween<AuditEntity>(x => x.OperationTime, from, until));
                операцииЗаПериод = DataService.LoadObjects(lcs).Cast<AuditEntity>().OrderBy(x => x.OperationTime)
                    .ToList();
            }
            catch (Exception ex)
            {
                LogService.LogError(
                    $@"Произошла ошибка при попытке получить изменения за период {from.ToShortDateString()} - {
                            until.ToShortDateString()
                        } для объекта с ключом {objPk}.{Environment.NewLine}{ex.Message}");
            }

            var итоговыйСтатусОбъекта = GetAuditOperationType(операцииЗаПериод);
            var изменениеОбъекта = new AuditChange
            {
                Type = GetObjTypeByPK(objPk),
                ObjPrimaryKey = objPk,
                Operation = итоговыйСтатусОбъекта
            };

            if (итоговыйСтатусОбъекта != tAuditOperation.CreateAndDelete
                && итоговыйСтатусОбъекта != tAuditOperation.NoChange
                && (firstLoop || recursive))
            {
                var fieldsLcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditField), ViewForField);
                foreach (var операцияИзменения in операцииЗаПериод)
                {
                    var измененияПолей = new List<AuditField>();
                    try
                    {
                        fieldsLcs.LimitFunction = FunctionBuilder.BuildEquals<AuditField>(x => x.AuditEntity,
                            операцияИзменения);
                        измененияПолей = DataService.LoadObjects(fieldsLcs).Cast<AuditField>().ToList();
                    }
                    catch (Exception ex)
                    {
                        LogService.LogError(
                            $@"Произошла ошибка при попытке получить набор изменения изменения полей за период {
                                    from.ToShortDateString()
                                } - {until.ToShortDateString()} для объекта с ключом {objPk} для изменения с ключом {
                                    операцияИзменения.__PrimaryKey
                                }.{Environment.NewLine}{ex.Message}");
                    }

                    var толькоСобственныеИзменения = измененияПолей.Where(
                        y => y.MainChange != null
                             || !измененияПолей.Exists(x => PKHelper.EQPK(x.MainChange, y)));

                    foreach (var измененныйАтрибут in толькоСобственныеИзменения)
                    {
                        if (измененныйАтрибут.MainChange == null)
                        {
                            // Это изменение собственного поля.
                            изменениеОбъекта.FieldsChanges[измененныйАтрибут.Field] = измененныйАтрибут.NewValue;
                        }
                        else
                        {
                            var главноеИзменение =
                                измененияПолей.First(x => PKHelper.EQPK(x, измененныйАтрибут.MainChange));
                            if (Regex.IsMatch(главноеИзменение.Field, "[ ][(][0-9]+[)]$"))
                            {
                                // Это изменение детейла.
                                var номерДетейла = Regex.Match(главноеИзменение.Field, "[ ][(][0-9]+[)]$").Value;
                                // Если ссылка на детейл стала нулл, то соберём изменение удаления этого объекта.
                                var ключДетейла = измененныйАтрибут.NewValue == "-NULL-"
                                    ? измененныйАтрибут.OldValue
                                    : измененныйАтрибут.NewValue;

                                // Заменяем номер детейла на ключ объекта. Так как номер переприсваевается следующими по порядку детейлу,
                                // в качестве ключа изменения детейла используем тип детейла и его первичного ключа заключенный в между@@
                                изменениеОбъекта.DetailsChanges[
                                        главноеИзменение.Field.Replace(номерДетейла, $"@{ключДетейла}@")] =
                                    GetChangesByPeriodByPK(from, until, ключДетейла, false, recursive);
                            }
                            else
                            {
                                // Это изменение мастера.
                                // Если ссылка на мастра стала нулл, то и изменения не будем собирать, возвращаем нулл.
                                изменениеОбъекта.MastersChanges[главноеИзменение.Field] =
                                    измененныйАтрибут.NewValue == "-NULL-"
                                        ? null
                                        : GetChangesByPeriodByPK(from, until, измененныйАтрибут.NewValue, false,
                                            recursive);
                            }
                        }
                    }
                }
            }

            return изменениеОбъекта;
        }

        public static void GetObjForDate(DateTime date, ref DataObject obj, Guid? changeAuditPK = null,
            bool onlySelfObj = true)
        {
            if (obj != null)
            {
                try
                {
                    //Загружаем текущее состояние объекта по выбранному представлению
                    obj.DisableInitDataCopy();
                    //это объект никогда не будет сохраняться в бд, копия данных -, производительность +
                    DataService.LoadObject("AuditView", obj, true, false);
                }
                catch (Exception ex)
                {
                    //throw new LoadChangedObjectException(appObjType.Name, appObjPK, ex.Message);
                    LogService.LogError("Ошибка при вычитке объекта из бд");
                    //TODO поймать исключение о существовании объекта
                    //объект в текущий момент может быть удалён, тогда его нельзя будет загрузить из бд
                    // нужно ли вообще по нему что-то высылать кроме ключа елси его он всё равно будет удалён следующими сообщениями?
                    //Объект восстановиться, если ведется аудит удаления для него - запись удаленя - это занулление всех текущих значений
                }

                var changedAuditEntity = new List<AuditEntity>();
                try
                {
                    var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditEntity),
                        AuditEntity.Views.AuditEntityE);
                    lcs.LimitFunction = FunctionBuilder.BuildAnd(
                        FunctionBuilder.BuildEquals(nameof(AuditEntity.ObjectPrimaryKey), obj.__PrimaryKey),
                        FunctionBuilder.BuildGreaterOrEqual<AuditEntity>(x => x.OperationTime, date));
                    lcs.ColumnsSort = new[] {new ColumnsSortDef(nameof(AuditEntity.OperationTime), SortOrder.Desc)};
                    changedAuditEntity = DataService.LoadObjects(lcs).Cast<AuditEntity>().ToList();
                }
                catch (Exception ex)
                {
                    LogService.LogError(@"Ошибка при загрузке операций изменения из аудита");
                }

                var lastChange = changedAuditEntity.LastOrDefault();
                if (changeAuditPK.HasValue && PKHelper.GetGuidByObject(lastChange) != changeAuditPK)
                {
                    LogService.LogError(
                        @"Ошибка сбой при загрузке изменеий! Обнаружено не соответствиие загруженных изменений и ссылки на изменения аудита в synclogitem");
                }

                var objType = obj.GetType();
                var auditFieldsLcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(AuditField), ViewForField);
                foreach (var changeEntity in changedAuditEntity)
                {
                    if (changeEntity.OperationType != operationCreateType)
                    {
                        var changedFields = new List<AuditField>();
                        try
                        {
                            auditFieldsLcs.LimitFunction =
                                FunctionBuilder.BuildEquals<AuditField>(x => x.AuditEntity, changeEntity);
                            changedFields = DataService.LoadObjects(auditFieldsLcs).Cast<AuditField>().ToList();
                        }
                        catch (Exception ex)
                        {
                            LogService.LogError(
                                $@"Произошла ошибка при попытке получить набор изменения изменения полей за период.{
                                        Environment.NewLine
                                    }{ex.Message}");
                        }

                        //Берём только изменения, вспомогательные объекты LinkedPrimaryKey остаются в основном списке
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
                                            value = Convert.ChangeType(changedField.OldValue, typeprop);
                                        }

                                        propertyInfo.SetValue(obj, value);
                                    }
                                    catch (Exception ex)
                                    {
                                        LogService.LogError(value != null
                                            ? $"Ошибка установки поля {changedField.Field}"
                                            : $"Ошибка преобразования типа полей");
                                    }
                                }
                                else
                                {
                                    LogService.LogError(
                                        $@"Ошбика не найдено поле {changedField.Field} в объекте {objType.Name}.");
                                }
                            }
                            else
                            {
                                // В аудите детейл отличается от мастера тем, что у него приписывается в скобках позиция
                                if (Regex.IsMatch(changedField.Field, "[ ][(][0-9]+[)]$"))
                                {
                                    var separateIndex = changedField.Field.IndexOf(" ", StringComparison.Ordinal);
                                    var detailNameFromField = changedField.Field.Substring(0, separateIndex);
                                    var propertyInfo = objType.GetProperty(detailNameFromField);
                                    if (propertyInfo != null)
                                    {
                                        var detailValue = propertyInfo.GetValue(obj) as DetailArray;
                                        if (detailValue != null)
                                        {
                                            //TODO исследовать возможность пустой ссылки на детейл
                                            if (changedField.OldValue == "-NULL-")
                                            {
                                                var key = new KeyGuid(mainChange.NewValue);
                                                detailValue.RemoveByKey(key);
                                            }
                                            else
                                            {
                                                var detailItemType = detailValue.ItemType;
                                                var oldDetailObj =
                                                    GetInstanseOfObjWithPK(detailItemType, mainChange.OldValue);
                                                detailValue.AddObject(oldDetailObj);
                                            }
                                        }

                                        /*else
                                        {
                                            LogService.LogError(
                                                $@"Ошибка не найден детейл {detailNameFromField} в объекте {objType.Name}.");
                                        }*/
                                    }
                                    else
                                    {
                                        LogService.LogError(
                                            $@"Ошибка не найден детейл {
                                                    detailNameFromField
                                                } в объекте {objType.Name}.");
                                    }
                                }
                                else
                                {
                                    var propertyInfo = objType.GetProperty(changedField.Field);
                                    if (propertyInfo != null)
                                    {
                                        // Это изменение мастера.
                                        if (changedField.OldValue == "-NULL-")
                                        {
                                            propertyInfo.SetValue(obj, null);
                                        }
                                        else
                                        {
                                            var typeprop = propertyInfo.PropertyType;
                                            var oldMasterObj = GetInstanseOfObjWithPK(typeprop, mainChange.OldValue);
                                            propertyInfo.SetValue(obj, oldMasterObj);
                                        }
                                    }
                                    else
                                    {
                                        LogService.LogError(
                                            $@"Ошбика не найден мастер {changedField.Field} в объекте {objType.Name}.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Если откатываем создание объекта, то возвращаем нулл.
                        obj = null;
                    }
                }

                // На этом этапе основной объект и все его собственные поля и зависимые сущности возвращены на дату
                // Получаем мастера и откатываем их поля, рекурсивно вызывая этот метод
                // Получаем детейлы объекта и откатываем их поля, рекурсивно вызывая этот метод
                if (!onlySelfObj)
                {
                    var objProperties = objType.GetProperties();
                    foreach (var property in objProperties)
                    {
                        var typeprop = property.PropertyType;
                        if (typeprop.IsSubclassOf(typeof(DataObject)))
                        {
                            //Перебираем все мастера
                            var masterValue = property.GetValue(obj) as DataObject;
                            GetObjForDate(date, ref masterValue, null, onlySelfObj);
                        }
                        else if (typeprop.IsSubclassOf(typeof(DetailArray)))
                        {
                            //Перебираем все детейлы
                            var detailValue = property.GetValue(obj) as DetailArray;
                            var detailObjects = detailValue.GetAllObjects();
                            foreach (var dataObject in detailObjects)
                            {
                                var currentObj = dataObject;
                                GetObjForDate(date, ref currentObj, null, onlySelfObj);
                            }
                        }
                    }
                }
            }
        }

        public static DataObject GetInstanseOfObjWithPK(Type type, object pk)
        {
            object result = null;
            var method = typeof(PKHelper).GetMethod(
                nameof(PKHelper.CreateDataObject),
                BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly,
                null,
                CallingConventions.Any,
                new[] {typeof(object)},
                null);
            if (method != null)
            {
                var generic = method.MakeGenericMethod(type);
                result = generic.Invoke(null, new[] {pk});
            }

            return result as DataObject;
        }
    }
}