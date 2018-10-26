namespace ServiceBus.ObjectDataModel.CatalogData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Класс для описания уровня нормативно – правового регулировния.
    /// </summary>
    [DataContract(Name = "LegalLevel", Namespace = "")]
    public class LegalLevel
    {
        /// <summary>
        ///     Уникальный идентификатор уровня нормативно – правового регулирования.
        /// </summary>
        [DataMember(Name = "guid", IsRequired = true, Order = 0)]
        public Guid Guid { get; set; }

        /// <summary>
        ///     Код уровня нормативно – правового регулирования.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false, Order = 1)]
        public string Code { get; set; }

        /// <summary>
        ///     Наименована уровня нормативно – правового регулировния.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 2)]
        public string Name { get; set; }
    }
}