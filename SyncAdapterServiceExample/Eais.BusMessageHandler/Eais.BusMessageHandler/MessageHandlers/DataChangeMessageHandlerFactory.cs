namespace BusMessageHandler.MessageHandlers
{
    using System;

    using ICSSoft.Services;

    using Interface;
    using Microsoft.Practices.Unity;

    public class DataChangeMessageHandlerFactory
    {
        /// <summary>
        ///     Сервис сбора изменений по умолчанию.
        /// </summary>
        public static IDataMessageHandler DataMessageHandler { get; }

        static DataChangeMessageHandlerFactory()
        {
            var container = UnityFactory.GetContainer();
            DataMessageHandler = container.Resolve<IDataMessageHandler>();

            if (DataMessageHandler == null)
            {
                throw new Exception($"Не проинициализирован {nameof(DataMessageHandler)}!");
            }
        }
    }
}