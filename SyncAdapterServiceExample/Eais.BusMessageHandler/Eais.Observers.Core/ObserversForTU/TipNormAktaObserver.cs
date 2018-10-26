namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="TipNormAkta"/>.
    /// </summary>
    public class TipNormAktaObserver : DataObjectObserver<TipNormAkta>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(TipNormAkta) };
            view.AddProperties(
                Information.ExtractPropertyPath<TipNormAkta>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<TipNormAkta>(x => x.Oldid),
                Information.ExtractPropertyPath<TipNormAkta>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<TipNormAkta>(x => x.CreateTime),
                Information.ExtractPropertyPath<TipNormAkta>(x => x.Creator),
                Information.ExtractPropertyPath<TipNormAkta>(x => x.EditTime),
                Information.ExtractPropertyPath<TipNormAkta>(x => x.Editor));
            return view;
        }
    }
}