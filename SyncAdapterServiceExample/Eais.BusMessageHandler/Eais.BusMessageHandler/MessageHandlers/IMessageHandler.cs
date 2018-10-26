namespace BusMessageHandler.MessageHandlers
{
    using Synchronization.Objects;

    /// <summary>
    /// Интерфейс обработчика сообщения из шины.
    /// </summary>
    public interface IMessageHandler
    {
        /// <summary>
        /// Обработать сообщение.
        /// </summary>
        /// <param name="message">Сообщение из шины.</param>
        void HandleMessage(SyncLogItem logItem);

        /// <summary>
        /// Обработать событие.
        /// </summary>
        /// <param name="eventTypeId">Идентификатор типа события.</param>
        void RiseEvent(string eventTypeId);
    }
}
