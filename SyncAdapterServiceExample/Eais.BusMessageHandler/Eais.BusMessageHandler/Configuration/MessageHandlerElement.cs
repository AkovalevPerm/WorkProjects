namespace BusMessageHandler.Configuration
{
    using System.Configuration;

    class MessageHandlerElement : ConfigurationElement
    {
        [ConfigurationProperty("messageTypeId", IsRequired = true)]
        public string MessageTypeId
        {
            get => (string)this["messageTypeId"];
            set => this["messageTypeId"] = value;
        }

        [ConfigurationProperty("class", IsRequired = true)]
        public string Class
        {
            get => (string)this["class"];
            set => this["class"] = value;
        }

        [ConfigurationProperty("handler", IsRequired = true)]
        public string Handler
        {
            get => (string)this["handler"];
            set => this["handler"] = value;
        }
    }
}
