namespace ServiceBus.ObjectDataModel.FIAS
{
    using System;
    using System.Runtime.Serialization;
    using Common.Attribute;

    /// <summary>
    ///     Класс для описания cведений по отдельным зданиям, сооружениям.
    /// </summary>
    [AliasType("1472")]
    [DataContract(Name = "fiasHousesStructures", Namespace = "")]
    public class FiasHousesStructures
    {
        /// <summary>
        ///     Почтовый индекс.
        /// </summary>
        [DataMember(Name = "POSTALCODE", EmitDefaultValue = false, Order = 0)]
        public string POSTALCODE { get; set; }

        /// <summary>
        ///     Код региона.
        /// </summary>
        [DataMember(Name = "REGIONCODE", EmitDefaultValue = false, Order = 1)]
        public string REGIONCODE { get; set; }

        /// <summary>
        ///     Код ИФНС ФЛ.
        /// </summary>
        [DataMember(Name = "IFNSFL", EmitDefaultValue = false, Order = 2)]
        public string IFNSFL { get; set; }

        /// <summary>
        ///     Код территориального участка ИФНС ФЛ.
        /// </summary>
        [DataMember(Name = "TERRIFNSFL", EmitDefaultValue = false, Order = 3)]
        public string TERRIFNSFL { get; set; }

        /// <summary>
        ///     Код ИФНС ЮЛ.
        /// </summary>
        [DataMember(Name = "IFNSUL", EmitDefaultValue = false, Order = 4)]
        public string IFNSUL { get; set; }

        /// <summary>
        ///     Код территориального участка ИФНС ЮЛ.
        /// </summary>
        [DataMember(Name = "TERRIFNSUL", EmitDefaultValue = false, Order = 5)]
        public string TERRIFNSUL { get; set; }

        /// <summary>
        ///     OKATO.
        /// </summary>
        [DataMember(Name = "OKATO", EmitDefaultValue = false, Order = 6)]
        public string OKATO { get; set; }

        /// <summary>
        ///     OKTMO.
        /// </summary>
        [DataMember(Name = "OKTMO", EmitDefaultValue = false, Order = 7)]
        public string OKTMO { get; set; }

        /// <summary>
        ///     Дата время внесения (обновления) записи.
        /// </summary>
        [DataMember(Name = "UPDATEDATE", IsRequired = true, EmitDefaultValue = false, Order = 8)]
        public string strUPDATEDATE
        {
            get { return UPDATEDATE.ToString("yyyy-MM-dd"); }
            set { UPDATEDATE = DateTime.Parse(value); }
        }

        public DateTime UPDATEDATE { get; set; }

        /// <summary>
        ///     Номер дома.
        /// </summary>
        [DataMember(Name = "HOUSENUM", EmitDefaultValue = false, Order = 9)]
        public string HOUSENUM { get; set; }

        /// <summary>
        ///     Признак владения.
        /// </summary>
        [DataMember(Name = "ESTSTATUS", IsRequired = true, Order = 10)]
        public int ESTSTATUS { get; set; }

        /// <summary>
        ///     Номер корпуса.
        /// </summary>
        [DataMember(Name = "BUILDNUM", EmitDefaultValue = false, Order = 11)]
        public string BUILDNUM { get; set; }

        /// <summary>
        ///     Номер строения.
        /// </summary>
        [DataMember(Name = "STRUCNUM", EmitDefaultValue = false, Order = 12)]
        public string STRUCNUM { get; set; }

        /// <summary>
        ///     Признак строения.
        /// </summary>
        [DataMember(Name = "STRSTATUS", EmitDefaultValue = false, Order = 13)]
        public int? STRSTATUS { get; set; }

        /// <summary>
        ///     Уникальный идентификатор записи дома.
        /// </summary>
        [DataMember(Name = "HOUSEID", IsRequired = true, Order = 14)]
        public string HOUSEID { get; set; }

        /// <summary>
        ///     Глобальный уникальный идентификатор дома.
        /// </summary>
        [DataMember(Name = "HOUSEGUID", IsRequired = true, Order = 15)]
        public string HOUSEGUID { get; set; }

        /// <summary>
        ///     Guid записи родительского объекта (улицы, города, населенного пункта и т.п.).
        /// </summary>
        [DataMember(Name = "AOGUID", IsRequired = true, Order = 16)]
        public string AOGUID { get; set; }

        /// <summary>
        ///     Начало действия записи.
        /// </summary>
        [DataMember(Name = "STARTDATE", IsRequired = true, EmitDefaultValue = false, Order = 17)]
        public string strSTARTDATE
        {
            get { return STARTDATE.ToString("yyyy-MM-dd"); }
            set { STARTDATE = DateTime.Parse(value); }
        }

        public DateTime STARTDATE { get; set; }

        /// <summary>
        ///     Окончание действия записи.
        /// </summary>
        [DataMember(Name = "ENDDATE", IsRequired = true, EmitDefaultValue = false, Order = 18)]
        public string strENDDATE
        {
            get { return ENDDATE.ToString("yyyy-MM-dd"); }
            set { ENDDATE = DateTime.Parse(value); }
        }

        public DateTime ENDDATE { get; set; }

        /// <summary>
        ///     Состояние дома.
        /// </summary>
        [DataMember(Name = "STATSTATUS", IsRequired = true, Order = 19)]
        public int STATSTATUS { get; set; }

        /// <summary>
        ///     Внешний ключ на нормативный документ.
        /// </summary>
        [DataMember(Name = "NORMDOC", EmitDefaultValue = false, Order = 20)]
        public string NORMDOC { get; set; }

        /// <summary>
        ///     Счетчик записей зданий, сооружений для формирования классификационного кода.
        /// </summary>
        [DataMember(Name = "COUNTER", IsRequired = true, Order = 21)]
        public int COUNTER { get; set; }

        /// <summary>
        ///     Кадастровый номер.
        /// </summary>
        [DataMember(Name = "CADNUM", EmitDefaultValue = false, Order = 22)]
        public string CADNUM { get; set; }

        /// <summary>
        ///     Тип деления.
        /// </summary>
        [DataMember(Name = "DIVTYPE", IsRequired = true, Order = 23)]
        public int DIVTYPE { get; set; }
    }
}