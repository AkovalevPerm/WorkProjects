namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="TipLgoty"/>.
    /// </summary>
    public class TipLgotyObserver : DataObjectObserver<TipLgoty>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(TipLgoty) };
            view.AddProperties(
                Information.ExtractPropertyPath<TipLgoty>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<TipLgoty>(x => x.Oldid),
                Information.ExtractPropertyPath<TipLgoty>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<TipLgoty>(x => x.CreateTime),
                Information.ExtractPropertyPath<TipLgoty>(x => x.Creator),
                Information.ExtractPropertyPath<TipLgoty>(x => x.EditTime),
                Information.ExtractPropertyPath<TipLgoty>(x => x.Editor));
            return view;
        }
    }
}