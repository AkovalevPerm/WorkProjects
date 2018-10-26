namespace Mappers.XMLtoAPP
{
    using System.Collections.Generic;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers.Generic;
    using Synchronization.Objects;

    public abstract class XmlToAppWithChangedAttrsMapper<TIn, TOut> : XMLToAppMapper<TIn, TOut>,
        IPropertyMapperWithChangedAttrs<TIn, TOut>, IPropertyMapperWithChangedAttrs
        where TIn : class, ISync, new()
        where TOut : DataObject, ISync, new()
    {
        public DataObject Map(object source, DataObject dest, List<string> attrs)
        {
            return Map(source as TIn, dest as TOut, attrs);
        }

        public IQueryable<DataObject> GetAltKey(object obj, IDataService defDS, IDataService syncDS, Source source,
            ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            return GetAltKey(obj as TIn, defDS, syncDS, source, ref arrToUpd, ref arrConformity);
        }

        public void SetMasters(object obj, DataObject dobj, List<string> attrs, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity)
        {
            SetMasters(obj as TIn, dobj as TOut, attrs, defDS, syncDS, source, ref arrToUpd, ref arrConformity);
        }

        public View GetView()
        {
            return GetDestinationView();
        }

        public abstract TOut Map(TIn source, TOut dest, List<string> attrs);

        public abstract IQueryable<DataObject> GetAltKey(TIn obj, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity);

        public abstract void SetMasters(TIn obj, TOut dobj, List<string> attrs, IDataService defDS, IDataService syncDS,
            Source source, ref List<DataObject> arrToUpd, ref Dictionary<string, List<DataObject>> arrConformity);
    }
}