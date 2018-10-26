using System.Linq;
using System.Security.Claims;
using System.Web;
using static ICSSoft.Services.CurrentUserService;

namespace Iis.Eais.Common.CurrentUserService
{
    /// <summary>
    /// Класс, представляющий текущего аутентифицированного пользователя на основе ClaimsIdentity из HttpContext
    /// (для аутентификации по токену OpenId Connect).
    /// </summary>
    public class User : IUser
    {
        private string _login;

        private string _domain;

        private string _friendlyName;

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login
        {
            get
            {
                string contextLogin = ((ClaimsIdentity)(HttpContext.Current?.User.Identity))?.Claims?.FirstOrDefault(x => x.Type == "username")?.Value;

                if (!string.IsNullOrEmpty(contextLogin) && !contextLogin.Equals(_login))
                {
                    _login = contextLogin;
                }

                return _login;
            }
            set
            {
                _login = value;
            }
        }

        /// <summary>
        /// Домен пользователя.
        /// </summary>
        public string Domain
        {
            get
            {
                return _domain;
            }

            set
            {
                _domain = value;
            }
        }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FriendlyName
        {
            get
            {
                string contextFriendlyName = ((ClaimsIdentity)(HttpContext.Current?.User.Identity))?.Claims?.FirstOrDefault(x => x.Type == "name")?.Value;

                if (!string.IsNullOrEmpty(contextFriendlyName) && !contextFriendlyName.Equals(_friendlyName))
                {
                    _friendlyName = contextFriendlyName;
                }

                return _friendlyName;
            }
            set
            {
                _friendlyName = value;
            }
        }        
    }
}
