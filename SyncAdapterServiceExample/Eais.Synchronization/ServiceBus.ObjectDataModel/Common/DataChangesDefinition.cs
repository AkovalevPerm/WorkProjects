namespace ServiceBus.ObjectDataModel.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Attribute;
    using BeneficiaryData;
    using Iis.Eais.Catalogs;
    using Iis.Eais.Leechnost;
    using Interfaces;
    using VidUdostDok = Iis.Eais.Catalogs.VidUdostDok;

    /// <summary>
    ///     Класс для описания изменений льготополучателя.
    /// </summary>
    [DataContract(Name = "Item", Namespace = "")]
    public class DataChangesDefinition : IChangedItem
    {
        /// <inheritdoc />
        [DataMember(Name = "state", IsRequired = true, Order = 0)]
        public tState State { get; set; }

        /// <inheritdoc />
        [DataMember(Name = "Timestamp", IsRequired = true, Order = 1)]
        public DateTime? ChangeDate { get; set; }

        /// <inheritdoc />
        [DataMember(Name = "changedAttributes", EmitDefaultValue = false, Order = 2)]
        public List<AttributeDefinition> СhangedAttributes { get; set; }

        [XMLDataFieldType(typeof(Leechnost))]
        [DataMember(Name = "Beneficiary", EmitDefaultValue = false, Order = 3)]
        public Beneficiary Beneficiary { get; set; }

        [XMLDataFieldType(typeof(VidUdostDok))]
        [DataMember(Name = "KindDocument", EmitDefaultValue = false, Order = 4)]
        public KindDocument KindDocument { get; set; }

        [XMLDataFieldType(typeof(TipUdostDok))]
        [DataMember(Name = "TypeDocument", EmitDefaultValue = false, Order = 5)]
        public TypeDocument TypeDocument { get; set; }

        [XMLDataFieldType(typeof(Territoriia))]
        [DataMember(Name = "Territory", EmitDefaultValue = false, Order = 6)]
        public Territory Territory { get; set; }

        [XMLDataFieldType(typeof(Ulitca))]
        [DataMember(Name = "Street", EmitDefaultValue = false, Order = 7)]
        public Street Street { get; set; }
    }
}