namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="Specialist"/>.
    /// </summary>
    public class SpecialistObserver : DataObjectObserver<Specialist>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(Specialist) };
            view.AddProperties(
                Information.ExtractPropertyPath<Specialist>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<Specialist>(x => x.Oldid),
                Information.ExtractPropertyPath<Specialist>(x => x.Familiya),
                Information.ExtractPropertyPath<Specialist>(x => x.Imya),
                Information.ExtractPropertyPath<Specialist>(x => x.Otchestvo),
                Information.ExtractPropertyPath<Specialist>(x => x.RukOrganaCZ),
                Information.ExtractPropertyPath<Specialist>(x => x.Agent.Login),
                Information.ExtractPropertyPath<Specialist>(x => x.OrganSZ),
                Information.ExtractPropertyPath<Specialist>(x => x.OrganSZ.__PrimaryKey),
                Information.ExtractPropertyPath<Specialist>(x => x.CreateTime),
                Information.ExtractPropertyPath<Specialist>(x => x.Creator),
                Information.ExtractPropertyPath<Specialist>(x => x.EditTime),
                Information.ExtractPropertyPath<Specialist>(x => x.Editor));
            return view;
        }
    }
}