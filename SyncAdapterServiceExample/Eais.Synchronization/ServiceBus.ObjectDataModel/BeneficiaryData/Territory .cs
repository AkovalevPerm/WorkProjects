namespace ServiceBus.ObjectDataModel.BeneficiaryData
{
    using System;
    using System.Runtime.Serialization;
    using Common;
    using IIS.Synchronizer;

    /// <summary>
    ///     Территория.
    /// </summary>
    [DataContract(Name = "territory", Namespace = "")]
    public class Territory : SyncXMLDataObject
    {
        /// <summary>
        ///     Код ФИАС.
        /// </summary>
        [DataMember(Name = "FIAS", EmitDefaultValue = false, Order = 1)]
        public string FIAS { get; set; }

        /// <summary>
        ///     Вид объекта.
        /// </summary>
        [DataMember(Name = "objectType", EmitDefaultValue = false, Order = 2)]
        public string ObjectType { get; set; }

        /// <summary>
        ///     Наименование.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 3)]
        public string Name { get; set; }

        /// <summary>
        ///     Почтовый индекс.
        /// </summary>
        [DataMember(Name = "postIndex", EmitDefaultValue = false, Order = 4)]
        public string PostIndex { get; set; }

        /// <summary>
        ///     Родительская территория (иерархия).
        /// </summary>
        [DataMember(Name = "parent", EmitDefaultValue = false, Order = 5)]
        public Territory Parent { get; set; }
    }
}