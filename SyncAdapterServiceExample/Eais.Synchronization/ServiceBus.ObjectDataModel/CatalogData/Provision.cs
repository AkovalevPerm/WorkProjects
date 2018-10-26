namespace ServiceBus.ObjectDataModel.CatalogData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Класс для описания формы предоставления МСЗ.
    /// </summary>
    [DataContract(Name = "Provision", Namespace = "")]
    public class Provision
    {
        /// <summary>
        ///     Уникальный идентификатор формы предоставления МСЗ
        /// </summary>
        [DataMember(Name = "guid", IsRequired = true, Order = 0)]
        public Guid Guid { get; set; }

        /// <summary>
        ///     Код формы предоставления МСЗ
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false, Order = 1)]
        public string Code { get; set; }

        /// <summary>
        ///     Наименование формы предоставления МСЗ.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 2)]
        public string Name { get; set; }
    }
}