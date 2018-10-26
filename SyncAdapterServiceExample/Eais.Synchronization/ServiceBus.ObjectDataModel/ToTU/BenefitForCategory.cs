namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using Iis.Eais.Catalogs;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    /// <summary>
    /// Льгота для категории.
    /// </summary>
    [DataContract(Name = "benefitForCategory", Namespace = "")]
    public class BenefitForCategory : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор льготы для категории.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Дата назначения.
        /// </summary>
        [DataMember(Name = "appointmentDate", EmitDefaultValue = false, Order = 2)]
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        /// Дата отмены.
        /// </summary>
        [DataMember(Name = "cancellationDate", EmitDefaultValue = false, Order = 3)]
        public DateTime? CancellationDate { get; set; }

        /// <summary>
        /// Период предоставления.
        /// </summary>
        [DataMember(Name = "period", EmitDefaultValue = false, Order = 4)]
        public tPeriodType Period { get; set; }

        /// <summary>
        /// Тип выплаты.
        /// </summary>
        [DataMember(Name = "paymentType", IsRequired = true, Order = 5)]
        public tTipVyplaty PaymentType { get; set; }

        /// <summary>
        /// Льгота.
        /// </summary>
        [DataMember(Name = "benefit", IsRequired = true, Order = 6)]
        public SyncXMLDataObject Benefit { get; set; }

        /// <summary>
        /// Источник финансирования.
        /// </summary>
        [DataMember(Name = "fundingSource", EmitDefaultValue = false, Order = 7)]
        public SyncXMLDataObject FundingSource { get; set; }

        /// <summary>
        /// Основание.
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false, Order = 8)]
        public SyncXMLDataObject Reason { get; set; }

        /// <summary>
        /// Льготная категория.
        /// </summary>
        [DataMember(Name = "preferentialCategory", IsRequired = true, Order = 9)]
        public SyncXMLDataObject PreferentialCategory { get; set; }

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
