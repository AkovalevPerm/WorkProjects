namespace Mappers.APPtoXML
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class TipUdostDokToTypeDocumentMapper : AppToXMLMapper<TipUdostDok, TypeDocument>
    {
        protected override View GetSourceView()
        {
            return TipUdostDok.Views.TipUdostDokEdit;
        }

        protected override Guid? GetSourceObjectPrimaryKey(TipUdostDok source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override TypeDocument Map(TipUdostDok source, TypeDocument dest)
        {
            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            if (source.Naimenovanie?.Length > 80)
            {
                throw new ArgumentOutOfRangeException($"{nameof(source.Naimenovanie)} more than 80 symbols!");
            }
            dest.TypeDocName = source.Naimenovanie;
            return dest;
        }
    }
}
