namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="Period"/>.
    /// </summary>
    public class PeriodObserver : DataObjectObserver<Period>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(Period) };
            view.AddProperties(
                Information.ExtractPropertyPath<Period>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<Period>(x => x.Oldid),
                Information.ExtractPropertyPath<Period>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<Period>(x => x.DataNachala),
                Information.ExtractPropertyPath<Period>(x => x.DataKontca),
                Information.ExtractPropertyPath<Period>(x => x.Tip),
                Information.ExtractPropertyPath<Period>(x => x.Znachenie),
                Information.ExtractPropertyPath<Period>(x => x.Ierarhiia),
                Information.ExtractPropertyPath<Period>(x => x.Ierarhiia.__PrimaryKey),
                Information.ExtractPropertyPath<Period>(x => x.CreateTime),
                Information.ExtractPropertyPath<Period>(x => x.Creator),
                Information.ExtractPropertyPath<Period>(x => x.EditTime),
                Information.ExtractPropertyPath<Period>(x => x.Editor));
            return view;
        }
    }
}