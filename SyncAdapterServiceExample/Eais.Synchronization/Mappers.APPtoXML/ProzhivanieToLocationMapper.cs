namespace Mappers.APPtoXML
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;

    public class ProzhivanieToLocationMapper : AppToXMLMapper<Prozhivanie, Location>
    {
        protected override View GetSourceView()
        {
            return Prozhivanie.Views.ProzhivanieE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Prozhivanie source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Location Map(Prozhivanie source, Location dest)
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
