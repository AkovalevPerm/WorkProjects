namespace Mappers.APPtoXML.ToTU
{
    using System;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.ToTU;
    public class ToTUOrganVydDokToAuthorityIssuedDocumentMapper : AppToXMLMapper<OrganVydDok, AuthorityIssuedDocument>
    {
        protected override Guid? GetSourceObjectPrimaryKey(OrganVydDok source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override AuthorityIssuedDocument Map(OrganVydDok source, AuthorityIssuedDocument dest)
        {
            if (!PKHelper.GetGuidByObject(source).HasValue)
            {
                throw new ArgumentNullException(nameof(source));
            }

            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.Id = source.Oldid;
            dest.Name = source.Naimenovanie;
            dest.Address = source.Adres;
            dest.PhoneNumber = source.Telefon;

            if (source.OrganSZ != null)
            {
                dest.SocialProtectionAuthority = new SyncXMLDataObject()
                {
                    Guid = PKHelper.GetGuidByObject(source.OrganSZ).Value
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
