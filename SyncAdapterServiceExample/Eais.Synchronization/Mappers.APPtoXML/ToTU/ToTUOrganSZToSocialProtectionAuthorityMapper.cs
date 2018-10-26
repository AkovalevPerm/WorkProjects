namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.ToTU;

    public class ToTUOrganSZToSocialProtectionAuthorityMapper : AppToXMLMapper<OrganSZ, SocialProtectionAuthority>
    {
        protected override Guid? GetSourceObjectPrimaryKey(OrganSZ source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override SocialProtectionAuthority Map(OrganSZ source, SocialProtectionAuthority dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;
            dest.Address = source.Adres;
            dest.Phone = source.Telefon;
            dest.Code = (int)source.Kod;
            dest.ShortName = source.KratkNaim;
            dest.CodePF = source.KodPF;
            dest.FullName = source.PolnoeNaimenovanie;
            dest.CodeSB = source.KodDliaSB;
            dest.DistrictCoefficient = (int)source.RaionKoef;
            dest.SONOCodeFNS = source.KodFNSpoSONO;
            dest.INN = source.INN;
            dest.KPP = source.KPP;

            switch (source.UchetPoFilialuBezOtdelnPoOSZ)
            {
                case tLogicheskii.Net:
                    dest.BranchAccouningWithoutSeparateSPA = tBool.Нет;
                    break;
                case tLogicheskii.Da:
                    dest.BranchAccouningWithoutSeparateSPA = tBool.Да;
                    break;
            }

            dest.CodeOKPO = source.KodOKPO;
            dest.CodeOKTMO = source.KodOKTMO;
            dest.TerritorialAuthorityFT = source.TerOrganFedKaznach;
            dest.CodeTerritorialAuthorityFT = source.KodTerOrganaFedKaznach;
            dest.CodeBP = source.KodBP;
            dest.NameTU = source.NaimTU;
            dest.CodeTU = source.KodTU;
            dest.ConnectionString = source.StrokaPodcliucheniia;

            if (source.ObedinennyiOrganSZ)
            {
                dest.UnitedSPA = tBool.Да;
            }
            else
            {
                dest.UnitedSPA = tBool.Нет;
            }

            dest.OGRN = source.OGRN;
            dest.RegNumberPF = source.RegNomerPF;
            dest.CodeTerAuthorityPF = source.KodTerOrganaPF;
            dest.NameTerAuthorityPF = source.NaimTerOrganaPF;

            if (source.Ierarhiia != null)
            {
                dest.Parent = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Ierarhiia).Value
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
