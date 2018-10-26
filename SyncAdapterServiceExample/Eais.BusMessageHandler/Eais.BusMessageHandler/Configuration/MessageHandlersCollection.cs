namespace BusMessageHandler.Configuration
{
    using System.Configuration;

    [ConfigurationCollection(typeof(MessageHandlerElement))]
    public class MessageHandlersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MessageHandlerElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MessageHandlerElement)element).MessageTypeId;
        }
    }
}
