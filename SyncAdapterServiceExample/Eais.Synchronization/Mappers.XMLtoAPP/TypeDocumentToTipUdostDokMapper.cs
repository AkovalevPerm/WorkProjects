namespace Mappers.XMLtoAPP
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using ServiceBus.ObjectDataModel.BeneficiaryData;

    public class TypeDocumentToTipUdostDokMapper : XMLToAppMapper<TypeDocument, TipUdostDok>
    {
        protected override View GetDestinationView()
        {
            return TipUdostDok.Views.TipUdostDokEdit;
        }

        protected override Guid? GetSourceObjectPrimaryKey(TypeDocument source)
        {
            return source.Guid;
        }

        public override TipUdostDok Map(TypeDocument source, TipUdostDok dest)
        {
            dest.__PrimaryKey = source.Guid;
            dest.Naimenovanie = source.TypeDocName;
            return dest;
        }
    }
}
