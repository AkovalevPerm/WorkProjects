namespace Iis.Eais.Common.CurrentUserService
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;

    using Microsoft.Practices.Unity;

    using ICSSoft.Services;
    using ICSSoft.STORMNET.Security;

    using Iis.Eais.Common;
    
    public class EaisCurrentUser : Singleton<EaisCurrentUser>
    {
        private readonly IUnityContainer _container;

        private readonly Dictionary<string, IEaisUserContext> _contexts;
        
        private EaisCurrentUser()
        {
            _container = UnityFactory.GetContainer();
            _contexts = new Dictionary<string, IEaisUserContext>();
        }

        private static CurrentUserService.IUser GetUser()
        {
            return CurrentUserService.CurrentUser;
        }

        private IEaisUserContext GetUserContext()
        {
            // Запрос неавторизованного пользователя.
            string userName = GetUser().Login;
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }
            
            if (!_contexts.ContainsKey(userName))
            {
                // При параллельных запросах могут случаться коллизии словаря.
                lock (_contexts)
                {
                    if (!_contexts.ContainsKey(userName))
                    {
                        _contexts.Add(
                            userName,
                            _container.Resolve<IEaisUserContext>(new ParameterOverride("userName", userName)));
                    }
                }
            }

            return _contexts[userName];
        }

        /// <summary>
        /// STORMAG для текущего пользователя.
        /// </summary>
        public Agent User
        {
            get
            {
                // вытащить из токена срок окончания сессии (атрибут exp)
                string tokenString = System.Web.HttpContext.Current.Request.Headers["Authorization"];
                DateTime dateExp = DateTime.UtcNow.AddMinutes(-1);
                
                if (!string.IsNullOrEmpty(tokenString))
                {
                    string jwtTokenString = tokenString.Substring(7);
                    var token = new JwtSecurityToken(jwtTokenString);
                    string expString = token.Claims.First(c => c.Type == "exp").Value;
                    dateExp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    dateExp = dateExp.AddSeconds(int.Parse(expString));
                }

                // если время сессии вышло, почистить кэш
                if (!(bool)GetUserContext()?.FirstEntry && dateExp < DateTime.UtcNow)
                {
                    ResetCachedFields();
                    return null;
                }

                return GetUserContext()?.User;
            }
        }

        /// <summary>
        /// Аудит сессии для текущего пользователя.
        /// </summary>
        public SessionAudit Audit => GetUserContext()?.Audit;

        /// <summary>
        /// Метод для сброса закэшированных полей текущего пользователя.
        /// </summary>
        public void ResetCachedFields()
        {
            GetUserContext()?.ClearCache();
        }
    }
}
