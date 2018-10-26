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
    ///     Данные сообщения для шины типа "ToMsrFromReestrMspMergedItemsResponse".
    /// </summary>
    [DataContract(Name = NameForESB, Namespace = "")]
    public class ToMsrFromReestrMspMergedItemsResponse : ICommonMessage
    {
        public const string NameForESB = "ToMSRfromReestrMSPMergedItems";

        /// <summary>
        ///     Контейнер Item;
        /// </summary>
        [DataMember(Name = "Items", EmitDefaultValue = false, Order = 1)]
        public List<MergeItemDefinition> Items { get; set; }

        //<inheritdoc />
        [DataMember(Name = "RequestInfo", EmitDefaultValue = false, Order = 0)]
        public string RequestInfo { get; set; }

        public bool Save(string senderName = null, string serializeData = null, bool throwException = false)
        {
            var result = false;

            try
            {
                var sli = new SyncLogItem
                {
                    Created = DateTime.Now,
                    ChangesFrom = null,
                    ChangesTo = null,
                    DataSet = string.IsNullOrEmpty(serializeData)
                        ? Serialize(throwException)
                        : serializeData,
                    DataSource = senderName,
                    Description = NameForESB,
                    Direction = tSyncDirection.In,
                    Processed = null,
                    RequestInfo = null,
                    ResultInfo = null,
                    Status = tSyncStatus.Prepared
                };

                DataServiceFactory.SyncDataService.UpdateObject(sli);
                result = true;
            }
            catch (Exception)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при попытке сохранить SyncLogItem для сообщения: {nameof(ToMsrFromReestrMspMergedItemsResponse)}.");
            }

            return result;
        }

        public string Serialize(bool throwException = false)
        {
            var result = "";
            try
            {
                var xmlString = SerializationTools.SerializeDataContract(this);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);
                xmlDoc.DocumentElement?.SetAttribute("xmlns", "http://eais.com/mergeditems.xsd");
                result = xmlDoc.OuterXml;
            }
            catch (Exception ex)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при попытке сериализовать сообщение: {nameof(ToMsrFromReestrMspMergedItemsResponse)}. Ошибка - {ex.Message}");
            }

            return result;
        }
    }
}