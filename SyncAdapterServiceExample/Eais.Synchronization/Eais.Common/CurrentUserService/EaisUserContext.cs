namespace Iis.Eais.Common.CurrentUserService
{
    using System;
    using System.Web;
    using System.Linq;

    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Security;
    using ICSSoft.STORMNET.UserDataTypes;
    using Iis.Eais.Common;

    using IIS.University.Tools;

    using Helpers;

    public class EaisUserContext : IEaisUserContext
    {
        private readonly string _userName;

        public bool FirstEntry { get; private set; }

        private IDataService DataService { get; } = DataServiceProvider.DataService;

        private void UpdateAuditSession()
        {
            if (_user != null)
            {
                if (Audit == null)
                {
                    var requestInfo = HttpContext.Current.Request;
                    var audit = new SessionAudit
                    {
                        Agent = _user,
                        Start = DateTime.Now,
                        Browser = $"{requestInfo.Browser.Browser} {requestInfo.Browser.Version}",
                        IPAddress = HttpRequestHelper.GetIP(requestInfo),
                        OperatingSystem = HttpRequestHelper.GetUserPlatform(requestInfo),
                        ScreenResolution = requestInfo.Headers["Screen-Resolution"]
                    };

                    Audit = audit;
                }

                if ((Audit.Finish == null) || Audit.Finish.Value < DateTime.Now)
                {
                    Audit.Finish = (NullableDateTime)DateTime.Now.AddMinutes(30);
                    DataService.UpdateObject(Audit);
                }
            }
        }

        public EaisUserContext(string userName)
        {
            _userName = userName;
            FirstEntry = true;
        }

        private Agent _user;

        public SessionAudit Audit { get; set; }

        public Agent User
        {
            get
            {
                if (FirstEntry && _user == null)
                {
                    try
                    {
                        var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Agent), Agent.Views.UserE);
                        lcs.LimitFunction = FunctionBuilder.BuildEquals<Agent>(a => a.Login, _userName);

                        _user = DataService.LoadObjects(lcs).Cast<Agent>().FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        LogService.Log.Error(ex);
                        throw;
                    }

                    FirstEntry = false;
                }

                UpdateAuditSession();

                return _user;
            }
        }

        /// <summary>
        /// Очистить закэшированные поля.
        /// </summary>
        public void ClearCache()
        {
            _user = null;
            FirstEntry = true;
            Audit = null;
        }

        /// <summary>
        /// Сбросить флаг "первого входа".
        /// </summary>
        public void ResetFlag()
        {
            FirstEntry = true;
        }
    }
}
