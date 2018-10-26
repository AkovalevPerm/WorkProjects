namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    /// <summary>
    /// Родственные отношения.
    /// </summary>
    [DataContract(Name = "familyRelation", Namespace = "")]
    public class FamilyRelation : SyncXMLDataObject
    {
        /// <summary>
        /// Идентификатор родственных отношений.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        [DataMember(Name = "gender", EmitDefaultValue = false, Order = 3)]
        public tGender Gender { get; set; }

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
