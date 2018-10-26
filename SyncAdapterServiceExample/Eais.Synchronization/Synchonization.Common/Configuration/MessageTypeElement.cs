namespace Synchronization.Common.Configuration
{
    using System.Configuration;

    internal class MessageTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("messageTypeId", DefaultValue = "", IsRequired = true)]
        public string MessageTypeId
        {
            get => (string) base["messageTypeId"];
            set => base["messageTypeId"] = value;
        }

        [ConfigurationProperty("class", DefaultValue = "", IsRequired = true)]
        public string Class
        {
            get => (string) base["class"];
            set => base["class"] = value;
        }
    }
}