﻿namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUTipLgotyToTypeBenefitMapper : AppToXMLMapper<TipLgoty, TypeBenefit>
    {
        protected override Guid? GetSourceObjectPrimaryKey(TipLgoty source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override TypeBenefit Map(TipLgoty source, TypeBenefit dest)
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
