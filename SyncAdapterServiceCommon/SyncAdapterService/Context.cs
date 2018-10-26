namespace SyncAdapterService
{
    using System.Configuration;
    using System.Linq;
    using Configuration;

    public static class Context
    {
        public const string CustomSBListenerConfigSectionName = "serviceBusListener";

        /// <summary>
        ///     Путь до папки с xml-файлами.
        /// </summary>
        public static string XMLMessagePath { get; } = ConfigurationManager.AppSettings["XMLMessagePath"];

        /// <summary>
        ///     Путь до папки с xsd-схемами.
        /// </summary>
        public static string XSDSchemasPath { get; } = ConfigurationManager.AppSettings["XSDSchemasPath"];

        /// <summary>
        ///     Название приложения.
        /// </summary>
        public static string AppName { get; } = ConfigurationManager.AppSettings["AppName"];

        /// <summary>
        ///     Размер синхронизационного сообщения по умолчанию.
        /// </summary>
        public static int DefaultPackageSize
        {
            get
            {
                var stringInt = "";
                try
                {
                    stringInt = ConfigurationManager.AppSettings["DefaultPackageSize"];
                }
                catch
                {
                    // ignored
                }

                if (!int.TryParse(stringInt, out var result))
                {
                    result = 100;
                }

                return result;
            }
        }

        /// <summary>
        ///     Адрес точки входа для callback-сервиса шины.
        /// </summary>
        public static string SBListenerServiceAddress { get; } =
            ConfigurationManager.AppSettings["SBListenerServiceAddress"];

        /// <summary>
        ///     Включить XSD-валидацию входящих сообщений.
        /// </summary>
        public static bool EnableXSDValidation { get; } =
            bool.Parse(ConfigurationManager.AppSettings["EnableXSDValidation"]);

        private static ServiceBusListenerConfigSection ConfigSection =>
            (ServiceBusListenerConfigSection) ConfigurationManager.GetSection(CustomSBListenerConfigSectionName);

        /// <summary>
        ///     Получить имя xml-класса сообщения по идентификатору типа сообщения.
        /// </summary>
        /// <param name="messageTypeId">Идентификатор типа сообщения.</param>
        /// <returns>Имя типа обработчика сообщений, или <c>null</c>, если он не найден.</returns>
        public static string GetMessageXMLClassNameByMessageID(string messageTypeId)
        {
            return ConfigSection.MessageTypes.Cast<MessageTypeElement>()
                .FirstOrDefault(x => x.MessageTypeId == messageTypeId)?.Class;
        }
    }
}