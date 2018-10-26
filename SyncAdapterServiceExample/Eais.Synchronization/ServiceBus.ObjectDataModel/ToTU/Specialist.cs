namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    /// <summary>
    /// Специалист ОСЗ.
    /// </summary>
    [DataContract(Name = "specialist", Namespace = "")]
    public class Specialist : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор специалиста.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [DataMember(Name = "familyName", IsRequired = true, Order = 2)]
        public string FamilyName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember(Name = "firstName", IsRequired = true, Order = 3)]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [DataMember(Name = "patronymic", EmitDefaultValue = false, Order = 4)]
        public string Patronymic { get; set; }

        /// <summary>
        /// Руководитель органа СЗ.
        /// </summary>
        [DataMember(Name = "chiefSPA", IsRequired = true, Order = 5)]
        public tBool ChiefSPA { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        [DataMember(Name = "login", EmitDefaultValue = false, Order = 6)]
        public string Login { get; set; }

        /// <summary>
        /// Орган СЗ.
        /// </summary>
        [DataMember(Name = "socialProtectionAuthority", IsRequired = true, Order = 7)]
        public SyncXMLDataObject SocialProtectionAuthority { get; set; }

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
