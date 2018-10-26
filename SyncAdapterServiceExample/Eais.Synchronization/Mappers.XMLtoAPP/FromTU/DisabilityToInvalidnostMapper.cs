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

    public class DisabilityToInvalidnostMapper : XmlToAppWithChangedAttrsMapper<Disability, Invalidnost>
    {
        protected override View GetDestinationView()
        {
            return Invalidnost.Views.AuditView;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Disability source)
        {
            return source.Guid;
        }

        public override Invalidnost Map(Disability source, Invalidnost dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.Gruppa =
                (tGruppaInvalidnosti) EnumCaption.GetValueFor(source.Group.ToString(), typeof(tGruppaInvalidnosti));
            dest.NomerSpravkiVTEK = source.ReferenceNumberVTEK;
            dest.DataVydSpravVTEK = (NullableDateTime) source.IssueDateVTEK;
            dest.OrganVydSprav = source.OrgName;
            dest.StepenOgranichTrudosp =
                (tGruppaInvalidnosti) EnumCaption.GetValueFor(source.DisabilityDegree.ToString(),
                    typeof(tGruppaInvalidnosti));
            dest.KemVydSprMSE = source.ReferenceIssuedBy == null
                ? null
                : PKHelper.CreateDataObject<OrganVydDok>(source.ReferenceIssuedBy?.Guid);
            dest.LgKatLeechnosti = source.BeneficiaryPreferentialCategory == null
                ? null
                : PKHelper.CreateDataObject<LgKatLeechnosti>(source.BeneficiaryPreferentialCategory?.Guid);
            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;
            return dest;
        }

        public override Invalidnost Map(Disability source, Invalidnost dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(Disability.ConstGroup))
            {
                dest.Gruppa =
                    (tGruppaInvalidnosti) EnumCaption.GetValueFor(source.Group.ToString(), typeof(tGruppaInvalidnosti));
            }

            if (attrs.Contains(Disability.ConstReferenceNumberVTEK))
            {
                dest.NomerSpravkiVTEK = source.ReferenceNumberVTEK;
            }

            if (attrs.Contains(Disability.ConstIssueDateVTEK))
            {
                dest.DataVydSpravVTEK = (NullableDateTime) source.IssueDateVTEK;
            }

            if (attrs.Contains(Disability.ConstOrgName))
            {
                dest.OrganVydSprav = source.OrgName;
            }

            if (attrs.Contains(Disability.ConstDisabilityDegree))
            {
                dest.StepenOgranichTrudosp =
                    (tGruppaInvalidnosti) EnumCaption.GetValueFor(source.DisabilityDegree.ToString(),
                        typeof(tGruppaInvalidnosti));
            }

            if (attrs.Contains(Disability.ConstReferenceIssuedBy))
            {
                dest.KemVydSprMSE = source.ReferenceIssuedBy == null
                    ? null
                    : PKHelper.CreateDataObject<OrganVydDok>(source.ReferenceIssuedBy?.Guid);
            }

            if (attrs.Contains(Disability.ConstBeneficiaryPreferentialCategory))
            {
                dest.LgKatLeechnosti = source.BeneficiaryPreferentialCategory == null
                    ? null
                    : PKHelper.CreateDataObject<LgKatLeechnosti>(source.BeneficiaryPreferentialCategory?.Guid);
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

        public override IQueryable<DataObject> GetAltKey(Disability dobj, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var lgKatLeechnosti = MapperHelper.GetMaster(typeof(LgKatLeechnosti),
                dobj.BeneficiaryPreferentialCategory.Guid,
                defDS.Query<LgKatLeechnosti>(LgKatLeechnosti.Views.LgKatLeechnostiE), syncDS, source, ref arrToUpd,
                ref arrConformity);
            var date = (NullableDateTime) dobj.IssueDateVTEK;

            return defDS.Query<Invalidnost>(Invalidnost.Views.AuditView).Where(x =>
                x.NomerSpravkiVTEK == dobj.ReferenceNumberVTEK
                && x.DataVydSpravVTEK == date
                && x.LgKatLeechnosti.__PrimaryKey.Equals(lgKatLeechnosti.__PrimaryKey));
        }

        public override void SetMasters(Disability obj, Invalidnost dobj, List<string> attrs, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.BeneficiaryPreferentialCategory != null &&
                (status == ObjectStatus.Created ||
                 attrs != null && attrs.Contains(Disability.ConstBeneficiaryPreferentialCategory)))
            {
                var lgKatLeechnosti = (LgKatLeechnosti) MapperHelper.GetMaster(typeof(LgKatLeechnosti),
                    obj.BeneficiaryPreferentialCategory.Guid,
                    defDS.Query<LgKatLeechnosti>(LgKatLeechnosti.Views.LgKatLeechnostiE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.LgKatLeechnosti = lgKatLeechnosti;
            }

            if (obj.ReferenceIssuedBy != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Disability.ConstReferenceIssuedBy)))
            {
                var val = new OrganVydDok();
                val.SetExistObjectPrimaryKey(obj.ReferenceIssuedBy.Guid);
                defDS.LoadObject(val);
                dobj.KemVydSprMSE = val;
            }
        }
    }
}