namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="PrichinaPeremeshcheniia"/>.
    /// </summary>
    public class PrichinaPeremeshcheniiaObserver : DataObjectObserver<PrichinaPeremeshcheniia>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(PrichinaPeremeshcheniia) };
            view.AddProperties(
                Information.ExtractPropertyPath<PrichinaPeremeshcheniia>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<PrichinaPeremeshcheniia>(x => x.Oldid),
                Information.ExtractPropertyPath<PrichinaPeremeshcheniia>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<PrichinaPeremeshcheniia>(x => x.CreateTime),
                Information.ExtractPropertyPath<PrichinaPeremeshcheniia>(x => x.Creator),
                Information.ExtractPropertyPath<PrichinaPeremeshcheniia>(x => x.EditTime),
                Information.ExtractPropertyPath<PrichinaPeremeshcheniia>(x => x.Editor));
            return view;
        }
    }
}