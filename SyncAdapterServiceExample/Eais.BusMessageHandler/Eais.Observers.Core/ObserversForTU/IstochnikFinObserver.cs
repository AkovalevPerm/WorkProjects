namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="IstochnikFin"/>.
    /// </summary>
    public class IstochnikFinObserver : DataObjectObserver<IstochnikFin>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(IstochnikFin) };
            view.AddProperties(
                Information.ExtractPropertyPath<IstochnikFin>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<IstochnikFin>(x => x.Oldid),
                Information.ExtractPropertyPath<IstochnikFin>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<IstochnikFin>(x => x.CreateTime),
                Information.ExtractPropertyPath<IstochnikFin>(x => x.Creator),
                Information.ExtractPropertyPath<IstochnikFin>(x => x.EditTime),
                Information.ExtractPropertyPath<IstochnikFin>(x => x.Editor));
            return view;
        }
    }
}