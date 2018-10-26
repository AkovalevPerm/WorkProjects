namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    /// <summary>
    /// Льгота.
    /// </summary>
    [DataContract(Name = "benefit", Namespace = "")]
    public class Benefit : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Включение в социальный пакет.
        /// </summary>
        [DataMember(Name = "inSocialPackage", EmitDefaultValue = false, Order = 3)]
        public tBool InSocialPackage { get; set; }

        /// <summary>
        /// Код дохода.
        /// </summary>
        [DataMember(Name = "codeIncome", EmitDefaultValue = false, Order = 4)]
        public string CodeIncome { get; set; }

        /// <summary>
        /// Облагается НДФЛ.
        /// </summary>
        [DataMember(Name = "taxedNDFL", EmitDefaultValue = false, Order = 5)]
        public tBool TaxedNDFL { get; set; }

        /// <summary>
        /// Облагается ЕСН.
        /// </summary>
        [DataMember(Name = "taxedESN", EmitDefaultValue = false, Order = 6)]
        public tBool TaxedESN { get; set; }

        /// <summary>
        /// Иерархия льготы.
        /// </summary>
        [DataMember(Name = "parent", EmitDefaultValue = false, Order = 7)]
        public SyncXMLDataObject Parent { get; set; }

        /// <summary>
        /// Тип льготы.
        /// </summary>
        [DataMember(Name = "typeBenefit", EmitDefaultValue = false, Order = 8)]
        public SyncXMLDataObject TypeBenefit { get; set; }

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
