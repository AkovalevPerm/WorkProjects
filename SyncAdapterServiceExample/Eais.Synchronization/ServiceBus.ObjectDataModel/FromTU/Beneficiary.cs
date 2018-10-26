namespace ServiceBus.ObjectDataModel.FromTU
{
    using System;
    using System.Runtime.Serialization;
    using Common;

    using IIS.Synchronizer;
    using ServiceBus.ObjectDataModel.FromTU;
    using ICSSoft.STORMNET;

    /// <summary>
    ///     Класс для описания льготополучателя.
    /// </summary>
    [DataContract(Name = "beneficiary", Namespace = "")]
    public class Beneficiary : SyncXMLDataObject
    {
        public const string ConstFamilyName = "familyName";

        /// <summary>
        ///     Фамилия льготополучателя.
        /// </summary>
        [DataMember(Name = ConstFamilyName, IsRequired = true, Order = 1)]
        public string FamilyName { get; set; }

        public const string ConstFirstName = "firstName";
        /// <summary>
        ///     Имя льготополучателя.
        /// </summary>
        [DataMember(Name = ConstFirstName, IsRequired = true, Order = 2)]
        public string FirstName { get; set; }

        public const string ConstPatronymic = "patronymic";
        /// <summary>
        ///     Отчество льготополучателя.
        /// </summary>
        [DataMember(Name = ConstPatronymic, EmitDefaultValue = false, Order = 3)]
        public string Patronymic { get; set; }

        public const string ConstGender = "gender";
        /// <summary>
        ///     Пол льготополучателя.
        /// </summary>
        [DataMember(Name = ConstGender, IsRequired = true, Order = 4)]
        public string strGender
        {
            get { return EnumCaption.GetCaptionFor(Gender); }
            set { Gender = (tGender)EnumCaption.GetValueFor(value, typeof(tGender)); }
        }
        public tGender Gender { get; set; }

        public const string ConstBirthDate = "birthDate";
        /// <summary>
        ///     Дата рождения.
        /// </summary>
        [DataMember(Name = ConstBirthDate, EmitDefaultValue = false, Order = 5)]
        public string strBirthDate
        {
            get { return BirthDate.HasValue? BirthDate?.ToString("yyyy-MM-dd") : null; }
            set { BirthDate = string.IsNullOrWhiteSpace(value)? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? BirthDate { get; set; }

        public const string ConstSnils = "snils";
        /// <summary>
        ///     СНИЛС.
        /// </summary>
        [DataMember(Name = ConstSnils, EmitDefaultValue = false, Order = 6)]
        public string Snils { get; set; }

        public const string ConstINN = "INN";
        /// <summary>
        ///     ИНН.
        /// </summary>
        [DataMember(Name = ConstINN, EmitDefaultValue = false, Order = 7)]
        public string INN { get; set; }

        public const string ConstEmail = "email";
        /// <summary>
        ///     Адрес электронной почты.
        /// </summary>
        [DataMember(Name = ConstEmail, EmitDefaultValue = false, Order = 8)]
        public string Email { get; set; }

        public const string ConstPhone = "phone";
        /// <summary>
        ///     Номер телефон.
        /// </summary>
        [DataMember(Name = ConstPhone, EmitDefaultValue = false, Order = 9)]
        public string Phone { get; set; }

        public const string ConstEducation = "education";
        /// <summary>
        ///     Образование.
        /// </summary>
        [DataMember(Name = ConstEducation, EmitDefaultValue = false, Order = 10)]
        public string strEducation
        {
            get { return EnumCaption.GetCaptionFor(Education); }
            set { Education = string.IsNullOrWhiteSpace(value) ? tEducation.Pusto : (tEducation)EnumCaption.GetValueFor(value, typeof(tEducation)); }
        }
        public tEducation Education { get; set; }

        public const string ConstBirthCountry = "birthCountry";
        /// <summary>
        ///     Страна рождения.
        /// </summary>
        [DataMember(Name = ConstBirthCountry, EmitDefaultValue = false, Order = 11)]
        public string BirthCountry { get; set; }

        public const string ConstBirthRegion = "birthRegion";
        /// <summary>
        ///     Область рождения.
        /// </summary>
        [DataMember(Name = ConstBirthRegion, EmitDefaultValue = false, Order = 12)]
        public string BirthRegion { get; set; }

        public const string ConstBirthTown = "birthTown";
        /// <summary>
        ///     Город рождения.
        /// </summary>
        [DataMember(Name = ConstBirthTown, EmitDefaultValue = false, Order = 12)]
        public string BirthTown { get; set; }

        public const string ConstBirthDistrict = "birthDistrict";
        /// <summary>
        ///     Район рождения.
        /// </summary>
        [DataMember(Name = ConstBirthDistrict, EmitDefaultValue = false, Order = 13)]
        public string BirthDistrict { get; set; }

        public const string ConstTotalExperience = "totalExperience";
        /// <summary>
        /// Общий стаж
        /// </summary>
        [DataMember(Name = ConstTotalExperience, EmitDefaultValue = false, Order = 14)]
        public uint? TotalExperience { get; set; }

        public const string ConstAdditionalInformation = "additionalInformation";
        /// <summary>
        /// Дополнительные сведения
        /// </summary>
        [DataMember(Name = ConstAdditionalInformation, EmitDefaultValue = false, Order = 15)]
        public string AdditionalInformation { get; set; }

        public const string ConstLocation = "location";
        /// <summary>
        ///     Проживание.
        /// </summary>
        [DataMember(Name = ConstLocation, EmitDefaultValue = false, Order = 16)]
        public Address Location { get; set; }

        public const string ConstRegistration = "registration";
        /// <summary>
        ///     Прописка.
        /// </summary>
        [DataMember(Name = ConstRegistration, EmitDefaultValue = false, Order = 17)]
        public Address Registration { get; set; }

        public const string ConstCitizenship = "citizenship";
        /// <summary>
        /// Гражданство
        /// </summary>
        [DataMember(Name = ConstCitizenship, EmitDefaultValue = false, Order = 18)]
        public SyncXMLDataObject Citizenship { get; set; }




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