namespace ServiceBus.ObjectDataModel.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using CatalogData;
    using Interfaces;

    /// <summary>
    ///     Класс для передачи изменений справочника «Классификатор мер социальной защиты».
    /// </summary>
    [DataContract(Name = "Item", Namespace = "")]
    public class CatalogDataDefinition : IChangedItem
    {
        [DataMember(Name = "Classifier", EmitDefaultValue = false, Order = 3)]
        public Classifier Classifier { get; set; }

        /// <inheritdoc />
        [DataMember(Name = "state", IsRequired = true, Order = 0)]
        public tState State { get; set; }

        /// <inheritdoc />
        [DataMember(Name = "Timestamp", IsRequired = true, Order = 1)]
        public DateTime? ChangeDate { get; set; }

        /// <inheritdoc />
        [DataMember(Name = "changedAttributes", EmitDefaultValue = false, Order = 2)]
        public List<AttributeDefinition> СhangedAttributes { get; set; }
    }
}