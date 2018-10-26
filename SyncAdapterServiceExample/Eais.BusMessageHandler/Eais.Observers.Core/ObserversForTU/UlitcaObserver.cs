namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="Ulitca"/>.
    /// </summary>
    public class UlitcaObserver : DataObjectObserver<Ulitca>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(Ulitca) };
            view.AddProperties(
                Information.ExtractPropertyPath<Ulitca>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<Ulitca>(x => x.Oldid),
                Information.ExtractPropertyPath<Ulitca>(x => x.PochtIndeks),
                Information.ExtractPropertyPath<Ulitca>(x => x.KodCLADR),
                Information.ExtractPropertyPath<Ulitca>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<Ulitca>(x => x.KodGR),
                Information.ExtractPropertyPath<Ulitca>(x => x.VidObekta),
                Information.ExtractPropertyPath<Ulitca>(x => x.KodFIAS),
                Information.ExtractPropertyPath<Ulitca>(x => x.NovoeNazv),
                Information.ExtractPropertyPath<Ulitca>(x => x.NovoeNazv.__PrimaryKey),
                Information.ExtractPropertyPath<Ulitca>(x => x.Territoriia),
                Information.ExtractPropertyPath<Ulitca>(x => x.Territoriia.__PrimaryKey),
                Information.ExtractPropertyPath<Ulitca>(x => x.CreateTime),
                Information.ExtractPropertyPath<Ulitca>(x => x.Creator),
                Information.ExtractPropertyPath<Ulitca>(x => x.EditTime),
                Information.ExtractPropertyPath<Ulitca>(x => x.Editor));
            return view;
        }
    }
}