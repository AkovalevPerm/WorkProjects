namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.ToTU;

    public class ToTUNormAktToLegalActMapper : AppToXMLMapper<NormAkt, LegalAct>
    {
        protected override Guid? GetSourceObjectPrimaryKey(NormAkt source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override LegalAct Map(NormAkt source, LegalAct dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;
            dest.Number = source.Nomer;

            if (source.DataPodpisaniia.HasValue)
            {
                dest.SignatureDate = source.DataPodpisaniia.Value;
            }

            dest.CodeReportFK = source.KodOtchFedKaznach;

            if (source.Tip != null)
            {
                dest.TypeLegalAct = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Tip).Value
                };
            }

            if (source.Izdatel != null)
            {
                dest.NamePublisher = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Izdatel).Value
                };
            }

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }
    }
}
