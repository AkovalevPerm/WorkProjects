namespace SyncAdapterService.MessageCreator
{
    using SyncAdapterService.XMLMessageModel.Interface;
    using System;
    using System.Collections.Generic;
    using XMLDataModel.Interface;

    public class DataChangesCreator<TMessage, TItem> : IServiceBusMessageCreator<TMessage>
        where TMessage : IDataChangeMessageResponce<TItem>
        where TItem : IChangedItem
    {
        private readonly List<TItem> _changedItems;

        private readonly string _requestInfo;

        public DataChangesCreator(List<TItem> changedItems, string requestInfo = "")
        {
            _changedItems = changedItems;
            _requestInfo = requestInfo;
        }

        public TMessage CreateMessage()
        {
            var changedMessage = Activator.CreateInstance<TMessage>();
            changedMessage.Items = _changedItems;
            changedMessage.RequestInfo = _requestInfo;

            return changedMessage;
        }
    }
}