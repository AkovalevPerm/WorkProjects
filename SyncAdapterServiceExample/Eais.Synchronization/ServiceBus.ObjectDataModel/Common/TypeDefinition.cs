namespace ServiceBus.ObjectDataModel.Common
{
    using System.Runtime.Serialization;
    using Interfaces;

    /// <summary>
    ///     Описание типа.
    /// </summary>
    [DataContract(Name = "Type", Namespace = "")]
    public class TypeDefinition : IType
    {
        public TypeDefinition(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Наименование типа.
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 0)]
        public string Name { get; set; }
    }
}