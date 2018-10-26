using System;
using ServiceBus.ObjectDataModel.FromTU;
using Iis.Eais.Catalogs;
using System.Collections.Generic;
using ICSSoft.STORMNET;
using IIS.University.Tools;
using ICSSoft.STORMNET.Business;
using Synchronization.Objects;
using System.Linq;
using ICSSoft.STORMNET.Business.LINQProvider;
using ServiceBus.ObjectDataModel.Common;

namespace Mappers.XMLtoAPP.FromTU
{
    public class StructureToStroenieMapper: XmlToAppWithChangedAttrsMapper<Structure, Stroenie>
    {
        protected override View GetDestinationView()
        {
            return Stroenie.Views.StroenieE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Structure source)
        {
            return source.Guid;
        }

        public override Stroenie Map(Structure source, Stroenie dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
                dest.__PrimaryKey = source.Guid;

            dest.KodFIAS = source.FIAS;
            dest.VidStroeniia = (tVidStroeniia)EnumCaption.GetValueFor(EnumCaption.GetCaptionFor(source.TypeStructure), typeof(tVidStroeniia));
            dest.Nomer = source.Number == null ? 0 : (uint)source.Number;
            dest.PochtIndeks = source.PostIndex;
            dest.DopStroenie = source.Additional;
            dest.KodPodtverzhd = source.VerificationCode == null ? 0 : (uint)source.VerificationCode;
            dest.Raion = source.Area == null ? null : PKHelper.CreateDataObject<Territoriia>(source.Area.Guid);
            dest.Ulitca = source.Street == null ? null : PKHelper.CreateDataObject<Ulitca>(source.Street.Guid);

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }

        public override Stroenie Map(Structure source, Stroenie dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
                return Map(source, dest);
            else
            {
                if (attrs.Contains(Structure.ConstFIAS))
                    dest.KodFIAS = source.FIAS;
                if (attrs.Contains(Structure.ConstType))
                    dest.VidStroeniia = (tVidStroeniia)EnumCaption.GetValueFor(EnumCaption.GetCaptionFor(source.TypeStructure), typeof(tVidStroeniia));
                if (attrs.Contains(Structure.ConstNumber))
                    dest.Nomer = (uint)source.Number;
                if (attrs.Contains(Structure.ConstPostIndex))
                    dest.PochtIndeks = source.PostIndex;
                if (attrs.Contains(Structure.ConstAdditional))
                    dest.DopStroenie = source.Additional;
                if (attrs.Contains(Structure.ConstVerificationCode))
                    dest.KodPodtverzhd = source.VerificationCode == null ? 0 : (uint)source.VerificationCode;
                if (attrs.Contains(Structure.ConstArea))
                    dest.Raion = source.Area == null ? null : PKHelper.CreateDataObject<Territoriia>(source.Area.Guid);
                if (attrs.Contains(Structure.ConstStreet))
                    dest.Ulitca = source.Street == null ? null : PKHelper.CreateDataObject<Ulitca>(source.Street.Guid);

                if (attrs.Contains(SyncXMLDataObject.ConstCreateTime))
                    dest.CreateTime = source.CreateTime;
                if (attrs.Contains(SyncXMLDataObject.ConstCreator))
                    dest.Creator = source.Creator;
                if (attrs.Contains(SyncXMLDataObject.ConstEditTime))
                    dest.EditTime = source.EditTime;
                if (attrs.Contains(SyncXMLDataObject.ConstEditor))
                    dest.Editor = source.Editor;

                return dest;
            }
        }

        public override IQueryable<DataObject> GetAltKey(Structure obj, IDataService defDS, IDataService syncDS, Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var terr = new Territoriia() { __PrimaryKey = obj.Area.Guid };            

            var query = defDS.Query<Stroenie>(Stroenie.Views.StroenieE).Where(x =>
                x.Raion.__PrimaryKey.Equals(terr.__PrimaryKey)               
                && x.Nomer == obj.Number
                && x.DopStroenie == obj.Additional);

            if (obj.Street != null)
            {
                var street = new Ulitca() { __PrimaryKey = obj.Street.Guid };
                query = query.Where(x => x.Ulitca.__PrimaryKey.Equals(street.__PrimaryKey));
            }
            else
                query = query.Where(x => x.Ulitca == null);

            return query;
        }

        public override void SetMasters(Structure obj, Stroenie dobj, List<string> attrs, IDataService defDS, IDataService syncDS, Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.Area != null &&
               (status == ObjectStatus.Created || attrs != null && attrs.Contains(Structure.ConstArea)))
            {
                var val = new Territoriia();
                val.SetExistObjectPrimaryKey(obj.Area.Guid);
                defDS.LoadObject(val);
                dobj.Raion = val;
            }
            if (obj.Street != null &&
               (status == ObjectStatus.Created || attrs != null && attrs.Contains(Structure.ConstStreet)))
            {
                var val = new Ulitca();
                val.SetExistObjectPrimaryKey(obj.Street.Guid);
                defDS.LoadObject(val);
                dobj.Ulitca = val;
            }
        }
    }
}
