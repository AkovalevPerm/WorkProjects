namespace ServiceBus.ObjectMessageModel
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Common.Interfaces;
    using ICSSoft.STORMNET;
    using ObjectDataModel.FromTU;
    using Synchronization.Objects;
    using Synchronization.Utils;

    [DataContract(Name = NameForESB, Namespace = "")]
    public class ToMsrFromTUResponse : IDataChangeMessageResponse<ChangedItem>
    {
        public const string NameForESB = "ToMSRfromTU";

        //<inheritdoc />
        [DataMember(Name = "RequestInfo", EmitDefaultValue = false, Order = 1)]
        public string RequestInfo { get; set; }

        //<inheritdoc />
        [DataMember(Name = "Items", EmitDefaultValue = false, Order = 2)]
        public List<ChangedItem> Items { get; set; }

        public bool Save(string senderName = null, string serializeData = null, bool throwException = false)
        {
            var result = false;

            try
            {
                var sli = new SyncLogItem
                {
                    Created = DateTime.Now,
                    ChangesFrom = Items[0].ChangeDate,
                    ChangesTo = Items[Items.Count - 1].ChangeDate,
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
                    $"Произошла ошибка при попытке сохранить SyncLogItem для сообщения: {nameof(ToMsrFromTUResponse)}.");
            }

            return result;
        }

        public string Serialize(bool throwException = false)
        {
            var result = "";
            try
            {
                result = SerializationTools.SerializeDataContract(this);
            }
            catch (Exception ex)
            {
                if (throwException)
                {
                    throw;
                }

                LogService.LogError(
                    $"Произошла ошибка при попытке сериализовать сообщение: {nameof(ToMsrFromTUResponse)}. Ошибка - {ex.Message}");
            }

            return result;
        }
    }
}