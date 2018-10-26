namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;

    /// <summary>
    /// Страна.
    /// </summary>
    [DataContract(Name = "country", Namespace = "")]
    public class Country : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор страны.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Полное наименование.
        /// </summary>
        [DataMember(Name = "fullName", EmitDefaultValue = false, Order = 2)]
        public string FullName { get; set; }

        /// <summary>
        /// Краткое наименование.
        /// </summary>
        [DataMember(Name = "shortName", IsRequired = true, Order = 3)]
        public string ShortName { get; set; }

        /// <summary>
        /// Цифровой код.
        /// </summary>
        [DataMember(Name = "numericCode", EmitDefaultValue = false, Order = 4)]
        public int NumericCode { get; set; }

        /// <summary>
        /// Буквенный код альфа 2.
        /// </summary>
        [DataMember(Name = "codeAlpha2", EmitDefaultValue = false, Order = 5)]
        public string CodeAlpha2 { get; set; }

        /// <summary>
        /// Буквенный код альфа 3.
        /// </summary>
        [DataMember(Name = "codeAlpha3", EmitDefaultValue = false, Order = 6)]
        public string CodeAlpha3 { get; set; }

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
