namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUUrovenVlastiToGovernmentLevelMapper : AppToXMLMapper<UrovenVlasti, GovernmentLevel>
    {
        protected override Guid? GetSourceObjectPrimaryKey(UrovenVlasti source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override GovernmentLevel Map(UrovenVlasti source, GovernmentLevel dest)
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
