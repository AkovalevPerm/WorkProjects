namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="UrovenVlasti"/>.
    /// </summary>
    public class UrovenVlastiObserver : DataObjectObserver<UrovenVlasti>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(UrovenVlasti) };
            view.AddProperties(
                Information.ExtractPropertyPath<UrovenVlasti>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<UrovenVlasti>(x => x.Oldid),
                Information.ExtractPropertyPath<UrovenVlasti>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<UrovenVlasti>(x => x.CreateTime),
                Information.ExtractPropertyPath<UrovenVlasti>(x => x.Creator),
                Information.ExtractPropertyPath<UrovenVlasti>(x => x.EditTime),
                Information.ExtractPropertyPath<UrovenVlasti>(x => x.Editor));
            return view;
        }
    }
}