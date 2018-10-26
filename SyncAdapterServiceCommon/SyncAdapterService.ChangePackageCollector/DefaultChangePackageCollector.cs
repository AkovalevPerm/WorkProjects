namespace SyncAdapterService.ChangePackageCollector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CustomException;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.FunctionalLanguage;
    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers;
    using IIS.Synchronizer.Services;
    using IIS.University.Tools;
    using Interfaces;
    using SyncAdapterService.Mappers.CustomException;
    using SyncAdapterService.MessageCreator;
    using SyncAdapterService.Utils;
    using XMLDataModel;
    using XMLDataModel.Interface;
    using XMLMessageModel.Interface;

    public abstract class DefaultChangePackageCollector : IChangePackageCollector

    {
        private const string LogErrorMessageHeader =
            "ChangePackageCollector: Возникла ошибка при попытке собрать изменения.";

        private const string LogWarnMessageHeader =
            "ChangePackageCollector: Возникло предупреждение при попытке собрать изменения.";

        protected IDataService AppDataService = DataServiceFactory.AppDataService;

        protected IDataService SyncDataService = DataServiceFactory.SyncDataService;

        /// <inheritdoc />
        public virtual void PackChanges<TMessage, TItem>(DateTime? fromDate = null, DateTime? toDate = null)
            where TMessage : IDataChangeMessageResponce<TItem>
            where TItem : IChangedItem
        {
            //Перевычисляем дату с которой будет собирать изменения, что бы не отправить изменения повторно.
            CalculateFromDate<TMessage, TItem>(ref fromDate);
            LogService.LogInfo(
                $"ChangePackageCollector: Начата обработка фактов-изменений для сообщения типа {typeof(TMessage).Name}{Helper.GetDatePartAsString(fromDate, toDate)}.");

            try
            {
                //Узнаём сколько фактов-изменений было за период с последний отправки изменений.
                var syncEntityView = SyncDOEntity.Views.E;
                syncEntityView.AddProperties(Information.ExtractPropertyPath<SyncDOEntity>(x => x.Setting.Source.Name));
                var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(SyncDOEntity), syncEntityView);
                lcs.ColumnsSort = new[] {new ColumnsSortDef(nameof(SyncDOEntity.Date), SortOrder.Asc)};
                lcs.LimitFunction = GetSyncEntityLimitForDataChangeMessageResponce<TItem>(fromDate, toDate);
                var loadingCount = GetSyncDOEntityCount(lcs);

                if (loadingCount > 0)
                {
                    //Определяем размер пакета которым будут отправлены изменения.
                    var packageSize = SyncAdapterTools.GetPackageSizeForMessage<TMessage>();

                    //Размер порции одной вычитки определяет размерность пакета сообщения.
                    lcs.LoadingBufferSize = packageSize;
                    //Состояние сервиса данных, для порционной вычитки.
                    object state = null;
                    var syncDoEntities = GetSyncDOEntity(lcs, ref state);

                    LogService.LogInfo(
                        $"ChangePackageCollector: Всего фактов-изменений для сообщения типа {typeof(TMessage).Name} - {loadingCount}, размер одного пакета установлен в {packageSize}.");
                    var currentNumPackage = 0;
                    var totalNumPackage = loadingCount / packageSize;


                    //Пока дата сервис возвращает факты-изменения.
                    while (syncDoEntities.Count > 0)
                    {
                        currentNumPackage++;
                        LogService.LogInfo(
                            $"ChangePackageCollector: Обрабатывается {currentNumPackage} порция фактов-изменений из {totalNumPackage}.");

                        var changedItems = new List<TItem>();
                        //Обрабатываем вычитанную порцию фактов-изменений.
                        foreach (var syncEntity in syncDoEntities)
                        {
                            //Получаем настройки для обработки факта-изменения.
                            GetSyncSettings(syncEntity, out var type, out var mapper, out var appObjPrimaryKey);

                            if (syncEntity.Date != null
                                && syncEntity.AuditChangePK != null)
                            {
                                var appObject = GetDataObjectBySyncEntity(appObjPrimaryKey, type, syncEntity.ObjectStatus, syncEntity.Date.Value);

                                List<string> changedFields = null;
                                if (SyncAdapterTools.GetSendChangedFieldAttributeForMessage<TMessage>())
                                {
                                    changedFields = GetChangedFieldBySyncEntity(syncEntity.ObjectStatus, syncEntity.AuditChangePK.Value);
                                }

                                //маппим объект в xml объект
                                var xmlObjects = GetXMLObjectByMapper(mapper, appObject);

                                //Cкладываем xml-объект в список, который будет передан создателю сообщения об изменении.
                                changedItems.AddRange(xmlObjects.Select(x => CreateChangedItem<TItem>(syncEntity, x, changedFields)));
                            }
                        }

                        //После обработки всех фактов-изменений, создаём сообщение-изменение нужного типа.
                        //Реальный размер объектов-изменения в сообщении может быть больше указанного размера пакета, это происходит из-за преобразований одного объкта в несколько при маппинге.
                        var message = new DataChangesCreator<TMessage, TItem>(changedItems).CreateMessage();
                        message.Save();

                        //Вычитываем очередную порцию фактов-изменений.
                        syncDoEntities = GetSyncDOEntity(null, ref state);
                    }

                    LogService.LogInfo(
                        $"ChangePackageCollector: Успешное завершение обработки фактов-изменений для сообщения типа {typeof(TMessage).Name}{Helper.GetDatePartAsString(fromDate, toDate)}.");
                }
                else
                {
                    LogService.LogInfo(
                        $"ChangePackageCollector: Нет новых фактов-изменений для сообщения типа {typeof(TMessage).Name} с изменениями {Helper.GetDatePartAsString(fromDate, toDate)}. Синхронизационные сообщения сформированы не будут!");
                }
            }
            catch (Exception ex)
            {
                LogService.LogError($"{LogErrorMessageHeader} Операция будет прервана!", ex);
                throw;
            }
        }

        public abstract DataObject GetDataObjectBySyncEntity(
            Guid appObjPK,
            Type appObjType,
            ObjectStatus changedObjStatus,
            DateTime changedDate);

        public abstract List<string> GetChangedFieldBySyncEntity(
            ObjectStatus changedObjStatus,
            Guid auditChangePK);

        #region Вспомогательные методы

        /// <summary>
        ///     Возвращает кол-во SyncDOEntity по заданному LoadingCustomizationStruct.
        /// </summary>
        /// <param name="lcs"></param>
        /// <returns></returns>
        private int GetSyncDOEntityCount(LoadingCustomizationStruct lcs)
        {
            int loadingCount;
            try
            {
                loadingCount = SyncDataService.GetObjectsCount(lcs);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Ошибка: не удалось вычислить кол-во фактов-изменений{Environment.NewLine}{ex.Message}");
            }

            return loadingCount;
        }

        /// <summary>
        ///     Вычитывает SyncDOEntity по заданному LoadingCustomizationStruct.
        /// </summary>
        /// <param name="lcs"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private List<SyncDOEntity> GetSyncDOEntity(LoadingCustomizationStruct lcs, ref object state)
        {
            DataObject[] syncDoEntities;
            try
            {
                syncDoEntities = lcs == null
                    ? SyncDataService.LoadObjects(ref state)
                    : SyncDataService.LoadObjects(lcs, ref state);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Ошибка при вычитке фактов-изменений из бд! Обработка изменений не может быть запущена!{Environment.NewLine}{ex.Message}");
            }

            return syncDoEntities.Cast<SyncDOEntity>().ToList();
        }

        /// <summary>
        ///     Преобразовывает прикладной объект в объект xml-модели, используя указанный маппер.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="appObject"></param>
        /// <returns></returns>
        private IEnumerable<ISync> GetXMLObjectByMapper(IPropertyMapper mapper, DataObject appObject)
        {
            IEnumerable<ISync> xmlObjects;
            try
            {
                //Преобразуем вычитанный изменнённый объект в его xml-представление.
                //TODO Проверить обработку мастеровых и детейловых объектов при маппинге. В маппинге используется дочитка, возможно сброситься состояние полученное при откате изменений.
                xmlObjects = mapper.Map(appObject).Cast<ISync>();
            }
            catch (Exception ex)
            {
                throw new MappingException(appObject, ex.Message);
            }

            return xmlObjects;
        }

        private TItem CreateChangedItem<TItem>(SyncDOEntity syncEntity, ISync xmlObjects, List<string> changedField)
            where TItem : IChangedItem
        {
            var errorMessage = "";
            var changedItem = default(TItem);
            try
            {
                changedItem = Activator.CreateInstance<TItem>();
                changedItem.ChangeDate = syncEntity.Date;
                var objectStatus = tState.updated;
                switch (syncEntity.ObjectStatus)
                {
                    case ObjectStatus.Deleted:
                        objectStatus = tState.deleted;
                        break;
                    case ObjectStatus.Created:
                        objectStatus = tState.created;
                        break;
                }

                changedItem.State = objectStatus;
                var xmlObjType = xmlObjects.GetType();
                var field = typeof(TItem).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(x => x.FieldType == xmlObjType);
                if (field != null)
                {
                    field.SetValue(changedItem, xmlObjects);
                }
                else
                {
                    errorMessage = $"Не найдено свойство типа {xmlObjType.FullName} в объекте {typeof(TItem).FullName}";
                }

                if (changedField != null && changedField.Any())
                {
                    changedItem.СhangedAttributes = new List<AttributeDefinition>();
                    changedItem.СhangedAttributes.AddRange(changedField.Select(x=> new AttributeDefinition(x)));
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"{ex.Message}";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(
                    $"Ошибка: не удалось создать ChangedItem типа {typeof(TItem).Name}{Environment.NewLine}{errorMessage}");
            }

            return changedItem;
        }

        /// <summary>
        ///     Получить настройки из SyncDOEntity.
        /// </summary>
        /// <param name="syncEntity">SyncDOEntity из которой будем получать настройки</param>
        /// <param name="type">Тип объекта, который был изменён.</param>
        /// <param name="mapper">Маппер для объекта, который был изменён.</param>
        /// <param name="appObjPrimaryKey">Первичный ключ прикладного объекта, который был изменён.</param>
        private void GetSyncSettings(SyncDOEntity syncEntity, out Type type, out IPropertyMapper mapper, out Guid appObjPrimaryKey)
        {
            SyncSetting setting = null;
            type = null;
            mapper = null;
            if (syncEntity.ObjectPrimaryKey == null
                || !syncEntity.Date.HasValue
                || !syncEntity.AuditChangePK.HasValue)
            {
                throw new NullParamInSyncEntityException(syncEntity);
            }

            appObjPrimaryKey = syncEntity.ObjectPrimaryKey.Value;

            try
            {
                setting = SettingService.Current.GetSetting(syncEntity);
                type = setting.Source.ExtractType();
                mapper = setting.ExtractMapper<IPropertyMapper>();
            }
            catch (Exception ex)
            {
                throw new LoadSyncSettingException(syncEntity.ObjectPrimaryKey, setting, type, mapper, ex.Message);
            }
        }

        private Function GetSyncEntityLimitForDataChangeMessageResponce<TItem>(DateTime? fromDate, DateTime? toDate)
            where TItem : IChangedItem
        {
            var timeFunc = FunctionBuilder.BuildTrue();
            if (fromDate != null || toDate != null)
            {
                if (fromDate != null && toDate != null)
                {
                    timeFunc = FunctionBuilder.BuildBetween<SyncDOEntity>(x => x.Date, fromDate, toDate);
                }
                else if (fromDate != null)
                {
                    timeFunc = FunctionBuilder.BuildGreater<SyncDOEntity>(x => x.Date, fromDate);
                }
                else
                {
                    timeFunc = FunctionBuilder.BuildLessOrEqual<SyncDOEntity>(x => x.Date, toDate);
                }
            }

            var typesFunc = FunctionBuilder.BuildTrue();
            var supTypes = SyncAdapterTools.GetSupportTypeForChangedItem<TItem>();
            if (supTypes.Any())
            {
                typesFunc = FunctionBuilder.BuildIn<SyncDOEntity>(x => x.Setting.Source.Name,
                    supTypes.Select(x => x.FullName));
            }

            return FunctionBuilder.BuildAnd(FunctionBuilder.BuildIsNotNull<SyncDOEntity>(x => x.Date), timeFunc,
                typesFunc);
        }

        private void CalculateFromDate<TMessage, TItem>(ref DateTime? fromDate)
            where TMessage : IDataChangeMessageResponce<TItem>
            where TItem : IChangedItem
        {
            var lastSyncTMessage = SyncAdapterTools.GetLastSendMessage<TMessage>();
            if (lastSyncTMessage?.ChangesTo == null)
            {
                if (fromDate == null)
                {
                    LogService.LogWarn(
                        $"{LogWarnMessageHeader} Не задана дата с которой брать изменения и не удалось определить дату из последнего sync-сообщение типа {typeof(TMessage).Name}. Факты-изменения будут обработаны с самого начала!");
                }
            }
            else
            {
                if (fromDate != null)
                {
                    if (lastSyncTMessage.ChangesTo > fromDate)
                    {
                        LogService.LogWarn(
                            $"{LogWarnMessageHeader} Дата с которой планировалось отправить изменения меньше, чем дата отправки последнего sync-сообщение типа {typeof(TMessage).Name}. Дата начала отправки изменений была изменена с {fromDate.Value:G} на {lastSyncTMessage.ChangesTo.Value:G}");
                        fromDate = lastSyncTMessage.ChangesTo;
                    }
                }
                else
                {
                    fromDate = lastSyncTMessage.ChangesTo;
                }
            }
        }

        #endregion
    }
}