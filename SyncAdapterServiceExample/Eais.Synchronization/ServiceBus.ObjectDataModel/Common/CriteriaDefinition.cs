namespace ServiceBus.ObjectDataModel.Common
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Criteria", Namespace = "")]
    public class CriteriaDefinition
    {
        [DataMember(Name = "Type", EmitDefaultValue = false, Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "Conditions", EmitDefaultValue = false, Order = 1)]
        public ConditionDefinition[] Condition { get; set; }

        [DataMember(Name = "Criteria", EmitDefaultValue = false, Order = 2)]
        public CriteriaDefinition Criteria { get; set; }
    }
}