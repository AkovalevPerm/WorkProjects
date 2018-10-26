namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.ToTU;

    public class ToTUStranaToCountryMapper : AppToXMLMapper<Strana, Country>
    {
        protected override Guid? GetSourceObjectPrimaryKey(Strana source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Country Map(Strana source, Country dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.FullName = source.PolnoeNaimenovanie;
            dest.ShortName = source.KratkoeNaimenovanie;
            dest.NumericCode = (int)source.TcifrKod;
            dest.CodeAlpha2 = source.BukvKodAlfa2;
            dest.CodeAlpha3 = source.BukvKodAlfa3;

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }
    }
}
