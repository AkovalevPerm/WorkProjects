namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="NormAkt"/>.
    /// </summary>
    public class NormAktObserver : DataObjectObserver<NormAkt>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(NormAkt) };
            view.AddProperties(
                Information.ExtractPropertyPath<NormAkt>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<NormAkt>(x => x.Oldid),
                Information.ExtractPropertyPath<NormAkt>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<NormAkt>(x => x.Nomer),
                Information.ExtractPropertyPath<NormAkt>(x => x.DataPodpisaniia),
                Information.ExtractPropertyPath<NormAkt>(x => x.KodOtchFedKaznach),
                Information.ExtractPropertyPath<NormAkt>(x => x.Tip),
                Information.ExtractPropertyPath<NormAkt>(x => x.Tip.__PrimaryKey),
                Information.ExtractPropertyPath<NormAkt>(x => x.Izdatel),
                Information.ExtractPropertyPath<NormAkt>(x => x.Izdatel.__PrimaryKey),
                Information.ExtractPropertyPath<NormAkt>(x => x.CreateTime),
                Information.ExtractPropertyPath<NormAkt>(x => x.Creator),
                Information.ExtractPropertyPath<NormAkt>(x => x.EditTime),
                Information.ExtractPropertyPath<NormAkt>(x => x.Editor));
            return view;
        }
    }
}