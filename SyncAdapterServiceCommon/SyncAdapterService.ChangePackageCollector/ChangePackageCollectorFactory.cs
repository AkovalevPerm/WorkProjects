namespace SyncAdapterService.ChangePackageCollector
{
    using System;
    using Interfaces;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class ChangePackageCollectorFactory
    {
        private static UnityContainer _container;

        /// <summary>
        ///     Сервис сбора изменений по умолчанию.
        /// </summary>
        public static IChangePackageCollector ChangePackageCollector => _container.Resolve<IChangePackageCollector>("DefaultPackageCollector");

        /// <summary>
        ///     Инициализация сервиса сборщика изменений.
        /// </summary>
        public static void Init()
        {
            _container = new UnityContainer();
            _container.LoadConfiguration();

            if (ChangePackageCollector == null)
            {
                throw new Exception($"Не проинициализирован {nameof(ChangePackageCollector)}!");
            }
        }
    }
}