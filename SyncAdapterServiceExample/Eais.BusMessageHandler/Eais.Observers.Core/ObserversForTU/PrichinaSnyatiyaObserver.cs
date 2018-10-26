namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="PrichinaSnyatiya"/>.
    /// </summary>
    public class PrichinaSnyatiyaObserver : DataObjectObserver<PrichinaSnyatiya>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(PrichinaSnyatiya) };
            view.AddProperties(
                Information.ExtractPropertyPath<PrichinaSnyatiya>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<PrichinaSnyatiya>(x => x.Oldid),
                Information.ExtractPropertyPath<PrichinaSnyatiya>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<PrichinaSnyatiya>(x => x.PrekraschVyiplatyi),
                Information.ExtractPropertyPath<PrichinaSnyatiya>(x => x.CreateTime),
                Information.ExtractPropertyPath<PrichinaSnyatiya>(x => x.Creator),
                Information.ExtractPropertyPath<PrichinaSnyatiya>(x => x.EditTime),
                Information.ExtractPropertyPath<PrichinaSnyatiya>(x => x.Editor));
            return view;
        }
    }
}