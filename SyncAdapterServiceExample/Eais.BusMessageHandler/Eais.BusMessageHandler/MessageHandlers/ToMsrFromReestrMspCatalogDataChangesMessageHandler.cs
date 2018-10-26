namespace BusMessageHandler.MessageHandlers
{
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectMessageModel;
    using Synchronization.Utils;
    using System;

    /// <summary>
    /// Обработчик для <see cref="ToMsrFromReestrMspCatalogDataChanges"/>.
    /// </summary> 
    public class ToMsrFromReestrMspCatalogDataChangesMessageHandler : ToMsrFromReestrMspCatalogBaseMessageHandler
    {
        protected override void Process()
        {
            if (!string.IsNullOrEmpty(_syncLogItem.DataSet))
            {
                var response = SerializationTools.DeserialiseDataContract<ToMsrFromReestrMspCatalogDataChanges>(_syncLogItem.DataSet);
                foreach (var item in response?.Items)
                {
                    DateTime? state = item.State == tState.deleted ? (DateTime?)DateTime.Now : null;
                    ProcessClassifier(item.Classifier, state);
                }
            }
        }
    }
}