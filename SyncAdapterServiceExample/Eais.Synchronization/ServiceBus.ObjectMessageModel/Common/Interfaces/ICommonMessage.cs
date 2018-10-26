namespace ServiceBus.ObjectMessageModel.Common.Interfaces
{
    /// <summary>
    ///     Общий интерфейс для всех типов передаваемых сообщений.
    /// </summary>
    public interface ICommonMessage
    {
        /// <summary>
        ///     Информация о запросе, нужна для идентификации запроса-ответа.
        ///     Заполняется, если сообщение является ответом на запрос и в запросе был заполнен данный параметр.
        /// </summary>
        string RequestInfo { get; set; }

        /// <summary>
        ///     Метод, который сохраняет сообщение в журнал синхронизации.
        /// </summary>
        /// <param name="senderName">Название отправителя сообщения.</param>
        /// <param name="serializeData">Сериализованное значение объекта.</param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        bool Save(string senderName = null, string serializeData = "", bool throwException = false);

        /// <summary>
        ///     Метод, сериалиации сообщения.
        /// </summary>
        /// <param name="throwException"></param>
        /// <returns></returns>
        string Serialize(bool throwException = false);
    }
}