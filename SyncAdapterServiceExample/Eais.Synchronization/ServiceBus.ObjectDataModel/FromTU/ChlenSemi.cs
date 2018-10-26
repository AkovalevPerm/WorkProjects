namespace ServiceBus.ObjectDataModel.FromTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;

    /// <summary>
    /// Члень семьи.
    /// </summary>
    [DataContract(Name = "chlenSemi", Namespace = "")]
    public class ChlenSemi : SyncXMLDataObject
    {
        public const string ConstIdentifikDannyeLeechnosti = "IdentifikDannyeLeechnosti";

        public const string ConstShkolnik = "Shkolnik";

        public const string ConstZaiavlenie = "Zaiavlenie";

        public const string ConstLeechnost = "Leechnost";

        public const string ConstRodstvOtn = "RodstvOtn";

        /// <summary>
        /// Идентификационные данные личности.
        /// </summary>
        [DataMember(Name = ConstIdentifikDannyeLeechnosti, EmitDefaultValue = false, Order = 1)]
        public string IdentifikDannyeLeechnosti { get; set; }

        /// <summary>
        /// Школьник.
        /// </summary>
        [DataMember(Name = ConstShkolnik, EmitDefaultValue = false, Order = 2)]
        public tSchoolChild Shkolnik { get; set; }

        /// <summary>
        /// Заявление
        /// </summary>
        [DataMember(Name = ConstZaiavlenie, IsRequired = true, Order = 3)]
        public SyncXMLDataObject Zaiavlenie { get; set; }

        /// <summary>
        /// Личность.
        /// </summary>
        [DataMember(Name = ConstLeechnost, EmitDefaultValue = false, Order = 4)]
        public SyncXMLDataObject Leechnost { get; set; }

        /// <summary>
        /// Родственные отношения.
        /// </summary>
        [DataMember(Name = ConstRodstvOtn, EmitDefaultValue = false, Order = 5)]
        public SyncXMLDataObject RodstvOtn { get; set; }

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
