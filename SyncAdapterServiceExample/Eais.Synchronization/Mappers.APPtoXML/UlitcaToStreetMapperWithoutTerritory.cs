namespace Mappers.APPtoXML
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class UlitcaToStreetMapperWithoutTerritory : AppToXMLMapper<Ulitca, Street>
    {
        protected override View GetSourceView()
        {
            return Ulitca.Views.UlitcaE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Ulitca source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Street Map(Ulitca source, Street dest)
        {
            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.FIAS = source.KodFIAS;
            dest.ObjectType = source.VidObekta;
            if (source.Naimenovanie?.Length > 255)
            {
                throw new ArgumentOutOfRangeException($"{nameof(source.Naimenovanie)} more than 80 symbols!");
            }
            dest.Name = source.Naimenovanie;
            dest.PostIndex = source.PochtIndeks;
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
