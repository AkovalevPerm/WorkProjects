namespace ServiceBus.ObjectDataModel.CatalogData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Класс для описания рубрикатора разделов МСЗ.
    /// </summary>
    [DataContract(Name = "Section", Namespace = "")]
    public class Section
    {
        /// <summary>
        ///     Уникальный идентификатор рубрикатора разделов МСЗ.
        /// </summary>
        [DataMember(Name = "guid", IsRequired = true, Order = 0)]
        public Guid Guid { get; set; }

        /// <summary>
        ///     Код рубрикатора разделов МСЗ.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false, Order = 1)]
        public string Code { get; set; }

        /// <summary>
        ///     Наименование рубрикатора разделов МСЗ.
        /// </summary>
        [DataMember(Name = "name",  EmitDefaultValue = false, Order = 2)]
        public string Name { get; set; }
    }
}