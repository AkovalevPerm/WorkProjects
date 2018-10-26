using IIS.Synchronizer;
using System;
using System.Runtime.Serialization;
using ServiceBus.ObjectDataModel.Common;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    /// Перемещение
    /// </summary>
    [DataContract(Name = "changeName", Namespace = "")]
    public class ChangeName: SyncXMLDataObject
    {
        public const string ConstFamilyName = "familyName";
        /// <summary>
        ///     Фамилия.
        /// </summary>
        [DataMember(Name = ConstFamilyName, IsRequired = true, Order = 1)]
        public string FamilyName { get; set; }

        public const string ConstFirstName = "firstName";
        /// <summary>
        ///     Имя.
        /// </summary>
        [DataMember(Name = ConstFirstName, IsRequired = true, Order = 2)]
        public string FirstName { get; set; }

        public const string ConstPatronymic = "patronymic";
        /// <summary>
        ///     Отчество.
        /// </summary>
        [DataMember(Name = ConstPatronymic, EmitDefaultValue = false, Order = 3)]
        public string Patronymic { get; set; }

        public const string ConstChangeDate = "changeDate";
        /// <summary>
        ///     Дата изменения ФИО
        /// </summary>
        [DataMember(Name = ConstChangeDate, EmitDefaultValue = false, Order = 4)]
        public string strChangeDate
        {
            get { return ChangeDate.HasValue ? ChangeDate?.ToString("yyyy-MM-dd") : null; }
            set { ChangeDate = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? ChangeDate { get; set; }

        public const string ConstBeneficiary = "beneficiary";
        /// <summary>
        /// Личность
        /// </summary>
        [DataMember(Name = ConstBeneficiary, IsRequired = true, Order = 5)]
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