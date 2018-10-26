namespace Synchronization.SyncAdapter.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using ICSSoft.STORMNET;
    using Iis.Eais.Synchronization;
    using Microsoft.Practices.ObjectBuilder2;
    using ServiceBusListener;
    using Utils;

    public class SyncAdapterController : ApiController
    {
        [HttpPost]
        [Route("api/SyncAdapter/StopSBListenerService")]
        public HttpResponseMessage StopSBListenerService()
        {
            BusListenerServiceHostFactory.StopService();
            return Request.CreateResponse(HttpStatusCode.OK, "SBListener service был остановлен!");
        }

        [HttpPost]
        [Route("api/SyncAdapter/StartSBListenerService")]
        public HttpResponseMessage StartSBListenerService()
        {
            BusListenerServiceHostFactory.StartService();
            return Request.CreateResponse(HttpStatusCode.OK, "SBListener service был запущен!");
        }

        [HttpGet]
        [Route("api/SyncAdapter/Test")]
        public HttpResponseMessage Test()
        {
            LogService.LogInfo($"Был вызван тестовый API-метод Test в {DateTime.Now:G}");
            return Request.CreateResponse(HttpStatusCode.OK, "Work!");
        }

        [HttpPost]
        [Route("api/SyncAdapter/TestCallMethod")]
        public HttpResponseMessage TestCallMethod()
        {
            LogService.LogInfo($"Был вызван тестовый API-метод TestCallMethod в {DateTime.Now:G}");
            return Request.CreateResponse(HttpStatusCode.OK, "Work!");
        }

        [HttpPost]
        [Route("api/SyncAdapter/TestCallMethodWithParam")]
        public HttpResponseMessage TestCallMethodWithParam(DateTime date1, DateTime date2)
        {
            LogService.LogInfo(
                $"Был вызван тестовый API-метод TestCallMethodWithParam в {DateTime.Now:G} с параметрами date1={date1:G} и date2={date2:G}");
            return Request.CreateResponse(HttpStatusCode.OK, "Work!");
        }

        [HttpPost]
        [Route("api/SyncAdapter/TestCallMethodError")]
        public HttpResponseMessage TestCallMethodError()
        {
            LogService.LogInfo($"Был вызван тестовый API-метод TestCallMethodError в {DateTime.Now:G}");
            return Request.CreateResponse(HttpStatusCode.Forbidden, "Test error!");
        }

        [HttpGet]
        [Route("api/SyncAdapter/Info")]
        public HttpResponseMessage Info()
        {
            var res = new StringBuilder();
            var currentAssembly = Assembly.GetExecutingAssembly();

            var controllers = currentAssembly.GetTypes()
                .Where(type => typeof(ApiController).IsAssignableFrom(type))
                .Select(t => new
                {
                    t.Name,
                    MethodsInfo = t.GetMethods(BindingFlags.DeclaredOnly |
                                               BindingFlags.Public |
                                               BindingFlags.Instance).Where(method =>
                            !method.IsDefined(typeof(NonActionAttribute)))
                        .Select(m => new
                        {
                            Type = m.GetCustomAttributes().FirstOrDefault(attr => attr is IActionHttpMethodProvider)
                                ?.GetType().Name,
                            Route = m.GetCustomAttribute<RouteAttribute>()?.Template,
                            Parameters =
                            m.GetParameters().Select(p => $"{p.ParameterType.Name} - {p.Name}").JoinStrings("<br>"),
                            ReturnType = m.ReturnType.Name
                        })
                });

            res.AppendLine("<!DOCTYPE HTML>");
            res.AppendLine("<html>");
            res.AppendLine("<head>");
            res.AppendLine(@"<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">");
            res.AppendLine("</head>");
            res.AppendLine("<body>");

            foreach (var controller in controllers)
            {
                res.AppendLine($"<h1>{controller.Name}</h1>");
                res.AppendLine(@"<table cellspacing=""2"" border=""1"" cellpadding=""5"" width=""100%"">");
                res.AppendLine("<tr>");
                res.AppendLine(@"<td width=""20%"">Маршрут</td>");
                res.AppendLine(@"<td width=""10%"">Метод</td>");
                res.AppendLine(@"<td width=""50%"">Параметры</td>");
                res.AppendLine(@"<td width=""20%"">Возвращаемый тип</td>");
                res.AppendLine("</tr>");
                foreach (var actionMethod in controller.MethodsInfo)
                {
                    res.AppendLine("<tr>");
                    res.AppendLine(
                        $@"<td width=""20%""><a href=""/{actionMethod.Route}"">{actionMethod.Route}</a></td>");
                    res.AppendLine($@"<td width=""10%"">{actionMethod.Type}</td>");
                    res.AppendLine($@"<td width=""50%"">{actionMethod.Parameters}</td>");
                    res.AppendLine($@"<td width=""20%"">{actionMethod.ReturnType}</td>");
                    res.AppendLine("</tr>");
                }

                res.AppendLine("</table>");
                res.AppendLine("<hr>");
            }

            res.AppendLine("</body>");
            res.AppendLine("</html>");

            var response = new HttpResponseMessage
            {
                Content = new StringContent(res.ToString())
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}