namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;

    public class ToTUSpecialistToSpecialistMapper : AppToXMLMapper<Specialist, ServiceBus.ObjectDataModel.ToTU.Specialist>
    {
        protected override Guid? GetSourceObjectPrimaryKey(Specialist source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override ServiceBus.ObjectDataModel.ToTU.Specialist Map(Specialist source, ServiceBus.ObjectDataModel.ToTU.Specialist dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.FamilyName = source.Familiya;
            dest.FirstName = source.Imya;
            dest.Patronymic = source.Otchestvo;

            switch (source.RukOrganaCZ)
            {
                case tLogicheskii.Net:
                    dest.ChiefSPA = tBool.Нет;
                    break;
                case tLogicheskii.Da:
                    dest.ChiefSPA = tBool.Да;
                    break;
            }

            if (source.OrganSZ != null)
            {
                dest.SocialProtectionAuthority = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.OrganSZ).Value
                };
            }

            dest.Login = source.Agent.Login;

            dest.CreateTime = source.CreateTime;
            dest.Creator = source.Creator;
            dest.EditTime = source.EditTime;
            dest.Editor = source.Editor;

            return dest;
        }
    }
}
