namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    /// <summary>
    /// Период.
    /// </summary>
    [DataContract(Name = "period", Namespace = "")]
    public class Period : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор периода.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        [DataMember(Name = "startDate", IsRequired = true, Order = 3)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата конца.
        /// </summary>
        [DataMember(Name = "endDate", IsRequired = true, Order = 4)]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Тип периода.
        /// </summary>
        [DataMember(Name = "periodType", IsRequired = true, Order = 5)]
        public tPeriodType PeriodType { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        [DataMember(Name = "value", IsRequired = true, Order = 6)]
        public int Value { get; set; }

        /// <summary>
        /// Иерархия.
        /// </summary>
        [DataMember(Name = "parent", EmitDefaultValue = false, Order = 7)]
        public SyncXMLDataObject Parent { get; set; }

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
