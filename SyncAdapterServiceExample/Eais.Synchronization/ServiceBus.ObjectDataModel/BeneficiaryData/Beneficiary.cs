namespace ServiceBus.ObjectDataModel.BeneficiaryData
{
    using System;
    using System.Runtime.Serialization;
    using Common;

    using IIS.Synchronizer;

    /// <summary>
    ///     Класс для описания льготополучателя.
    /// </summary>
    [DataContract(Name = "Beneficiary", Namespace = "")]
    public class Beneficiary : SyncXMLDataObject
    {
        /// <summary>
        ///     Фамилия льготополучателя.
        /// </summary>
        [DataMember(Name = "familyName", EmitDefaultValue = false, Order = 1)]
        public string FamilyName { get; set; }

        /// <summary>
        ///     Имя льготополучателя.
        /// </summary>
        [DataMember(Name = "firstName", EmitDefaultValue = false, Order = 2)]
        public string FirstName { get; set; }

        /// <summary>
        ///     Отчество льготополучателя.
        /// </summary>
        [DataMember(Name = "patronymic", EmitDefaultValue = false, Order = 3)]
        public string Patronymic { get; set; }

        /// <summary>
        ///     Пол льготополучателя.
        /// </summary>
        [DataMember(Name = "gender", Order = 4)]
        public tGender Gender { get; set; }

        /// <summary>
        ///     Дата рождения.
        /// </summary>
        [DataMember(Name = "birthDate", EmitDefaultValue = false, Order = 5)]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        ///     СНИЛС.
        /// </summary>
        [DataMember(Name = "snils", EmitDefaultValue = false, Order = 6)]
        public string Snils { get; set; }

        /// <summary>
        ///     ИНН.
        /// </summary>
        [DataMember(Name = "INN", EmitDefaultValue = false, Order = 7)]
        public string INN { get; set; }

        /// <summary>
        ///     Адрес электронной почты.
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false, Order = 8)]
        public string Email { get; set; }

        /// <summary>
        ///     Номер телефон.
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false, Order = 9)]
        public string Phone { get; set; }

        /// <summary>
        ///     Образование.
        /// </summary>
        [DataMember(Name = "education", Order = 10)]
        public tEducation Education { get; set; }

        /// <summary>
        ///     Страна рождения.
        /// </summary>
        [DataMember(Name = "birthCountry", EmitDefaultValue = false, Order = 11)]
        public string BirthCountry { get; set; }

        /// <summary>
        ///     Область рождения.
        /// </summary>
        [DataMember(Name = "birthRegion", EmitDefaultValue = false, Order = 12)]
        public string BirthRegion { get; set; }

        /// <summary>
        ///     Город рождения.
        /// </summary>
        [DataMember(Name = "birthTown", EmitDefaultValue = false, Order = 12)]
        public string BirthTown { get; set; }

        /// <summary>
        ///     Район рождения.
        /// </summary>
        [DataMember(Name = "birthDistrict", EmitDefaultValue = false, Order = 13)]
        public string BirthDistrict { get; set; }

        /// <summary>
        ///     Проживание.
        /// </summary>
        [DataMember(Name = "location", EmitDefaultValue = false, Order = 14)]
        public Location Location { get; set; }
        
        /// <summary>
        ///     Прописка.
        /// </summary>
        [DataMember(Name = "registration", EmitDefaultValue = false, Order = 15)]
        public Registration Registration { get; set; }

        /// <summary>
        ///     Признак смерти.
        /// </summary>
        [DataMember(Name = "died", EmitDefaultValue = false, Order = 16)]
        public bool? Died { get; set; }

        /// <summary>
        ///     Дата смерти.
        /// </summary>
        [DataMember(Name = "dieDate", EmitDefaultValue = false, Order = 17)]
        public DateTime? DieDate { get; set; }

        /// <summary>
        ///     Документы.
        /// </summary>
        [DataMember(Name = "documents", EmitDefaultValue = false, Order = 18)]
        public Document[] Documents { get; set; }
    }
}