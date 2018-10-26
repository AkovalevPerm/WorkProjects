namespace Mappers.XMLtoAPP.FromTU
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using Iis.Eais.Catalogs;
    using ServiceBus.ObjectDataModel.FromTU;
    using Synchronization.Objects;

    public static class Helper
    {
        /// <summary>
        ///     Получить проживание
        /// </summary>
        /// <param name="address">Адрес источника</param>
        /// <param name="source">Наименование источника</param>
        /// <returns>Проживание</returns>
        public static Prozhivanie GetProzhivanie(Address address, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            if (address == null)
            {
                return null;
            }

            var type = typeof(Prozhivanie);
            var nameType = type.FullName;

            //сначала поищем среди объектов на обновление
            var obj = new MapperHelper.PkDataObject {__PrimaryKey = address.Guid};
            var prozivanie = (Prozhivanie) arrToUpd.FirstOrDefault(x =>
                x.GetType().FullName == nameType && x.__PrimaryKey.Equals(obj.__PrimaryKey));
            if (prozivanie != null)
            {
                return prozivanie;
            }

            var typeAddress = arrConformity[MapperHelper.sObjectType].Cast<ObjectType>()
                                  .FirstOrDefault(x => x.name == nameType) ??
                              syncDS.Query<ObjectType>(ObjectType.Views.ObjectTypeE)
                                  .FirstOrDefault(x => x.name == nameType) ??
                              new ObjectType {name = nameType, id = type.Name};
            if (typeAddress.GetStatus() == ObjectStatus.Created)
            {
                arrConformity[MapperHelper.sObjectType].Add(typeAddress);
            }

            var conformity = arrConformity[MapperHelper.sConformity].Cast<Conformity>().FirstOrDefault(x =>
                x.Source.__PrimaryKey.Equals(source.__PrimaryKey)
                && x.Type.__PrimaryKey.Equals(typeAddress.__PrimaryKey) && x.pkSource.Equals(address.Guid));


            if (conformity == null && typeAddress.GetStatus() != ObjectStatus.Created &&
                source.GetStatus() != ObjectStatus.Created)
            {
                conformity = syncDS.Query<Conformity>(Conformity.Views.ConformityE).FirstOrDefault(x =>
                    x.Source.__PrimaryKey.Equals(source.__PrimaryKey)
                    && x.Type.__PrimaryKey.Equals(typeAddress.__PrimaryKey) && x.pkSource.Equals(address.Guid));
            }

            if (conformity == null)
            {
                var adr = new Prozhivanie {__PrimaryKey = address.Guid};
                prozivanie = defDS.Query<Prozhivanie>(Prozhivanie.Views.ProzhivanieE)
                    .FirstOrDefault(x => x.__PrimaryKey.Equals(adr.__PrimaryKey));
                if (prozivanie == null)
                {
                    var terr = address.Territory.Guid.ToString();
                    var query = defDS.Query<Prozhivanie>(Prozhivanie.Views.ProzhivanieE).Where(x =>
                        x.Territoriia.__PrimaryKey.ToString().Equals(terr)
                        && x.NomerDoma == address.Number
                        && x.NomerStroeniia == address.HouseNumber
                        && x.Kvartira == address.Appartment);

                    if (address.Street == null)
                    {
                        query = query.Where(x => x.Ulitca == null);
                    }
                    else
                    {
                        var street = address.Street?.Guid.ToString();
                        query = query.Where(x => x.Ulitca != null && x.Ulitca.__PrimaryKey.ToString().Equals(street));
                    }

                    prozivanie = query.FirstOrDefault();
                }
            }
            else
            {
                obj = new MapperHelper.PkDataObject {__PrimaryKey = conformity.pkDest};
                prozivanie = defDS.Query<Prozhivanie>(Prozhivanie.Views.ProzhivanieE).FirstOrDefault(x =>
                    x.__PrimaryKey.Equals(obj.__PrimaryKey));

                prozivanie = new AddressToProzhivanieMapper().Map(address, prozivanie);
                if (prozivanie.GetStatus() == ObjectStatus.Altered)
                {
                    arrToUpd.Add(prozivanie);
                }
            }

            if (prozivanie == null)
            {
                prozivanie = new Prozhivanie();
                prozivanie = new AddressToProzhivanieMapper().Map(address, prozivanie);
                arrToUpd.Add(prozivanie);
            }

            if (conformity == null)
            {
                conformity = new Conformity
                {
                    Source = source,
                    Type = typeAddress,
                    pkSource = address.Guid,
                    pkDest = new Guid(prozivanie.__PrimaryKey.ToString())
                };
                arrConformity[MapperHelper.sConformity].Add(conformity);
            }

            return prozivanie;
        }
    }
}