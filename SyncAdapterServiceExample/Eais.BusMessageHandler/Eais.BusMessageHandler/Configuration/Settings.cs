namespace BusMessageHandler.Configuration
{
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// Класс для получения настроек сервиса.
    /// </summary>
    public static class Settings
    {
        private const string ConfigSectionName = "serviceBusListener";

        private static ServiceBusListenerConfigSection ConfigSection
        {
            get
            {
                return (ServiceBusListenerConfigSection)ConfigurationManager.GetSection(ConfigSectionName);
            }
        }

        /// <summary>
        /// Получить имя типа обработчика сообщений по идентификатору типа сообщения.
        /// </summary>
        /// <param name="messageTypeId">Идентификатор типа сообщения.</param>
        /// <returns>Имя типа обработчика сообщений, или <c>null</c>, если он не найден.</returns>
        public static string GetMessageHandlerTypeName(string messageTypeId)
        {
            return ConfigSection.MessageHandlers.Cast<MessageHandlerElement>().FirstOrDefault(x => x.MessageTypeId == messageTypeId)?.Handler;
        }

        /// <summary>
        /// Получить тип класса, соответствующий идентификатору типа сообщения.
        /// </summary>
        /// <param name="messageTypeId">Идентификатор типа сообщения.</param>
        /// <returns>Имя типа обработчика сообщений, или <c>null</c>, если он не найден.</returns>
        public static string GetMessageClassTypeName(string messageTypeId)
        {
            return ConfigSection.MessageHandlers.Cast<MessageHandlerElement>().FirstOrDefault(x => x.MessageTypeId == messageTypeId)?.Class;
        }
    }
}
