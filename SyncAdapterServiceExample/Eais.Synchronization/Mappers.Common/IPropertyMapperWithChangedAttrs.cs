namespace Mappers.XMLtoAPP
{
    using System.Collections.Generic;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers;
    using Synchronization.Objects;

    public interface IPropertyMapperWithChangedAttrs : IPropertyMapper
    {
        /// <summary>
        ///     Get View
        /// </summary>
        /// <returns></returns>
        View GetView();

        /// <summary>
        ///     Map object from Source to Destination types.
        /// </summary>
        /// <param name="source">Object from Source system.</param>
        /// <returns>An object that represents the Destination type.</returns>
        DataObject Map(object source, DataObject dest, List<string> attrs);

        /// <summary>
        ///     Получить альтернативный ключ поиска объекта
        /// </summary>
        /// <param name="obj">объект, который пришел</param>
        /// <param name="defDS">DataService по умолчанию</param>
        /// <param name="syncDS">DataService синхронизации</param>
        /// <param name="source">Источник изменений</param>
        /// <param name="arrToUpd">Список обновляемых объектов данных</param>
        /// <param name="arrConformity">Список обновляемых объектов синхронизации</param>
        /// <returns></returns>
        IQueryable<DataObject> GetAltKey(object obj, IDataService defDS, IDataService syncDS, Source source,
            ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity);

        /// <summary>
        ///     Установить мастера
        /// </summary>
        /// <param name="obj">объект, который пришел</param>
        /// <param name="dobj">целевой объект</param>
        /// <param name="attrs">список изменяемых свойств</param>
        /// <param name="defDS">DataService по умолчанию</param>
        /// <param name="syncDS">DataService синхронизации</param>
        /// <param name="source">Источник изменений</param>
        /// <param name="arrToUpd">Список обновляемых объектов данных</param>
        /// <param name="arrConformity">Список обновляемых объектов синхронизации</param>
        void SetMasters(object obj, DataObject dobj, List<string> attrs, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity);
    }

    public interface IPropertyMapperWithChangedAttrs<TIn, TOut>
        where TIn : class, ISync, new()
        where TOut : DataObject, new()
    {
        /// <summary>
        ///     Synchronization setting.
        /// </summary>
        SyncSetting Setting { get; set; }

        /// <summary>
        ///     Map object from Source to Destination types.
        /// </summary>
        /// <param name="source">Object from Source system.</param>
        /// <returns>An object that represents the Destination type.</returns>
        TOut Map(TIn source, TOut dest, List<string> attrs);

        IQueryable<DataObject> GetAltKey(TIn obj, IDataService defDS, IDataService syncDS, Source source,
            ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity);

        void SetMasters(TIn obj, TOut dobj, List<string> attrs, IDataService defDS, IDataService syncDS, Source source,
            ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity);
    }
}