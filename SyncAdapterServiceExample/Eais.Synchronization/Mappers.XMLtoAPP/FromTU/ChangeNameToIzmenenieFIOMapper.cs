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


    public class ChangeNameToIzmenenieFIOMapper : XmlToAppWithChangedAttrsMapper<ChangeName, IzmenenieFIO>
    {
        protected override View GetDestinationView()
        {
            return IzmenenieFIO.Views.IzmenenieFIOL;
        }

        protected override Guid? GetSourceObjectPrimaryKey(ChangeName source)
        {
            return source.Guid;
        }

        public override IzmenenieFIO Map(ChangeName source, IzmenenieFIO dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.Familiia = source.FamilyName;
            dest.Imia = source.FirstName;
            dest.Otchestvo = source.Patronymic;
            dest.DataIzmeneniiaDannykh = (NullableDateTime) source.ChangeDate;
            dest.Leechnost = source.Beneficiary == null
                ? null
                : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary?.Guid);
            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;
            return dest;
        }

        public override IzmenenieFIO Map(ChangeName source, IzmenenieFIO dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(ChangeName.ConstFamilyName))
            {
                dest.Familiia = source.FamilyName;
            }

            if (attrs.Contains(ChangeName.ConstFirstName))
            {
                dest.Imia = source.FirstName;
            }

            if (attrs.Contains(ChangeName.ConstPatronymic))
            {
                dest.Otchestvo = source.Patronymic;
            }

            if (attrs.Contains(ChangeName.ConstChangeDate))
            {
                dest.DataIzmeneniiaDannykh = (NullableDateTime) source.ChangeDate;
            }

            if (attrs.Contains(ChangeName.ConstBeneficiary))
            {
                dest.Leechnost = source.Beneficiary == null
                    ? null
                    : PKHelper.CreateDataObject<Leechnost>(source.Beneficiary?.Guid);
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

        public override IQueryable<DataObject> GetAltKey(ChangeName dobj, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var leechnost = MapperHelper.GetMaster(typeof(Leechnost), dobj.Beneficiary.Guid,
                defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd, ref arrConformity);
            var date = (NullableDateTime) dobj.ChangeDate;

            return defDS.Query<IzmenenieFIO>(IzmenenieFIO.Views.IzmenenieFIOL).Where(x =>
                x.Familiia == dobj.FamilyName
                && x.Imia == dobj.FirstName
                && x.Otchestvo == dobj.Patronymic
                && x.DataIzmeneniiaDannykh == date
                && x.Leechnost.__PrimaryKey.Equals(leechnost.__PrimaryKey));
        }

        public override void SetMasters(ChangeName obj, IzmenenieFIO dobj, List<string> attrs, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dobj.GetStatus();

            if (status == ObjectStatus.Created || attrs != null && attrs.Contains(ChangeName.ConstBeneficiary))
            {
                var leechnost = (Leechnost) MapperHelper.GetMaster(typeof(Leechnost), obj.Beneficiary.Guid,
                    defDS.Query<Leechnost>(Leechnost.Views.LeechnostE), syncDS, source, ref arrToUpd,
                    ref arrConformity);
                dobj.Leechnost = leechnost;
            }
        }
    }
}