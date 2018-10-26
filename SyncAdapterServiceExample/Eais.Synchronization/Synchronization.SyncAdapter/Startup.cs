using Microsoft.Owin;
using Synchronization.SyncAdapter;

[assembly: OwinStartup(typeof(Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]

namespace Synchronization.SyncAdapter
{
    using System;
    using System.Web.Http;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using Owin;
    using ServiceBusListener;
    using Utils;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DataServiceProvider.AlwaysNewDS = false;
            try
            {
                DataServiceProvider.DataService = DataServiceFactory.SyncDataService;

                GlobalConfiguration.Configure(WebApiConfig.Register);
                BusListenerServiceHostFactory.StartService();
            }
            catch (Exception ex)
            {
                LogService.LogError("SyncAdapter: произошла ошибка при инициализации сервиса. SyncAdapter не запущен!", ex);
                throw;
            }
        }
    }
}