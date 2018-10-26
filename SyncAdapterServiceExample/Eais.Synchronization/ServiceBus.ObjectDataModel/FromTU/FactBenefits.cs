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
    /// Факт льгот
    /// </summary>
    [DataContract(Namespace = "")]    
    public class FactBenefits: SyncXMLDataObject
    {
        public const string ConstAccrualDate = "accrualDate";
        /// <summary>
        /// Дата начисления
        /// </summary>
        [DataMember(Name = ConstAccrualDate, EmitDefaultValue = false, Order = 1)]
        public string strAccrualDate
        {
            get { return AccrualDate.HasValue ? AccrualDate?.ToString("yyyy-MM-dd") : string.Empty; }
            set { AccrualDate = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? AccrualDate { get; set; }

        public const string ConstReceiveDate = "receiveDate";
        /// <summary>
        /// Дата назначения
        /// </summary>
        [DataMember(Name = ConstReceiveDate, IsRequired = true, Order = 2)]
        public string strReceiveDate
        {
            get { return ReceiveDate.ToString("yyyy-MM-dd"); }
            set { ReceiveDate = DateTime.Parse(value); }
        }

        public DateTime ReceiveDate { get; set; }

        public const string ConstAmount = "amount";
        /// <summary>
        /// Сумма
        /// </summary>
        [DataMember(Name = ConstAmount, IsRequired = true, Order = 3)]
        public decimal Amount { get; set; }

        public const string ConstAmountSocialPackage = "amountSocialPackage";
        /// <summary>
        /// Сумма социального пакета
        /// </summary>
        [DataMember(Name = ConstAmountSocialPackage, EmitDefaultValue = false, Order = 4)]
        public decimal? AmountSocialPackage { get; set; }

        public const string ConstComments = "comments";
        /// <summary>
        ///     Комментарии.
        /// </summary>
        [DataMember(Name = ConstComments, EmitDefaultValue = false, Order = 5)]
        public string Comments { get; set; }

        public const string ConstPaymentMethod = "paymentMethod";
        /// <summary>
        ///     Способ оплаты.
        /// </summary>
        [DataMember(Name = ConstPaymentMethod, EmitDefaultValue = false, Order = 6)]
        public string strPaymentMethod
        {
            get { return EnumCaption.GetCaptionFor(PaymentMethod); }
            set { PaymentMethod = string.IsNullOrWhiteSpace(value) ? tPaymentMethod.Pusto : (tPaymentMethod)EnumCaption.GetValueFor(value, typeof(tPaymentMethod)); }
        }
        public tPaymentMethod PaymentMethod { get; set; }

        public const string ConstOverpaymentDateFrom = "overpaymentDateFrom";
        /// <summary>
        /// Дата переплаты с
        /// </summary>
        [DataMember(Name = ConstOverpaymentDateFrom, EmitDefaultValue = false, Order = 7)]
        public string strOverpaymentDateFrom
        {
            get { return OverpaymentDateFrom.HasValue ? OverpaymentDateFrom?.ToString("yyyy-MM-dd") : string.Empty; }
            set { OverpaymentDateFrom = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? OverpaymentDateFrom { get; set; }

        public const string ConstOverpaymentDateTo = "overpaymentDateTo";
        /// <summary>
        /// Дата переплаты по
        /// </summary>
        [DataMember(Name = ConstOverpaymentDateTo, EmitDefaultValue = false, Order = 8)]
        public string strOverpaymentDateTo
        {
            get { return OverpaymentDateTo.HasValue ? OverpaymentDateTo?.ToString("yyyy-MM-dd") : string.Empty; }
            set { OverpaymentDateTo = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? OverpaymentDateTo { get; set; }

        public const string ConstMediumBenefit = "mediumBenefit";
        /// <summary>
        /// Носитель льготы
        /// </summary>
        [DataMember(Name = ConstMediumBenefit, IsRequired = true, Order = 9)]
        public SyncXMLDataObject MediumBenefit { get; set; }

        public const string ConstDependent = "dependent";
        /// <summary>
        /// Иждивенец
        /// </summary>
        [DataMember(Name = ConstDependent, EmitDefaultValue = false, Order = 10)]
        public SyncXMLDataObject Dependent { get; set; }

        public const string ConstRecipient = "recipient";
        /// <summary>
        /// Получатель
        /// </summary>
        [DataMember(Name = ConstRecipient, EmitDefaultValue = false, Order = 11)]
        public SyncXMLDataObject Recipient { get; set; }

        public const string ConstBenefit = "benefit";
        /// <summary>
        /// Льгота
        /// </summary>
        [DataMember(Name = ConstBenefit, IsRequired = true, Order = 12)]
        public SyncXMLDataObject Benefit { get; set; }

        public const string ConstSocialProtectionAuthority = "socialProtectionAuthority";
        /// <summary>
        /// Орган СЗ
        /// </summary>
        [DataMember(Name = ConstSocialProtectionAuthority, IsRequired = true, Order = 13)]
        public SyncXMLDataObject SocialProtectionAuthority { get; set; }

        public const string ConstPeriod = "period";
        /// <summary>
        /// Период
        /// </summary>
        [DataMember(Name = ConstPeriod, EmitDefaultValue = false, Order = 14)]
        public SyncXMLDataObject Period { get; set; }



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
