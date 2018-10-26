namespace MessageCreator
{
    using ServiceBus.ObjectMessageModel.Common.Interfaces;

    /// <summary>
    ///     Абстрактный класс описывающий создателей сообщений, которые отправляются с этого адаптера.
    /// </summary>
    public interface IServiceBusMessageCreator<out TMessage>
        where TMessage : ICommonMessage
    {
        TMessage CreateMessage();
    }
}