namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;

    /// <summary>
    /// Нормативный акт.
    /// </summary>
    [DataContract(Name = "legalAct", Namespace = "")]
    public class LegalAct : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор нормативного акта.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        [DataMember(Name = "number", EmitDefaultValue = false, Order = 3)]
        public string Number { get; set; }

        /// <summary>
        /// Дата подписания.
        /// </summary>
        [DataMember(Name = "signatureDate", EmitDefaultValue = false, Order = 4)]
        public DateTime SignatureDate { get; set; }

        /// <summary>
        /// Код отчета федерального казначейства.
        /// </summary>
        [DataMember(Name = "codeReportFK", EmitDefaultValue = false, Order = 5)]
        public string CodeReportFK { get; set; }

        /// <summary>
        /// Тип нормативного акта.
        /// </summary>
        [DataMember(Name = "typeLegalAct", IsRequired = true, Order = 6)]
        public SyncXMLDataObject TypeLegalAct { get; set; }

        /// <summary>
        /// Издатель акта.
        /// </summary>
        [DataMember(Name = "namePublisher", IsRequired = true, Order = 7)]
        public SyncXMLDataObject NamePublisher { get; set; }

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
