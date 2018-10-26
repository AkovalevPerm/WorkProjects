namespace Mappers.XMLtoAPP.FromTU
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using Iis.Eais.Catalogs;
    using IIS.University.Tools;
    using Mappers.Common;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using Synchronization.Objects;

    public class LocationToProzhivanieMapper : XmlToAppWithChangedAttrsMapper<Location, Prozhivanie>
    {
        protected override View GetDestinationView()
        {
            return Prozhivanie.Views.ProzhivanieE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Location source)
        {
            return source.Guid;
        }

        public override Prozhivanie Map(Location source, Prozhivanie dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.Stroenie = source.Structure == null
                ? null
                : PKHelper.CreateDataObject<Stroenie>(source.Structure.Guid);
            dest.Territoriia = source.Territory == null
                ? null
                : PKHelper.CreateDataObject<Territoriia>(source.Territory.Guid);
            dest.Ulitca = source.Street == null ? null : PKHelper.CreateDataObject<Ulitca>(source.Street.Guid);
            dest.NomerStroeniia = source.HouseNumber;
            dest.PochtIndeks = source.Index;
            dest.Kvartira = source.Appartment;
            dest.Telefon = source.Phone;
            dest.Ploshchad = source.Area == null ? 0 : (uint) source.Area;
            dest.KolKomnat = source.NumberRooms;
            dest.Iznos = source.Deterioration;
            dest.KolProzhiv = source.NumberResidents == null ? 0 : (uint) source.NumberResidents;
            dest.ProchHarakteristiki = source.OtherCharacteristics;

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }

        public override Prozhivanie Map(Location source, Prozhivanie dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(Location.ConstStructure))
            {
                dest.Stroenie = source.Structure == null
                    ? null
                    : PKHelper.CreateDataObject<Stroenie>(source.Structure.Guid);
            }

            if (attrs.Contains(Location.ConstTerritory))
            {
                dest.Territoriia = source.Territory == null
                    ? null
                    : PKHelper.CreateDataObject<Territoriia>(source.Territory.Guid);
            }

            if (attrs.Contains(Location.ConstStreet))
            {
                dest.Ulitca = source.Street == null ? null : PKHelper.CreateDataObject<Ulitca>(source.Street.Guid);
            }

            if (attrs.Contains(Location.ConstHouseNumber))
            {
                dest.NomerStroeniia = source.HouseNumber;
            }

            if (attrs.Contains(Location.ConstIndex))
            {
                dest.PochtIndeks = source.Index;
            }

            if (attrs.Contains(Location.ConstAppartment))
            {
                dest.Kvartira = source.Appartment;
            }

            if (attrs.Contains(Location.ConstPhone))
            {
                dest.Telefon = source.Phone;
            }

            if (attrs.Contains(Location.ConstArea))
            {
                dest.Ploshchad = source.Area == null ? 0 : (uint) source.Area;
            }

            if (attrs.Contains(Location.ConstNumberRooms))
            {
                dest.KolKomnat = source.NumberRooms;
            }

            if (attrs.Contains(Location.ConstDeterioration))
            {
                dest.Iznos = source.Deterioration;
            }

            if (attrs.Contains(Location.ConstNumberResidents))
            {
                dest.KolProzhiv = source.NumberResidents == null ? 0 : (uint) source.NumberResidents;
            }

            if (attrs.Contains(Location.ConstOtherCharacteristics))
            {
                dest.ProchHarakteristiki = source.OtherCharacteristics;
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

        public override IQueryable<DataObject> GetAltKey(Location obj, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var terr = new Territoriia {__PrimaryKey = obj.Territory.Guid};

            var query = defDS.Query<Prozhivanie>(Prozhivanie.Views.ProzhivanieE).Where(x =>
                x.Territoriia.__PrimaryKey.Equals(terr.__PrimaryKey)
                && x.NomerDoma == obj.Number
                && x.NomerStroeniia == obj.HouseNumber
                && x.Kvartira == obj.Appartment);

            if (obj.Street != null)
            {
                var street = new Ulitca {__PrimaryKey = obj.Street.Guid};
                query = query.Where(x => x.Ulitca.__PrimaryKey.Equals(street.__PrimaryKey));
            }
            else
            {
                query = query.Where(x => x.Ulitca == null);
            }

            return query;
        }

        public override void SetMasters(Location obj, Prozhivanie dobj, List<string> attrs, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.Territory != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Location.ConstTerritory)))
            {
                var val = new Territoriia();
                val.SetExistObjectPrimaryKey(obj.Territory.Guid);
                defDS.LoadObject(val);
                dobj.Territoriia = val;
            }

            if (obj.Street != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Location.ConstStreet)))
            {
                var val = new Ulitca();
                val.SetExistObjectPrimaryKey(obj.Street.Guid);
                defDS.LoadObject(val);
                dobj.Ulitca = val;
            }

            if (obj.Structure != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Location.ConstStructure)))
            {
                var stroenie = (Stroenie) MapperHelper.GetMaster(typeof(Stroenie), obj.Structure.Guid,
                    defDS.Query<Stroenie>(Stroenie.Views.StroenieE), syncDS, source, ref arrToUpd, ref arrConformity);
                dobj.Stroenie = stroenie;
            }
        }
    }
}