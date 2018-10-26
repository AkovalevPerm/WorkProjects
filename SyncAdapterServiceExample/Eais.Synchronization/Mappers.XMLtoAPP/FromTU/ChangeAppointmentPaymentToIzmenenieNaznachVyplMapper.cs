namespace Mappers.XMLtoAPP.FromTU
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using ICSSoft.STORMNET.UserDataTypes;
    using Iis.Eais.Leechnost;
    using IIS.University.Tools;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using Synchronization.Objects;

    public class
        ChangeAppointmentPaymentToIzmenenieNaznachVyplMapper : XmlToAppWithChangedAttrsMapper<ChangeAppointmentPayment,
            IzmenenieNaznachVypl>
    {
        protected override View GetDestinationView()
        {
            return IzmenenieNaznachVypl.Views.AuditView;
        }

        protected override Guid? GetSourceObjectPrimaryKey(ChangeAppointmentPayment source)
        {
            return source.Guid;
        }

        public override IzmenenieNaznachVypl Map(ChangeAppointmentPayment source, IzmenenieNaznachVypl dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.DataNaznacheniia = (NullableDateTime) source.AppointmentDate;
            dest.DataOtmeny = (NullableDateTime) source.CancellationDate;
            dest.TipVypl = (tTipVyplaty) EnumCaption.GetValueFor(source.PaymentType.ToString(), typeof(tTipVyplaty));
            dest.PeriodPredost =
                (tTipPerioda) EnumCaption.GetValueFor(EnumCaption.GetCaptionFor(source.Period), typeof(tTipPerioda));
            dest.Summa = (NullableDecimal) source.Amount;
            dest.Primechanie = source.Note;
            dest.OrganSZ = source.SocialProtectionAuthority == null
                ? null
                : PKHelper.CreateDataObject<OrganSZ>(source.SocialProtectionAuthority.Guid);
            dest.LgKatLeechnosti = source.BeneficiaryPreferentialCategory == null
                ? null
                : PKHelper.CreateDataObject<LgKatLeechnosti>(source.BeneficiaryPreferentialCategory.Guid);
            dest.Poluchatel = source.Recipient == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Recipient.Guid);
            dest.Naznachenie = source.PaymentAppointment == null
                ? null
                : PKHelper.CreateDataObject<NaznachenieVyplaty>(source.PaymentAppointment.Guid);

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }

        public override IzmenenieNaznachVypl Map(ChangeAppointmentPayment source, IzmenenieNaznachVypl dest,
            List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstAppointmentDate))
            {
                dest.DataNaznacheniia = (NullableDateTime) source.AppointmentDate;
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstCancellationDate))
            {
                dest.DataOtmeny = (NullableDateTime) source.CancellationDate;
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstPaymentType))
            {
                dest.TipVypl =
                    (tTipVyplaty) EnumCaption.GetValueFor(source.PaymentType.ToString(), typeof(tTipVyplaty));
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstPeriod))
            {
                dest.PeriodPredost =
                    (tTipPerioda) EnumCaption.GetValueFor(EnumCaption.GetCaptionFor(source.Period),
                        typeof(tTipPerioda));
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstAmount))
            {
                dest.Summa = (NullableDecimal) source.Amount;
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstNote))
            {
                dest.Primechanie = source.Note;
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstSocialProtectionAuthority))
            {
                dest.OrganSZ = source.SocialProtectionAuthority == null
                    ? null
                    : PKHelper.CreateDataObject<OrganSZ>(source.SocialProtectionAuthority.Guid);
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstBeneficiaryPreferentialCategory))
            {
                dest.LgKatLeechnosti = source.BeneficiaryPreferentialCategory == null
                    ? null
                    : PKHelper.CreateDataObject<LgKatLeechnosti>(source.BeneficiaryPreferentialCategory.Guid);
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstRecipient))
            {
                dest.Poluchatel = source.Recipient == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Recipient.Guid);
            }

            if (attrs.Contains(ChangeAppointmentPayment.ConstPaymentAppointment))
            {
                dest.Naznachenie = source.PaymentAppointment == null
                    ? null
                    : PKHelper.CreateDataObject<NaznachenieVyplaty>(source.PaymentAppointment.Guid);
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

        public override IQueryable<DataObject> GetAltKey(ChangeAppointmentPayment dobj, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var naznachenie = MapperHelper.GetMaster(typeof(NaznachenieVyplaty), dobj.PaymentAppointment.Guid,
                defDS.Query<NaznachenieVyplaty>(NaznachenieVyplaty.Views.NaznachenieVyplatyE), syncDS, source,
                ref arrToUpd, ref arrConformity);
            var date = (NullableDateTime) dobj.AppointmentDate;
            var paymentType = (tTipVyplaty) EnumCaption.GetValueFor(dobj.PaymentType.ToString(), typeof(tTipVyplaty));

            return defDS.Query<IzmenenieNaznachVypl>(IzmenenieNaznachVypl.Views.AuditView).Where(x =>
                x.DataNaznacheniia == date
                && x.TipVypl == paymentType
                && x.Naznachenie.__PrimaryKey.Equals(naznachenie.__PrimaryKey));
        }

        public override void SetMasters(ChangeAppointmentPayment obj, IzmenenieNaznachVypl dobj, List<string> attrs,
            IDataService defDS, IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.SocialProtectionAuthority != null &&
                (status == ObjectStatus.Created || attrs != null &&
                 attrs.Contains(ChangeAppointmentPayment.ConstSocialProtectionAuthority)))
            {
                var val = new OrganSZ();
                val.SetExistObjectPrimaryKey(obj.SocialProtectionAuthority.Guid);
                defDS.LoadObject(val);
                dobj.OrganSZ = val;
            }

            if (obj.BeneficiaryPreferentialCategory != null &&
                (status == ObjectStatus.Created || attrs != null &&
                 attrs.Contains(ChangeAppointmentPayment.ConstBeneficiaryPreferentialCategory)))
            {
                var lgKatLeechnosti = (LgKatLeechnosti) MapperHelper.GetMaster(typeof(LgKatLeechnosti),
                    obj.BeneficiaryPreferentialCategory.Guid,
                    defDS.Query<LgKatLeechnosti>(LgKatLeechnosti.Views.LgKatLeechnostiE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.LgKatLeechnosti = lgKatLeechnosti;
            }

            if (obj.Recipient != null &&
                (status == ObjectStatus.Created ||
                 attrs != null && attrs.Contains(ChangeAppointmentPayment.ConstRecipient)))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Recipient.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Poluchatel = leechnost;
            }

            if (obj.PaymentAppointment != null &&
                (status == ObjectStatus.Created ||
                 attrs != null && attrs.Contains(ChangeAppointmentPayment.ConstPaymentAppointment)))
            {
                var naznachenie = (NaznachenieVyplaty) MapperHelper.GetMaster(typeof(NaznachenieVyplaty),
                    obj.PaymentAppointment.Guid,
                    defDS.Query<NaznachenieVyplaty>(NaznachenieVyplaty.Views.NaznachenieVyplatyE), syncDS, source,
                    ref arrToUpd, ref arrConformity);
                dobj.Naznachenie = naznachenie;
            }
        }
    }
}