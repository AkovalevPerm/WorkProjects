namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUTipUdostDokToTypeDocumentMapper : AppToXMLMapper<TipUdostDok, TypeDocument>
    {
        protected override Guid? GetSourceObjectPrimaryKey(TipUdostDok source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override TypeDocument Map(TipUdostDok source, TypeDocument dest)
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
