namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="Lgota"/>.
    /// </summary>
    public class LgotaObserver : DataObjectObserver<Lgota>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(Lgota) };
            view.AddProperties(
                Information.ExtractPropertyPath<Lgota>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<Lgota>(x => x.Oldid),
                Information.ExtractPropertyPath<Lgota>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<Lgota>(x => x.VclVSotcPaket),
                Information.ExtractPropertyPath<Lgota>(x => x.KodDohoda),
                Information.ExtractPropertyPath<Lgota>(x => x.OblagNDFL),
                Information.ExtractPropertyPath<Lgota>(x => x.OblagESN),
                Information.ExtractPropertyPath<Lgota>(x => x.Ierarhiia),
                Information.ExtractPropertyPath<Lgota>(x => x.Ierarhiia.__PrimaryKey),
                Information.ExtractPropertyPath<Lgota>(x => x.Tip),
                Information.ExtractPropertyPath<Lgota>(x => x.Tip.__PrimaryKey),
                Information.ExtractPropertyPath<Lgota>(x => x.CreateTime),
                Information.ExtractPropertyPath<Lgota>(x => x.Creator),
                Information.ExtractPropertyPath<Lgota>(x => x.EditTime),
                Information.ExtractPropertyPath<Lgota>(x => x.Editor));
            return view;
        }
    }
}