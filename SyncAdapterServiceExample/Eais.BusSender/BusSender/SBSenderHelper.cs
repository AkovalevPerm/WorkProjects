namespace BusSender
{
    using System;
    using System.Configuration;
    using System.ServiceModel;

    using ICSSoft.STORMNET;

    using NewPlatform.Flexberry.HighwaySB;

    public static class SBSenderHelper
    {
        /// <summary>
        /// Сервис отправки сообщений в шину.
        /// </summary>
        private static IServiceBusService _sbClient;

        /// <summary>
        /// Фабрика для создания сервиса <see cref="IServiceBusService" />.
        /// </summary>
        private static readonly ChannelFactory<IServiceBusService> ChannelFactory;

        /// <summary>
        /// Идентификатор клиента, отправляющего сообщения о событиях в шину.
        /// </summary>
        public static readonly string SBClientName = ConfigurationManager.AppSettings["SBClientName"];

        /// <summary>
        /// Адрес шины, куда слать сообщения.
        /// </summary>
        public static readonly string SBServiceEndpointAddress = ConfigurationManager.AppSettings["SBServiceEndpoint"];

        static SBSenderHelper()
        {
            ChannelFactory = new ChannelFactory<IServiceBusService>(
                new WSHttpBinding(SecurityMode.None),
                new EndpointAddress(SBServiceEndpointAddress));
        }

        /// <summary>
        /// Получение клиента для шины с проверкой доступности.
        /// </summary>
        public static IServiceBusService GetSBClient()
        {
            if (_sbClient == null)
            {
                _sbClient = ChannelFactory.CreateChannel();
            }

            try
            {
                _sbClient.IsUp();
            }
            catch (Exception ex)
            {
                LogService.LogWarn($"{nameof(SBSenderHelper)}.{nameof(GetSBClient)}: service bus is not up. Trying to recreate channel.", ex);
                _sbClient = ChannelFactory.CreateChannel();
            }

            return _sbClient;
        }

        /// <summary>
        /// Отправить сообщение в шину.
        /// </summary>
        /// <param name="messageTypeID">Идентификатор типа сообщения.</param>
        /// <param name="messageBody">Тело сообщения.</param>
        public static void SendMessageToESB(string messageTypeID, string messageBody = null)
        {
            GetSBClient().SendMessageToESB(new MessageForESB
            {
                ClientID = SBClientName,
                MessageTypeID = messageTypeID,
                Body = messageBody
            });
        }
    }
}
