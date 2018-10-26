namespace ServiceBusListener
{
    using System;
    using System.ServiceModel;

    public class ServiceHostWithoutConfiguration : ServiceHost
    {
        public ServiceHostWithoutConfiguration(Type serviceType, Uri baseAddresses) : base(serviceType, baseAddresses)
        {
            CreateDescription(out var descriptions);
        }

        /// <summary>
        ///     Переопределяем метод применения конфигурации пустым методом, т.к. в Mono он не работает (не реализована
        ///     работа с файлом конфигурации).
        /// </summary>
        protected override void ApplyConfiguration()
        {
        }
    }
}