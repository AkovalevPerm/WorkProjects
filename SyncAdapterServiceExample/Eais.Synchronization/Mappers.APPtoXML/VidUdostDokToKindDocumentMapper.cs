namespace Mappers.APPtoXML
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class VidUdostDokToKindDocumentMapper : AppToXMLMapper<VidUdostDok, KindDocument>
    {
        protected override View GetSourceView()
        {
            return VidUdostDok.Views.VidUdostDokEdit;
        }

        protected override Guid? GetSourceObjectPrimaryKey(VidUdostDok source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override KindDocument Map(VidUdostDok source, KindDocument dest)
        {
            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            if (source.Naimenovanie?.Length > 80)
            {
                throw new ArgumentOutOfRangeException($"{nameof(source.Naimenovanie)} more than 80 symbols!");
            }
            dest.KindDocName = source.Naimenovanie;
            return dest;
        }
    }
}
