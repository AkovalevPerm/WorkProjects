namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.ToTU;

    public class ToTURodstvOtnToFamilyRelationMapper : AppToXMLMapper<RodstvOtn, FamilyRelation>
    {
        protected override Guid? GetSourceObjectPrimaryKey(RodstvOtn source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override FamilyRelation Map(RodstvOtn source, FamilyRelation dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;

            switch (source.Pol)
            {
                case tPol.Muzhskoi:
                    dest.Gender = tGender.Muzhskoi;
                    break;
                case tPol.Zhenskii:
                    dest.Gender = tGender.Zhenskii;
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
