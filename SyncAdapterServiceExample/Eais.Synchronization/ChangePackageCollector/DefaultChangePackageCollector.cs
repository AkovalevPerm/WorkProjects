namespace ChangePackageCollector
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
    using Mappers.Common.CustomException;
    using MessageCreator;
    using Microsoft.Practices.ObjectBuilder2;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.Common.Attribute;
    using ServiceBus.ObjectDataModel.Common.Interfaces;
    using ServiceBus.ObjectMessageModel.Common.Interfaces;
    using Synchronization.Common;
    using Synchronization.Utils;

    public abstract class DefaultChangePackageCollector : IChangePackageCollector

    {
        private const string LogErrorMessageHeader =
            "ChangePackageCollector: Возникла ошибка при попытке собрать изменения.";

        private const string LogWarnMessageHeader =
            "ChangePackageCollector: Возникло предупреждение при попытке собрать изменения.";

        protected IDataService AppDataService { get; }

        protected IDataService SyncDataService { get; }

        protected DefaultChangePackageCollector(IDataService appDS, IDataService syncDS)
        {
            AppDataService = appDS;
            SyncDataService = syncDS;
        }

        /// <inheritdoc />
        public virtual void PackChanges<TMessage, TItem>(DateTime? fromDate = null, DateTime? toDate = null)
            where TMessage : IDataChangeMessageResponse<TItem>
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
                            GetSyncSettings(syncEntity, out var type, out var appObjPrimaryKey);

                            if (syncEntity.AuditChangePK != null)
                            {
                                var appObject = GetDataObjectBySyncEntity(appObjPrimaryKey, type, syncEntity.ObjectStatus, syncEntity.AuditChangePK.Value);

                                List<string> changedFields = null;
                                if (SyncAdapterTools.GetSendChangedFieldAttributeForMessage<TMessage>())
                                {
                                    changedFields = GetChangedFieldBySyncEntity(syncEntity.ObjectStatus, syncEntity.AuditChangePK.Value);
                                }

                                //маппим объект в xml объект
                                var xmlObjects = GetXMLObjectByMapper<TItem>(appObject);

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
            Guid auditChangePK);

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
        /// Получить тип xml-объекта приемника из метаданных сообщения
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="appObject"></param>
        /// <returns></returns>
        private Type GetXMLDestinationTypeByChangedItem<TItem>(DataObject appObject)
            where TItem : IChangedItem
        {
            var properties = typeof(TItem).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.GetCustomAttribute<XMLDataFieldType>()?.Type?.AssemblyQualifiedName == appObject.GetType().AssemblyQualifiedName).ToList();
            if(properties.Count == 1)
            {
                return properties.First().PropertyType;
            }
            else
            {
                if (properties.Any())
                {
                    throw new ArgumentException($"Ошибка: не удалось установить однозначное соответствие xml-типа приёмника. Выбор между типами {properties.JoinStrings(",", x=>x.PropertyType.FullName)} в {typeof(TItem).FullName}. Проверьте настройки {nameof(XMLDataFieldType)} атрибута.");
                }
                else
                {
                    throw new ArgumentException($"Ошибка: не удалось определить xml-тип приёмника. Для xml-объекта типа {typeof(TItem).FullName} не нашлось свойства помеченого атрибутом {nameof(XMLDataFieldType)} с типом приемником {appObject.GetType().FullName}");
                }
            }
        }

        /// <summary>
        ///     Преобразовывает прикладной объект в объект xml-модели, используя указанный маппер.
        /// </summary>
        /// <param name="appObject"></param>
        /// <returns></returns>
        private IEnumerable<ISync> GetXMLObjectByMapper<TItem>(DataObject appObject)
            where TItem : IChangedItem
        {
            IEnumerable<ISync> xmlObjects;
            SyncSetting setting = null;
            IPropertyMapper mapper = null;
            try
            {
                // Преобразуем вычитанный изменнённый объект в его xml-представление.
                //TODO Проверить обработку мастеровых и детейловых объектов при маппинге. В маппинге используется дочитка, возможно сброситься состояние полученное при откате изменений.
                var field = GetXMLDestinationTypeByChangedItem<TItem>(appObject);
                // Этот объект так же должен поддерживать ISync.
                var syncObj = appObject as ISync; 
                setting = SettingService.Current.GetSettings(syncObj).First(s => s.Destination.Name == field.FullName);
                mapper = setting.ExtractMapper<IPropertyMapper>();
                xmlObjects = mapper.Map(appObject).Cast<ISync>();
            }
            catch (ArgumentException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new MappingException(appObject, setting, mapper, ex.Message);
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
                var properties = typeof(TItem).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .FirstOrDefault(x => x.PropertyType == xmlObjType);
                if (properties != null)
                {
                    properties.SetValue(changedItem, xmlObjects);
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
        /// <param name="appObjPrimaryKey">Первичный ключ прикладного объекта, который был изменён.</param>
        private void GetSyncSettings(SyncDOEntity syncEntity, out Type type, out Guid appObjPrimaryKey)
        {
            SyncSetting setting = null;
            type = null;
            
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
            }
            catch (Exception ex)
            {
                throw new LoadSyncSettingException(syncEntity.ObjectPrimaryKey, setting, type, ex.Message);
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
            where TMessage : IDataChangeMessageResponse<TItem>
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