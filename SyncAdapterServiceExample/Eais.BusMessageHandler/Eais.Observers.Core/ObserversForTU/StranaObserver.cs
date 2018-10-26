namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="Strana"/>.
    /// </summary>
    public class StranaObserver : DataObjectObserver<Strana>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(Strana) };
            view.AddProperties(
                Information.ExtractPropertyPath<Strana>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<Strana>(x => x.Oldid),
                Information.ExtractPropertyPath<Strana>(x => x.PolnoeNaimenovanie),
                Information.ExtractPropertyPath<Strana>(x => x.KratkoeNaimenovanie),
                Information.ExtractPropertyPath<Strana>(x => x.TcifrKod),
                Information.ExtractPropertyPath<Strana>(x => x.BukvKodAlfa2),
                Information.ExtractPropertyPath<Strana>(x => x.BukvKodAlfa3),
                Information.ExtractPropertyPath<Strana>(x => x.CreateTime),
                Information.ExtractPropertyPath<Strana>(x => x.Creator),
                Information.ExtractPropertyPath<Strana>(x => x.EditTime),
                Information.ExtractPropertyPath<Strana>(x => x.Editor));
            return view;
        }
    }
}