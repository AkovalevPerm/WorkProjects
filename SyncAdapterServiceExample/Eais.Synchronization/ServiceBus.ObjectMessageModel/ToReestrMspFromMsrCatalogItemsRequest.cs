namespace ServiceBus.ObjectMessageModel
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Runtime.Serialization;
    using System.Xml;
    using Common.Interfaces;
    using ICSSoft.STORMNET;
    using ObjectDataModel.Common;
    using Synchronization.Objects;
    using Synchronization.Utils;

    /// <summary>
    ///     Данные сообщения для шины типа "ToReestrMspFromMsrCatalogItemsRequest".
    /// </summary>
    [DataContract(Name = NameForESB, Namespace = "")]
    public class ToReestrMspFromMsrCatalogItemsRequest : ICommonMessage
    {
        public const string NameForESB = "ToReestrMSPfromMSRCatalogItemsRequest";

        /// <summary>
        ///     Условие выборки объектов.
        /// </summary>
        [DataMember(Name = "Criteria", EmitDefaultValue = false, Order = 1)]
        public CriteriaDefinition Criteria { get; set; }

        /// <summary>
        ///     Описание сортировки.
        /// </summary>
        [DataMember(Name = "Sorting", EmitDefaultValue = false, Order = 2)]
        public List<SortingDefinition> Sorting { get; set; }
        
        /// <summary>
        ///     Идентификатор справочника.
        /// </summary>
        [DataMember(Name = "RequestType", EmitDefaultValue = false, Order = 3)]
        public string Type { get; set; }
        
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
                    ChangesFrom = null,
                    ChangesTo = null,
                    Created = DateTime.Now,
                    DataSource = string.IsNullOrEmpty(senderName)
                        ? ConfigurationManager.AppSettings["AppName"]
                        : senderName,
                    DataSet = string.IsNullOrEmpty(serializeData)
                        ? Serialize(throwException)
                        : serializeData,
                    Description = NameForESB,
                    Direction = tSyncDirection.Out,
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
                    $"Произошла ошибка при попытке сохранить SyncLogItem для сообщения: {nameof(ToReestrMspFromMsrCatalogItemsRequest)}.");
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
                xmlDoc.DocumentElement?.SetAttribute("xmlns", "http://eais.com/requestitems.xsd");
                result = xmlDoc.OuterXml;
            }
            catch (Exception)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при сериализации для сообщения: {nameof(ToReestrMspFromMsrCatalogItemsRequest)}.");
            }

            return result;
        }
    }
}