namespace BusMessageHandler.MessageHandlers
{
    using BusMessageHandler.Loaders;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using Iis.Eais.Catalogs;
    using ServiceBus.ObjectDataModel.Common.Attribute;
    using ServiceBus.ObjectDataModel.FIAS;
    using Synchronization.Objects;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Synchronization.Utils;

    /// <summary>
    /// Базовый класс для обработки Fias сообщений.
    /// </summary>
    public abstract class ToMsrFromReestrMspFiasBaseMessageHandler : IMessageHandler
    {
        /// <summary>
        /// Сервис данных по умолчанию.
        /// </summary>
        private IDataService _ds = DataServiceFactory.AppDataService;

        /// <summary>
        /// Загрузчик справочников.
        /// </summary>
        private CatalogLoader _catalogLoader { get; set; }

        /// <summary>
        /// Загрузчик <see cref="ForeignCatValue">.
        /// </summary>
        private ForeignCatValueLoader _foreignCatValueLoader { get; set; }

        /// <summary>
        /// Объект <see cref="SyncLogItem">.
        /// </summary>
        protected SyncLogItem _syncLogItem;

        /// <summary>
        /// Список объектов для обновления.
        /// </summary>
        protected List<DataObject> _toUpdateDef;

        /// <summary>
        /// Список сообщений, которые надо записать в лог в случае удачного обновления объектов.
        /// </summary>
        protected List<string> _messagesToLog;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public ToMsrFromReestrMspFiasBaseMessageHandler()
        {
            _toUpdateDef = new List<DataObject>();
            _messagesToLog = new List<string>();
            _catalogLoader = new CatalogLoader(_ds);
            _foreignCatValueLoader = new ForeignCatValueLoader(_ds);
        }

        /// <summary>
        /// Абстрактный метод для реализации специфичной логики классов-наследников
        /// </summary>
        protected abstract void Process();

        /// <summary>
        /// Обработка поступившего объекта <see cref="SyncLogItem"/>.
        /// </summary>
        /// <param name="logItem"></param>
        public void HandleMessage(SyncLogItem logItem)
        {
            _syncLogItem = logItem;
            Process();
            var toUpdate = _toUpdateDef.ToArray();
            _ds.UpdateObjects(ref toUpdate);

            // Если объекты обновились\добавились успешно, то запишем в лог сообщения.
            foreach (var msg in _messagesToLog)
            {
                LogService.LogInfo(msg);
            }
        }

        public void RiseEvent(string eventTypeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Обработка элемента <see cref="FiasAddressObjects"/>.
        /// </summary>
        /// <param name="fhStructures">Элемент <see cref="FiasAddressObjects"/>.</param>        
        protected void ProcessFiasAddressObjects(FiasAddressObjects faObjects)
        {
            if (faObjects == null)
            {
                return;
            }

            // Получение справочника, создаем если его нет.
            var aliasType = typeof(FiasAddressObjects).GetCustomAttribute<AliasType>().Alias;
            var catalog = _catalogLoader.LoadCatalog(aliasType);
            if (catalog == null)
            {
                catalog = new Catalog();
                catalog.Code = aliasType;
                catalog.Name = "ФИАС - адресообразующие элементы";
                catalog.Description = "Справочник территорий, улиц";
                catalog.CreateTime = DateTime.Now;
            }

            var foreignCatValue = _foreignCatValueLoader.LoadForeignCatValueByCode(faObjects.AOGUID);
            if (foreignCatValue == null)
            {
                foreignCatValue = new ForeignCatValue();
                foreignCatValue.Code = faObjects.AOGUID;
                catalog.Values.Add(foreignCatValue);
            }
            else if (faObjects.CURRSTATUS != 0)
            {
                return;
            }

            foreignCatValue.Description = $"{faObjects.SHORTNAME?.Trim()} {faObjects.FORMALNAME?.Trim()}";
            foreignCatValue.NoActual = faObjects.ENDDATE;
            foreignCatValue.FullValue = _syncLogItem.DataSet;
            if (!string.IsNullOrEmpty(faObjects.PARENTGUID))
            {
                var parent = _foreignCatValueLoader.LoadForeignCatValueByCode(faObjects.PARENTGUID);
                if (parent == null)
                {
                    var parentForeignCatValueCreatedMessage = $"При обработке сообщения {_syncLogItem.Description} (primaryKey={_syncLogItem.__PrimaryKey}) для объекта с Code={faObjects.AOGUID} из ForeignCatValue не был найден родительский объект с Code={faObjects.PARENTGUID}, поэтому был создан новый ForeignCatValue с Code={faObjects.PARENTGUID}.";
                    parent = new ForeignCatValue();
                    parent.Code = faObjects.PARENTGUID;
                    parent.Catalog = catalog;
                    _toUpdateDef.Add(parent);
                    _messagesToLog.Add(parentForeignCatValueCreatedMessage);
                }

                foreignCatValue.ParentGuid = parent;
            }

            _toUpdateDef.Add(catalog);
        }

        /// <summary>
        /// Обработка элемента <see cref="FiasHousesStructures"/>.
        /// </summary>
        /// <param name="fhStructures">Элемент <see cref="FiasHousesStructures"/>.</param>        
        protected void ProcessFiasHousesStructures(FiasHousesStructures fhStructures)
        {
            if (fhStructures == null)
            {
                return;
            }

            // Получение справочника, создаем если его нет.
            var aliasType = typeof(FiasHousesStructures).GetCustomAttribute<AliasType>().Alias;
            var catalog = _catalogLoader.LoadCatalog(aliasType);
            if (catalog == null)
            {
                catalog = new Catalog();
                catalog.Code = aliasType;
                catalog.Name = "ФИАС - здания, строения, сооружения";
                catalog.CreateTime = DateTime.Now;
            }

            var foreignCatValue = _foreignCatValueLoader.LoadForeignCatValueByCode(fhStructures.HOUSEGUID);
            if (foreignCatValue == null)
            {
                foreignCatValue = new ForeignCatValue();
                foreignCatValue.Code = fhStructures.HOUSEGUID;
                catalog.Values.Add(foreignCatValue);
            }

            foreignCatValue.Description = $"{fhStructures.HOUSENUM?.Trim()} {fhStructures.BUILDNUM?.Trim()} {fhStructures.STRUCNUM?.Trim()}";
            foreignCatValue.NoActual = fhStructures.ENDDATE;
            foreignCatValue.FullValue = _syncLogItem.DataSet;
            if (!string.IsNullOrEmpty(fhStructures.AOGUID))
            {
                var fiasAddressObjectsCatalog = _catalogLoader.LoadCatalog(typeof(FiasAddressObjects).GetCustomAttribute<AliasType>().Alias);
                var parent = _foreignCatValueLoader.LoadForeignCatValueByCode(fhStructures.AOGUID);
                if (parent == null)
                {
                    var parentForeignCatValueCreatedMessage = $"При обработке сообщения {_syncLogItem.Description} (primaryKey={_syncLogItem.__PrimaryKey}) для объекта с Code={fhStructures.HOUSEGUID} из ForeignCatValue не был найден родительский объект с Code={fhStructures.AOGUID}, поэтому был создан новый ForeignCatValue с Code={fhStructures.AOGUID}.";
                    parent = new ForeignCatValue();
                    parent.Code = fhStructures.AOGUID;
                    parent.Catalog = fiasAddressObjectsCatalog;
                    _toUpdateDef.Add(parent);
                    _messagesToLog.Add(parentForeignCatValueCreatedMessage);
                }

                foreignCatValue.ParentGuid = parent;
            }

            _toUpdateDef.Add(catalog);
        }
    }
}