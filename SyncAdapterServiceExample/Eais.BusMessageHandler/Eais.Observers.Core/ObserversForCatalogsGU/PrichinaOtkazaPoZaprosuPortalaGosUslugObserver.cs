using ICSSoft.STORMNET;

namespace Eais.Observers.Core.ObserversForCatalogsGU
{
    using Iis.Eais.GosUslugi;

    using IIS.Synchronizer.Observers;
    
    /// <summary>
    /// Observer of <see cref="PrichinaOtkazaPoZaprosuPortalaGosUslug"/>.
    /// </summary>
    public class PrichinaOtkazaPoZaprosuPortalaGosUslugObserver: DataObjectObserver<PrichinaOtkazaPoZaprosuPortalaGosUslug>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(PrichinaOtkazaPoZaprosuPortalaGosUslug) };
            view.AddProperties(
                Information.ExtractPropertyPath<PrichinaOtkazaPoZaprosuPortalaGosUslug>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<PrichinaOtkazaPoZaprosuPortalaGosUslug>(x => x.GosUsluga),
                Information.ExtractPropertyPath<PrichinaOtkazaPoZaprosuPortalaGosUslug>(x => x.GosUsluga.__PrimaryKey),
                Information.ExtractPropertyPath<PrichinaOtkazaPoZaprosuPortalaGosUslug>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<PrichinaOtkazaPoZaprosuPortalaGosUslug>(x => x.CreateTime),
                Information.ExtractPropertyPath<PrichinaOtkazaPoZaprosuPortalaGosUslug>(x => x.Creator),
                Information.ExtractPropertyPath<PrichinaOtkazaPoZaprosuPortalaGosUslug>(x => x.EditTime),
                Information.ExtractPropertyPath<PrichinaOtkazaPoZaprosuPortalaGosUslug>(x => x.Editor));
            return view;
        }
    }
}
