namespace Mappers.APPtoXML
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class ProzhivanieToRegistrationMapper : AppToXMLMapper<Prozhivanie, Registration>
    {
        protected override View GetSourceView()
        {
            return Prozhivanie.Views.ProzhivanieE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Prozhivanie source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Registration Map(Prozhivanie source, Registration dest)
        {
            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            if (source.NomerDoma == null)
            {
                throw new ArgumentNullException(nameof(Prozhivanie.NomerDoma));
            }
            dest.Number = source.NomerDoma.Value;
            dest.HouseNumber = source.NomerStroeniia;
            dest.Index = source.PochtIndeks;
            dest.Appartment = source.Kvartira;
            dest.Phone = source.Telefon;

            if (source.Territoriia != null)
            {
                dest.Territory = new Territory()
                {
                    Guid = PKHelper.GetGuidByObject(source.Territoriia).Value
                };
            }

            return dest;
        }
    }
}
