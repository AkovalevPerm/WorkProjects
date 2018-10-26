namespace ServiceBus.ObjectDataModel.FIAS
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Item", Namespace = "")]
    public class FiasItemsDataDefinition
    {
        /// <summary>
        ///     Реестр образующих элементов;
        /// </summary>
        [DataMember(Name = "fiasAddressObjects", EmitDefaultValue = false, Order = 2)]
        public FiasAddressObjects FiasAddressObjects { get; set; }

        /// <summary>
        ///     Сведения по отдельным зданиям, сооружениям
        /// </summary>
        [DataMember(Name = "fiasHousesStructures", EmitDefaultValue = false, Order = 3)]
        public FiasHousesStructures FiasHousesStructures { get; set; }
    }
}