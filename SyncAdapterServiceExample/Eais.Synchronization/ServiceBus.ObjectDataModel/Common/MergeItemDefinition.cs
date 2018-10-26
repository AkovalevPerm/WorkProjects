namespace ServiceBus.ObjectDataModel.Common
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using BeneficiaryData;

    [DataContract(Name = "Item", Namespace = "")]
    public class MergeItemDefinition
    {
        [DataMember(Name = "Beneficiary", EmitDefaultValue = false, Order = 1)]
        public Beneficiary Beneficiary;

        [DataMember(Name = "Sources", EmitDefaultValue = false, Order = 0)]
        public List<SourceKeyDefinition> Sources;
    }
}