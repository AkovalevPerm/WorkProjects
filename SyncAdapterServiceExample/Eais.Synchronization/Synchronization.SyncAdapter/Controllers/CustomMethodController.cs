namespace Synchronization.SyncAdapter.Controllers
{
    using ChangePackageCollector;

    using MessageCreator;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectMessageModel;

    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Synchronization.SyncAdapter.Serializers;

    public class CustomMethodController : ApiController
    {
        [HttpPost]
        [Route("api/CustomMethod/ProcessToReestrMSPFromMSRDataChanges")]
        public HttpResponseMessage ProcessToReestrMSPFromMSRDataChanges(DateTime? dateFrom, DateTime? dateTo)
        {
            HttpResponseMessage result;
            try
            {
                ChangePackageCollectorFactory.ChangePackageCollector
                    .PackChanges<ToReestrMspFromMsrDataChanges, DataChangesDefinition>(dateFrom, dateTo);
                result = Request.CreateResponse(HttpStatusCode.OK, $"Изменения успешно обработаны для сообщения типа {ToReestrMspFromMsrDataChanges.NameForESB}!");
            }
            catch (Exception ex)
            {
                result = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Возникла ошибка при попытке собрать изменения для сообщения типа {ToReestrMspFromMsrDataChanges.NameForESB}!", ex);
            }

            return result;
        }

        [HttpPost]
        [Route("api/CustomMethod/GetCatalogItemToReestrMSP")]
        public HttpResponseMessage
            GetCatalogItemToReestrMSP([FromBody] CatalogItem received) //, List<SortingDefinition> sorting)
        {
            var msg = new ToReestrMspFromMsrCatalogItemsRequestCreator(
                received.GetItType(), //"fiasAddressObject"
                new CriteriaDefinition
                {
                    Type = "and",
                    Condition = received.GetUslovies().Select(e => new ConditionDefinition
                    {
                        Attribute = e.Znachenie.ToString(),
                        Operator = "equals",
                        Value = e.Atribut
                    })
                    .ToArray()
                });
            // new List<SortingDefinition>());
            //{
            //    new SortingDefinition
            //    {
            //        SortOrder = 1,
            //        SortType = "333",
            //        TehName = "tehname"
            //    }
            //});

            var ms = msg.CreateMessage();
            var responseMessage = new HttpResponseMessage();
            var messageError =
                $"Произошла ошибка в методе {nameof(GetCatalogItemToReestrMSP)} для сообщения {nameof(ToReestrMspFromMsrCatalogItemsRequest)}.";
            try
            {
                if (ms.Save(null, null, true))
                {
                    responseMessage = Request.CreateResponse(HttpStatusCode.OK, $"Сообщение {nameof(ToReestrMspFromMsrCatalogItemsRequest)} успешно создано.");
                }
                else
                    responseMessage = Request.CreateErrorResponse(HttpStatusCode.Forbidden, messageError);
            }
            catch (Exception ex)
            {
                responseMessage =
                    Request.CreateErrorResponse(HttpStatusCode.Forbidden, $"{messageError} Ошибка - {ex.Message}");
            }
            
            return responseMessage;
        }
    }
}