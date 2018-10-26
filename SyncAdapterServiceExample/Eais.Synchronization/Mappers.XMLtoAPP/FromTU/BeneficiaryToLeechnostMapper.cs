namespace Mappers.XMLtoAPP.FromTU
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.UserDataTypes;
    using Iis.Eais.Leechnost;
    using IIS.University.Tools;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using Synchronization.Objects;

    public class BeneficiaryToLeechnostMapper : XmlToAppWithChangedAttrsMapper<Beneficiary, Leechnost>
    {
        protected override View GetDestinationView()
        {
            return Leechnost.Views.LeechnostE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Beneficiary source)
        {
            return source.Guid;
        }

        public override Leechnost Map(Beneficiary source, Leechnost dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.Familiia = source.FamilyName;
            dest.Imia = source.FirstName;
            dest.Otchestvo = source.Patronymic;
            switch (source.Gender)
            {
                case tGender.Muzhskoi:
                    dest.Pol = tPol.Muzhskoi;
                    break;
                case tGender.Zhenskii:
                    dest.Pol = tPol.Zhenskii;
                    break;
            }

            dest.DataRozhdeniia = (NullableDateTime) source.BirthDate;
            dest.Snils = source.Snils;
            dest.INN = source.INN;
            dest.Mail = source.Email;
            dest.Telefon = source.Phone;
            switch (source.Education)
            {
                case tEducation.Obshchee:
                    dest.Obrazovanie = tObrazovanieLeechn.Obshchee;
                    break;
                case tEducation.SredneeProf:
                    dest.Obrazovanie = tObrazovanieLeechn.SredneeProf;
                    break;
                case tEducation.Vysshee:
                    dest.Obrazovanie = tObrazovanieLeechn.Vysshee;
                    break;
            }

            dest.StranaRozhdeniia = source.BirthCountry;
            dest.OblastRozhdeniia = source.BirthRegion;
            dest.GorodRozhdeniia = source.BirthTown;
            dest.RaionRozhdeniia = source.BirthDistrict;
            dest.ObshchiiStazh = source.TotalExperience == null ? 0 : source.TotalExperience.Value;
            dest.DopSvedeniia = source.AdditionalInformation;
            dest.Prozhivanie = source.Location == null
                ? null
                : PKHelper.CreateDataObject<Prozhivanie>(source.Location?.Guid);
            dest.Propiska = source.Registration == null
                ? null
                : PKHelper.CreateDataObject<Prozhivanie>(source.Registration?.Guid);
            dest.Grazhdanstvo = source.Citizenship == null
                ? null
                : PKHelper.CreateDataObject<Strana>(source.Citizenship?.Guid);
            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;
            return dest;
        }

        public override Leechnost Map(Beneficiary source, Leechnost dest, List<string> attrs)
        {
            if (dest.GetStatus() == ObjectStatus.Created || attrs == null)
            {
                return Map(source, dest);
            }

            if (attrs.Contains(Beneficiary.ConstFamilyName))
            {
                dest.Familiia = source.FamilyName;
            }

            if (attrs.Contains(Beneficiary.ConstFirstName))
            {
                dest.Imia = source.FirstName;
            }

            if (attrs.Contains(Beneficiary.ConstPatronymic))
            {
                dest.Otchestvo = source.Patronymic;
            }

            if (attrs.Contains(Beneficiary.ConstGender))
            {
                switch (source.Gender)
                {
                    case tGender.Muzhskoi:
                        dest.Pol = tPol.Muzhskoi;
                        break;
                    case tGender.Zhenskii:
                        dest.Pol = tPol.Zhenskii;
                        break;
                }
            }

            if (attrs.Contains(Beneficiary.ConstBirthDate))
            {
                dest.DataRozhdeniia = (NullableDateTime) source.BirthDate;
            }

            if (attrs.Contains(Beneficiary.ConstSnils))
            {
                dest.Snils = source.Snils;
            }

            if (attrs.Contains(Beneficiary.ConstINN))
            {
                dest.INN = source.INN;
            }

            if (attrs.Contains(Beneficiary.ConstEmail))
            {
                dest.Mail = source.Email;
            }

            if (attrs.Contains(Beneficiary.ConstPhone))
            {
                dest.Telefon = source.Phone;
            }

            if (attrs.Contains(Beneficiary.ConstEducation))
            {
                switch (source.Education)
                {
                    case tEducation.Obshchee:
                        dest.Obrazovanie = tObrazovanieLeechn.Obshchee;
                        break;
                    case tEducation.SredneeProf:
                        dest.Obrazovanie = tObrazovanieLeechn.SredneeProf;
                        break;
                    case tEducation.Vysshee:
                        dest.Obrazovanie = tObrazovanieLeechn.Vysshee;
                        break;
                }
            }

            if (attrs.Contains(Beneficiary.ConstBirthCountry))
            {
                dest.StranaRozhdeniia = source.BirthCountry;
            }

            if (attrs.Contains(Beneficiary.ConstBirthRegion))
            {
                dest.OblastRozhdeniia = source.BirthRegion;
            }

            if (attrs.Contains(Beneficiary.ConstBirthTown))
            {
                dest.GorodRozhdeniia = source.BirthTown;
            }

            if (attrs.Contains(Beneficiary.ConstBirthDistrict))
            {
                dest.RaionRozhdeniia = source.BirthDistrict;
            }

            if (attrs.Contains(Beneficiary.ConstTotalExperience))
            {
                dest.ObshchiiStazh = source.TotalExperience == null ? 0 : source.TotalExperience.Value;
            }

            if (attrs.Contains(Beneficiary.ConstAdditionalInformation))
            {
                dest.DopSvedeniia = source.AdditionalInformation;
            }

            if (attrs.Contains(Beneficiary.ConstLocation))
            {
                dest.Prozhivanie = source.Location == null
                    ? null
                    : PKHelper.CreateDataObject<Prozhivanie>(source.Location?.Guid);
            }

            if (attrs.Contains(Beneficiary.ConstRegistration))
            {
                dest.Propiska = source.Registration == null
                    ? null
                    : PKHelper.CreateDataObject<Prozhivanie>(source.Registration?.Guid);
            }

            if (attrs.Contains(Beneficiary.ConstCitizenship))
            {
                dest.Grazhdanstvo = source.Citizenship == null
                    ? null
                    : PKHelper.CreateDataObject<Strana>(source.Citizenship?.Guid);
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

        public override IQueryable<DataObject> GetAltKey(Beneficiary obj, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            return null;
        }

        public override void SetMasters(Beneficiary beneficiary, Leechnost dest, List<string> attrs, IDataService defDS,
            IDataService syncDS, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            var status = dest.GetStatus();

            if (beneficiary.Location != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Beneficiary.ConstLocation)))
            {
                var prozivanie = Helper.GetProzhivanie(beneficiary.Location, defDS, syncDS, source, ref arrToUpd,
                    ref arrConformity);
                var address = new Prozhivanie();
                address.SetExistObjectPrimaryKey(prozivanie.__PrimaryKey);
                address.SetStatus(ObjectStatus.UnAltered);
                dest.Prozhivanie = address;
            }

            if (beneficiary.Registration != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Beneficiary.ConstRegistration)))
            {
                var propiska = Helper.GetProzhivanie(beneficiary.Registration, defDS, syncDS, source,
                    ref arrToUpd, ref arrConformity);
                var address = new Prozhivanie();
                address.SetExistObjectPrimaryKey(propiska.__PrimaryKey);
                address.SetStatus(ObjectStatus.UnAltered);
                dest.Propiska = address;
            }

            if (beneficiary.Citizenship != null &&
                (status == ObjectStatus.Created || attrs != null && attrs.Contains(Beneficiary.ConstCitizenship)))
            {
                var val = new Strana();
                val.SetExistObjectPrimaryKey(beneficiary.Citizenship.Guid);
                defDS.LoadObject(val);
                dest.Grazhdanstvo = val;
            }
        }
    }
}