namespace Mappers.APPtoXML
{
    using System;

    using ICSSoft.STORMNET;

    using Iis.Eais.Catalogs;

    using IIS.Synchronizer.Mappers.Generic;
    using IIS.University.Tools;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    public class TerritoriiaToTerritoryMapperWithMinimizedParent : AppToXMLMapper<Territoriia, Territory>
    {
        protected override View GetSourceView()
        {
            return Territoriia.Views.TerritoriiaE;
        }

        protected override Guid? GetSourceObjectPrimaryKey(Territoriia source)
        {
            return PKHelper.GetGuidByObject(source);
        }

        public override Territory Map(Territoriia source, Territory dest)
        {
            dest.Guid = PKHelper.GetGuidByObject(source).Value;
            dest.FIAS = source.KodFIAS;
            dest.ObjectType = source.VidObekta;
            if (source.Naimenovanie?.Length > 255)
            {
                throw new ArgumentOutOfRangeException($"{nameof(source.Naimenovanie)} more than 255 symbols!");
            }
            dest.Name = source.Naimenovanie;
            dest.PostIndex = source.PochtIndeks;
            if (source.Ierarhiia != null)
            {
                dest.Parent = new Territory()
                {
                    Guid = PKHelper.GetGuidByObject(source.Ierarhiia).Value
                };
            }

            return dest;
        }
    }
}
