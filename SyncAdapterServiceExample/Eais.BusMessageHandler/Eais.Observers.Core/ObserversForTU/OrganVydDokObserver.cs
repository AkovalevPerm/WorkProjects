namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="OrganVydDok"/>.
    /// </summary>
    public class OrganVydDokObserver : DataObjectObserver<OrganVydDok>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(OrganVydDok) };
            view.AddProperties(
                Information.ExtractPropertyPath<OrganVydDok>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.Oldid),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.Adres),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.Telefon),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.OrganSZ),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.OrganSZ.__PrimaryKey),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.CreateTime),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.Creator),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.EditTime),
                Information.ExtractPropertyPath<OrganVydDok>(x => x.Editor));
            return view;
        }
    }
}