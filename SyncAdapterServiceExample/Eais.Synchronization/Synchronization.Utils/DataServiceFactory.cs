namespace Synchronization.Utils
{
    using System;
    using ICSSoft.Services;
    using ICSSoft.STORMNET.Business;
    using Microsoft.Practices.Unity;

    /// <summary>
    ///     Фабрика сервисов данных.
    /// </summary>
    public static class DataServiceFactory
    {
        static DataServiceFactory()
        {
            var container = UnityFactory.GetContainer();

            if (container != null)
            {
                if (container.IsRegistered<IDataService>("SyncDataService"))
                {
                    SyncDataService = container.Resolve<IDataService>("SyncDataService");
                }

                if (container.IsRegistered<IDataService>("AppDataService"))
                {
                    AppDataService = container.Resolve<IDataService>("AppDataService");
                }
            }

            if (AppDataService == null)
            {
                throw new Exception($"Не проинициализирован {nameof(AppDataService)}!");
            }

            if (SyncDataService == null)
            {
                throw new Exception($"Не проинициализирован {nameof(SyncDataService)}!");
            }
        }

        /// <summary>
        ///     Сервис данных по умолчанию (WebEAIS).
        /// </summary>
        public static IDataService AppDataService { get; private set; }

        /// <summary>
        ///     Сервис данных синхронизации.
        /// </summary>
        public static IDataService SyncDataService { get; private set; }

        /// <summary>
        ///     Инициализация сервисов данных.
        /// </summary>
        /// <param name="customDSForSync">
        ///     Пользовательский дата сервис для БД синхронизатора, если нулл будет инициализирован через
        ///     юнити
        /// </param>
        /// <param name="customDSForApp">
        ///     Пользовательский дата сервис для БД приложения, если нулл будет инициализирован через
        ///     юнити
        /// </param>
        public static void Init(IDataService customDSForSync = null, IDataService customDSForApp = null)
        {
            SyncDataService = customDSForSync;
            AppDataService = customDSForApp;
        }
    }
}