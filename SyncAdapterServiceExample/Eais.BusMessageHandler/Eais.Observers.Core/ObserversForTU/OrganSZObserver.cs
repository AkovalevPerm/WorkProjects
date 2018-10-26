namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="OrganSZ"/>.
    /// </summary>
    public class OrganSZObserver : DataObjectObserver<OrganSZ>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(OrganSZ) };
            view.AddProperties(
                Information.ExtractPropertyPath<OrganSZ>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Oldid),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Adres),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Telefon),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Kod),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KratkNaim),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodPF),
                Information.ExtractPropertyPath<OrganSZ>(x => x.PolnoeNaimenovanie),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodDliaSB),
                Information.ExtractPropertyPath<OrganSZ>(x => x.RaionKoef),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodFNSpoSONO),
                Information.ExtractPropertyPath<OrganSZ>(x => x.INN),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KPP),
                Information.ExtractPropertyPath<OrganSZ>(x => x.UchetPoFilialuBezOtdelnPoOSZ),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodOKPO),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodOKTMO),
                Information.ExtractPropertyPath<OrganSZ>(x => x.TerOrganFedKaznach),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodTerOrganaFedKaznach),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodBP),
                Information.ExtractPropertyPath<OrganSZ>(x => x.NaimTU),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodTU),
                Information.ExtractPropertyPath<OrganSZ>(x => x.StrokaPodcliucheniia),
                Information.ExtractPropertyPath<OrganSZ>(x => x.ObedinennyiOrganSZ),
                Information.ExtractPropertyPath<OrganSZ>(x => x.OGRN),
                Information.ExtractPropertyPath<OrganSZ>(x => x.RegNomerPF),
                Information.ExtractPropertyPath<OrganSZ>(x => x.KodTerOrganaPF),
                Information.ExtractPropertyPath<OrganSZ>(x => x.NaimTerOrganaPF),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Ierarhiia),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Ierarhiia.__PrimaryKey),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Territoriia),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Territoriia.__PrimaryKey),
                Information.ExtractPropertyPath<OrganSZ>(x => x.CreateTime),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Creator),
                Information.ExtractPropertyPath<OrganSZ>(x => x.EditTime),
                Information.ExtractPropertyPath<OrganSZ>(x => x.Editor));
            return view;
        }
    }
}