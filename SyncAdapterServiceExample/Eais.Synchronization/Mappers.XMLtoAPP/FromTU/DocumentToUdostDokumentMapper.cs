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

    public class DocumentToUdostDokumentMapper : XmlToAppWithChangedAttrsMapper<Document, UdostDokument>
    {
        protected override View GetDestinationView()
        {
            return UdostDokument.Views.UdostDokumentE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Document source)
        {
            return source.Guid;
        }

        public override UdostDokument Map(Document source, UdostDokument dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.Seriia = source.Series;
            dest.Nomer = source.Number;
            dest.DataVydachi = (NullableDateTime) source.IssueDate;
            dest.DataPrekrashcheniia = (NullableDateTime) source.EndDate;
            dest.OrganVydDok = source.OrgName;
            dest.Primechanie = source.Note;
            dest.VidUdostDok = source.KindDocument == null
                ? null
                : PKHelper.CreateDataObject<VidUdostDok>(source.KindDocument?.Guid);
            dest.Leechnost = source.Beneficiary == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary.Guid);
            dest.KemVydan = source.IssuedBy == null
                ? null
                : PKHelper.CreateDataObject<OrganVydDok>(source.IssuedBy?.Guid);
            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;
            return dest;
        }

        public override UdostDokument Map(Document source, UdostDokument dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(Document.ConstSeries))
            {
                dest.Seriia = source.Series;
            }

            if (attrs.Contains(Document.ConstNumber))
            {
                dest.Nomer = source.Number;
            }

            if (attrs.Contains(Document.ConstIssueDate))
            {
                dest.DataVydachi = (NullableDateTime) source.IssueDate;
            }

            if (attrs.Contains(Document.ConstEndDate))
            {
                dest.DataPrekrashcheniia = (NullableDateTime) source.EndDate;
            }

            if (attrs.Contains(Document.ConstOrgName))
            {
                dest.OrganVydDok = source.OrgName;
            }

            if (attrs.Contains(Document.ConstNote))
            {
                dest.Primechanie = source.Note;
            }

            if (attrs.Contains(Document.ConstKindDocument))
            {
                dest.VidUdostDok = source.KindDocument == null
                    ? null
                    : PKHelper.CreateDataObject<VidUdostDok>(source.KindDocument?.Guid);
            }

            if (attrs.Contains(Document.ConstBeneficiary))
            {
                dest.Leechnost = source.Beneficiary == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary.Guid);
            }

            if (attrs.Contains(Document.ConstIssuedBy))
            {
                dest.KemVydan = source.IssuedBy == null
                    ? null
                    : PKHelper.CreateDataObject<OrganVydDok>(source.IssuedBy?.Guid);
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

        public override IQueryable<DataObject> GetAltKey(Document dobj, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var leechnost = MapperHelper.GetMaster(typeof(Leechnost), dobj.Beneficiary.Guid,
                defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd, ref arrConformity);
            var kindDoc = new VidUdostDok {__PrimaryKey = dobj.KindDocument.Guid};

            return defDS.Query<UdostDokument>(UdostDokument.Views.UdostDokumentE).Where(x =>
                x.Seriia == dobj.Series
                && x.Nomer == dobj.Number
                && x.VidUdostDok.__PrimaryKey.Equals(kindDoc.__PrimaryKey)
                && x.Leechnost.__PrimaryKey.Equals(leechnost.__PrimaryKey));
        }

        public override void SetMasters(Document obj, UdostDokument dobj, List<string> attrs, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();
            if (obj.KindDocument != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Document.ConstKindDocument)))
            {
                var val = new VidUdostDok();
                val.SetExistObjectPrimaryKey(obj.KindDocument.Guid);
                defDS.LoadObject(val);
                dobj.VidUdostDok = val;
            }

            if (obj.IssuedBy != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Document.ConstIssuedBy)))
            {
                var val = new OrganVydDok();
                val.SetExistObjectPrimaryKey(obj.IssuedBy.Guid);
                defDS.LoadObject(val);
                dobj.KemVydan = val;
            }

            if (status == ObjectStatus.Created || attrs != null && attrs.Contains(Document.ConstBeneficiary))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Beneficiary.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Leechnost = leechnost;
            }
        }
    }
}