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

    public class FactBenefitsToFaktLgotMapper : XmlToAppWithChangedAttrsMapper<FactBenefits, FaktLgot>
    {
        protected override View GetDestinationView()
        {
            return FaktLgot.Views.FaktLgotE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(FactBenefits source)
        {
            return source.Guid;
        }

        public override FaktLgot Map(FactBenefits source, FaktLgot dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.DataNachisleniia = (NullableDateTime) source.AccrualDate;
            dest.DataPolucheniia = (NullableDateTime) source.ReceiveDate;
            dest.Summa = (NullableDecimal) source.Amount;
            dest.SummaSotcPaketa = (NullableDecimal) source.AmountSocialPackage;
            dest.Kommentarii = source.Comments;
            dest.SposobOplaty = (tSposobOplaty) EnumCaption.GetValueFor(EnumCaption.GetCaptionFor(source.PaymentMethod),
                typeof(tSposobOplaty));
            dest.DataPereplS = (NullableDateTime) source.OverpaymentDateFrom;
            dest.DataPereplPo = (NullableDateTime) source.OverpaymentDateTo;
            dest.NositelLgoty = source.MediumBenefit == null
                ? null
                : PKHelper.CreateDataObject<LgKatLeechnosti>(source.MediumBenefit.Guid);
            dest.Izhdivenetc = source.Dependent == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Dependent.Guid);
            dest.Poluchatel = source.Recipient == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Recipient.Guid);
            dest.Lgota = source.Benefit == null ? null : PKHelper.CreateDataObject<Lgota>(source.Benefit.Guid);
            dest.OrganSZ = source.SocialProtectionAuthority == null
                ? null
                : PKHelper.CreateDataObject<OrganSZ>(source.SocialProtectionAuthority.Guid);
            dest.Period = source.Period == null ? null : PKHelper.CreateDataObject<Period>(source.Period.Guid);

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }

        public override FaktLgot Map(FactBenefits source, FaktLgot dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(FactBenefits.ConstAccrualDate))
            {
                dest.DataNachisleniia = (NullableDateTime) source.AccrualDate;
            }

            if (attrs.Contains(FactBenefits.ConstReceiveDate))
            {
                dest.DataPolucheniia = (NullableDateTime) source.ReceiveDate;
            }

            if (attrs.Contains(FactBenefits.ConstAmount))
            {
                dest.Summa = (NullableDecimal) source.Amount;
            }

            if (attrs.Contains(FactBenefits.ConstAmountSocialPackage))
            {
                dest.SummaSotcPaketa = (NullableDecimal) source.AmountSocialPackage;
            }

            if (attrs.Contains(FactBenefits.ConstComments))
            {
                dest.Kommentarii = source.Comments;
            }

            if (attrs.Contains(FactBenefits.ConstPaymentMethod))
            {
                dest.SposobOplaty =
                    (tSposobOplaty) EnumCaption.GetValueFor(EnumCaption.GetCaptionFor(source.PaymentMethod),
                        typeof(tSposobOplaty));
            }

            if (attrs.Contains(FactBenefits.ConstOverpaymentDateFrom))
            {
                dest.DataPereplS = (NullableDateTime) source.OverpaymentDateFrom;
            }

            if (attrs.Contains(FactBenefits.ConstOverpaymentDateTo))
            {
                dest.DataPereplPo = (NullableDateTime) source.OverpaymentDateTo;
            }

            if (attrs.Contains(FactBenefits.ConstMediumBenefit))
            {
                dest.NositelLgoty = source.MediumBenefit == null
                    ? null
                    : PKHelper.CreateDataObject<LgKatLeechnosti>(source.MediumBenefit.Guid);
            }

            if (attrs.Contains(FactBenefits.ConstDependent))
            {
                dest.Izhdivenetc = source.Dependent == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Dependent.Guid);
            }

            if (attrs.Contains(FactBenefits.ConstRecipient))
            {
                dest.Poluchatel = source.Recipient == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Recipient.Guid);
            }

            if (attrs.Contains(FactBenefits.ConstBenefit))
            {
                dest.Lgota = source.Benefit == null ? null : PKHelper.CreateDataObject<Lgota>(source.Benefit.Guid);
            }

            if (attrs.Contains(FactBenefits.ConstSocialProtectionAuthority))
            {
                dest.OrganSZ = source.SocialProtectionAuthority == null
                    ? null
                    : PKHelper.CreateDataObject<OrganSZ>(source.SocialProtectionAuthority.Guid);
            }

            if (attrs.Contains(FactBenefits.ConstPeriod))
            {
                dest.Period = source.Period == null ? null : PKHelper.CreateDataObject<Period>(source.Period.Guid);
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

        public override IQueryable<DataObject> GetAltKey(FactBenefits dobj, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var accrualDate = (NullableDateTime) dobj.AccrualDate;
            var receiveDate = (NullableDateTime) dobj.ReceiveDate;
            var lgKatLeechnosti = MapperHelper.GetMaster(typeof(LgKatLeechnosti), dobj.MediumBenefit.Guid,
                defDS.Query<LgKatLeechnosti>(LgKatLeechnosti.Views.LgKatLeechnostiE), syncDS, source, ref arrToUpd,
                ref arrConformity);
            var benefit = new Lgota {__PrimaryKey = dobj.Benefit.Guid};
            var organSZ = new OrganSZ {__PrimaryKey = dobj.SocialProtectionAuthority.Guid};

            var query = defDS.Query<FaktLgot>(FaktLgot.Views.FaktLgotE).Where(x =>
                x.DataNachisleniia == accrualDate
                && x.DataPolucheniia == receiveDate
                && x.NositelLgoty.__PrimaryKey.Equals(lgKatLeechnosti.__PrimaryKey)
                && x.Lgota.__PrimaryKey.Equals(benefit.__PrimaryKey)
                && x.OrganSZ.__PrimaryKey.Equals(organSZ.__PrimaryKey));

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

            if (dobj.Recipient != null)
            {
                var poluchatel = MapperHelper.GetMaster(typeof(Leechnost), dobj.Recipient.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                query = query.Where(x => x.Poluchatel.__PrimaryKey.Equals(poluchatel.__PrimaryKey));
            }
            else
            {
                query = query.Where(x => x.Poluchatel == null);
            }


            if (dobj.Period != null)
            {
                var period = new Period {__PrimaryKey = dobj.Period.Guid};
                query = query.Where(x => x.Period.__PrimaryKey.Equals(period.__PrimaryKey));
            }
            else
            {
                query = query.Where(x => x.Period == null);
            }

            return query;
        }

        public override void SetMasters(FactBenefits obj, FaktLgot dobj, List<string> attrs, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.MediumBenefit != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(FactBenefits.ConstMediumBenefit)))
            {
                var lgKatLeechnosti = (LgKatLeechnosti) MapperHelper.GetMaster(typeof(LgKatLeechnosti),
                    obj.MediumBenefit.Guid, defDS.Query<LgKatLeechnosti>(LgKatLeechnosti.Views.LgKatLeechnostiE),
                    syncDS, source, ref arrToUpd, ref arrConformity);
                dobj.NositelLgoty = lgKatLeechnosti;
            }

            if (obj.Dependent != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(FactBenefits.ConstDependent)))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Dependent.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Izhdivenetc = leechnost;
            }

            if (obj.Recipient != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(FactBenefits.ConstRecipient)))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Recipient.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Poluchatel = leechnost;
            }

            if (obj.Benefit != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(FactBenefits.ConstBenefit)))
            {
                var val = new Lgota();
                val.SetExistObjectPrimaryKey(obj.Benefit.Guid);
                defDS.LoadObject(val);
                dobj.Lgota = val;
            }

            if (obj.SocialProtectionAuthority != null &&
                (status == ObjectStatus.Created ||
                 attrs != null && attrs.Contains(FactBenefits.ConstSocialProtectionAuthority)))
            {
                var val = new OrganSZ();
                val.SetExistObjectPrimaryKey(obj.SocialProtectionAuthority.Guid);
                defDS.LoadObject(val);
                dobj.OrganSZ = val;
            }

            if (obj.Period != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(FactBenefits.ConstPeriod)))
            {
                var val = new Period();
                val.SetExistObjectPrimaryKey(obj.Period.Guid);
                defDS.LoadObject(val);
                dobj.Period = val;
            }
        }
    }
}