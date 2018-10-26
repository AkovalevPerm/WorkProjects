namespace BusMessageHandler.Loaders
{
    using ICSSoft.STORMNET.Business;
    using Iis.Eais.Catalogs;
    using IIS.University.Tools;
    using System.Linq;

    /// <summary>
    /// Загрузчик объектов <see cref="Catalog">
    /// </summary>
    public class CatalogLoader
    {
        /// <summary>
        /// Сервис данных.
        /// </summary>
        private IDataService _ds;

        public CatalogLoader(IDataService dataService)
        {
            _ds = dataService;
        }

        /// <summary>
        /// Загрузка <see cref="Catalog"/> по code.
        /// </summary>        
        public Catalog LoadCatalog(string code)
        {
            var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Catalog), Catalog.Views.CatalogE);
            lcs.LimitFunction = FunctionBuilder.BuildEquals<Catalog>(x => x.Code, code);
            return _ds.LoadObjects(lcs).Cast<Catalog>().FirstOrDefault();
        }
    }
}
