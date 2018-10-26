namespace SyncAdapterService.Configuration
{
    using System.Configuration;

    internal class ServiceBusListenerConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("messageTypes")]
        public MessageTypesCollection MessageTypes => (MessageTypesCollection) base["messageTypes"];
    }
}