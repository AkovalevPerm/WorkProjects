namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="VidUdostDok"/>.
    /// </summary>
    public class VidUdostDokObserver : DataObjectObserver<VidUdostDok>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(VidUdostDok) };
            view.AddProperties(
                Information.ExtractPropertyPath<VidUdostDok>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.Oldid),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.KratkoeNaimenovanie),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.KodPF),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.Prioritet),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.KodVidaDokumenta),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.PrioritetDliaFNS),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.TipUdostDok),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.TipUdostDok.__PrimaryKey),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.CreateTime),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.Creator),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.EditTime),
                Information.ExtractPropertyPath<VidUdostDok>(x => x.Editor));
            return view;
        }
    }
}