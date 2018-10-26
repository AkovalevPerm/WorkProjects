namespace Eais.Observers.Core.ObserversForCatalogsGU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.GosUslugi;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="GosUsluga"/>.
    /// </summary>
    public class GosUslugaObserver : DataObjectObserver<GosUsluga>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(GosUsluga) };
            view.AddProperties(
                Information.ExtractPropertyPath<GosUsluga>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<GosUsluga>(x => x.KratkoeNaimenovanie),
                Information.ExtractPropertyPath<GosUsluga>(x => x.PlanSrokIsp),
                Information.ExtractPropertyPath<GosUsluga>(x => x.PolnoeNaimenovanie),
                Information.ExtractPropertyPath<GosUsluga>(x => x.CreateTime),
                Information.ExtractPropertyPath<GosUsluga>(x => x.Creator),
                Information.ExtractPropertyPath<GosUsluga>(x => x.EditTime),
                Information.ExtractPropertyPath<GosUsluga>(x => x.Editor));

            return view;
        }
    }
}
