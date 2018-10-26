namespace ServiceBus.ObjectDataModel.Common
{
    using System.Runtime.Serialization;
    using CatalogData;

    /// <summary>
    ///     Класс для передачи содержимого справочника «Классификатор мер социальной защиты».
    /// </summary>
    [DataContract(Name = "Item", Namespace = "")]
    public class CatalogItemDefinition
    {
        [DataMember(Name = "Classifier", EmitDefaultValue = false, Order = 0)]
        public Classifier Classifier { get; set; }
    }
}