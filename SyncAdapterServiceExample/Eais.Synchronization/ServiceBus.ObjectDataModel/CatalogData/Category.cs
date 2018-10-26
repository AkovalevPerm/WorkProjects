namespace ServiceBus.ObjectDataModel.CatalogData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Класс для описания категории классификатора мер социальной защиты.
    /// </summary>
    [DataContract(Name = "Category", Namespace = "")]
    public class Category
    {
        /// <summary>
        ///     Уникальный идентификатор категории.
        /// </summary>
        [DataMember(Name = "guid", IsRequired = true, Order = 0)]
        public Guid Guid { get; set; }

        /// <summary>
        ///     Код категории.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false, Order = 1)]
        public string Code { get; set; }

        /// <summary>
        ///     Наименование категории.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 2)]
        public string Name { get; set; }

        /// <summary>
        ///     Примечание.
        /// </summary>
        [DataMember(Name = "note", EmitDefaultValue = false, Order = 3)]
        public string Note { get; set; }
    }
}