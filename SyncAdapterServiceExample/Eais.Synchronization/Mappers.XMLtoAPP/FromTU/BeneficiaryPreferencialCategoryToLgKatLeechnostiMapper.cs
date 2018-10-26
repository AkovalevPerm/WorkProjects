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
        BeneficiaryPreferencialCategoryToLgKatLeechnostiMapper : XmlToAppWithChangedAttrsMapper<
            BeneficiaryPreferentialCategory, LgKatLeechnosti>
    {
        protected override View GetDestinationView()
        {
            return LgKatLeechnosti.Views.LgKatLeechnostiE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(BeneficiaryPreferentialCategory source)
        {
            return source.Guid;
        }

        public override LgKatLeechnosti Map(BeneficiaryPreferentialCategory source, LgKatLeechnosti dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.DataNaznacheniia = (NullableDateTime) source.AppointmentDate;
            dest.DataOtmeny = (NullableDateTime) source.CancellationDate;
            dest.Primechanie = source.Note;
            dest.Dokument = source.Document == null
                ? null
                : PKHelper.CreateDataObject<UdostDokument>(source.Document.Guid);
            dest.LgotKat = source.PreferentialCategory == null
                ? null
                : PKHelper.CreateDataObject<LgotKat>(source.PreferentialCategory?.Guid);
            dest.AktInvalidnosti = source.ActDisability == null
                ? null
                : PKHelper.CreateDataObject<Invalidnost>(source.ActDisability?.Guid);
            dest.Leechnost = source.Beneficiary == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary.Guid);
            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;
            return dest;
        }

        public override LgKatLeechnosti Map(BeneficiaryPreferentialCategory source, LgKatLeechnosti dest,
            List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(BeneficiaryPreferentialCategory.ConstPurposeDate))
            {
                dest.DataNaznacheniia = (NullableDateTime) source.AppointmentDate;
            }

            if (attrs.Contains(BeneficiaryPreferentialCategory.ConstCancellationDate))
            {
                dest.DataOtmeny = (NullableDateTime) source.CancellationDate;
            }

            if (attrs.Contains(BeneficiaryPreferentialCategory.ConstNote))
            {
                dest.Primechanie = source.Note;
            }

            if (attrs.Contains(BeneficiaryPreferentialCategory.ConstDocument))
            {
                dest.Dokument = source.Document == null
                    ? null
                    : PKHelper.CreateDataObject<UdostDokument>(source.Document?.Guid);
            }

            if (attrs.Contains(BeneficiaryPreferentialCategory.ConstPreferentialCategory))
            {
                dest.LgotKat = source.PreferentialCategory == null
                    ? null
                    : PKHelper.CreateDataObject<LgotKat>(source.PreferentialCategory?.Guid);
            }

            if (attrs.Contains(BeneficiaryPreferentialCategory.ConstActDisability))
            {
                dest.AktInvalidnosti = source.ActDisability == null
                    ? null
                    : PKHelper.CreateDataObject<Invalidnost>(source.ActDisability?.Guid);
            }

            if (attrs.Contains(BeneficiaryPreferentialCategory.ConstBeneficiary))
            {
                dest.Leechnost = source.Beneficiary == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary.Guid);
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

        public override IQueryable<DataObject> GetAltKey(BeneficiaryPreferentialCategory dobj, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var leechnost = MapperHelper.GetMaster(typeof(Leechnost), dobj.Beneficiary.Guid,
                defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd, ref arrConformity);
            var date = (NullableDateTime) dobj.AppointmentDate;
            var lgKat = new LgotKat {__PrimaryKey = dobj.PreferentialCategory.Guid};

            return defDS.Query<LgKatLeechnosti>(LgKatLeechnosti.Views.LgKatLeechnostiE).Where(x =>
                x.DataNaznacheniia == date
                && x.Leechnost.__PrimaryKey.Equals(leechnost.__PrimaryKey)
                && x.LgotKat.__PrimaryKey.Equals(lgKat.__PrimaryKey));
        }

        public override void SetMasters(BeneficiaryPreferentialCategory obj, LgKatLeechnosti dobj, List<string> attrs,
            IDataService defDS, IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (obj.Document != null &&
                (status == ObjectStatus.Created ||
                 attrs != null && attrs.Contains(BeneficiaryPreferentialCategory.ConstDocument)))
            {
                dobj.Dokument = (UdostDokument) MapperHelper.GetMaster(typeof(UdostDokument), obj.Document.Guid,
                    defDS.Query<UdostDokument>(UdostDokument.Views.UdostDokumentE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
            }

            if (obj.PreferentialCategory != null &&
                (status == ObjectStatus.Created || attrs != null &&
                 attrs.Contains(BeneficiaryPreferentialCategory.ConstPreferentialCategory)))
            {
                var val = new LgotKat();
                val.SetExistObjectPrimaryKey(obj.PreferentialCategory.Guid);
                defDS.LoadObject(val);
                dobj.LgotKat = val;
            }

            if (status == ObjectStatus.Created ||
                attrs != null && attrs.Contains(BeneficiaryPreferentialCategory.ConstBeneficiary))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Beneficiary.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Leechnost = leechnost;
            }

            if (obj.ActDisability != null &&
                (status == ObjectStatus.Created ||
                 attrs != null && attrs.Contains(BeneficiaryPreferentialCategory.ConstActDisability)))
            {
                dobj.AktInvalidnosti = null;
            }
        }
    }
}