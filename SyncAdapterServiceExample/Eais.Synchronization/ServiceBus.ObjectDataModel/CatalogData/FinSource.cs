namespace ServiceBus.ObjectDataModel.CatalogData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Класс для описания источника финансирования МСЗ.
    /// </summary>
    [DataContract(Name = "FinSource", Namespace = "")]
    public class FinSource
    {
        /// <summary>
        ///     Уникальный идентификатор источника финансирования МСЗ.
        /// </summary>
        [DataMember(Name = "guid", IsRequired = true, Order = 0)]
        public Guid Guid { get; set; }

        /// <summary>
        ///     Код источника финансирования МСЗ.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false, Order = 1)]
        public string Code { get; set; }

        /// <summary>
        ///     Наименование источника финансирования МСЗ.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 2)]
        public string Name { get; set; }
    }
}