namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;

    /// <summary>
    /// Улица.
    /// </summary>
    [DataContract(Name = "street", Namespace = "")]
    public class Street : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор улицы.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        ///     Почтовый индекс.
        /// </summary>
        [DataMember(Name = "postIndex", EmitDefaultValue = false, Order = 2)]
        public string PostIndex { get; set; }

        /// <summary>
        /// Код КЛАДР.
        /// </summary>
        [DataMember(Name = "codeCLADR", EmitDefaultValue = false, Order = 3)]
        public string CodeCLADR { get; set; }

        /// <summary>
        /// Наименование улицы.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 4)]
        public string Name { get; set; }

        /// <summary>
        /// Код ГР.
        /// </summary>
        [DataMember(Name = "codeGR", EmitDefaultValue = false, Order = 5)]
        public int CodeGR { get; set; }

        /// <summary>
        ///     Вид объекта.
        /// </summary>
        [DataMember(Name = "objectType", EmitDefaultValue = false, Order = 6)]
        public string ObjectType { get; set; }

        /// <summary>
        ///     Код ФИАС.
        /// </summary>
        [DataMember(Name = "codeFIAS", EmitDefaultValue = false, Order = 7)]
        public string CodeFIAS { get; set; }

        /// <summary>
        /// Новое название улицы (иерархия).
        /// </summary>
        [DataMember(Name = "newName", EmitDefaultValue = false, Order = 8)]
        public SyncXMLDataObject NewName { get; set; }

        /// <summary>
        /// Территория.
        /// </summary>
        [DataMember(Name = "territory", IsRequired = true, Order = 9)]
        public SyncXMLDataObject Territory { get; set; }

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
