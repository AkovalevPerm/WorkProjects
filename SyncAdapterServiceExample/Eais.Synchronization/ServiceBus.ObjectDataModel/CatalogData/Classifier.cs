namespace ServiceBus.ObjectDataModel.CatalogData
{
    using System;
    using System.Runtime.Serialization;
    using Common.Attribute;

    /// <summary>
    ///     Класс для описания классификатора мер социальной защиты.
    /// </summary>
    [AliasType("1403")]
    [DataContract(Name = "Classifier", Namespace = "")]
    public class Classifier
    {
        /// <summary>
        ///     Уникальный идентификатор меры социальной защиты.
        /// </summary>
        [DataMember(Name = "guid", IsRequired = true, Order = 0)]
        public Guid Guid { get; set; }

        /// <summary>
        ///     Код меры социальной защиты.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false, Order = 1)]
        public string Code { get; set; }

        /// <summary>
        ///     Код меры социальной защиты.
        /// </summary>
        [DataMember(Name = "Social", EmitDefaultValue = false, Order = 2)]
        public Social Social { get; set; }

        /// <summary>
        ///     Категории.
        /// </summary>
        [DataMember(Name = "Category", EmitDefaultValue = false, Order = 3)]
        public Category Category { get; set; }

        /// <summary>
        ///     Уровень нормативно – правового регулирования.
        /// </summary>
        [DataMember(Name = "LegalLevel", EmitDefaultValue = false, Order = 4)]
        public LegalLevel LegalLevel { get; set; }

        /// <summary>
        ///     Источник финансирования МСЗ.
        /// </summary>
        [DataMember(Name = "FinSource", EmitDefaultValue = false, Order = 5)]
        public FinSource FinSource { get; set; }

        /// <summary>
        ///     Форма предоставления МСЗ.
        /// </summary>
        [DataMember(Name = "Provision", EmitDefaultValue = false, Order = 6)]
        public Provision Provision { get; set; }

        /// <summary>
        ///     Рубрикатора разделов МСЗ.
        /// </summary>
        [DataMember(Name = "Section", EmitDefaultValue = false, Order = 7)]
        public Section Section { get; set; }
    }
}