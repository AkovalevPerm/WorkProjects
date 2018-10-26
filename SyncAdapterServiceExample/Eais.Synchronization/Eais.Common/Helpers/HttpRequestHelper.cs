namespace Iis.Eais.Common.Helpers
{
    using System;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Вспомогательный класс для работы с телом Http запроса.
    /// </summary>
    public static class HttpRequestHelper
    {
        /// <summary>
        /// Метод возвращает название операционной системы, под управлением 
        /// которой находится устройство, отправившее запрос.
        /// </summary>
        /// <param name="request">Запрос из текущего контекста.</param>
        /// <returns>Название операционной систем.</returns>
        public static String GetUserPlatform(HttpRequest request)
        {
            var ua = request.UserAgent;

            if (ua.Contains("Android"))
                return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

            if (ua.Contains("iPad"))
                return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("iPhone"))
                return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                return "Kindle Fire";

            if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                return "Black Berry";

            if (ua.Contains("Windows Phone"))
                return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

            if (ua.Contains("Mac OS"))
                return "Mac OS";

            if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                return "Windows XP";

            if (ua.Contains("Windows NT 6.0"))
                return "Windows Vista";

            if (ua.Contains("Windows NT 6.1"))
                return "Windows 7";

            if (ua.Contains("Windows NT 6.2"))
                return "Windows 8";

            if (ua.Contains("Windows NT 6.3"))
                return "Windows 8.1";

            if (ua.Contains("Windows NT 10"))
                return "Windows 10";

            //fallback to basic platform:
            return request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
        }

        /// <summary>
        /// Возвращает версию операционной системы мобильного устройства.
        /// </summary>
        /// <param name="userAgent">Полное описание платформы.</param>
        /// <param name="device">название операционной системы.</param>
        /// <returns>Версия операционной системы.</returns>
        public static String GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }

        /// <summary>
        /// Получает ip адрес пользователя из указанного запроса.
        /// </summary>
        /// <param name="requestInfo">Запрос.</param>
        /// <returns>Возвращает ip адрес пользователя, отправившего запрос.</returns>
        public static string GetIP(HttpRequest requestInfo)
        {
            string ip = requestInfo.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = requestInfo.ServerVariables["REMOTE_ADDR"];
            }
            else
            { 
                ip = ip.Split(',')
                       .Last()
                       .Trim();
            }

            return ip;
        }
    }
}
