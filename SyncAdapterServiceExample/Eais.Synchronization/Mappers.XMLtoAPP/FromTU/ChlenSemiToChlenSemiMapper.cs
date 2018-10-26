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

    using ChlenSemi = ServiceBus.ObjectDataModel.FromTU.ChlenSemi;
    using ZaiavlenieNaGosUslugu = Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu;

    public class ChlenSemiToChlenSemiMapper : XmlToAppWithChangedAttrsMapper<ChlenSemi, Iis.Eais.GosUslugi.ChlenSemi>
    {
        protected override Guid? GetSourceObjectPrimaryKey(ChlenSemi dest)
        {
            return dest?.Guid;
        }

        public override Iis.Eais.GosUslugi.ChlenSemi Map(ChlenSemi source, Iis.Eais.GosUslugi.ChlenSemi dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.IdentifikDannyeLeechnosti = source.IdentifikDannyeLeechnosti;

            switch (source.Shkolnik)
            {
                case tSchoolChild.Дошкольник:
                    dest.Shkolnik = tStatusUchashchegosia.Doshkolnik;
                    break;
                case tSchoolChild.Учащийся:
                    dest.Shkolnik = tStatusUchashchegosia.Uchashchiisia;
                    break;
                case tSchoolChild.Работает:
                    dest.Shkolnik = tStatusUchashchegosia.Rabotaet;
                    break;
            }

            if (dest.Zaiavlenie != null)
            {
                dest.Zaiavlenie = PKHelper.CreateDataObject<ZaiavlenieNaGosUslugu>(source.Zaiavlenie?.Guid);
            }

            if (dest.Leechnost != null)
            {
                dest.Leechnost = PKHelper.CreateDataObject<Leechnost>(source.Leechnost?.Guid);
            }

            if (dest.RodstvOtn != null)
            {
                dest.RodstvOtn = PKHelper.CreateDataObject<RodstvOtn>(source.RodstvOtn?.Guid);
            }

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }

        public override Iis.Eais.GosUslugi.ChlenSemi Map(ChlenSemi source, Iis.Eais.GosUslugi.ChlenSemi dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(ChlenSemi.ConstIdentifikDannyeLeechnosti))
            {
                dest.IdentifikDannyeLeechnosti = source.IdentifikDannyeLeechnosti;
            }

            if (attrs.Contains(ChlenSemi.ConstShkolnik))
            {
                switch (source.Shkolnik)
                {
                    case tSchoolChild.Дошкольник:
                        dest.Shkolnik = tStatusUchashchegosia.Doshkolnik;
                        break;
                    case tSchoolChild.Учащийся:
                        dest.Shkolnik = tStatusUchashchegosia.Uchashchiisia;
                        break;
                    case tSchoolChild.Работает:
                        dest.Shkolnik = tStatusUchashchegosia.Rabotaet;
                        break;
                }
            }

            if (attrs.Contains(ChlenSemi.ConstZaiavlenie))
            {
                dest.Zaiavlenie = PKHelper.CreateDataObject<ZaiavlenieNaGosUslugu>(source.Zaiavlenie?.Guid);
            }

            if (attrs.Contains(ChlenSemi.ConstLeechnost))
            {
                dest.Leechnost = PKHelper.CreateDataObject<Leechnost>(source.Leechnost?.Guid);
            }

            if (attrs.Contains(ChlenSemi.ConstRodstvOtn))
            {
                dest.RodstvOtn = PKHelper.CreateDataObject<RodstvOtn>(source.RodstvOtn?.Guid);
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

        public override IQueryable<DataObject> GetAltKey(ChlenSemi obj, IDataService defDS, IDataService syncDS, Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            return null;
        }

        public override void SetMasters(
            ChlenSemi obj,
            Iis.Eais.GosUslugi.ChlenSemi dobj,
            List<string> attrs,
            IDataService defDS,
            IDataService syncDS,
            Source source,
            ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.Zaiavlenie != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ChlenSemi.ConstZaiavlenie)))
            {
                var val = PKHelper.CreateDataObject<ZaiavlenieNaGosUslugu>(obj.Zaiavlenie.Guid);
                defDS.LoadObject(val);
                dobj.Zaiavlenie = val;
            }

            if (obj.Leechnost != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ChlenSemi.ConstLeechnost)))
            {
                var val = PKHelper.CreateDataObject<Leechnost>(obj.Leechnost.Guid);
                defDS.LoadObject(val);
                dobj.Leechnost = val;
            }

            if (obj.RodstvOtn != null
                && (status == ObjectStatus.Created
                    || attrs != null && attrs.Contains(ChlenSemi.ConstRodstvOtn)))
            {
                var val = PKHelper.CreateDataObject<RodstvOtn>(obj.RodstvOtn.Guid);
                defDS.LoadObject(val);
                dobj.RodstvOtn = val;
            }
        }
    }
}
