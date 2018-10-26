namespace Mappers.XMLtoAPP
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers.Generic;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class KindDocumentToVidUdostDokMapper : XMLToAppMapper<KindDocument, VidUdostDok>
    {
        protected override View GetDestinationView()
        {
            return VidUdostDok.Views.VidUdostDokEdit;
        }

        protected override Guid? GetSourceObjectPrimaryKey(KindDocument source)
        {
            return source.Guid;
        }

        public override VidUdostDok Map(KindDocument source, VidUdostDok dest)
        {
            dest.__PrimaryKey = source.Guid;
            dest.Naimenovanie = source.KindDocName;
            return dest;
        }
    }
}
