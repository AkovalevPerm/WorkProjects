namespace Eais.Observers.Core.ObserversForTU
{
    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Observers;

    /// <summary>
    /// Observer of <see cref="LgotKat"/>.
    /// </summary>
    public class LgotKatObserver : DataObjectObserver<LgotKat>
    {
        protected override View GetSourceView()
        {
            var view = new View { DefineClassType = typeof(LgotKat) };
            view.AddProperties(
                Information.ExtractPropertyPath<LgotKat>(x => x.__PrimaryKey),
                Information.ExtractPropertyPath<LgotKat>(x => x.Oldid),
                Information.ExtractPropertyPath<LgotKat>(x => x.Naimenovanie),
                Information.ExtractPropertyPath<LgotKat>(x => x.Invalidnost),
                Information.ExtractPropertyPath<LgotKat>(x => x.Ierarhiia),
                Information.ExtractPropertyPath<LgotKat>(x => x.Ierarhiia.__PrimaryKey),
                Information.ExtractPropertyPath<LgotKat>(x => x.CreateTime),
                Information.ExtractPropertyPath<LgotKat>(x => x.Creator),
                Information.ExtractPropertyPath<LgotKat>(x => x.EditTime),
                Information.ExtractPropertyPath<LgotKat>(x => x.Editor));
            return view;
        }
    }
}