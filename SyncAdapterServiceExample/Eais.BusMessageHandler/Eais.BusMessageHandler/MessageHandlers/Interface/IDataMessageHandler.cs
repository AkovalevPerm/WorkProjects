namespace BusMessageHandler.MessageHandlers.Interface
{
    using ServiceBus.ObjectDataModel.Common.Interfaces;
    using ServiceBus.ObjectMessageModel.Common.Interfaces;
    using Synchronization.Objects;

    public interface IDataMessageHandler
    {
        void HandleDataChangeMessage<TMessage, TItem>(SyncLogItem logItem)
            where TMessage : IDataChangeMessageResponse<TItem>
            where TItem : IChangedItem;
    }
}