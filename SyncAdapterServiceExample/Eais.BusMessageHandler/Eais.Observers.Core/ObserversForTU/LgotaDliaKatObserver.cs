namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="LgotaDliaKat"/>.
    /// </summary>
    public class LgotaDliaKatObserver : DataObjectObserver<LgotaDliaKat>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(LgotaDliaKat) };
            view.AddProperties(
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Oldid),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.DataNaznacheniia),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.DataOtmeny),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.PeriodPredost),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.TipVyplaty),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Lgota),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Lgota.__PrimaryKey),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.IstochnikFin),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.IstochnikFin.__PrimaryKey),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Osnovanie),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Osnovanie.__PrimaryKey),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Kategoriia),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Kategoriia.__PrimaryKey),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.CreateTime),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Creator),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.EditTime),
                Information.ExtractPropertyPath<LgotaDliaKat>(x => x.Editor));
            return view;
        }
    }
}