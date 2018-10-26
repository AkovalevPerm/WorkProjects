namespace ServiceBus.ObjectDataModel.FromTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;

    /// <summary>
    /// Заявление на гос. услугу.
    /// </summary>
    [DataContract(Name = "zaiavlenieNaGosUslugu", Namespace = "")]
    public class ZaiavlenieNaGosUslugu : SyncXMLDataObject
    {
        public const string ConstDataVremia = "DataVremia";

        public const string ConstZaprosPortalaGosUsl = "ZaprosPortalaGosUsl";

        public const string ConstOtvetNaZapros = "OtvetNaZapros";

        public const string ConstSoobshchenieObOshibke = "SoobshchenieObOshibke";

        public const string ConstSoobshchenieObOshibkeShiny = "SoobshchenieObOshibkeShiny";

        public const string ConstDataVremiaZaprosa = "DataVremiaZaprosa";

        public const string ConstNomerZaprosa = "NomerZaprosa";

        public const string ConstIdentifikDannyeLeechnosti = "IdentifikDannyeLeechnosti";

        public const string ConstOtvetVSvobodnoiForme = "OtvetVSvobodnoiForme";

        public const string ConstDataIspolneniia = "DataIspolneniia";

        public const string ConstOriginalyDokPolucheny = "OriginalyDokPolucheny";

        public const string ConstZaprosPortalaGosUslParsed = "ZaprosPortalaGosUslParsed";

        public const string ConstGosUsluga = "GosUsluga";

        public const string ConstZaiavitel = "Zaiavitel";

        public const string ConstOpekaemyi = "Opekaemyi";

        public const string ConstIspolnitel = "Ispolnitel";

        public const string ConstOrganSZ = "OrganSZ";

        public const string ConstPrichinaOtkaza = "PrichinaOtkaza";

        public const string ConstRezultat = "Rezultat";

        /// <summary>
        /// Дата и время.
        /// </summary>
        [DataMember(Name = ConstDataVremia, IsRequired = true, Order = 1)]
        public DateTime DataVremia { get; set; }

        /// <summary>
        /// Запрос портала гос. услуг.
        /// </summary>
        [DataMember(Name = ConstZaprosPortalaGosUsl, EmitDefaultValue = false, Order = 2)]
        public string ZaprosPortalaGosUsl { get; set; }

        /// <summary>
        /// Ответ на запрос.
        /// </summary>
        [DataMember(Name = ConstOtvetNaZapros, EmitDefaultValue = false, Order = 3)]
        public string OtvetNaZapros { get; set; }

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        [DataMember(Name = ConstSoobshchenieObOshibke, EmitDefaultValue = false, Order = 4)]
        public string SoobshchenieObOshibke { get; set; }

        /// <summary>
        /// Сообщение об ошибке шины.
        /// </summary>
        [DataMember(Name = ConstSoobshchenieObOshibkeShiny, EmitDefaultValue = false, Order = 5)]
        public string SoobshchenieObOshibkeShiny { get; set; }

        /// <summary>
        /// Дата и время запроса.
        /// </summary>
        [DataMember(Name = ConstDataVremiaZaprosa, EmitDefaultValue = false, Order = 6)]
        public DateTime? DataVremiaZaprosa { get; set; }

        /// <summary>
        /// Номер запроса.
        /// </summary>
        [DataMember(Name = ConstNomerZaprosa, EmitDefaultValue = false, Order = 7)]
        public string NomerZaprosa { get; set; }

        /// <summary>
        /// Идентификационные данные.
        /// </summary>
        [DataMember(Name = ConstIdentifikDannyeLeechnosti, EmitDefaultValue = false, Order = 8)]
        public string IdentifikDannyeLeechnosti { get; set; }

        /// <summary>
        /// Ответ в свободной форме.
        /// </summary>
        [DataMember(Name = ConstOtvetVSvobodnoiForme, EmitDefaultValue = false, Order = 9)]
        public string OtvetVSvobodnoiForme { get; set; }

        /// <summary>
        /// Дата исполнения.
        /// </summary>
        [DataMember(Name = ConstDataIspolneniia, EmitDefaultValue = false, Order = 10)]
        public DateTime? DataIspolneniia { get; set; }

        /// <summary>
        /// Оригиналы документов получены.
        /// </summary>
        [DataMember(Name = ConstOriginalyDokPolucheny, IsRequired = true, Order = 11)]
        public tBool OriginalyDokPolucheny { get; set; }

        [DataMember(Name = ConstZaprosPortalaGosUslParsed, EmitDefaultValue = false, Order = 12)]
        public string ZaprosPortalaGosUslParsed { get; set; }

        /// <summary>
        /// Гос. услуга.
        /// </summary>
        [DataMember(Name = ConstGosUsluga, IsRequired = true, Order = 13)]
        public SyncXMLDataObject GosUsluga { get; set; }

        /// <summary>
        /// Заявитель.
        /// </summary>
        [DataMember(Name = ConstZaiavitel, EmitDefaultValue = false, Order = 14)]
        public SyncXMLDataObject Zaiavitel { get; set; }

        /// <summary>
        /// Опекаемый.
        /// </summary>
        [DataMember(Name = ConstOpekaemyi, EmitDefaultValue = false, Order = 15)]
        public SyncXMLDataObject Opekaemyi { get; set; }

        /// <summary>
        /// Исполнитель.
        /// </summary>
        [DataMember(Name = ConstIspolnitel, EmitDefaultValue = false, Order = 16)]
        public SyncXMLDataObject Ispolnitel { get; set; }

        /// <summary>
        /// Орган СЗ.
        /// </summary>
        [DataMember(Name = ConstOrganSZ, EmitDefaultValue = false, Order = 17)]
        public SyncXMLDataObject OrganSZ { get; set; }

        /// <summary>
        /// Причина отказа.
        /// </summary>
        [DataMember(Name = ConstPrichinaOtkaza, EmitDefaultValue = false, Order = 18)]
        public SyncXMLDataObject PrichinaOtkaza { get; set; }

        /// <summary>
        /// Результат.
        /// </summary>
        [DataMember(Name = ConstRezultat, EmitDefaultValue = false, Order = 19)]
        public SyncXMLDataObject Rezultat { get; set; }

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
