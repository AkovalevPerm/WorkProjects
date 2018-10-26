namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.ToTU;

    public class ToTUStatiaAktaToActMapper : AppToXMLMapper<StatiaAkta, Act>
    {
        protected override Guid? GetSourceObjectPrimaryKey(StatiaAkta source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Act Map(StatiaAkta source, Act dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Number = source.Nomer;
            dest.Comments = source.Kommentarii;
            dest.Benefit = source.Lgota;
            dest.Code = source.Kod;

            if (source.Akt != null)
            {
                dest.LegalAct = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.Akt).Value
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
