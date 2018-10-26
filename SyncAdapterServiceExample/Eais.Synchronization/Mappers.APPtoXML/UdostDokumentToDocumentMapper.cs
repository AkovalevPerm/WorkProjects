namespace Mappers.APPtoXML
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Leechnost;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;

    public class UdostDokumentToDocumentMapper : AppToXMLMapper<UdostDokument, Document>
    {
        protected override View GetSourceView()
        {
            return UdostDokument.Views.UdostDokumentE;
        }

        protected override View[] GetSourceViews()
        {
            return new[] { GetSourceView(), Iis.Eais.Catalogs.VidUdostDok.Views.VidUdostDokEdit };
        }

        protected override Guid? GetSourceObjectPrimaryKey(UdostDokument source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Document Map(UdostDokument source, Document dest)
        {
            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            if (source.Seriia?.Length > 15)
            {
                throw new ArgumentException($"{nameof(dest.DocSeries)} не может быть больше 15 символов!");
            }
            dest.DocSeries = source.Seriia;
            if (source.Nomer?.Length > 15)
            {
                throw new ArgumentException($"{nameof(dest.DocNumber)} не может быть больше 15 символов!");
            }
            dest.DocNumber = source.Nomer;
            dest.DocIssueDate = source.DataVydachi?.Value;
            dest.DocEndDate = source.DataPrekrashcheniia?.Value;
            dest.OrgName = source.OrganVydDok;

            if (source.VidUdostDok != null)
            {
                dest.DocKind = PKHelper.GetGuidByObject(source.VidUdostDok).Value;
            }

            return dest;
        }
    }
}
