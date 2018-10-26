namespace Eais.Observers.Core.ObserversForCatalogsGU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.GosUslugi;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="NaimOperRassmotrVedom"/>.
    /// </summary>
    public class NaimOperRassmotrVedomObserver : DataObjectObserver<NaimOperRassmotrVedom>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(NaimOperRassmotrVedom) };
            view.AddProperties(
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.GosUsluga),
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.GosUsluga.__PrimaryKey),
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.Tip),
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.CreateTime),
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.Creator),
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.EditTime),
                Information.ExtractPropertyPath<NaimOperRassmotrVedom>(x => x.Editor));
            return view;
        }
    }
}