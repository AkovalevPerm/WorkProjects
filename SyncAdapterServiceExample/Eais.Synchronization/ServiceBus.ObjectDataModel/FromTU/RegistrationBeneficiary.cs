using IIS.Synchronizer;
using System;
using System.Runtime.Serialization;
using ServiceBus.ObjectDataModel.Common;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    ///Учет личности
    /// </summary>
    [DataContract(Name = "registrationBeneficiary", Namespace = "")]
    public class RegistrationBeneficiary: SyncXMLDataObject
    {
        public const string ConstRegistrationDate = "registrationDate";
        /// <summary>
        ///    Дата постановки на учет
        /// </summary>
        [DataMember(Name = ConstRegistrationDate, IsRequired = true, Order = 1)]
        public string strRegistrationDate
        {
            get { return RegistrationDate.ToString("yyyy-MM-dd"); }
            set { RegistrationDate = DateTime.Parse(value); }
        }

        public DateTime RegistrationDate { get; set; }

        public const string ConstDeregistrationDate = "deregistrationDate";
        /// <summary>
        ///   Дата снятия с учета
        /// </summary>
        [DataMember(Name = ConstDeregistrationDate, EmitDefaultValue = false, Order = 2)]
        public string strDeregistrationDate
        {
            get { return DeregistrationDate.HasValue ? DeregistrationDate?.ToString("yyyy-MM-dd") : null; }
            set { DeregistrationDate = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? DeregistrationDate { get; set; }

        public const string ConstSocialProtectionAuthority = "socialProtectionAuthority";
        /// <summary>
        /// Орган СЗ
        /// </summary>
        [DataMember(Name = ConstSocialProtectionAuthority, IsRequired = true, Order = 3)]
        public SyncXMLDataObject SocialProtectionAuthority { get; set; }

        public const string ConstBeneficiary = "beneficiary";
        /// <summary>
        /// Личность
        /// </summary>
        [DataMember(Name = ConstBeneficiary, IsRequired = true, Order = 4)]
        public SyncXMLDataObject Beneficiary { get; set; }

        public const string ConstDeregestrationReason = "deregestrationReason";
        /// <summary>
        /// Причина снятия с учета
        /// </summary>
        [DataMember(Name = ConstDeregestrationReason, EmitDefaultValue = false, Order = 5)]
        public SyncXMLDataObject DeregestrationReason { get; set; }



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