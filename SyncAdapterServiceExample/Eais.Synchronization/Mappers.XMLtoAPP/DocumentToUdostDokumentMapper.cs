namespace Mappers.XMLtoAPP
{
    using System;

    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.UserDataTypes;

    using Iis.Eais.Leechnost;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class DocumentToUdostDokumentMapper : XMLToAppMapper<Document, UdostDokument>
    {
        protected override View GetDestinationView()
        {
            return UdostDokument.Views.UdostDokumentE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Document source)
        {
            return source.Guid;
        }

        public override UdostDokument Map(Document source, UdostDokument dest)
        {
            dest.__PrimaryKey = source.Guid;
            dest.Seriia = source.DocSeries;
            dest.Nomer = source.DocNumber;
            dest.DataVydachi = (NullableDateTime)source.DocIssueDate.Value;
            dest.DataPrekrashcheniia = (NullableDateTime)source.DocEndDate.Value;
            dest.OrganVydDok = source.OrgName;
            dest.VidUdostDok = PKHelper.CreateDataObject<VidUdostDok>(source.DocKind);
            return dest;
        }
    }
}
