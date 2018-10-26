namespace Mappers.XMLtoAPP.FromTU
{
    using System;
    using ICSSoft.STORMNET;
    using Iis.Eais.Catalogs;
    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;
    using ServiceBus.ObjectDataModel.FromTU;

    public class AddressToProzhivanieMapper : XMLToAppMapper<Address, Prozhivanie>
    {
        protected override View GetDestinationView()
        {
            return Prozhivanie.Views.ProzhivanieE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Address source)
        {
            return source.Guid;
        }

        public override Prozhivanie Map(Address source, Prozhivanie dest)
        {
            if (dest.GetStatus() == ObjectStatus.Created)
            {
                dest.__PrimaryKey = source.Guid;
            }

            dest.NomerDoma = source.Number;
            dest.Kvartira = source.Appartment;
            dest.NomerStroeniia = source.HouseNumber;
            if (source.Territory != null)
            {
                dest.Territoriia = PKHelper.CreateDataObject<Territoriia>(source.Territory.Guid);
            }

            if (source.Street != null)
            {
                dest.Ulitca = PKHelper.CreateDataObject<Ulitca>(source.Street.Guid);
            }

            return dest;
        }
    }
}