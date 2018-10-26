namespace Synchronization.SyncAdapter
{
    using System.Web.Http;
    using NewPlatform.Flexberry.AspNet.WebApi.Cors;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            config.EnableCors(new DynamicCorsPolicyProvider(true));

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "WebApiRoute",
                "api/{controller}/{action}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}