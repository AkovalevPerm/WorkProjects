namespace Mappers.XMLtoAPP.FromTU
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using Iis.Eais.Leechnost;
    using IIS.University.Tools;
    using Mappers.Common;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using Synchronization.Objects;

    public class
        PaymentAppointmentToNaznachenieVyplatyMapper : XmlToAppWithChangedAttrsMapper<PaymentAppointment,
            NaznachenieVyplaty>
    {
        protected override View GetDestinationView()
        {
            return NaznachenieVyplaty.Views.NaznachenieVyplatyE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(PaymentAppointment source)
        {
            return source.Guid;
        }

        public override NaznachenieVyplaty Map(PaymentAppointment source, NaznachenieVyplaty dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.Podtverzhdeno =
                (tLogicheskii) EnumCaption.GetValueFor(source.Confirmed.ToString(), typeof(tLogicheskii));
            dest.Lgota = source.Benefit == null ? null : PKHelper.CreateDataObject<Lgota>(source.Benefit.Guid);
            dest.Nositel = source.Medium == null ? null : PKHelper.CreateDataObject<Leechnost>(source.Medium.Guid);
            dest.Izhdivenetc = source.Dependent == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Dependent.Guid);

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }

        public override NaznachenieVyplaty Map(PaymentAppointment source, NaznachenieVyplaty dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(PaymentAppointment.ConstConfirmed))
            {
                dest.Podtverzhdeno =
                    (tLogicheskii) EnumCaption.GetValueFor(source.Confirmed.ToString(), typeof(tLogicheskii));
            }

            if (attrs.Contains(PaymentAppointment.ConstBenefit))
            {
                dest.Lgota = source.Benefit == null ? null : PKHelper.CreateDataObject<Lgota>(source.Benefit.Guid);
            }

            if (attrs.Contains(PaymentAppointment.ConstMedium))
            {
                dest.Nositel = source.Medium == null ? null : PKHelper.CreateDataObject<Leechnost>(source.Medium.Guid);
            }

            if (attrs.Contains(PaymentAppointment.ConstDependent))
            {
                dest.Izhdivenetc = source.Dependent == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Dependent.Guid);
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

        public override IQueryable<DataObject> GetAltKey(PaymentAppointment dobj, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var medium = MapperHelper.GetMaster(typeof(Leechnost), dobj.Medium.Guid,
                defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd, ref arrConformity);
            var benefit = new Lgota {__PrimaryKey = dobj.Benefit.Guid};

            var query = defDS.Query<NaznachenieVyplaty>(NaznachenieVyplaty.Views.NaznachenieVyplatyE).Where(x =>
                x.Lgota.__PrimaryKey.Equals(benefit.__PrimaryKey)
                && x.Nositel.__PrimaryKey.Equals(medium.__PrimaryKey));

            if (dobj.Dependent != null)
            {
                var dependent = MapperHelper.GetMaster(typeof(Leechnost), dobj.Dependent.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                query = query.Where(x => x.Izhdivenetc.__PrimaryKey.Equals(dependent.__PrimaryKey));
            }
            else
            {
                query = query.Where(x => x.Izhdivenetc == null);
            }

            return query;
        }

        public override void SetMasters(PaymentAppointment obj, NaznachenieVyplaty dobj, List<string> attrs,
            IDataService defDS, IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.Benefit != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(PaymentAppointment.ConstBenefit)))
            {
                var val = new Lgota();
                val.SetExistObjectPrimaryKey(obj.Benefit.Guid);
                defDS.LoadObject(val);
                dobj.Lgota = val;
            }

            if (obj.Medium != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(PaymentAppointment.ConstMedium)))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Medium.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Nositel = leechnost;
            }

            if (obj.Dependent != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(PaymentAppointment.ConstDependent)))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Dependent.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Izhdivenetc = leechnost;
            }
        }
    }
}