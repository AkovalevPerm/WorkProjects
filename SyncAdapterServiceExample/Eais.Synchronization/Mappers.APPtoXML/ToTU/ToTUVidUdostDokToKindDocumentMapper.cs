namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUVidUdostDokToKindDocumentMapper : AppToXMLMapper<VidUdostDok, KindDocument>
    {
        protected override Guid? GetSourceObjectPrimaryKey(VidUdostDok source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override KindDocument Map(VidUdostDok source, KindDocument dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;
            dest.ShortName = source.KratkoeNaimenovanie;
            dest.CodePF = source.KodPF;
            dest.Priority = (int)source.Prioritet;
            dest.CodeKindDocument = source.KodVidaDokumenta;
            dest.PriorityFNS = (int)source.PrioritetDliaFNS;

            if (source.TipUdostDok != null)
            {
                dest.TypeDocument = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.TipUdostDok).Value
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
