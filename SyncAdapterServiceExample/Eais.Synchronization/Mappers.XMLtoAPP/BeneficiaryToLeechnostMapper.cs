namespace Mappers.XMLtoAPP
{
    using System;
    using System.Collections.Generic;

    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.UserDataTypes;

    using Iis.Eais.Leechnost;

    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class BeneficiaryToLeechnostMapper : XMLToAppMapper<Beneficiary, Leechnost>
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
            dest.__PrimaryKey = source.Guid;
            dest.Familiia = source.FamilyName;
            dest.Imia = source.FirstName;
            dest.Otchestvo = source.Patronymic;
            switch (source.Gender)
            {
                case tGender.Муж:
                    dest.Pol = tPol.Muzhskoi;
                    break;
                case tGender.Жен:
                    dest.Pol = tPol.Zhenskii;
                    break;
                    
            }
            dest.DataRozhdeniia = (NullableDateTime)source.BirthDate.Value;
            dest.Snils = source.Snils;
            dest.INN = source.INN;
            dest.Mail = source.Email;
            dest.Telefon = source.Phone;
            switch (source.Education)
            {
                case tEducation.Общее:
                    dest.Obrazovanie = tObrazovanieLeechn.Obshchee;
                    break;
                case tEducation.Среднеепрофессиональное:
                    dest.Obrazovanie = tObrazovanieLeechn.SredneeProf;
                    break;
                case tEducation.Высшее:
                    dest.Obrazovanie = tObrazovanieLeechn.Vysshee;
                    break;
            }
            dest.StranaRozhdeniia = source.BirthCountry;
            dest.OblastRozhdeniia = source.BirthRegion;
            dest.GorodRozhdeniia = source.BirthTown;
            dest.RaionRozhdeniia = source.BirthDistrict;
            dest.Prozhivanie = PKHelper.CreateDataObject<Prozhivanie>(source.Location?.Guid);
            dest.Propiska = PKHelper.CreateDataObject<Prozhivanie>(source.Registration.Guid);

            return dest;
        }

        protected override DetailArray MapDetails(Leechnost aggregator, object[] source, DetailArray dest, SyncSetting setting, List<ISync> detailSeparatedMasters)
        {
            var detailArray = base.MapDetails(aggregator, source, dest, setting, detailSeparatedMasters) as DetailArrayOfUdostDokument;
            if (detailArray != null)
            {
                foreach (UdostDokument item in detailArray.GetAllObjects())
                {
                    item.Leechnost = aggregator;
                }
            }

            return detailArray;
        }
    }
}
