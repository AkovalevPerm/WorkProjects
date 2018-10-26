namespace ServiceBus.ObjectDataModel.Common
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Описание типа.
    /// </summary>
    [DataContract(Name = "Source", Namespace = "")]
    public class SourceKeyDefinition
    {
        [DataMember(Name = "Key", IsRequired = true, Order = 0)]
        public Guid Key;
    }
}