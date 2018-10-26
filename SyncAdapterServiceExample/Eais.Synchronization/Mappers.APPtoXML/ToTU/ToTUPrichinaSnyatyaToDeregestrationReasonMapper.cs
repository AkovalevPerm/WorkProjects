namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUPrichinaSnyatyaToDeregestrationReasonMapper : AppToXMLMapper<PrichinaSnyatiya, DeregestrationReason>
    {
        protected override Guid? GetSourceObjectPrimaryKey(PrichinaSnyatiya source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override DeregestrationReason Map(PrichinaSnyatiya source, DeregestrationReason dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;

            switch (source.PrekraschVyiplatyi)
            {
                case tLogicheskii.Net:
                    dest.Discontinuation = tBool.Нет;
                    break;
                case tLogicheskii.Da:
                    dest.Discontinuation = tBool.Да;
                    break;
            }

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }
    }
}
