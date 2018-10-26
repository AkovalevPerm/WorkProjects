namespace Iis.Eais.Common.log4net
{
    using System.Configuration;
    using System.IO;

    using global::log4net.Util;

    /// <inheritdoc />
    public class EaisPatternConverter : PatternConverter
    {
        /// <summary>
        /// Имя настройки в конфиг-файле для имени приложения.
        /// </summary>
        public const string AppNameSettingName = "AppName";

        /// <inheritdoc />
        protected override void Convert(TextWriter writer, object state)
        {
            string appName = ConfigurationManager.AppSettings[AppNameSettingName];
            writer.Write(appName);
        }
    }
}