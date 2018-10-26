namespace SyncAdapterService.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using Objects;

    public class MapperHelper
    {
        public static string sObjectType = typeof(ObjectType).FullName;
        public static string sConformity = typeof(Conformity).FullName;

        /// <summary>
        ///     Получить мастера
        /// </summary>
        /// <param name="type">Тип мастера</param>
        /// <param name="guid">ключ мастера, который пришел</param>
        /// <param name="query">запрос к конкретному источнику данных</param>
        /// <param name="source">Источник изменений</param>
        /// <param name="arrToUpd">Список обновляемых объектов данных</param>
        /// <param name="arrConformity">Список обновляемых объектов синхронизации</param>
        /// <returns>найденный объект</returns>
        public static DataObject GetMaster(Type type, Guid guid, IQueryable<DataObject> query, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            if (type == null || guid == null || query == null || source == null)
            {
                return null;
            }

            var nameType = type.FullName;
            var otype = arrConformity[sObjectType].Cast<ObjectType>().FirstOrDefault(x => x.name == nameType) ??
                        syncDS.Query<ObjectType>(ObjectType.Views.ObjectTypeE)
                            .FirstOrDefault(x => x.name == nameType) ??
                        new ObjectType {name = nameType, id = type.Name};
            if (otype.GetStatus() == ObjectStatus.Created)
            {
                arrConformity[sObjectType].Add(otype);
            }

            var conformity = arrConformity[sConformity].Cast<Conformity>().FirstOrDefault(x =>
                x.Source.__PrimaryKey.Equals(source.__PrimaryKey)
                && x.Type.__PrimaryKey.Equals(otype.__PrimaryKey) && x.pkSource.Equals(guid));
            DataObject dobj = null;
            if (conformity != null)
            {
                var obj = new PkDataObject {__PrimaryKey = conformity.pkSource};
                dobj = arrToUpd.FirstOrDefault(x =>
                    x.GetType().FullName == nameType && x.__PrimaryKey.Equals(obj.__PrimaryKey));
            }
            else
            {
                if (otype.GetStatus() != ObjectStatus.Created && source.GetStatus() != ObjectStatus.Created)
                {
                    conformity = syncDS.Query<Conformity>(Conformity.Views.ConformityE).FirstOrDefault(x =>
                        x.Source.__PrimaryKey.Equals(source.__PrimaryKey)
                        && x.Type.__PrimaryKey.Equals(otype.__PrimaryKey) && x.pkSource.Equals(guid));
                }

                if (conformity != null)
                {
                    var val = new PkDataObject {__PrimaryKey = conformity.pkSource};
                    dobj = query.FirstOrDefault(x => x.__PrimaryKey.Equals(val.__PrimaryKey));
                }
            }

            if (dobj == null)
            {
                var val = new PkDataObject {__PrimaryKey = guid};
                dobj = query.FirstOrDefault(x => x.__PrimaryKey.Equals(val.__PrimaryKey));
            }

            if (dobj == null)
            {
                throw new Exception(string.Format("Объект типа {0} c pk {1} не найден.", nameType, guid));
            }

            return dobj;
        }

        /// <summary>
        ///     Общий класс с pk
        /// </summary>
        public class PkDataObject : DataObject
        {
        }
    }
}