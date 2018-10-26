namespace ServiceBus.ObjectMessageModel
{
    using Common.Attribute;
    using Common.Interfaces;

    using ICSSoft.STORMNET;

    using ObjectDataModel.Common;

    using Synchronization.Objects;
    using Synchronization.Utils;
    using Synchronization.Utils.CustomException;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;



    /// <summary>
    ///     Данные сообщения для шины типа "ToReestrMspFromMsrDataChanges".
    /// </summary>
    [PackageSize(1)]
    [SendChangedField(false)]
    [DataContract(Name = NameForESB, Namespace = "")]
    public class ToReestrMspFromMsrDataChanges : IDataChangeMessageResponse<DataChangesDefinition>
    {
        public const string NameForESB = "ToReestrMSPfromMSRDataChanges";

        //<inheritdoc />
        [DataMember(Name = "RequestInfo", EmitDefaultValue = false, Order = 1)]
        public string RequestInfo { get; set; }

        //<inheritdoc />
        [DataMember(Name = "Items", EmitDefaultValue = false, Order = 2)]
        public List<DataChangesDefinition> Items { get; set; }

        public bool Save(string senderName = null, string serializeData = null, bool throwException = false)
        {
            var result = false;

            try
            {
                var sli = new SyncLogItem
                {
                    Created = DateTime.Now,
                    ChangesFrom = Items.FirstOrDefault()?.ChangeDate,
                    ChangesTo = Items.LastOrDefault()?.ChangeDate,
                    DataSet = string.IsNullOrEmpty(serializeData)
                        ? Serialize(throwException)
                        : serializeData,
                    DataSource = string.IsNullOrEmpty(senderName)
                        ? ConfigurationManager.AppSettings["AppName"]
                        : senderName,
                    Description = NameForESB,
                    Direction = tSyncDirection.Out,
                    Processed = null,
                    RequestInfo = null,
                    ResultInfo = null,
                    Status = tSyncStatus.Prepared
                };

                DataServiceFactory.SyncDataService.UpdateObject(sli);
                LogService.LogInfo(
                    $"Успешно сформировано синхронизационное сообщения типа {NameForESB}(pk-{sli.__PrimaryKey}) в него включено {Items.Count} изменений{Helper.GetDatePartAsString(sli.ChangesFrom, sli.ChangesTo)}");
                result = true;
            }
            catch (Exception)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при попытке сохранить SyncLogItem для сообщения: {nameof(ToReestrMspFromMsrDataChanges)}.");
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
                xmlDoc.DocumentElement?.SetAttribute("xmlns", "http://eais.com/beneficiary.xsd");
                result = xmlDoc.OuterXml;
            }

            catch (Exception ex)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при попытке сериализовать сообщение {NameForESB}. Ошибка - {ex.Message}");
            }

            return result;
        }
    }
}