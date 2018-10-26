namespace ServiceBus.ObjectDataModel.BeneficiaryData
{
    using System;
    using System.Runtime.Serialization;
    using Common;
    using IIS.Synchronizer;

    /// <summary>
    /// Проживание.
    /// </summary>
    [DataContract(Name = "location", Namespace = "")]
    public class Location: SyncXMLDataObject
    {
        /// <summary>
        ///     Территория.
        /// </summary>
        [DataMember(Name = "territory", EmitDefaultValue = false, Order = 1)]
        public Territory Territory { get; set; }

        /// <summary>
        ///     Улица.
        /// </summary>
        [DataMember(Name = "street", EmitDefaultValue = false, Order = 2)]
        public Street Street { get; set; }

        /// <summary>
        ///     Номер.
        /// </summary>
        [DataMember(Name = "number", EmitDefaultValue = false, Order = 3)]
        public int Number { get; set; }

        /// <summary>
        ///     Номер строения.
        /// </summary>
        [DataMember(Name = "houseNumber", EmitDefaultValue = false, Order = 4)]
        public string HouseNumber { get; set; }

        /// <summary>
        ///     Почтовый индекс.
        /// </summary>
        [DataMember(Name = "index", EmitDefaultValue = false, Order = 5)]
        public string Index { get; set; }

        /// <summary>
        ///     Квартира.
        /// </summary>
        [DataMember(Name = "appartment", EmitDefaultValue = false, Order = 6)]
        public string Appartment { get; set; }

        /// <summary>
        ///     Номер телефона по месту жительства.
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false, Order = 7)]
        public string Phone { get; set; }
    }
}