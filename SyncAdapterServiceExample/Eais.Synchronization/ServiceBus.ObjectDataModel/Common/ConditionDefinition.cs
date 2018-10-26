namespace ServiceBus.ObjectDataModel.Common
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Condition", Namespace = "")]
    public class ConditionDefinition
    {
        [DataMember(Name = "Attribute", IsRequired = true, Order = 0)]
        public string Attribute { get; set; }

        [DataMember(Name = "Operator", IsRequired = true, Order = 1)]
        public string Operator { get; set; }

        [DataMember(Name = "Value", IsRequired = true, Order = 2)]
        public string Value { get; set; }
    }
}