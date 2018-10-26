namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;

    /// <summary>
    /// Уровень власти.
    /// </summary>
    [DataContract(Name = "governmentLevel", Namespace = "")]
    public class GovernmentLevel : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор уровня власти.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        public string Name { get; set; }

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
