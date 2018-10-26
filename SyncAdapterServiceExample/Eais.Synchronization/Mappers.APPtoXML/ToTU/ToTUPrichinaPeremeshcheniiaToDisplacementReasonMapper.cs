namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUPrichinaPeremeshcheniiaToDisplacementReasonMapper : AppToXMLMapper<PrichinaPeremeshcheniia, DisplacementReason>
    {
        protected override Guid? GetSourceObjectPrimaryKey(PrichinaPeremeshcheniia source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override DisplacementReason Map(PrichinaPeremeshcheniia source, DisplacementReason dest)
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
