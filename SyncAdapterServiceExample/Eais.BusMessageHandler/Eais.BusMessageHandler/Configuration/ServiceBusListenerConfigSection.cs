namespace BusMessageHandler.Configuration
{
    using System.Configuration;

    public class ServiceBusListenerConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("messageHandlers")]
        public MessageHandlersCollection MessageHandlers => (MessageHandlersCollection)this["messageHandlers"];
    }
}
