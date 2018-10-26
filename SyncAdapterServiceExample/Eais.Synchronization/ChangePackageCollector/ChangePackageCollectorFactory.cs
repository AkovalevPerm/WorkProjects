namespace ChangePackageCollector
{
    using System;
    using ICSSoft.Services;
    using Interfaces;
    using Microsoft.Practices.Unity;

    public class ChangePackageCollectorFactory
    {
        /// <summary>
        ///     Инициализация сервиса сборщика изменений.
        /// </summary>
        static ChangePackageCollectorFactory()
        {
            var container = UnityFactory.GetContainer();

            if (container != null)
            {
                if (container.IsRegistered<IChangePackageCollector>("DefaultPackageCollector"))
                {
                    ChangePackageCollector = container.Resolve<IChangePackageCollector>("DefaultPackageCollector");
                }
            }

            if (ChangePackageCollector == null)
            {
                throw new Exception($"Не проинициализирован {nameof(ChangePackageCollector)}!");
            }
        }

        /// <summary>
        ///     Сервис сбора изменений по умолчанию.
        /// </summary>
        public static IChangePackageCollector ChangePackageCollector { get; }
    }
}