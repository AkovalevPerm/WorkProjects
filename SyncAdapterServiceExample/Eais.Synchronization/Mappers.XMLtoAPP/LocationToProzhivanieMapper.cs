﻿namespace Mappers.XMLtoAPP
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class LocationToProzhivanieMapper : XMLToAppMapper<Location, Prozhivanie>
    {
        protected override View GetDestinationView()
        {
            return Prozhivanie.Views.ProzhivanieE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Location source)
        {
            return source.Guid;
        }

        public override Prozhivanie Map(Location source, Prozhivanie dest)
        {
            dest.__PrimaryKey = source.Guid;
            dest.NomerDoma = source.Number;
            dest.Kvartira = source.Appartment;
            dest.NomerStroeniia = source.HouseNumber;
            dest.PochtIndeks = source.Index;
            dest.Telefon = source.Phone;

            if (source.Territory != null)
            {
                dest.Territoriia = PKHelper.CreateDataObject<Territoriia>(source.Territory.Guid);
            }

            return dest;
        }
    }
}
