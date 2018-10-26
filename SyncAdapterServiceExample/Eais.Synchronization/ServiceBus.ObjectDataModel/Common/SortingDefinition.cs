namespace ServiceBus.ObjectDataModel.Common
{
    using System.Runtime.Serialization;

    /// <summary>
    ///     Класс для описания сортировки по одному полю.
    /// </summary>
    [DataContract(Name = "Sort", Namespace = "")]
    public class SortingDefinition
    {
        /// <summary>
        ///     Имя поля для сортировки.
        /// </summary>
        [DataMember(Name = "Attribute", IsRequired = true)]
        public string TehName { get; set; }

        /// <summary>
        ///     Приоритет сортировки по данному полю.
        /// </summary>
        [DataMember(Name = "SortOrder", EmitDefaultValue = false)]
        public int SortOrder { get; set; }

        /// <summary>
        ///     Тип сортировки. Возможные значения: "Asc", "Desc".
        /// </summary>
        [DataMember(Name = "SortType", EmitDefaultValue = false)]
        public string SortType { get; set; }
    }
}