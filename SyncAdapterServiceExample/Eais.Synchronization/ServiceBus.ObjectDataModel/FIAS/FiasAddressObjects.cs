namespace ServiceBus.ObjectDataModel.FIAS
{
    using System;
    using System.Runtime.Serialization;
    using Common.Attribute;

    /// <summary>
    ///     Класс для описания cведений по отдельным зданиям, сооружениям.
    /// </summary>
    [AliasType("1438")]
    [DataContract(Name = "fiasAddressObjects", Namespace = "")]
    public class FiasAddressObjects
    {
        /// <summary>
        ///     Глобальный уникальный идентификатор адресного объекта .
        /// </summary>
        [DataMember(Name = "AOGUID", IsRequired = true, Order = 0)]
        public string AOGUID { get; set; }

        /// <summary>
        ///     Формализованное наименование.
        /// </summary>
        [DataMember(Name = "FORMALNAME", IsRequired = true, Order = 1)]
        public string FORMALNAME { get; set; }

        /// <summary>
        ///     Код региона.
        /// </summary>
        [DataMember(Name = "REGIONCODE", IsRequired = true, Order = 2)]
        public string REGIONCODE { get; set; }

        /// <summary>
        ///     Код автономии.
        /// </summary>
        [DataMember(Name = "AUTOCODE", IsRequired = true, Order = 3)]
        public string AUTOCODE { get; set; }

        /// <summary>
        ///     Код района.
        /// </summary>
        [DataMember(Name = "AREACODE", IsRequired = true, Order = 4)]
        public string AREACODE { get; set; }

        /// <summary>
        ///     Код города.
        /// </summary>
        [DataMember(Name = "CITYCODE", IsRequired = true, Order = 5)]
        public string CITYCODE { get; set; }

        /// <summary>
        ///     Код внутригородского района.
        /// </summary>
        [DataMember(Name = "CTARCODE", IsRequired = true, Order = 6)]
        public string CTARCODE { get; set; }

        /// <summary>
        ///     Код населенного пункта.
        /// </summary>
        [DataMember(Name = "PLACECODE", IsRequired = true, Order = 7)]
        public string PLACECODE { get; set; }

        /// <summary>
        ///     Код элемента планировочной структуры.
        /// </summary>
        [DataMember(Name = "PLANCODE", IsRequired = true, Order = 8)]
        public string PLANCODE { get; set; }

        /// <summary>
        ///     Код улицы.
        /// </summary>
        [DataMember(Name = "STREETCODE", EmitDefaultValue = false, Order = 9)]
        public string STREETCODE { get; set; }

        /// <summary>
        ///     Код дополнительного адресообразующего элемента.
        /// </summary>
        [DataMember(Name = "EXTRCODE", IsRequired = true, Order = 10)]
        public string EXTRCODE { get; set; }

        /// <summary>
        ///     Код подчиненного дополнительного адресообразующего элемента.
        /// </summary>
        [DataMember(Name = "SEXTCODE", IsRequired = true, Order = 11)]
        public string SEXTCODE { get; set; }

        /// <summary>
        ///     Официальное наименование.
        /// </summary>
        [DataMember(Name = "OFFNAME", EmitDefaultValue = false, Order = 12)]
        public string OFFNAME { get; set; }

        /// <summary>
        ///     Почтовый индекс.
        /// </summary>
        [DataMember(Name = "POSTALCODE", EmitDefaultValue = false, Order = 13)]
        public string POSTALCODE { get; set; }

        /// <summary>
        ///     Код ИФНС ФЛ.
        /// </summary>
        [DataMember(Name = "IFNSFL", EmitDefaultValue = false, Order = 14)]
        public string IFNSFL { get; set; }

        /// <summary>
        ///     Код территориального участка ИФНС ФЛ.
        /// </summary>
        [DataMember(Name = "TERRIFNSFL", EmitDefaultValue = false, Order = 15)]
        public string TERRIFNSFL { get; set; }

        /// <summary>
        ///     Код ИФНС ЮЛ.
        /// </summary>
        [DataMember(Name = "IFNSUL", EmitDefaultValue = false, Order = 16)]
        public string IFNSUL { get; set; }

        /// <summary>
        ///     Код территориального участка ИФНС ЮЛ.
        /// </summary>
        [DataMember(Name = "TERRIFNSUL", EmitDefaultValue = false, Order = 17)]
        public string TERRIFNSUL { get; set; }

        /// <summary>
        ///     OKATO.
        /// </summary>
        [DataMember(Name = "OKATO", EmitDefaultValue = false, Order = 18)]
        public string OKATO { get; set; }

        /// <summary>
        ///     OKTMO.
        /// </summary>
        [DataMember(Name = "OKTMO", EmitDefaultValue = false, Order = 19)]
        public string OKTMO { get; set; }

        /// <summary>
        ///     Дата  внесения (обновления) записи.
        /// </summary>
        [DataMember(Name = "UPDATEDATE", IsRequired = true, EmitDefaultValue = false, Order = 20)]
        public string strUPDATEDATE
        {
            get { return UPDATEDATE.ToString("yyyy-MM-dd"); }
            set { UPDATEDATE = DateTime.Parse(value); }
        }

        public DateTime UPDATEDATE { get; set; }

        /// <summary>
        ///     Краткое наименование типа объекта.
        /// </summary>
        [DataMember(Name = "SHORTNAME", IsRequired = true, Order = 21)]
        public string SHORTNAME { get; set; }

        /// <summary>
        ///     Уровень адресного объекта.
        /// </summary>
        [DataMember(Name = "AOLEVEL", IsRequired = true, Order = 22)]
        public int AOLEVEL { get; set; }

        /// <summary>
        ///     Идентификатор объекта родительского объекта.
        /// </summary>
        [DataMember(Name = "PARENTGUID", EmitDefaultValue = false, Order = 23)]
        public string PARENTGUID { get; set; }

        /// <summary>
        ///     Уникальный идентификатор записи. Ключевое поле.
        /// </summary>
        [DataMember(Name = "AOID", IsRequired = true, Order = 24)]
        public string AOID { get; set; }

        /// <summary>
        ///     Идентификатор записи связывания с предыдушей исторической записью.
        /// </summary>
        [DataMember(Name = "PREVID", EmitDefaultValue = false, Order = 25)]
        public string PREVID { get; set; }

        /// <summary>
        ///     Идентификатор записи  связывания с последующей исторической записью.
        /// </summary>
        [DataMember(Name = "NEXTID", EmitDefaultValue = false, Order = 26)]
        public string NEXTID { get; set; }

        /// <summary>
        ///     Код адресного элемента одной строкой с признаком актуальности из классификационного кода.
        /// </summary>
        [DataMember(Name = "CODE", EmitDefaultValue = false, Order = 27)]
        public string CODE { get; set; }

        /// <summary>
        ///     Код адресного элемента одной строкой без признака актуальности (последних двух цифр).
        /// </summary>
        [DataMember(Name = "PLAINCODE", EmitDefaultValue = false, Order = 28)]
        public string PLAINCODE { get; set; }

        /// <summary>
        ///     Статус последней исторической записи в жизненном цикле адресного.
        /// </summary>
        [DataMember(Name = "ACTSTATUS", IsRequired = true, Order = 29)]
        public int ACTSTATUS { get; set; }

        /// <summary>
        ///     Статус актуальности адресного объекта ФИАС на текущую дату.
        /// </summary>
        [DataMember(Name = "LIVESTATUS", IsRequired = true, Order = 30)]
        public int LIVESTATUS { get; set; }

        /// <summary>
        ///     Статус центра.
        /// </summary>
        [DataMember(Name = "CENTSTATUS", IsRequired = true, Order = 31)]
        public int CENTSTATUS { get; set; }

        /// <summary>
        ///     Статус действия над записью – причина появления записи.
        /// </summary>
        [DataMember(Name = "OPERSTATUS", IsRequired = true, Order = 32)]
        public int OPERSTATUS { get; set; }

        /// <summary>
        ///     Статус актуальности КЛАДР 4.
        /// </summary>
        [DataMember(Name = "CURRSTATUS", IsRequired = true, Order = 33)]
        public int CURRSTATUS { get; set; }

        /// <summary>
        ///     Начало действия записи.
        /// </summary>
        [DataMember(Name = "STARTDATE", IsRequired = true, EmitDefaultValue = false, Order = 34)]
        public string strSTARTDATE
        {
            get { return STARTDATE.ToString("yyyy-MM-dd"); }
            set { STARTDATE = DateTime.Parse(value); }
        }

        public DateTime STARTDATE { get; set; }

        /// <summary>
        ///     Окончание действия записи.
        /// </summary>
        [DataMember(Name = "ENDDATE", IsRequired = true, EmitDefaultValue = false, Order = 35)]
        public string strENDDATE
        {
            get { return ENDDATE.ToString("yyyy-MM-dd"); }
            set { ENDDATE = DateTime.Parse(value); }
        }

        public DateTime ENDDATE { get; set; }

        /// <summary>
        ///     Внешний ключ на нормативный документ.
        /// </summary>
        [DataMember(Name = "NORMDOC", IsRequired = true, Order = 36)]
        public string NORMDOC { get; set; }

        /// <summary>
        ///     Кадастровый номер.
        /// </summary>
        [DataMember(Name = "CADNUM", IsRequired = true, Order = 37)]
        public string CADNUM { get; set; }

        /// <summary>
        ///     Тип деления.
        /// </summary>
        [DataMember(Name = "DIVTYPE", IsRequired = true, Order = 38)]
        public int DIVTYPE { get; set; }
    }
}