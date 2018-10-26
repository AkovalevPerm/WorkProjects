namespace ServiceBus.ObjectDataModel.BeneficiaryData
{
    using System;
    using System.Runtime.Serialization;
    using Common;
    using IIS.Synchronizer;

    /// <summary>
    ///     Вид удостоверяющего документа.
    /// </summary>
    [DataContract(Name = "kindDocument", Namespace = "")]
    public class KindDocument : SyncXMLDataObject
    {
        /// <summary>
        ///     Наименование вида удостоверяющего документа.
        /// </summary>
        [DataMember(Name = "kindDocName", EmitDefaultValue = false, Order = 1)]
        public string KindDocName { get; set; }

        /// <summary>
        ///     Тип документа.
        /// </summary>
        [DataMember(Name = "typeDoc", EmitDefaultValue = false, Order = 2)]
        public TypeDocument TypeDoc { get; set; }
    }
}