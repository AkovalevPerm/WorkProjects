namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    public class ToTUPeriodToPeriodMapper : AppToXMLMapper<Period, ServiceBus.ObjectDataModel.ToTU.Period>

    {
        protected override Guid? GetSourceObjectPrimaryKey(Period source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override ServiceBus.ObjectDataModel.ToTU.Period Map(Period source, ServiceBus.ObjectDataModel.ToTU.Period dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;

            if (source.DataNachala.HasValue)
            {
                dest.StartDate = source.DataNachala.Value;
            }

            if (source.DataKontca.HasValue)
            {
                dest.EndDate = source.DataKontca.Value;
            }

            switch (source.Tip)
            {
                case tTipPerioda.pusto:
                    dest.PeriodType = tPeriodType.pusto;
                    break;
                case tTipPerioda.Mesiatc:
                    dest.PeriodType = tPeriodType.Mesiatc;
                    break;
                case tTipPerioda.Kvartal:
                    dest.PeriodType = tPeriodType.Kvartal;
                    break;
                case tTipPerioda.Polugodie:
                    dest.PeriodType = tPeriodType.Polugodie;
                    break;
                case tTipPerioda.God:
                    dest.PeriodType = tPeriodType.God;
                    break;
            }

            dest.Value = (int)source.Znachenie;

            if (source.Ierarhiia != null)
            {
                dest.Parent = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Ierarhiia).Value
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
