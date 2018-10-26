namespace SyncAdapterService.Utils
{
    using ICSSoft.STORMNET.Business;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    /// <summary>
    /// Фабрика сервисов данных.
    /// </summary>
    public static class DataServiceFactory
    {
        private static UnityContainer _container;

        /// <summary>
        /// Сервис данных по умолчанию (WebEAIS).
        /// </summary>
        public static IDataService AppDataService { get; private set; }

        /// <summary>
        /// Сервис данных синхронизации.
        /// </summary>
        public static IDataService SyncDataService { get; private set; } 

        /// <summary>
        /// Инициализация сервисов данных.
        /// </summary>
        /// <param name="customDSForSync">Пользовательский дата сервис для БД синхронизатора, если нулл будет инициализирован через юнити</param>
        /// <param name="customDSForApp">Пользовательский дата сервис для БД приложения, если нулл будет инициализирован через юнити</param>
        public static void Init(IDataService customDSForSync = null, IDataService customDSForApp = null)
        {
            _container = new UnityContainer();
            _container.LoadConfiguration();

            SyncDataService = customDSForSync ?? _container.Resolve<IDataService>("SyncDataService");
            AppDataService = customDSForApp ?? _container.Resolve<IDataService>("AppDataService");

            if (AppDataService == null)
            {
                throw new System.Exception($"Не проинициализирован {nameof(AppDataService)}!");
            }

            if (SyncDataService == null)
            {
                throw new System.Exception($"Не проинициализирован {nameof(SyncDataService)}!");
            }
        }
    }
}
