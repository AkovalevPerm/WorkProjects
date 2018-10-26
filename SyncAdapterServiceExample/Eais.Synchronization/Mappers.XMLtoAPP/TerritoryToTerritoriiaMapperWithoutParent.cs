namespace Mappers.XMLtoAPP
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class TerritoryToTerritoriiaMapperWithoutParent : XMLToAppMapper<Territory, Territoriia>
    {
        protected override View GetDestinationView()
        {
            return Territoriia.Views.TerritoriiaE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Territory source)
        {
            return source.Guid;
        }

        public override Territoriia Map(Territory source, Territoriia dest)
        {
            dest.__PrimaryKey = source.Guid;
            dest.KodFIAS = source.FIAS;
            dest.VidObekta = source.ObjectType;
            dest.Naimenovanie = source.Name;
            dest.PochtIndeks = source.PostIndex;

            return dest;
        }
    }
}
