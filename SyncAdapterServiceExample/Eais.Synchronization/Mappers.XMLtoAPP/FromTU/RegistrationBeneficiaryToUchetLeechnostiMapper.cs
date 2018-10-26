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

    public class
        RegistrationBeneficiaryToUchetLeechnostiMapper : XmlToAppWithChangedAttrsMapper<RegistrationBeneficiary,
            UchetLeechnosti>
    {
        protected override View GetDestinationView()
        {
            return UchetLeechnosti.Views.UchetLeechnostiE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(RegistrationBeneficiary source)
        {
            return source.Guid;
        }

        public override UchetLeechnosti Map(RegistrationBeneficiary source, UchetLeechnosti dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.DataPostNaUchet = source.RegistrationDate;
            dest.DataSnyatSUcheta = (NullableDateTime) source.DeregistrationDate;
            dest.OrganSZ = source.SocialProtectionAuthority == null
                ? null
                : PKHelper.CreateDataObject<OrganSZ>(source.SocialProtectionAuthority?.Guid);
            dest.Leechnost = source.Beneficiary == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary?.Guid);
            dest.PrichinaSnyatiya = source.DeregestrationReason == null
                ? null
                : PKHelper.CreateDataObject<PrichinaSnyatiya>(source.DeregestrationReason?.Guid);
            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;
            return dest;
        }

        public override UchetLeechnosti Map(RegistrationBeneficiary source, UchetLeechnosti dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(RegistrationBeneficiary.ConstRegistrationDate))
            {
                dest.DataPostNaUchet = source.RegistrationDate;
            }

            if (attrs.Contains(RegistrationBeneficiary.ConstDeregistrationDate))
            {
                dest.DataSnyatSUcheta = (NullableDateTime) source.DeregistrationDate;
            }

            if (attrs.Contains(RegistrationBeneficiary.ConstSocialProtectionAuthority))
            {
                dest.OrganSZ = source.SocialProtectionAuthority == null
                    ? null
                    : PKHelper.CreateDataObject<OrganSZ>(source.SocialProtectionAuthority?.Guid);
            }

            if (attrs.Contains(RegistrationBeneficiary.ConstBeneficiary))
            {
                dest.Leechnost = source.Beneficiary == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary?.Guid);
            }

            if (attrs.Contains(RegistrationBeneficiary.ConstDeregestrationReason))
            {
                dest.PrichinaSnyatiya = source.DeregestrationReason == null
                    ? null
                    : PKHelper.CreateDataObject<PrichinaSnyatiya>(source.DeregestrationReason?.Guid);
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

        public override IQueryable<DataObject> GetAltKey(RegistrationBeneficiary dobj, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var leechnost = MapperHelper.GetMaster(typeof(Leechnost), dobj.Beneficiary.Guid,
                defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd, ref arrConformity);
            var organSZ = new OrganSZ {__PrimaryKey = dobj.SocialProtectionAuthority.Guid};

            return defDS.Query<UchetLeechnosti>(UchetLeechnosti.Views.UchetLeechnostiE).Where(x =>
                x.DataPostNaUchet == dobj.RegistrationDate
                && x.OrganSZ.__PrimaryKey.Equals(organSZ.__PrimaryKey)
                && x.Leechnost.__PrimaryKey.Equals(leechnost.__PrimaryKey));
        }

        public override void SetMasters(RegistrationBeneficiary obj, UchetLeechnosti dobj, List<string> attrs,
            IDataService defDS, IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.Beneficiary != null &&
                (status == ObjectStatus.Created ||
                 attrs != null && attrs.Contains(RegistrationBeneficiary.ConstBeneficiary)))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Beneficiary.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Leechnost = leechnost;
            }

            if (obj.SocialProtectionAuthority != null &&
                (status == ObjectStatus.Created || attrs != null &&
                 attrs.Contains(RegistrationBeneficiary.ConstSocialProtectionAuthority)))
            {
                var val = new OrganSZ();
                val.SetExistObjectPrimaryKey(obj.SocialProtectionAuthority.Guid);
                defDS.LoadObject(val);
                dobj.OrganSZ = val;
            }

            if (obj.DeregestrationReason != null &&
                (status == ObjectStatus.Created ||
                 attrs != null && attrs.Contains(RegistrationBeneficiary.ConstDeregestrationReason)))
            {
                var val = new PrichinaSnyatiya();
                val.SetExistObjectPrimaryKey(obj.DeregestrationReason.Guid);
                defDS.LoadObject(val);
                dobj.PrichinaSnyatiya = val;
            }
        }
    }
}