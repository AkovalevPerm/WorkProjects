namespace ServiceBus.ObjectMessageModel
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml;
    using Common.Interfaces;
    using ICSSoft.STORMNET;
    using ObjectDataModel.Common;
    using Synchronization.Objects;
    using Synchronization.Utils;

    /// <summary>
    ///     Сообщение об изменениях справочника «Классификатор мер социальной защиты»(<see cref="CatalogDataDefinition" />).
    /// </summary>
    [DataContract(Name = NameForESB, Namespace = "")]
    public class ToMsrFromReestrMspCatalogDataChanges : IDataChangeMessageResponse<CatalogDataDefinition>
    {
        public const string NameForESB = "ToMSRfromReestrMSPCatalogDataChanges";

        /// <inheritdoc />
        [DataMember(Name = "RequestInfo", EmitDefaultValue = false, Order = 0)]
        public string RequestInfo { get; set; }

        //<inheritdoc />
        [DataMember(Name = "Items", EmitDefaultValue = false, Order = 1)]
        public List<CatalogDataDefinition> Items { get; set; }

        public bool Save(string senderName = null, string serializeData = null, bool throwException = false)
        {
            var resultOperation = true;
            var syncLogItemToSave = new SyncLogItem
            {
                Created = DateTime.Now,
                Direction = tSyncDirection.In,
                DataSet = string.IsNullOrEmpty(serializeData)
                    ? Serialize(throwException)
                    : serializeData,
                Description = NameForESB,
                Status = tSyncStatus.Prepared,
                DataSource = senderName
            };

            try
            {
                DataServiceFactory.SyncDataService.UpdateObject(syncLogItemToSave);
            }
            catch (Exception ex)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при попытке сохранить SyncLogItem для сообщения: {nameof(ToMsrFromReestrMspCatalogDataChanges)}. Ошибка - {ex.Message}");
                resultOperation = false;
            }

            return resultOperation;
        }

        public string Serialize(bool throwException = false)
        {
            var result = "";
            try
            {
                var xmlString = SerializationTools.SerializeDataContract(this);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);
                xmlDoc.DocumentElement?.SetAttribute("xmlns", "http://eais.com/kmsz.xsd");
                result = xmlDoc.OuterXml;
            }
            catch (Exception ex)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при попытке сериализовать сообщение: {nameof(ToMsrFromReestrMspCatalogDataChanges)}. Ошибка - {ex.Message}");
            }

            return result;
        }
    }
}