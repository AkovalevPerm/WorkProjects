namespace ServiceBus.ObjectMessageModel
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml;
    using Common.Interfaces;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ObjectDataModel.FIAS;
    using Synchronization.Objects;
    using Synchronization.Utils;

    [DataContract(Name = NameForESB, Namespace = "")]
    public class ToMsrFromReestrMspFiasItemsResponse : ICommonMessage
    {
        public const string NameForESB = "ToMSRfromReestrMSPFiasItemsResponse";

        /// <summary>
        ///     Контейнер Item;
        /// </summary>
        [DataMember(Name = "Items", Order = 1)]
        public List<FiasItemsDataDefinition> Items { get; set; }

        //<inheritdoc />
        [DataMember(Name = "RequestInfo", Order = 0)]
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
                    RequestInfo = RequestInfo,
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
                    $"Произошла ошибка при попытке сохранить SyncLogItem для сообщения: {nameof(ToMsrFromReestrMspFiasItemsResponse)}.");
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
                xmlDoc.DocumentElement?.SetAttribute("xmlns", "http://eais.com/fiasitems.xsd");
                result = xmlDoc.OuterXml;
            }
            catch (Exception ex)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при попытке сериализовать сообщение: {nameof(ToMsrFromReestrMspFiasItemsResponse)}. Ошибка - {ex.Message}");
            }

            return result;
        }
    }
}