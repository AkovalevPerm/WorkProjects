namespace MessageCreator
{
    using System;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectMessageModel;

    public class
        ToReestrMspFromMsrCatalogItemsRequestCreator : IServiceBusMessageCreator<ToReestrMspFromMsrCatalogItemsRequest>
    {
        public ToReestrMspFromMsrCatalogItemsRequestCreator(string type,
            CriteriaDefinition criteria) //, List<SortingDefinition> sorting)
        {
            Type = type;
            Criteria = criteria;
            //Sorting = sorting;
        }

        public string Type { get; set; }

        public CriteriaDefinition Criteria { get; set; }
        
        //public List<SortingDefinition> Sorting { get; set; }

        public ToReestrMspFromMsrCatalogItemsRequest CreateMessage()
        {
            var message = new ToReestrMspFromMsrCatalogItemsRequest
            {
                RequestInfo = Guid.NewGuid().ToString(),
                Type = Type,
                Criteria = Criteria
                //Sorting = Sorting
            };
            return message;
        }
    }
}