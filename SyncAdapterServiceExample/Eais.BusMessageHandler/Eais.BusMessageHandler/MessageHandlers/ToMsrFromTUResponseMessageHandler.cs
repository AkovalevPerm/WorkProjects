namespace BusMessageHandler.MessageHandlers
{
    using System;
    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectMessageModel;
    using Synchronization.Objects;

    public class ToMsrFromTUResponseMessageHandler : IMessageHandler
    {
        /// <summary>
        ///     Обработать сообщение.
        /// </summary>
        /// <param name="logItem">Сообщение из журнала сообщений.</param>
        public void HandleMessage(SyncLogItem logItem)
        {
            DataChangeMessageHandlerFactory.DataMessageHandler.HandleDataChangeMessage<ToMsrFromTUResponse, ChangedItem>(logItem);
        }

        /// <summary>
        ///     Обработать событие.
        /// </summary>
        /// <param name="eventTypeId">Идентификатор типа события.</param>
        public void RiseEvent(string eventTypeId)
        {
            throw new NotImplementedException();
        }
    }
}