namespace Mappers.APPtoXML
{
    using System;
    using System.Collections.Generic;

    using ICSSoft.STORMNET;

    using Iis.Eais.Leechnost;

    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    using Prozhivanie = Iis.Eais.Catalogs.Prozhivanie;

    public class LeechnostToBeneficiaryMapper : AppToXMLMapper<Leechnost, Beneficiary>
    {
        protected override View GetSourceView()
        {
            return Leechnost.Views.LeechnostE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Leechnost source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        /// <summary>
        /// Дополнительные представления для вложенных isSeparatedMaster объектов.
        /// </summary>
        /// <returns>Views.</returns>
        protected override View[] GetSourceViews()
        {
            return new[]{ Prozhivanie.Views.ProzhivanieE };
        }

        public override Beneficiary Map(Leechnost source, Beneficiary dest)
        {
            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.FamilyName = source.Familiia;
            dest.FirstName = source.Imia;
            dest.Patronymic = source.Otchestvo;
            switch (source.Pol)
            {
                case tPol.Muzhskoi:
                    dest.Gender = tGender.Муж;
                    break;
                case tPol.Zhenskii:
                    dest.Gender = tGender.Жен;
                    break;
            }
            dest.BirthDate = source.DataRozhdeniia?.Value;
            dest.Snils = source.Snils;
            dest.INN = source.INN;
            dest.Email = source.Mail;
            dest.Phone = source.Telefon;
            switch (source.Obrazovanie)
            {
                case tObrazovanieLeechn.Pusto:
                    dest.Education = tEducation.Общее;
                    break;
                case tObrazovanieLeechn.Obshchee:
                    dest.Education = tEducation.Общее;
                    break;
                case tObrazovanieLeechn.SredneeProf:
                    dest.Education = tEducation.Среднеепрофессиональное;
                    break;
                case tObrazovanieLeechn.Vysshee:
                    dest.Education = tEducation.Высшее;
                    break;
            }
            dest.BirthCountry = source.StranaRozhdeniia;
            dest.BirthRegion = source.OblastRozhdeniia;
            dest.BirthTown = source.GorodRozhdeniia;
            dest.BirthDistrict = source.RaionRozhdeniia;
            if (source.Prozhivanie != null)
            {
                dest.Location = new Location()
                {
                    Guid = PKHelper.GetGuidByObject(source.Prozhivanie).Value
                };
            }

            if (source.Propiska != null)
            {
                dest.Registration = new Registration()
                {
                    Guid = PKHelper.GetGuidByObject(source.Propiska).Value
                };
            }

            return dest;
        }

        protected override object[] MapDetails(DetailArray source, SyncSetting setting, List<ISync> detailSeparatedMasters)
        {
            Document[] result = null;
            var details = base.MapDetails(source, setting, detailSeparatedMasters);
            if (details != null)
            {
                result = new Document[details.Length];
                for (int i = 0; i < details.Length; i++)
                {
                    result[i] = (Document) details[i];
                }
            }

            return result;
        }
    }
}
