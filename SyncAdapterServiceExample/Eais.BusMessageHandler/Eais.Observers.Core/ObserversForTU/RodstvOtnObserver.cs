namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="RodstvOtn"/>.
    /// </summary>
    public class RodstvOtnObserver : DataObjectObserver<RodstvOtn>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(RodstvOtn) };
            view.AddProperties(
                Information.ExtractPropertyPath<RodstvOtn>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<RodstvOtn>(x => x.Oldid),
                Information.ExtractPropertyPath<RodstvOtn>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<RodstvOtn>(x => x.Pol),
                Information.ExtractPropertyPath<RodstvOtn>(x => x.CreateTime),
                Information.ExtractPropertyPath<RodstvOtn>(x => x.Creator),
                Information.ExtractPropertyPath<RodstvOtn>(x => x.EditTime),
                Information.ExtractPropertyPath<RodstvOtn>(x => x.Editor));
            return view;
        }
    }
}