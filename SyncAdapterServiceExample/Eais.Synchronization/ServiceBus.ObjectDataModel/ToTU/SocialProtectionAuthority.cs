namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    /// <summary>
    /// Орган СЗ.
    /// </summary>
    [DataContract(Name = "socialProtectionAuthority", Namespace = "")]
    public class SocialProtectionAuthority : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор ОСЗ.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false, Order = 3)]
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false, Order = 4)]
        public string Phone { get; set; }

        /// <summary>
        /// Код.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false, Order = 5)]
        public int Code { get; set; }

        /// <summary>
        /// Краткое наименование.
        /// </summary>
        [DataMember(Name = "shortName", EmitDefaultValue = false, Order = 6)]
        public string ShortName { get; set; }

        /// <summary>
        /// Код ПФ.
        /// </summary>
        [DataMember(Name = "codePF", EmitDefaultValue = false, Order = 7)]
        public string CodePF { get; set; }

        /// <summary>
        /// Полное наименование.
        /// </summary>
        [DataMember(Name = "fullName", EmitDefaultValue = false, Order = 8)]
        public string FullName { get; set; }

        /// <summary>
        /// Код для СБ.
        /// </summary>
        [DataMember(Name = "codeSB", EmitDefaultValue = false, Order = 9)]
        public string CodeSB { get; set; }

        /// <summary>
        /// Районный коэффициент.
        /// </summary>
        [DataMember(Name = "districtCoefficient", EmitDefaultValue = false, Order = 10)]
        public int DistrictCoefficient { get; set; }

        /// <summary>
        /// Код для ФНС по СОНО.
        /// </summary>
        [DataMember(Name = "SONOcodeFNS", EmitDefaultValue = false, Order = 11)]
        public string SONOCodeFNS { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        [DataMember(Name = "INN", EmitDefaultValue = false, Order = 12)]
        public string INN { get; set; }

        /// <summary>
        /// КПП.
        /// </summary>
        [DataMember(Name = "KPP", EmitDefaultValue = false, Order = 13)]
        public string KPP { get; set; }

        /// <summary>
        /// Учет по филиалу без отдельного по ОСЗ.
        /// </summary>
        [DataMember(Name = "branchAccouningWithoutSeparateSPA", EmitDefaultValue = false, Order = 14)]
        public tBool BranchAccouningWithoutSeparateSPA { get; set; }

        [DataMember(Name = "codeOKPO", EmitDefaultValue = false, Order = 15)]
        public string CodeOKPO { get; set; }

        /// <summary>
        /// Код ОКТМО.
        /// </summary>
        [DataMember(Name = "codeOKTMO", EmitDefaultValue = false, Order = 16)]
        public string CodeOKTMO { get; set; }

        /// <summary>
        /// Территориальный орган федерального казначейства.
        /// </summary>
        [DataMember(Name = "territorialAuthorityFT", EmitDefaultValue = false, Order = 17)]
        public string TerritorialAuthorityFT { get; set; }

        /// <summary>
        /// Код территориального органа федерального казначейства.
        /// </summary>
        [DataMember(Name = "codeTerritorialAuthorityFT", EmitDefaultValue = false, Order = 18)]
        public string CodeTerritorialAuthorityFT { get; set; }

        /// <summary>
        /// Код БП.
        /// </summary>
        [DataMember(Name = "codeBP", EmitDefaultValue = false, Order = 19)]
        public string CodeBP { get; set; }

        /// <summary>
        /// Наименование ТУ.
        /// </summary>
        [DataMember(Name = "nameTU", EmitDefaultValue = false, Order = 20)]
        public string NameTU { get; set; }

        /// <summary>
        /// Код ТУ.
        /// </summary>
        [DataMember(Name = "codeTU", EmitDefaultValue = false, Order = 21)]
        public string CodeTU { get; set; }

        /// <summary>
        /// Строка подключения.
        /// </summary>
        [DataMember(Name = "connectionString", EmitDefaultValue = false, Order = 22)]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Объединенный орган СЗ.
        /// </summary>
        [DataMember(Name = "unitedSPA", EmitDefaultValue = false, Order = 23)]
        public tBool UnitedSPA { get; set; }

        /// <summary>
        /// ОГРН.
        /// </summary>
        [DataMember(Name = "OGRN", EmitDefaultValue = false, Order = 24)]
        public string OGRN { get; set; }

        /// <summary>
        /// Регистрационный номер ПФ.
        /// </summary>
        [DataMember(Name = "regNumberPF", EmitDefaultValue = false, Order = 25)]
        public string RegNumberPF { get; set; }

        /// <summary>
        /// Код территориального органа ПФ.
        /// </summary>
        [DataMember(Name = "codeTerAuthorityPF", EmitDefaultValue = false, Order = 26)]
        public string CodeTerAuthorityPF { get; set; }

        /// <summary>
        /// Наименование территориального органа ПФ.
        /// </summary>
        [DataMember(Name = "nameTerAythorityPF", EmitDefaultValue = false, Order = 27)]
        public string NameTerAuthorityPF { get; set; }

        /// <summary>
        /// Иерархия органа СЗ.
        /// </summary>
        [DataMember(Name = "parent", EmitDefaultValue = false, Order = 28)]
        public SyncXMLDataObject Parent { get; set; }

        /// <summary>
        /// Территория.
        /// </summary>
        [DataMember(Name = "territory", EmitDefaultValue = false, Order = 29)]
        public SyncXMLDataObject Territory { get; set; }

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
