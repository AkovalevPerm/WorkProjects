namespace BusMessageHandler.Loaders
{
    using ICSSoft.STORMNET.Business;
    using Iis.Eais.Catalogs;
    using IIS.University.Tools;
    using System.Linq;

    /// <summary>
    /// Загрузчик объектов <see cref="ForeignCatValueLoader">
    /// </summary>
    public class ForeignCatValueLoader
    {
        /// <summary>
        /// Сервис данных.
        /// </summary>
        private IDataService _ds;

        public ForeignCatValueLoader(IDataService dataService)
        {
            _ds = dataService;
        }

        /// <summary>
        /// Загрузка <see cref="ForeignCatValue"/> по code.
        /// </summary>        
        public ForeignCatValue LoadForeignCatValueByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }

            var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(ForeignCatValue), ForeignCatValue.Views.ForeignCatValueE);
            lcs.LimitFunction = FunctionBuilder.BuildEquals<ForeignCatValue>(x => x.Code, code);
            return _ds.LoadObjects(lcs).Cast<ForeignCatValue>().FirstOrDefault();
        }        
    }
}
