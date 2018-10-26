namespace ServiceBus.ObjectDataModel.BeneficiaryData
{
    using IIS.Synchronizer;
    using System;
    using System.Runtime.Serialization;
    using Common;

    /// <summary>
    ///     Класс для описания документа льготополучателя.
    /// </summary>
    [DataContract(Name = "document", Namespace = "")]
    public class Document : SyncXMLDataObject
    {
        /// <summary>
        ///     Серия.
        /// </summary>
        [DataMember(Name = "docSeries", EmitDefaultValue = false, Order = 1)]
        public string DocSeries { get; set; }

        /// <summary>
        ///     Номер.
        /// </summary>
        [DataMember(Name = "docNumber", EmitDefaultValue = false, Order = 2)]
        public string DocNumber { get; set; }

        /// <summary>
        ///     Дата выдачи документа.
        /// </summary>
        [DataMember(Name = "docIssueDate", EmitDefaultValue = false, Order = 3)]
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        ///     Дата прекращения действительности документа.
        /// </summary>
        [DataMember(Name = "docEndDate", EmitDefaultValue = false, Order = 4)]
        public DateTime? DocEndDate { get; set; }

        /// <summary>
        ///     Орган выдавший документ.
        /// </summary>
        [DataMember(Name = "orgName", EmitDefaultValue = false, Order = 5)]
        public string OrgName { get; set; }

        /// <summary>
        ///     Вид документа.
        /// </summary>
        [DataMember(Name = "docKind", EmitDefaultValue = false, Order = 6)]
        public Guid DocKind { get; set; }
    }
}