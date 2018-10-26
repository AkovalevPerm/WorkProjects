namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    /// <summary>
    /// Территория.
    /// </summary>
    [DataContract(Name = "territory", Namespace = "")]
    public class Territory : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор территории.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        ///     Код ФИАС.
        /// </summary>
        [DataMember(Name = "FIAS", EmitDefaultValue = false, Order = 2)]
        public string FIAS { get; set; }

        /// <summary>
        ///     Вид объекта.
        /// </summary>
        [DataMember(Name = "objectType", EmitDefaultValue = false, Order = 3)]
        public string ObjectType { get; set; }

        /// <summary>
        ///     Наименование.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 4)]
        public string Name { get; set; }

        /// <summary>
        ///     Почтовый индекс.
        /// </summary>
        [DataMember(Name = "postIndex", EmitDefaultValue = false, Order = 5)]
        public string PostIndex { get; set; }

        /// <summary>
        ///     Родительская территория (иерархия).
        /// </summary>
        [DataMember(Name = "parent", EmitDefaultValue = false, Order = 6)]
        public SyncXMLDataObject Parent { get; set; }

        /// <summary>
        ///     Орган социальной защиты.
        /// </summary>
        [DataMember(Name = "socialProtectionAuthority", EmitDefaultValue = false, Order = 7)]
        public SyncXMLDataObject SocialProtectionAuthority { get; set; }

        /// <summary>
        /// Код СЗ.
        /// </summary>
        [DataMember(Name = "codeSPA", EmitDefaultValue = false, Order = 8)]
        public string CodeSPA { get; set; }

        /// <summary>
        /// Код КЛАДР.
        /// </summary>
        [DataMember(Name = "codeKLADR", EmitDefaultValue = false, Order = 9)]
        public string CodeKLADR { get; set; }
        
        /// <summary>
        /// Код ОКАТО.
        /// </summary>
        [DataMember(Name = "codeOKATO", EmitDefaultValue = false, Order = 10)]
        public string CodeOKATO { get; set; }

        /// <summary>
        /// Городской район.
        /// </summary>
        [DataMember(Name = "urbanArea", EmitDefaultValue = false, Order = 11)]
        public tBool UrbanArea { get; set; }

        /// <summary>
        /// Код региона ПФ.
        /// </summary>
        [DataMember(Name = "regionCodePF", EmitDefaultValue = false, Order = 12)]
        public string RegionCodePF { get; set; }

        /// <summary>
        /// Код ОКТМО.
        /// </summary>
        [DataMember(Name = "codeOKTMO", EmitDefaultValue = false, Order = 13)]
        public string CodeOKTMO { get; set; }

        /// <summary>
        /// Код ОПФР.
        /// </summary>
        [DataMember(Name = "codeOPFR", EmitDefaultValue = false, Order = 14)]
        public string CodeOPFR { get; set; }

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
