namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="TipUdostDok"/>.
    /// </summary>
    public class TipUdostDokObserver : DataObjectObserver<TipUdostDok>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(TipUdostDok) };
            view.AddProperties(
                Information.ExtractPropertyPath<TipUdostDok>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<TipUdostDok>(x => x.Oldid),
                Information.ExtractPropertyPath<TipUdostDok>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<TipUdostDok>(x => x.CreateTime),
                Information.ExtractPropertyPath<TipUdostDok>(x => x.Creator),
                Information.ExtractPropertyPath<TipUdostDok>(x => x.EditTime),
                Information.ExtractPropertyPath<TipUdostDok>(x => x.Editor));
            return view;
        }
    }
}