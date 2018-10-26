namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;

    /// <summary>
    /// Статья акта.
    /// </summary>
    [DataContract(Name = "act", Namespace = "")]
    public class Act : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор статьи акта.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        [DataMember(Name = "number", IsRequired = true, Order = 2)]
        public string Number { get; set; }

        /// <summary>
        /// Комментарии.
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false, Order = 3)]
        public string Comments { get; set; }

        /// <summary>
        /// Льгота.
        /// </summary>
        [DataMember(Name = "benefit", EmitDefaultValue = false, Order = 4)]
        public string Benefit { get; set; }

        /// <summary>
        /// Код.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false, Order = 5)]
        public string Code { get; set; }

        /// <summary>
        /// Нормативный акт.
        /// </summary>
        [DataMember(Name = "legalAct", IsRequired = true, Order = 6)]
        public SyncXMLDataObject LegalAct { get; set; }

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
