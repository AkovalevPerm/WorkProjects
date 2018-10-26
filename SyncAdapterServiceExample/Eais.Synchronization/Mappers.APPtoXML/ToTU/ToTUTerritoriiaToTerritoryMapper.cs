namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.ToTU;

    public class ToTUTerritoriiaToTerritoryMapper : AppToXMLMapper<Territoriia, Territory>
    {
        protected override Guid? GetSourceObjectPrimaryKey(Territoriia source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Territory Map(Territoriia source, Territory dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.FIAS = source.KodFIAS;
            dest.ObjectType = source.VidObekta;
            dest.Name = source.Naimenovanie;
            dest.PostIndex = source.PochtIndeks;

            if (source.Ierarhiia != null)
            {
                dest.Parent = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Ierarhiia).Value
                };
            }

            if (source.OrganSZ != null)
            {
                dest.SocialProtectionAuthority = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.OrganSZ).Value
                };
            }

            dest.CodeSPA = source.KodSZ;
            dest.CodeKLADR = source.KodCLADR;
            dest.CodeOKATO = source.KodOKATO;

            switch (source.GorRaion)
            {
                case tLogicheskii.Net:
                    dest.UrbanArea = tBool.Нет;
                    break;
                case tLogicheskii.Da:
                    dest.UrbanArea = tBool.Да;
                    break;
            }

            dest.RegionCodePF = source.KodRegionaPF;
            dest.CodeOKTMO = source.KodOKTMO;
            dest.CodeOPFR = source.KodOPFR;
            
            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }
    }
}
