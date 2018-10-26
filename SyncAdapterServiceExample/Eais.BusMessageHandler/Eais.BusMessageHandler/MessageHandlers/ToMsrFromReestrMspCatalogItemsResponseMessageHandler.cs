namespace BusMessageHandler.MessageHandlers
{
    using ServiceBus.ObjectMessageModel;
    using Synchronization.Utils;

    /// <summary>
    /// Обработчик для <see cref="ToMsrFromReestrMspCatalogItemsResponse"/>.
    /// </summary>    
    public class ToMsrFromReestrMspCatalogItemsResponseMessageHandler : ToMsrFromReestrMspCatalogBaseMessageHandler
    {
        protected override void Process()
        {
            if (!string.IsNullOrEmpty(_syncLogItem.DataSet))
            {
                var response = SerializationTools.DeserialiseDataContract<ToMsrFromReestrMspCatalogItemsResponse>(_syncLogItem.DataSet);
                foreach (var item in response?.Items)
                {
                    ProcessClassifier(item.Classifier, null);
                }
            }
        }
    }
}
