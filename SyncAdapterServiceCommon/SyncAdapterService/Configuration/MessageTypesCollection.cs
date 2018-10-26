namespace SyncAdapterService.Configuration
{
    using System.Configuration;

    internal class MessageTypesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MessageTypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MessageTypeElement) element).MessageTypeId;
        }
    }
}