namespace Iis.Eais.Common.CurrentUserService
{
    using ICSSoft.STORMNET.Security;
    using Iis.Eais.Common;

    interface IEaisUserContext
    {
        /// <summary>
        /// STORMAG для текущего пользователя.
        /// </summary>
        Agent User { get; }

        /// <summary>
        /// Аудит сессии для текущего пользователя.
        /// </summary>
        SessionAudit Audit { get; }

        /// <summary>
        /// Флаг первого входа
        /// </summary>
        bool FirstEntry { get; }

        /// <summary>
        /// Сбросить флаг "первого входа".
        /// </summary>
        void ResetFlag();

        /// <summary>
        /// Очистить закэшированные поля.
        /// </summary>
        void ClearCache();

    }
}
