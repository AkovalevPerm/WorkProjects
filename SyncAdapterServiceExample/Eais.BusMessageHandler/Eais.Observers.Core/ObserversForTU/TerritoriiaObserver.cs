namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="Territoriia"/>.
    /// </summary>
    public class TerritoriiaObserver : DataObjectObserver<Territoriia>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(Territoriia) };
            view.AddProperties(
                Information.ExtractPropertyPath<Territoriia>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<Territoriia>(x => x.Oldid),
                Information.ExtractPropertyPath<Territoriia>(x => x.KodFIAS),
                Information.ExtractPropertyPath<Territoriia>(x => x.VidObekta),
                Information.ExtractPropertyPath<Territoriia>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<Territoriia>(x => x.PochtIndeks),
                Information.ExtractPropertyPath<Territoriia>(x => x.Ierarhiia),
                Information.ExtractPropertyPath<Territoriia>(x => x.Ierarhiia.__PrimaryKey),
                Information.ExtractPropertyPath<Territoriia>(x => x.OrganSZ),
                Information.ExtractPropertyPath<Territoriia>(x => x.OrganSZ.__PrimaryKey),
                Information.ExtractPropertyPath<Territoriia>(x => x.KodSZ),
                Information.ExtractPropertyPath<Territoriia>(x => x.KodCLADR),
                Information.ExtractPropertyPath<Territoriia>(x => x.KodOKATO),
                Information.ExtractPropertyPath<Territoriia>(x => x.GorRaion),
                Information.ExtractPropertyPath<Territoriia>(x => x.KodRegionaPF),
                Information.ExtractPropertyPath<Territoriia>(x => x.KodOKTMO),
                Information.ExtractPropertyPath<Territoriia>(x => x.KodOPFR),
                Information.ExtractPropertyPath<Territoriia>(x => x.CreateTime),
                Information.ExtractPropertyPath<Territoriia>(x => x.Creator),
                Information.ExtractPropertyPath<Territoriia>(x => x.EditTime),
                Information.ExtractPropertyPath<Territoriia>(x => x.Editor));
            return view;
        }
    }
}