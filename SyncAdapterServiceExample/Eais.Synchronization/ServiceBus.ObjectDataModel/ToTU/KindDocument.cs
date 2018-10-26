namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;

    /// <summary>
    /// Вид удостоверяющего документа.
    /// </summary>
    [DataContract(Name = "kindDocument", Namespace = "")]
    public class KindDocument : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор вида удостоверяющего документа.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Краткое наименование.
        /// </summary>
        [DataMember(Name = "shortName", EmitDefaultValue = false, Order = 3)]
        public string ShortName { get; set; }

        /// <summary>
        /// Код ПФ.
        /// </summary>
        [DataMember(Name = "codePF", EmitDefaultValue = false, Order = 4)]
        public string CodePF { get; set; }

        /// <summary>
        /// Приоритет.
        /// </summary>
        [DataMember(Name = "priority", EmitDefaultValue = false, Order = 5)]
        public int Priority { get; set; }

        /// <summary>
        /// Код вида документа.
        /// </summary>
        [DataMember(Name = "codeKindDocument", EmitDefaultValue = false, Order = 6)]
        public string CodeKindDocument { get; set; }

        /// <summary>
        /// Приоритет для ФНС.
        /// </summary>
        [DataMember(Name = "priorityFNS", EmitDefaultValue = false, Order = 7)]
        public int PriorityFNS { get; set; }

        /// <summary>
        /// Тип удостоверяющего документа.
        /// </summary>
        [DataMember(Name = "typeDocument", IsRequired = true, Order = 8)]
        public SyncXMLDataObject TypeDocument { get; set; }

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
