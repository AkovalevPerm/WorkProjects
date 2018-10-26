namespace Mappers.XMLtoAPP
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;

    public class StreetToUlitcaMapperWithoutTerritory : XMLToAppMapper<Street, Ulitca>
    {
        protected override View GetDestinationView()
        {
            return Ulitca.Views.UlitcaE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Street source)
        {
            return source.Guid;
        }

        public override Ulitca Map(Street source, Ulitca dest)
        {
            dest.__PrimaryKey = source.Guid;
            dest.KodFIAS = source.FIAS;
            dest.VidObekta = source.ObjectType;
            dest.Naimenovanie = source.Name;
            dest.PochtIndeks = source.PostIndex;
            if (source.Territory != null)
            {
                dest.Territoriia = PKHelper.CreateDataObject<Territoriia>(source.Territory.Guid);
            }

            return dest;
        }
    }
}
