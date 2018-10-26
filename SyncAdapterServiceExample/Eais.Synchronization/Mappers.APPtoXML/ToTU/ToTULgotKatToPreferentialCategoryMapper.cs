namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.ToTU;

    public class ToTULgotKatToPreferentialCategoryMapper : AppToXMLMapper<LgotKat, PreferentialCategory>
    {
        protected override Guid? GetSourceObjectPrimaryKey(LgotKat source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override PreferentialCategory Map(LgotKat source, PreferentialCategory dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;

            switch (source.Invalidnost)
            {
                case tLogicheskii.Net:
                    dest.Disability = tBool.Нет;
                    break;
                case tLogicheskii.Da:
                    dest.Disability = tBool.Да;
                    break;
            }

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
