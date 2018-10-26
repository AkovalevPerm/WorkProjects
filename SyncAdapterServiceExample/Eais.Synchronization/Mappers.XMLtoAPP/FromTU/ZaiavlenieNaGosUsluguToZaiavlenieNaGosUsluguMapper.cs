namespace Mappers.XMLtoAPP.FromTU
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;

    using Iis.Eais.GosUslugi;

    using IIS.University.Tools;

    using Mappers.Common;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    using Synchronization.Objects;

    using ZaiavlenieNaGosUslugu = ServiceBus.ObjectDataModel.FromTU.ZaiavlenieNaGosUslugu;

    public class ZaiavlenieNaGosUsluguToZaiavlenieNaGosUsluguMapper : XmlToAppWithChangedAttrsMapper<ZaiavlenieNaGosUslugu, Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu>
    {
        protected override Guid? GetSourceObjectPrimaryKey(ZaiavlenieNaGosUslugu dest)
        {
            return dest?.Guid;
        }

        public override Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu Map(ZaiavlenieNaGosUslugu source, Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.DataVremia = source.DataVremia;
            dest.ZaprosPortalaGosUsl = source.ZaprosPortalaGosUsl;
            dest.OtvetNaZapros = source.OtvetNaZapros;
            dest.SoobshchenieObOshibke = source.SoobshchenieObOshibke;
            dest.SoobshchenieObOshibkeShiny = source.SoobshchenieObOshibkeShiny;
            dest.DataVremiaZaprosa = source.DataVremiaZaprosa;
            dest.NomerZaprosa = source.NomerZaprosa;
            dest.IdentifikDannyeLeechnosti = source.IdentifikDannyeLeechnosti;
            dest.OtvetVSvobodnoiForme = source.OtvetVSvobodnoiForme;
            dest.DataIspolneniia = source.DataIspolneniia;

            switch (source.OriginalyDokPolucheny)
            {
                case tBool.Да:
                    dest.OriginalyDokPolucheny = true;
                    break;
                case tBool.Нет:
                    dest.OriginalyDokPolucheny = false;
                    break;
            }

            dest.ZaprosPortalaGosUslParsed = source.ZaprosPortalaGosUslParsed;
            if (source.GosUsluga != null)
            {
                dest.GosUsluga = PKHelper.CreateDataObject<GosUsluga>(source.GosUsluga?.Guid);
            }

            if (source.Zaiavitel != null)
            {
                dest.Zaiavitel = PKHelper.CreateDataObject<Leechnost>(source.Zaiavitel?.Guid);
            }

            if (source.Opekaemyi != null)
            {
                dest.Opekaemyi = PKHelper.CreateDataObject<Leechnost>(source.Opekaemyi?.Guid);
            }

            if (source.Ispolnitel != null)
            {
                dest.Ispolnitel = PKHelper.CreateDataObject<Specialist>(source.Ispolnitel?.Guid);
            }

            if (source.OrganSZ != null)
            {
                dest.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(source.OrganSZ?.Guid);
            }

            if (source.PrichinaOtkaza != null)
            {
                dest.PrichinaOtkaza = PKHelper.CreateDataObject<PrichinaOtkazaPoZaprosuPortalaGosUslug>(source.PrichinaOtkaza?.Guid);
            }

            if (source.Rezultat != null)
            {
                dest.Rezultat = PKHelper.CreateDataObject<NaimOperRassmotrVedom>(source.Rezultat?.Guid);
            }

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }

        public override Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu Map(ZaiavlenieNaGosUslugu source, Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstDataVremia))
            {
                dest.DataVremia = source.DataVremia;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstZaprosPortalaGosUsl))
            {
                dest.ZaprosPortalaGosUsl = source.ZaprosPortalaGosUsl;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstOtvetNaZapros))
            {
                dest.OtvetNaZapros = source.OtvetNaZapros;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstSoobshchenieObOshibke))
            {
                dest.SoobshchenieObOshibke = source.SoobshchenieObOshibke;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstSoobshchenieObOshibkeShiny))
            {
                dest.SoobshchenieObOshibkeShiny = source.SoobshchenieObOshibkeShiny;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstDataVremiaZaprosa))
            {
                dest.DataVremiaZaprosa = source.DataVremiaZaprosa;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstNomerZaprosa))
            {
                dest.NomerZaprosa = source.NomerZaprosa;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstIdentifikDannyeLeechnosti))
            {
                dest.IdentifikDannyeLeechnosti = source.IdentifikDannyeLeechnosti;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstOtvetVSvobodnoiForme))
            {
                dest.OtvetVSvobodnoiForme = source.OtvetVSvobodnoiForme;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstDataIspolneniia))
            {
                dest.DataIspolneniia = source.DataIspolneniia;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstOriginalyDokPolucheny))
            {
                switch (source.OriginalyDokPolucheny)
                {
                    case tBool.Да:
                        dest.OriginalyDokPolucheny = true;
                        break;
                    case tBool.Нет:
                        dest.OriginalyDokPolucheny = false;
                        break;
                }
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstZaprosPortalaGosUslParsed))
            {
                dest.ZaprosPortalaGosUslParsed = source.ZaprosPortalaGosUslParsed;
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstGosUsluga))
            {
                dest.GosUsluga = PKHelper.CreateDataObject<GosUsluga>(source.GosUsluga?.Guid);
            }

            
            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstZaiavitel))
            {
                dest.Zaiavitel = PKHelper.CreateDataObject<Leechnost>(source.Zaiavitel?.Guid);
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstOpekaemyi))
            {
                dest.Opekaemyi = PKHelper.CreateDataObject<Leechnost>(source.Opekaemyi?.Guid);
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstIspolnitel))
            {
                dest.Ispolnitel = PKHelper.CreateDataObject<Specialist>(source.Ispolnitel?.Guid);
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstOrganSZ))
            {
                dest.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(source.OrganSZ?.Guid);
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstPrichinaOtkaza))
            {
                dest.PrichinaOtkaza = PKHelper.CreateDataObject<PrichinaOtkazaPoZaprosuPortalaGosUslug>(source.PrichinaOtkaza?.Guid);
            }

            if (attrs.Contains(ZaiavlenieNaGosUslugu.ConstRezultat))
            {
                dest.Rezultat = PKHelper.CreateDataObject<NaimOperRassmotrVedom>(source.Rezultat?.Guid);
            }

            if (attrs.Contains(SyncXMLDataObject.ConstCreateTime))
            {
                dest.CreateTime = source.CreateTime;
            }

            if (attrs.Contains(SyncXMLDataObject.ConstCreator))
            {
                dest.Creator = source.Creator;
            }

            if (attrs.Contains(SyncXMLDataObject.ConstEditTime))
            {
                dest.EditTime = source.EditTime;
            }

            if (attrs.Contains(SyncXMLDataObject.ConstEditor))
            {
                dest.Editor = source.Editor;
            }

            return dest;
        }

        public override IQueryable<DataObject> GetAltKey(
            ZaiavlenieNaGosUslugu obj,
            IDataService defDS,
            IDataService syncDS,
            Source source,
            ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            return null;
        }

        public override void SetMasters(
            ZaiavlenieNaGosUslugu obj,
            Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu dobj,
            List<string> attrs,
            IDataService defDS,
            IDataService syncDS,
            Source source,
            ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.GosUsluga != null
                && (status == ObjectStatus.Created 
                    || attrs != null && attrs.Contains(ZaiavlenieNaGosUslugu.ConstGosUsluga)))
            {
                var val = PKHelper.CreateDataObject<GosUsluga>(obj.GosUsluga.Guid);
                defDS.LoadObject(val);
                dobj.GosUsluga = val;
            }

            if (obj.Zaiavitel != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ZaiavlenieNaGosUslugu.ConstZaiavitel)))
            {
                var val = PKHelper.CreateDataObject<Leechnost>(obj.Zaiavitel.Guid);
                defDS.LoadObject(val);
                dobj.Zaiavitel = val;
            }

            if (obj.Opekaemyi != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ZaiavlenieNaGosUslugu.ConstOpekaemyi)))
            {
                var val = PKHelper.CreateDataObject<Leechnost>(obj.Opekaemyi.Guid);
                defDS.LoadObject(val);
                dobj.Opekaemyi = val;
            }

            if (obj.Ispolnitel != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ZaiavlenieNaGosUslugu.ConstIspolnitel)))
            {
                var val = PKHelper.CreateDataObject<Specialist>(obj.Ispolnitel.Guid);
                defDS.LoadObject(val);
                dobj.Ispolnitel = val;
            }

            if (obj.OrganSZ != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ZaiavlenieNaGosUslugu.ConstOrganSZ)))
            {
                var val = PKHelper.CreateDataObject<OrganSZ>(obj.OrganSZ.Guid);
                defDS.LoadObject(val);
                dobj.OrganSZ = val;
            }

            if (obj.PrichinaOtkaza != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ZaiavlenieNaGosUslugu.ConstPrichinaOtkaza)))
            {
                var val = PKHelper.CreateDataObject<PrichinaOtkazaPoZaprosuPortalaGosUslug>(obj.PrichinaOtkaza.Guid);
                defDS.LoadObject(val);
                dobj.PrichinaOtkaza = val;
            }

            if (obj.Rezultat != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ZaiavlenieNaGosUslugu.ConstRezultat)))
            {
                var val = PKHelper.CreateDataObject<NaimOperRassmotrVedom>(obj.Rezultat.Guid);
                defDS.LoadObject(val);
                dobj.Rezultat = val;
            }
        }
    }
}
