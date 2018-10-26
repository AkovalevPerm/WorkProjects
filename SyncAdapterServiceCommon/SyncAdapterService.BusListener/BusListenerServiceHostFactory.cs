namespace SyncAdapterService.BusListener
{
    using System;
    using System.Configuration;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using ICSSoft.STORMNET;
    using NewPlatform.Flexberry.HighwaySB.ClientTools;

    public static class BusListenerServiceHostFactory
    {
        private static ServiceHost _blServiceHost;

        private static ServiceHost CreateServiceHost()
        {
            var listenAddress = ConfigurationManager.AppSettings["SBListenerServiceAddress"];
            if (string.IsNullOrEmpty(listenAddress))
            {
                throw new InvalidOperationException("Не задан параметр SBListenerServiceAddress в AppSettings.");
            }

            var binding = new BasicHttpBinding();
            var serviceHost = new ServiceHostWithoutConfiguration(typeof(CallbackSubscriber), new Uri(listenAddress));
            serviceHost.AddServiceEndpoint(typeof(ICallbackSubscriber), binding, listenAddress);
            var smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true
            };
            serviceHost.Description.Behaviors.Add(smb);

            return serviceHost;
        }

        public static void StartService()
        {
            LogService.LogInfo("Запуск SBListener service...");
            try
            {
                _blServiceHost = _blServiceHost ?? CreateServiceHost();
                if (_blServiceHost?.State == CommunicationState.Created)
                {
                    _blServiceHost.Open();
                }
            }
            catch (Exception ex)
            {
                LogService.LogError("Ошибка при запуске SBListener service.", ex);
            }
        }

        public static void StopService()
        {
            if (_blServiceHost?.State == CommunicationState.Opened)
            {
                _blServiceHost?.Close();
            }
            LogService.LogInfo("SBListener service остановлен.");
        }
    }
}