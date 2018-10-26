namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUTipNormAktaToTypeLegalActMapper : AppToXMLMapper<TipNormAkta, TypeLegalAct>
    {
        protected override Guid? GetSourceObjectPrimaryKey(TipNormAkta source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override TypeLegalAct Map(TipNormAkta source, TypeLegalAct dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }
    }
}
