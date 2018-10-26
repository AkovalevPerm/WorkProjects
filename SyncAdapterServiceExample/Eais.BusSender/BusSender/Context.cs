namespace BusSender
{
    using System.Configuration;

    public static class Context
    {
        /// <summary>
        ///     Включить XSD-валидацию входящих сообщений.
        /// </summary>
        public static bool EnableXSDValidation { get; } = bool.Parse(ConfigurationManager.AppSettings["EnableXSDValidation"]);

        /// <summary>
        ///     Путь до папки с xml-файлами.
        /// </summary>
        public static string XMLMessagePath { get; } = ConfigurationManager.AppSettings["XMLMessagePath"];

        /// <summary>
        ///     Путь до папки с xsd-схемами.
        /// </summary>
        public static string XSDSchemasPath { get; } = ConfigurationManager.AppSettings["XSDSchemasPath"];
    }
}