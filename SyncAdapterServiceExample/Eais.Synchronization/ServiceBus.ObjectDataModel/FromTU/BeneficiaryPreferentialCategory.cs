using IIS.Synchronizer;
using System;
using System.Runtime.Serialization;
using ServiceBus.ObjectDataModel.Common;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    ///     Льготная категория личности.
    /// </summary>
    [DataContract(Name = "beneficiary", Namespace = "")]
    public class BeneficiaryPreferentialCategory: SyncXMLDataObject
    {
        public const string ConstPurposeDate = "appointmentDate";
        /// <summary>
        ///     Дата назначения
        /// </summary>
        [DataMember(Name = ConstPurposeDate, IsRequired = true, Order = 1)]
        public string strAppointmentDate
        {
            get { return AppointmentDate.ToString("yyyy-MM-dd"); }
            set { AppointmentDate = DateTime.Parse(value); }
        }

        public DateTime AppointmentDate { get; set; }

        public const string ConstCancellationDate = "cancellationDate";
        /// <summary>
        ///     Дата отмены
        /// </summary>
        [DataMember(Name = ConstCancellationDate, EmitDefaultValue = false, Order = 2)]
        public string strCancellationDate
        {
            get { return CancellationDate.HasValue ? CancellationDate?.ToString("yyyy-MM-dd"):string.Empty; }
            set { CancellationDate = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? CancellationDate { get; set; }

        public const string ConstNote = "note";
        /// <summary>
        ///    Примечание.
        /// </summary>
        [DataMember(Name = ConstNote, EmitDefaultValue = false, Order = 3)]
        public string Note { get; set; }

        public const string ConstDocument = "document";
        /// <summary>
        /// Удостоверяющий документ
        /// </summary>
        [DataMember(Name = ConstDocument, EmitDefaultValue = false, Order = 4)]
        public SyncXMLDataObject Document { get; set; }

        public const string ConstPreferentialCategory = "preferentialCategory";
        /// <summary>
        /// Льготная категория
        /// </summary>
        [DataMember(Name = ConstPreferentialCategory, IsRequired = true, Order = 5)]
        public SyncXMLDataObject PreferentialCategory { get; set; }

        public const string ConstActDisability = "actDisability";
        /// <summary>
        /// Акт инвалидности
        /// </summary>
        [DataMember(Name = ConstActDisability, EmitDefaultValue = false, Order = 6)]
        public SyncXMLDataObject ActDisability { get; set; }

        public const string ConstBeneficiary = "beneficiary";
        /// <summary>
        /// Личность
        /// </summary>
        [DataMember(Name = ConstBeneficiary, IsRequired = true, Order = 7)]
        public SyncXMLDataObject Beneficiary { get; set; }



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