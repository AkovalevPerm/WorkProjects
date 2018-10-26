namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUUlitcaToStreetMapper : AppToXMLMapper<Ulitca, Street>
    {
        protected override Guid? GetSourceObjectPrimaryKey(Ulitca source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Street Map(Ulitca source, Street dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.PostIndex = source.PochtIndeks;
            dest.CodeCLADR = source.KodCLADR;
            dest.Name = source.Naimenovanie;
            dest.CodeGR = (int)source.KodGR;
            dest.ObjectType = source.VidObekta;
            dest.CodeFIAS = source.KodFIAS;

            if (source.NovoeNazv != null)
            {
                dest.NewName = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.NovoeNazv).Value
                };
            }

            if (source.Territoriia != null)
            {
                dest.Territory = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Territoriia).Value
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
