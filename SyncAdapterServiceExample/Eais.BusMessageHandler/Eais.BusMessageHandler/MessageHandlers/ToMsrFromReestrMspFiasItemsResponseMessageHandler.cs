namespace BusMessageHandler.MessageHandlers
{
    using ServiceBus.ObjectMessageModel;
    using Synchronization.Utils;

    /// <summary>
    /// Обработчик для <see cref="ToMsrFromReestrMspFiasItemsResponse"/>.
    /// </summary>    
    class ToMsrFromReestrMspFiasItemsResponseMessageHandler : ToMsrFromReestrMspFiasBaseMessageHandler
    {
        protected override void Process()
        {
            if (!string.IsNullOrEmpty(_syncLogItem.DataSet))
            {
                var response = SerializationTools.DeserialiseDataContract<ToMsrFromReestrMspFiasItemsResponse>(_syncLogItem.DataSet);
                foreach (var item in response?.Items)
                {
                    ProcessFiasAddressObjects(item.FiasAddressObjects);
                    ProcessFiasHousesStructures(item.FiasHousesStructures);
                }
            }
        }      
    }
}