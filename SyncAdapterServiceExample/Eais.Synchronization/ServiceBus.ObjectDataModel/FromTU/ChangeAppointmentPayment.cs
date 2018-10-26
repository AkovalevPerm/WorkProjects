using ICSSoft.STORMNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceBus.ObjectDataModel.Common;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    /// Изменение назначения выплаты
    /// </summary>
    [DataContract(Namespace = "")]
    public class ChangeAppointmentPayment: SyncXMLDataObject
    {
        public const string ConstAppointmentDate = "appointmentDate";
        /// <summary>
        /// Дата назначения
        /// </summary>
        [DataMember(Name = ConstAppointmentDate, IsRequired = true, Order = 1)]
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
            get { return CancellationDate.HasValue ? CancellationDate?.ToString("yyyy-MM-dd") : string.Empty; }
            set { CancellationDate = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? CancellationDate { get; set; }

        public const string ConstPaymentType = "paymentType";
        /// <summary>
        /// Тип выплаты
        /// </summary>
        [DataMember(Name = ConstPaymentType, IsRequired = true, Order = 3)]
        public tPaymentType PaymentType { get; set; }

        public const string ConstPeriod = "period";
        /// <summary>
        /// Период предоставления
        /// </summary>
        [DataMember(Name = ConstPeriod, EmitDefaultValue = false, Order = 4)]
        public string strPeriod
        {
            get { return EnumCaption.GetCaptionFor(Period); }
            set { Period = string.IsNullOrWhiteSpace(value) ? tPeriodType.pusto : (tPeriodType)EnumCaption.GetValueFor(value, typeof(tPeriodType)); }
        }
        public tPeriodType Period { get; set; }

        public const string ConstAmount = "amount";
        /// <summary>
        /// Сумма
        /// </summary>
        [DataMember(Name = ConstAmount, IsRequired = true, Order = 5)]
        public decimal Amount { get; set; }

        public const string ConstNote = "note";
        /// <summary>
        ///     Примечание.
        /// </summary>
        [DataMember(Name = ConstNote, EmitDefaultValue = false, Order = 6)]
        public string Note { get; set; }

        public const string ConstSocialProtectionAuthority = "socialProtectionAuthority";
        /// <summary>
        /// Орган СЗ
        /// </summary>
        [DataMember(Name = ConstSocialProtectionAuthority, IsRequired = true, Order = 7)]
        public SyncXMLDataObject SocialProtectionAuthority { get; set; }

        public const string ConstBeneficiaryPreferentialCategory = "beneficiaryPreferentialCategory";
        /// <summary>
        ///  Льготная категория личности
        /// </summary>
        [DataMember(Name = ConstBeneficiaryPreferentialCategory, IsRequired = true, Order = 8)]
        public SyncXMLDataObject BeneficiaryPreferentialCategory { get; set; }

        public const string ConstRecipient = "recipient";
        /// <summary>
        /// Получатель
        /// </summary>
        [DataMember(Name = ConstRecipient, IsRequired = true, Order = 9)]
        public SyncXMLDataObject Recipient { get; set; }

        public const string ConstPaymentAppointment = "paymentAppointment";
        /// <summary>
        /// Назначение выплаты
        /// </summary>
        [DataMember(Name = ConstPaymentAppointment, IsRequired = true, Order = 10)]
        public SyncXMLDataObject PaymentAppointment { get; set; }


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
