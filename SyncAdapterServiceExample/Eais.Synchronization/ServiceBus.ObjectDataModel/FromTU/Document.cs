using IIS.Synchronizer;
using System;
using System.Runtime.Serialization;
using ServiceBus.ObjectDataModel.Common;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    /// Удостоверяющий документ
    /// </summary>
    [DataContract(Name = "document", Namespace = "")]
    public class Document: SyncXMLDataObject
    {
        public const string ConstSeries = "series";
        /// <summary>
        ///     Серия.
        /// </summary>
        [DataMember(Name = ConstSeries, EmitDefaultValue = false, Order = 1)]
        public string Series { get; set; }

        public const string ConstNumber = "number";
        /// <summary>
        ///     Номер.
        /// </summary>
        [DataMember(Name = ConstNumber, EmitDefaultValue = false, Order = 2)]
        public string Number { get; set; }

        public const string ConstIssueDate = "issueDate";
        /// <summary>
        ///     Дата выдачи документа.
        /// </summary>
        [DataMember(Name = ConstIssueDate, EmitDefaultValue = false, Order = 3)]
        public string strIssueDate
        {
            get { return IssueDate.HasValue ? IssueDate?.ToString("yyyy-MM-dd") : null; }
            set { IssueDate = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? IssueDate { get; set; }

        public const string ConstEndDate = "endDate";
        /// <summary>
        ///     Дата прекращения действительности документа.
        /// </summary>
        [DataMember(Name = ConstEndDate, EmitDefaultValue = false, Order = 4)]
        public string strEndDate
        {
            get { return EndDate.HasValue ? EndDate?.ToString("yyyy-MM-dd") : null; }
            set { EndDate = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? EndDate { get; set; }

        public const string ConstOrgName = "orgName";
        /// <summary>
        ///     Орган, выдавший документ.
        /// </summary>
        [DataMember(Name = ConstOrgName, EmitDefaultValue = false, Order = 5)]
        public string OrgName { get; set; }

        public const string ConstNote = "note";
        /// <summary>
        ///     Примечание.
        /// </summary>
        [DataMember(Name = ConstNote, EmitDefaultValue = false, Order = 6)]
        public string Note { get; set; }

        public const string ConstKindDocument = "kindDocument";
        /// <summary>
        /// Вид удостоверяющего документа
        /// </summary>
        [DataMember(Name = ConstKindDocument, IsRequired = true, Order = 7)]
        public SyncXMLDataObject KindDocument { get; set; }

        public const string ConstBeneficiary = "beneficiary";
        /// <summary>
        /// Личность
        /// </summary>
        [DataMember(Name = ConstBeneficiary, IsRequired = true, Order = 8)]
        public SyncXMLDataObject Beneficiary { get; set; }

        public const string ConstIssuedBy = "issuedBy";
        /// <summary>
        /// Орган, выдавший документ
        /// </summary>
        [DataMember(Name = ConstIssuedBy, EmitDefaultValue = false, Order = 9)]
        public SyncXMLDataObject IssuedBy { get; set; }



        /// <summary>
        ///  Время создания объекта
        /// </summary>
        [DataMember(Name = ConstCreateTime, EmitDefaultValue = false, Order = 100)]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Создатель
        /// </summary>
        [DataMember(Name = ConstCreator, EmitDefaultValue = false, Order = 101)]
        public string Creator { get; set; }

        /// <summary>
        ///  Время последнего редактирования объекта
        /// </summary>
        [DataMember(Name = ConstEditTime, EmitDefaultValue = false, Order = 102)]
        public DateTime? EditTime { get; set; }

        /// <summary>
        /// Последний редактор объекта
        /// </summary>
        [DataMember(Name = ConstEditor, EmitDefaultValue = false, Order = 103)]
        public string Editor { get; set; }
    }
}