namespace ServiceBus.ObjectDataModel.FIAS
{
    using System;
    using System.Runtime.Serialization;
    using Common;

    [DataContract(Name = "Item", Namespace = "")]
    public class FiasDataDefinition
    {
        /// <summary>
        ///     Тип изменения;
        /// </summary>
        [DataMember(Name = "state", Order = 0)]
        public tState State { get; set; }

        /// <summary>
        ///     Дата и время изменения;
        /// </summary>
        [DataMember(Name = "Timestamp", Order = 1)]
        public DateTime Timestamp { get; set; }

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