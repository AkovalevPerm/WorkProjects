namespace ServiceBus.ObjectMessageModel
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using ICSSoft.STORMNET;

    using ServiceBus.ObjectDataModel.ToTU;
    using ServiceBus.ObjectMessageModel.Common.Interfaces;

    using Synchronization.Objects;
    using Synchronization.Utils;

    [DataContract(Name = NameForESB, Namespace = "")]
    public class ToTUFromMsrResponse : IDataChangeMessageResponse<ToTUChangeItem>
    {
        public const string NameForESB = "ToTUfromMsr";

        /// <inheritdoc />
        [DataMember(Name = "requestInfo", EmitDefaultValue = false, Order = 1)]
        public string RequestInfo { get; set; }

        /// <inheritdoc />
        [DataMember(Name = "ChangedItems", EmitDefaultValue = false, Order = 2)]
        public List<ToTUChangeItem> Items { get; set; }

        public bool Save(string senderName = null, string serializeData = "", bool throwException = false)
        {
            bool result = false;

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
                    Direction = tSyncDirection.Out,
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
                    $"Произошла ошибка при попытке сохранить SyncLogItem для сообщения: {nameof(ToTUFromMsrResponse)}.");
            }

            return result;
        }

        public string Serialize(bool throwException = false)
        {
            string result = "";

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
                    $"Произошла ошибка при попытке сериализовать сообщение: {nameof(ToTUFromMsrResponse)}. Ошибка - {ex.Message}");
            }

            return result;
        }
    }
}
