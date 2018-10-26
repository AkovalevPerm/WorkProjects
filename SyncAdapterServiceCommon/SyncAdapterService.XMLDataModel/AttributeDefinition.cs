using System.Runtime.Serialization;

namespace SyncAdapterService.XMLDataModel
{
    /// <summary>
    ///     Описание атрибута.
    /// </summary>
    [DataContract(Name = "Attribute", Namespace = "")]
    public class AttributeDefinition
    {
        public AttributeDefinition()
        {
        }

        public AttributeDefinition(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Наименование атрибута.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 0)]
        public string Name { get; set; }
    }
}