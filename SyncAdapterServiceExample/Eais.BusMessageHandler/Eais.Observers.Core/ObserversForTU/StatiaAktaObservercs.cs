namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="StatiaAkta"/>.
    /// </summary>
    public class StatiaAktaObserver : DataObjectObserver<StatiaAkta>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(StatiaAkta) };
            view.AddProperties(
                Information.ExtractPropertyPath<StatiaAkta>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Oldid),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Nomer),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Kommentarii),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Lgota),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Kod),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Akt),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Akt.__PrimaryKey),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.CreateTime),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Creator),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.EditTime),
                Information.ExtractPropertyPath<StatiaAkta>(x => x.Editor));
            return view;
        }
    }
}