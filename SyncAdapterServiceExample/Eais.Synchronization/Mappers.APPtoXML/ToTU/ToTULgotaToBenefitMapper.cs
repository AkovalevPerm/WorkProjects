namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTULgotaToBenefitMapper : AppToXMLMapper<Lgota, Benefit>
    {
        protected override Guid? GetSourceObjectPrimaryKey(Lgota source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Benefit Map(Lgota source, Benefit dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;

            switch (source.VclVSotcPaket)
            {
                case tLogicheskii.Net:
                    dest.InSocialPackage = tBool.Нет;
                    break;
                case tLogicheskii.Da:
                    dest.InSocialPackage = tBool.Да;
                    break;
            }

            dest.CodeIncome = source.KodDohoda;
            dest.TaxedNDFL = source.OblagNDFL == tLogicheskii.Da ? tBool.Да : tBool.Нет;
            dest.TaxedESN = source.OblagESN == tLogicheskii.Da ? tBool.Да : tBool.Нет;

            if (source.Ierarhiia != null)
            {
                dest.Parent = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Ierarhiia).Value
                };
            }

            if (source.Tip != null)
            {
                dest.TypeBenefit = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Tip).Value
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
