namespace Eais.Observers.Core
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Leechnost;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="Leechnost"/>.
    /// </summary>
    public class LeechnostObserver : DataObjectObserver<Leechnost>
    {
        /// <inheritdoc />
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(Leechnost) };
            view.AddProperties(
                Information.ExtractPropertyPath<Leechnost>(x => x.Familiia),
                Information.ExtractPropertyPath<Leechnost>(x => x.Imia),
                Information.ExtractPropertyPath<Leechnost>(x => x.Otchestvo),
                Information.ExtractPropertyPath<Leechnost>(x => x.Pol),
                Information.ExtractPropertyPath<Leechnost>(x => x.DataRozhdeniia),
                Information.ExtractPropertyPath<Leechnost>(x => x.Snils),
                Information.ExtractPropertyPath<Leechnost>(x => x.INN),
                Information.ExtractPropertyPath<Leechnost>(x => x.Mail),
                Information.ExtractPropertyPath<Leechnost>(x => x.Telefon),
                Information.ExtractPropertyPath<Leechnost>(x => x.Obrazovanie),
                Information.ExtractPropertyPath<Leechnost>(x => x.StranaRozhdeniia),
                Information.ExtractPropertyPath<Leechnost>(x => x.OblastRozhdeniia),
                Information.ExtractPropertyPath<Leechnost>(x => x.RaionRozhdeniia),
                Information.ExtractPropertyPath<Leechnost>(x => x.GorodRozhdeniia),
                Information.ExtractPropertyPath<Leechnost>(x => x.Prozhivanie),
                Information.ExtractPropertyPath<Leechnost>(x => x.Prozhivanie.__PrimaryKey),
                Information.ExtractPropertyPath<Leechnost>(x => x.Propiska),
                Information.ExtractPropertyPath<Leechnost>(x => x.Propiska.__PrimaryKey),
                Information.ExtractPropertyPath<Leechnost>(x => x.Umer),
                Information.ExtractPropertyPath<Leechnost>(x => x.DataSmerti),
                Information.ExtractPropertyPath<Leechnost>(x => x.UdostDokument));

            view.AddDetailInView(nameof(UdostDokument), UdostDokument.Views.UdostDokumentE, true);

            return view;
        }
    }
}
