namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;
    /// <summary>
    /// Орган, выдавший документ.
    /// </summary>
    [DataContract(Name = "authorityIssuedDocument", Namespace = "")]
    public class AuthorityIssuedDocument : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор органа, выдавшего документ.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false, Order = 3)]
        public string Address { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        [DataMember(Name = "phoneNumber", EmitDefaultValue = false, Order = 4)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Орган СЗ.
        /// </summary>
        [DataMember(Name = "socialProtectionAuthority", EmitDefaultValue = false, Order = 5)]
        public SyncXMLDataObject SocialProtectionAuthority { get; set; }

        /// <summary>
        ///  Время создания объекта.
        /// </summary>
        [DataMember(Name = ConstCreateTime, EmitDefaultValue = false, Order = 100)]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Создатель.
        /// </summary>
        [DataMember(Name = ConstCreator, EmitDefaultValue = false, Order = 101)]
        public string Creator { get; set; }

        /// <summary>
        ///  Время последнего редактирования объекта.
        /// </summary>
        [DataMember(Name = ConstEditTime, EmitDefaultValue = false, Order = 102)]
        public DateTime? EditTime { get; set; }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        [DataMember(Name = ConstEditor, EmitDefaultValue = false, Order = 103)]
        public string Editor { get; set; }
    }
}
