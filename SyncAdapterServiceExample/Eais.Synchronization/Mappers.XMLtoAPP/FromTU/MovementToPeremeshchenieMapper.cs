namespace Mappers.XMLtoAPP.FromTU
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using ICSSoft.STORMNET.UserDataTypes;
    using Iis.Eais.Leechnost;
    using IIS.University.Tools;
    using Mappers.Common;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using Synchronization.Objects;

    public class MovementToPeremeshchenieMapper : XmlToAppWithChangedAttrsMapper<Movement, Peremeshchenie>
    {
        protected override View GetDestinationView()
        {
            return Peremeshchenie.Views.PeremeshchenieE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Movement source)
        {
            return source.Guid;
        }

        public override Peremeshchenie Map(Movement source, Peremeshchenie dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.DataUbytiia = (NullableDateTime) source.DepatureDate;
            dest.TipAdresa = (tTipAdresa) EnumCaption.GetValueFor(source.AddressType.ToString(), typeof(tTipAdresa));
            dest.AdresUbytiia = source.DepatureAddress == null
                ? null
                : PKHelper.CreateDataObject<Prozhivanie>(source.DepatureAddress?.Guid);
            dest.Leechnost = source.Beneficiary == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary?.Guid);
            dest.PrichinaPeremeshcheniia = source.MovementCause == null
                ? null
                : PKHelper.CreateDataObject<PrichinaPeremeshcheniia>(source.MovementCause?.Guid);
            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;
            return dest;
        }

        public override Peremeshchenie Map(Movement source, Peremeshchenie dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(Movement.ConstDepatureDate))
            {
                dest.DataUbytiia = (NullableDateTime) source.DepatureDate;
            }

            if (attrs.Contains(Movement.ConstAddressType))
            {
                dest.TipAdresa =
                    (tTipAdresa) EnumCaption.GetValueFor(source.AddressType.ToString(), typeof(tTipAdresa));
            }

            if (attrs.Contains(Movement.ConstDepatureAddress))
            {
                dest.AdresUbytiia = source.DepatureAddress == null
                    ? null
                    : PKHelper.CreateDataObject<Prozhivanie>(source.DepatureAddress?.Guid);
            }

            if (attrs.Contains(Movement.ConstBeneficiary))
            {
                dest.Leechnost = source.Beneficiary == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary?.Guid);
            }

            if (attrs.Contains(Movement.ConstMovementCause))
            {
                dest.PrichinaPeremeshcheniia = source.MovementCause == null
                    ? null
                    : PKHelper.CreateDataObject<PrichinaPeremeshcheniia>(source.MovementCause?.Guid);
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

        public override IQueryable<DataObject> GetAltKey(Movement dobj, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var leechnost = MapperHelper.GetMaster(typeof(Leechnost), dobj.Beneficiary.Guid,
                defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd, ref arrConformity);
            var address = Helper.GetProzhivanie(dobj.DepatureAddress, defDS, syncDS, source, ref arrToUpd,
                ref arrConformity);
            var typeAddress = (tTipAdresa) EnumCaption.GetValueFor(dobj.AddressType.ToString(), typeof(tTipAdresa));
            var date = (NullableDateTime) dobj.DepatureDate;

            return defDS.Query<Peremeshchenie>(Peremeshchenie.Views.PeremeshchenieE).Where(x =>
                x.DataUbytiia == date
                && x.TipAdresa == typeAddress
                && x.AdresUbytiia.__PrimaryKey.Equals(address.__PrimaryKey)
                && x.Leechnost.__PrimaryKey.Equals(leechnost.__PrimaryKey));
        }

        public override void SetMasters(Movement obj, Peremeshchenie dobj, List<string> attrs, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();
            if (obj.DepatureAddress != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Movement.ConstDepatureAddress)))
            {
                var address = Helper.GetProzhivanie(obj.DepatureAddress, defDS, syncDS, source, ref arrToUpd,
                    ref arrConformity);
                var adr = new Prozhivanie();
                adr.SetExistObjectPrimaryKey(address.__PrimaryKey);
                adr.SetStatus(ObjectStatus.UnAltered);
                dobj.AdresUbytiia = adr;
            }

            if (obj.MovementCause != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Movement.ConstMovementCause)))
            {
                var val = new PrichinaPeremeshcheniia();
                val.SetExistObjectPrimaryKey(obj.MovementCause.Guid);
                defDS.LoadObject(val);
                dobj.PrichinaPeremeshcheniia = val;
            }

            if (status == ObjectStatus.Created || attrs != null && attrs.Contains(Movement.ConstBeneficiary))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Beneficiary.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Leechnost = leechnost;
            }
        }
    }
}