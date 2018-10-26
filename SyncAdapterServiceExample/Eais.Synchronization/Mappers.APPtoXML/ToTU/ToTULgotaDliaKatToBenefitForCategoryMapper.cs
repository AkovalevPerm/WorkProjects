namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.ToTU;

    public class ToTULgotaDliaKatToBenefitForCategoryMapper : AppToXMLMapper<LgotaDliaKat, BenefitForCategory>
    {
        protected override Guid? GetSourceObjectPrimaryKey(LgotaDliaKat source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override BenefitForCategory Map(LgotaDliaKat source, BenefitForCategory dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.AppointmentDate = source.DataNaznacheniia;
            dest.CancellationDate = source.DataOtmeny;

            switch (source.PeriodPredost)
            {
                case tTipPerioda.pusto:
                    dest.Period = tPeriodType.pusto;
                    break;
                case tTipPerioda.Mesiatc:
                    dest.Period = tPeriodType.Mesiatc;
                    break;
                case tTipPerioda.Kvartal:
                    dest.Period = tPeriodType.Kvartal;
                    break;
                case tTipPerioda.Polugodie:
                    dest.Period = tPeriodType.Polugodie;
                    break;
                case tTipPerioda.God:
                    dest.Period = tPeriodType.God;
                    break;
            }

            dest.PaymentType = source.TipVyplaty;

            if (source.Lgota != null)
            {
                dest.Benefit = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Lgota).Value
                };
            }

            if (source.IstochnikFin != null)
            {
                dest.FundingSource = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.IstochnikFin).Value
                };
            }

            if (source.Osnovanie != null)
            {
                dest.Reason = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Osnovanie).Value
                };
            }

            if (source.Kategoriia != null)
            {
                dest.PreferentialCategory = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Kategoriia).Value
                };
            }

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }
    }
}
