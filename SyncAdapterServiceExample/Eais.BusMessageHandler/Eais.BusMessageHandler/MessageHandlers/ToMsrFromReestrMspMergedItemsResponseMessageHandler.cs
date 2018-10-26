namespace BusMessageHandler.MessageHandlers
{
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using Iis.Eais.Leechnost;
    using ServiceBus.ObjectMessageModel;
    using Synchronization.Objects;
    using Synchronization.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class ToMsrFromReestrMspMergedItemsResponseMessageHandler: IMessageHandler
    {
        /// <summary>
        /// Обработать сообщение.
        /// </summary>
        /// <param name="message">Сообщение из шины.</param>
        public void HandleMessage(SyncLogItem logItem)
        {
            if (!string.IsNullOrEmpty(logItem.DataSet))
            {
                var ds = DataServiceProvider.DataService;
                List<DataObject> toUpdate = new List<DataObject>();
                var viewGruppa = new View {DefineClassType = typeof(GruppaDublei)};
                viewGruppa.AddProperties(
                    nameof(GruppaDublei.idReestrZapisi),
                    nameof(GruppaDublei.FullValue)
                    );
                var viewLichnost = new View { DefineClassType = typeof(Leechnost) };
                viewLichnost.AddProperty(nameof(Leechnost.GruppaDublei));

                var doc = new XmlDocument();
                doc.LoadXml(logItem.DataSet);

                var response = SerializationTools.DeserialiseDataContract<ToMsrFromReestrMspMergedItemsResponse>(logItem.DataSet);
                var i = 0;
                if (response?.Items == null)
                    return;
                foreach (var item in response.Items)
                {
                    var idReestrZapisi = item.Beneficiary.Guid.ToString();
                    var xml = doc.SelectNodes("//*[local-name() = 'Item']")[i].OuterXml;
                    var gruppa = ds.Query<GruppaDublei>(GruppaDublei.Views.AuditView).Where(x => x.idReestrZapisi == idReestrZapisi).FirstOrDefault();
                    if(gruppa == null)
                    {
                        gruppa = new GruppaDublei
                        {
                            idReestrZapisi = idReestrZapisi.ToString(),
                            FullValue = xml 
                        };
                    }
                    else
                    {
                        gruppa.FullValue = xml;
                    }
                    toUpdate.Add(gruppa);
                    var keys = item.Sources.Select(x => (object)x.Key).ToList();
                    var lichnosti = ds.Query<Leechnost>(viewLichnost).Where(x => keys.Contains(x.__PrimaryKey)).ToList();
                    lichnosti.ForEach(x => x.GruppaDublei = gruppa);
                    toUpdate.AddRange(lichnosti);
                    i++;
                }

                var objects = toUpdate.ToArray();

                ds.UpdateObjects(ref objects);
            }
        }

        /// <summary>
        /// Обработать событие.
        /// </summary>
        /// <param name="eventTypeId">Идентификатор типа события.</param>
        public void RiseEvent(string eventTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
