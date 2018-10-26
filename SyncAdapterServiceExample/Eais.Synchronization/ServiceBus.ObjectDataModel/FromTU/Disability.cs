using IIS.Synchronizer;
using System;
using System.Runtime.Serialization;
using ServiceBus.ObjectDataModel.Common;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    /// Инвалидность
    /// </summary>
    [DataContract(Name = "disability", Namespace = "")]
    public class Disability: SyncXMLDataObject
    {
        public const string ConstGroup = "group";
        /// <summary>
        ///     Группа инвалидности.
        /// </summary>
        [DataMember(Name = ConstGroup, EmitDefaultValue = false, Order = 1)]
        public tGroupDisability Group { get; set; }

        public const string ConstReferenceNumberVTEK = "referenceNumberVTEK";
        /// <summary>
        ///     Номер справки ВТЭК.
        /// </summary>
        [DataMember(Name = ConstReferenceNumberVTEK, EmitDefaultValue = false, Order = 2)]
        public string ReferenceNumberVTEK { get; set; }

        public const string ConstIssueDateVTEK = "issueDateVTEK";
        /// <summary>
        ///     Дата выдачи справки ВТЭК
        /// </summary>
        [DataMember(Name = ConstIssueDateVTEK, EmitDefaultValue = false, Order = 3)]
        public string strIssueDateVTEK
        {
            get { return IssueDateVTEK.HasValue ? IssueDateVTEK?.ToString("yyyy-MM-dd") : null; }
            set { IssueDateVTEK = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? IssueDateVTEK { get; set; }

        public const string ConstOrgName = "orgName";
        /// <summary>
        ///    Орган, выдавший справку ВТЭК
        /// </summary>
        [DataMember(Name = ConstOrgName, EmitDefaultValue = false, Order = 4)]
        public string OrgName { get; set; }

        public const string ConstDisabilityDegree = "disabilityDegree";
        /// <summary>
        ///    Степень ограничения трудоспособности.
        /// </summary>
        [DataMember(Name = ConstDisabilityDegree, EmitDefaultValue = false, Order = 5)]
        public tGroupDisability DisabilityDegree { get; set; }

        public const string ConstReferenceIssuedBy = "referenceIssuedBy";
        /// <summary>
        ///   Орган, выдавший документ
        /// </summary>
        [DataMember(Name = ConstReferenceIssuedBy, EmitDefaultValue = false, Order = 6)]
        public SyncXMLDataObject ReferenceIssuedBy { get; set; }

        public const string ConstBeneficiaryPreferentialCategory = "beneficiaryPreferentialCategory";
        /// <summary>
        ///  Льготная категория личности
        /// </summary>
        [DataMember(Name = ConstBeneficiaryPreferentialCategory, IsRequired = true, Order = 7)]
        public SyncXMLDataObject BeneficiaryPreferentialCategory { get; set; }


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