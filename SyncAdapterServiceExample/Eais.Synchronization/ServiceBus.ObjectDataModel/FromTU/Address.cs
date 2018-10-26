using IIS.Synchronizer;
using ServiceBus.ObjectDataModel.BeneficiaryData;
using ServiceBus.ObjectDataModel.Common;
using System;
using System.Runtime.Serialization;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    /// Описание адреса
    /// </summary>
    [DataContract(Namespace = "")]
    public class Address: SyncXMLDataObject
    {    
        public const string ConstNumber = "number";
        /// <summary>
        ///     Номер дома.
        /// </summary>
        [DataMember(Name = ConstNumber, EmitDefaultValue = false, Order = 1)]
        public int? Number { get; set; }

        public const string ConstHouseNumber = "houseNumber";
        /// <summary>
        ///     Номер строения.
        /// </summary>
        [DataMember(Name = ConstHouseNumber, EmitDefaultValue = false, Order = 2)]
        public string HouseNumber { get; set; }

        public const string ConstAppartment = "appartment";
        /// <summary>
        ///     Квартира.
        /// </summary>
        [DataMember(Name = ConstAppartment, EmitDefaultValue = false, Order = 3)]
        public string Appartment { get; set; }

        public const string ConstTerritory = "territory";
        /// <summary>
        ///     Территория.
        /// </summary>
        [DataMember(Name = ConstTerritory, EmitDefaultValue = false, Order = 4)]
        public SyncXMLDataObject Territory { get; set; }

        public const string ConstStreet = "street";
        /// <summary>
        ///     Улица.
        /// </summary>
        [DataMember(Name = ConstStreet, EmitDefaultValue = false, Order = 5)]
        public SyncXMLDataObject Street { get; set; }
    }
}
