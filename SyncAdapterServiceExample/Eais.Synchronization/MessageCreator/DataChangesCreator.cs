namespace MessageCreator
{
    using System;
    using System.Collections.Generic;
    using ServiceBus.ObjectDataModel.Common.Interfaces;
    using ServiceBus.ObjectMessageModel.Common.Interfaces;

    public class DataChangesCreator<TMessage, TItem> : IServiceBusMessageCreator<TMessage>
        where TMessage : IDataChangeMessageResponse<TItem>
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