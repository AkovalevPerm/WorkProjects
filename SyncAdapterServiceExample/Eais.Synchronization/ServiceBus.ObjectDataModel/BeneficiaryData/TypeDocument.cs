namespace ServiceBus.ObjectDataModel.BeneficiaryData
{
    using System;
    using System.Runtime.Serialization;
    using Common;
    using IIS.Synchronizer;

    /// <summary>
    ///     Класс для описания типа удостоверяющего документа.
    /// </summary>
    [DataContract(Name = "typeDocument", Namespace = "")]
    public class TypeDocument : SyncXMLDataObject
    {
        /// <summary>
        ///     Наименование типа удостоверяющего документа.
        /// </summary>
        [DataMember(Name = "typeDocName", EmitDefaultValue = false, Order = 1)]
        public string TypeDocName { get; set; }
    }
}