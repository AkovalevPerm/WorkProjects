namespace BusMessageHandler.MessageHandlers
{
    using BusMessageHandler.Loaders;
    using ICSSoft.STORMNET.Business;
    using Iis.Eais.Catalogs;
    using ServiceBus.ObjectDataModel.CatalogData;
    using ServiceBus.ObjectDataModel.Common.Attribute;
    using Synchronization.Objects;
    using System;
    using System.Reflection;
    using Synchronization.Utils;

    /// <summary>
    /// Базовый класс для обработки Catalog сообщений.
    /// </summary>
    public abstract class ToMsrFromReestrMspCatalogBaseMessageHandler : IMessageHandler
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
        /// Конструктор.
        /// </summary>
        public ToMsrFromReestrMspCatalogBaseMessageHandler()
        {
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
        }

        public void RiseEvent(string eventTypeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Обработка элемента <see cref="Classifier"/>.
        /// </summary>
        /// <param name="classifier">Элемент <see cref="Classifier"/>.</param>
        /// <param name="noActual">Значение, которое нужно проставить в поле ForeignCatValue.NoActual.</param>
        protected void ProcessClassifier(Classifier classifier, DateTime? noActual)
        {
            if (classifier == null)
            {
                return;
            }

            // Получение справочника, создаем если его нет.
            var aliasType = typeof(Classifier).GetCustomAttribute<AliasType>().Alias;
            var catalog = _catalogLoader.LoadCatalog(aliasType);
            if (catalog == null)
            {
                catalog = new Catalog();
                catalog.Code = aliasType;
                catalog.Name = "Классификатор мер социальной защиты";
                catalog.CreateTime = DateTime.Now;
            }

            var foreignCatValue = _foreignCatValueLoader.LoadForeignCatValueByCode(classifier.Social.Code);
            if (foreignCatValue == null)
            {
                foreignCatValue = new ForeignCatValue();
                foreignCatValue.Code = classifier.Social.Code;
                catalog.Values.Add(foreignCatValue);
            }

            foreignCatValue.Description = classifier.Social.Name.Trim();
            foreignCatValue.NoActual = noActual;
            foreignCatValue.FullValue = _syncLogItem.DataSet;
            foreignCatValue.ParentGuid = null;
            _ds.UpdateObject(catalog);
        }
    }
}