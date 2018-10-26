namespace Mappers.Tests
{
    using System;
    using System.Linq;

    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Security;
    using ICSSoft.STORMNET.UserDataTypes;

    using Iis.Eais.Catalogs;
    using Iis.Eais.GosUslugi;
    using Iis.Eais.Leechnost;

    using IIS.Synchronizer;
    using IIS.Synchronizer.Helpers;
    using IIS.Synchronizer.Mappers;
    using IIS.Synchronizer.Mappers.Generic;
    using IIS.Synchronizer.Services;
    using IIS.University.Tools;

    using Mappers.APPtoXML.ToTU;
    using Mappers.XMLtoAPP.FromTU;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using ServiceBus.ObjectDataModel.BeneficiaryData;

    using OrganSZ = Iis.Eais.Catalogs.OrganSZ;
    using Prozhivanie = Iis.Eais.Catalogs.Prozhivanie;
    using tPol = Iis.Eais.Leechnost.tPol;
    using VidUdostDok = Iis.Eais.Catalogs.VidUdostDok;
    using FromTU = ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.ToTU;

    using KindDocument = ServiceBus.ObjectDataModel.BeneficiaryData.KindDocument;
    using Leechnost = Iis.Eais.Leechnost.Leechnost;
    using Lgota = Iis.Eais.Catalogs.Lgota;
    using LgotKat = Iis.Eais.Catalogs.LgotKat;
    using OrganVydDok = Iis.Eais.Catalogs.OrganVydDok;
    using Period = Iis.Eais.Catalogs.Period;
    using PrichinaPeremeshcheniia = Iis.Eais.Catalogs.PrichinaPeremeshcheniia;
    using PrichinaSnyatiya = Iis.Eais.Catalogs.PrichinaSnyatiya;
    using RodstvOtn = Iis.Eais.Catalogs.RodstvOtn;
    using Specialist = Iis.Eais.Catalogs.Specialist;
    using Strana = Iis.Eais.Catalogs.Strana;
    using Street = ServiceBus.ObjectDataModel.BeneficiaryData.Street;
    using tLogicheskii = Iis.Eais.Catalogs.tLogicheskii;
    using tTipPerioda = Iis.Eais.Catalogs.tTipPerioda;
    using tTipVyplaty = Iis.Eais.Catalogs.tTipVyplaty;
    using Territory = ServiceBus.ObjectDataModel.BeneficiaryData.Territory;
    using TypeDocument = ServiceBus.ObjectDataModel.BeneficiaryData.TypeDocument;

    /// <summary>
    /// MappersTest.
    /// </summary>
    [TestClass]
    public class MappersTest
    {
        [TestMethod]
        public void TipUdostDokToTypeDocumentMapperTest()
        {
            var tip = PKHelper.CreateDataObject<TipUdostDok>(Guid.NewGuid());
            tip.Naimenovanie = "Тип1";

            SyncSetting setting = SettingService.Current.GetSettings(tip).First(s => s.Destination.Name == typeof(TypeDocument).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(tip);
            Assert.AreEqual(resultList.Count(), 1);
            var type = (TypeDocument)resultList.First();
            TipUdostDokCompareToTypeDocument(tip, type);
        }

        [TestMethod]
        public void TypeDocumentToTipUdostDokMapperTest()
        {
            var type = new TypeDocument
            {
                Guid = Guid.NewGuid(),
                TypeDocName = "Type1"
            };

            SyncSetting setting = SettingService.Current.GetSettings(type).First(s => s.Destination.Name == typeof(TipUdostDok).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(type);
            Assert.AreEqual(resultList.Count(), 1);
            var tip = (TipUdostDok)resultList.First();
            TipUdostDokCompareToTypeDocument(tip, type);
        }

        [TestMethod]
        public void VidUdostDokToKindDocumentMapperTest()
        {
            var tip = PKHelper.CreateDataObject<TipUdostDok>(Guid.NewGuid());
            tip.Naimenovanie = "Тип1";
            var vid = PKHelper.CreateDataObject<VidUdostDok>(Guid.NewGuid());
            vid.Naimenovanie = "Vid1";
            vid.TipUdostDok = tip;

            SyncSetting setting = SettingService.Current.GetSettings(vid).First(s => s.Destination.Name == typeof(KindDocument).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(vid);
            Assert.AreEqual(resultList.Count(), 1);
            var kind = (KindDocument)resultList.First();
            VidUdostDokCompareToKindDocument(vid, kind.Guid);
        }

        [TestMethod]
        public void KindDocumentToVidUdostDokMapperTest()
        {
            var kind = new KindDocument
            {
                Guid = Guid.NewGuid(),
                KindDocName = "Kind1",
                TypeDoc = new TypeDocument
                {
                    Guid = Guid.NewGuid(),
                    TypeDocName = "Type1"
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(kind).First(s => s.Destination.Name == typeof(VidUdostDok).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(kind);
            Assert.AreEqual(resultList.Count(), 1);
            var vid = (VidUdostDok)resultList.First();
            TipUdostDokCompareToTypeDocument(vid.TipUdostDok, kind.TypeDoc);
            VidUdostDokCompareToKindDocument(vid, kind.Guid);
        }

        [TestMethod]
        public void TerritoriaToTerritoryMapperTest()
        {
            var territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            territoriia.KodFIAS = "123456";
            territoriia.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            territoriia.VidObekta = "vid11";
            territoriia.Naimenovanie = "Королевство Дания";
            territoriia.PochtIndeks = "614083";
            territoriia.Ierarhiia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            territoriia.Ierarhiia.KodFIAS = "6457";
            territoriia.Ierarhiia.VidObekta = "object34";
            territoriia.Ierarhiia.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            territoriia.Ierarhiia.Naimenovanie = "Европа";
            territoriia.Ierarhiia.PochtIndeks = "450000";
            territoriia.Ierarhiia.Ierarhiia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());

            SyncSetting setting = SettingService.Current.GetSettings(territoriia).First(s => s.Destination.Name == typeof(Territory).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(territoriia);
            Assert.AreEqual(resultList.Count(), 1);
            var territory = (Territory)resultList.First();
            TerritoriiaCompareToTerritory(territoriia, territory);
            TerritoriiaCompareToTerritory(territoriia.Ierarhiia, territory.Parent, true);
        }

        [TestMethod]
        public void TerritoryToTerritoriiaMapperTest()
        {
            var territory = new Territory
            {
                Guid = Guid.NewGuid(),
                FIAS = "123456",
                ObjectType = "vid11",
                Name = "Королевство Дания",
                PostIndex = "614083",
                Parent = new Territory
                {
                    Guid = Guid.NewGuid(),
                    FIAS = "6457",
                    ObjectType = "vid78",
                    PostIndex = "614000",
                    Name = "Европа",
                    Parent = new Territory
                    {
                        Guid = Guid.NewGuid()
                    }
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(territory).First(s => s.Destination.Name == typeof(Territoriia).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(territory);
            Assert.AreEqual(resultList.Count(), 1);
            var territoriia = (Territoriia)resultList.First();
            TerritoriiaCompareToTerritory(territoriia, territory);
            TerritoriiaCompareToTerritory(territoriia.Ierarhiia, territory.Parent, true);
        }

        [TestMethod]
        public void UlitcaToStreetMapperTest()
        {
            var ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());
            ulitca.KodFIAS = "123456";
            ulitca.VidObekta = "улица";
            ulitca.Naimenovanie = "Запорожская";
            ulitca.PochtIndeks = "614083";
            ulitca.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            ulitca.Territoriia.KodFIAS = "1689098";
            ulitca.Territoriia.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            ulitca.Territoriia.VidObekta = "vid11";
            ulitca.Territoriia.Naimenovanie = "Королевство Дания";
            ulitca.Territoriia.PochtIndeks = "614084";
            ulitca.Territoriia.Ierarhiia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());

            SyncSetting setting = SettingService.Current.GetSettings(ulitca).First(s => s.Destination.Name == typeof(Street).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(ulitca);
            Assert.AreEqual(resultList.Count(), 1);
            var street = (Street)resultList.First();
            UlitcaCompareToStreet(ulitca, street);
            TerritoriiaCompareToTerritory(ulitca.Territoriia, street.Territory);
        }

        [TestMethod]
        public void StreetToUlitcaMapperTest()
        {
            var street = new Street
            {
                Guid = Guid.NewGuid(),
                FIAS = "123456",
                ObjectType = "улица",
                Name = "Запорожская",
                PostIndex = "614083",
                Territory = new Territory
                {
                    Guid = Guid.NewGuid(),
                    FIAS = "7890",
                    ObjectType = "страна",
                    Name = "Королевство Дания",
                    PostIndex = "12345",
                    Parent = new Territory { Guid = Guid.NewGuid()}
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(street).First(s => s.Destination.Name == typeof(Ulitca).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(street);
            Assert.AreEqual(resultList.Count(), 1);
            var ulitca = (Ulitca)resultList.First();
            UlitcaCompareToStreet(ulitca, street);
            TerritoriiaCompareToTerritory(ulitca.Territoriia, street.Territory);
        }

        [TestMethod]
        public void ProzhivanieToLocationMapperTest()
        {
            var prozhivanie = PKHelper.CreateDataObject<Prozhivanie>(Guid.NewGuid());
            prozhivanie.NomerDoma = 35;
            prozhivanie.NomerStroeniia = "60";
            prozhivanie.PochtIndeks = "456780";
            prozhivanie.Kvartira = "7";
            prozhivanie.Telefon = "88005353535";
            prozhivanie.Ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());
            prozhivanie.Ulitca.KodFIAS = "123456";
            prozhivanie.Ulitca.VidObekta = "улица";
            prozhivanie.Ulitca.Naimenovanie = "Запорожская";
            prozhivanie.Ulitca.PochtIndeks = "614083";
            prozhivanie.Ulitca.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Territoriia.KodFIAS = "1234444";
            prozhivanie.Territoriia.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            prozhivanie.Territoriia.VidObekta = "vid11";
            prozhivanie.Territoriia.Naimenovanie = "Королевство Дания";
            prozhivanie.Territoriia.PochtIndeks = "614000";
            prozhivanie.Territoriia.Ierarhiia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Stroenie = PKHelper.CreateDataObject<Stroenie>(Guid.NewGuid());
            prozhivanie.Stroenie.KodFIAS = "567890";
            prozhivanie.Stroenie.VidStroeniia = tVidStroeniia.Obshchezhitie;
            prozhivanie.Stroenie.Nomer = 1234;
            prozhivanie.Stroenie.DopStroenie = "dopstr";
            prozhivanie.Stroenie.PochtIndeks = "614083";
            prozhivanie.Stroenie.Raion = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Stroenie.Ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());

            SyncSetting setting = SettingService.Current.GetSettings(prozhivanie).First(s => s.Destination.Name == typeof(Location).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(prozhivanie);
            Assert.AreEqual(resultList.Count(), 1);
            var location = (Location)resultList.First();
            ProzhivanieCompareToLocation(prozhivanie, location);
            UlitcaCompareToStreet(prozhivanie.Ulitca, location.Street);
            TerritoriiaCompareToTerritory(prozhivanie.Territoriia, location.Territory);
        }

        [TestMethod]
        public void LocationToProzhivanieMapperTest()
        {
            var location = new Location
            {
                Guid = Guid.NewGuid(),
                Number = 45,
                HouseNumber = "567",
                Index = "564322",
                Appartment = "11",
                Phone = "88005353535",
                Territory = new Territory
                {
                    Guid = Guid.NewGuid(),
                    FIAS = "1255456",
                    ObjectType = "vid11",
                    Name = "Королевство Дания",
                    PostIndex = "614553",
                    Parent = new Territory
                    {
                        Guid = Guid.NewGuid()
                    }

                },
                Street = new Street
                {
                    Guid = Guid.NewGuid(),
                    FIAS = "123456",
                    ObjectType = "улица",
                    Name = "Запорожская",
                    PostIndex = "614083",
                    Territory = new Territory
                    {
                        Guid = Guid.NewGuid()
                    }
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(location).First(s => s.Destination.Name == typeof(Prozhivanie).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(location);
            Assert.AreEqual(resultList.Count(), 1);
            var prozhivanie = (Prozhivanie)resultList.First();
            ProzhivanieCompareToLocation(prozhivanie, location);
            UlitcaCompareToStreet(prozhivanie.Ulitca, location.Street);
            TerritoriiaCompareToTerritory(prozhivanie.Territoriia, location.Territory);
        }

        [TestMethod]
        public void ProzhivanieToRegistrationMapperTest()
        {
            var prozhivanie = PKHelper.CreateDataObject<Prozhivanie>(Guid.NewGuid());
            prozhivanie.NomerDoma = 35;
            prozhivanie.NomerStroeniia = "60";
            prozhivanie.PochtIndeks = "456780";
            prozhivanie.Kvartira = "7";
            prozhivanie.Telefon = "88005353535";
            prozhivanie.Ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());
            prozhivanie.Ulitca.KodFIAS = "123456";
            prozhivanie.Ulitca.VidObekta = "улица";
            prozhivanie.Ulitca.Naimenovanie = "Запорожская";
            prozhivanie.Ulitca.PochtIndeks = "614083";
            prozhivanie.Ulitca.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Territoriia.KodFIAS = "1234444";
            prozhivanie.Territoriia.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            prozhivanie.Territoriia.VidObekta = "vid11";
            prozhivanie.Territoriia.Naimenovanie = "Королевство Дания";
            prozhivanie.Territoriia.PochtIndeks = "614000";
            prozhivanie.Territoriia.Ierarhiia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Stroenie = PKHelper.CreateDataObject<Stroenie>(Guid.NewGuid());
            prozhivanie.Stroenie.KodFIAS = "567890";
            prozhivanie.Stroenie.VidStroeniia = tVidStroeniia.Obshchezhitie;
            prozhivanie.Stroenie.Nomer = 1234;
            prozhivanie.Stroenie.DopStroenie = "dopstr";
            prozhivanie.Stroenie.PochtIndeks = "614083";
            prozhivanie.Stroenie.Raion = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Stroenie.Ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());

            SyncSetting setting = SettingService.Current.GetSettings(prozhivanie).First(s => s.Destination.Name == typeof(Registration).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(prozhivanie);
            Assert.AreEqual(resultList.Count(), 1);
            var registration = (Registration)resultList.First();
            ProzhivanieCompareToRegistration(prozhivanie, registration);
            UlitcaCompareToStreet(prozhivanie.Ulitca, registration.Street);
            TerritoriiaCompareToTerritory(prozhivanie.Territoriia, registration.Territory);
        }

        [TestMethod]
        public void RegistrationToProzhivanieMapperTest()
        {
            var location = new Registration
            {
                Guid = Guid.NewGuid(),
                Number = 45,
                HouseNumber = "567",
                Index = "564322",
                Appartment = "11",
                Phone = "88005353535",
                Territory = new Territory
                {
                    Guid = Guid.NewGuid(),
                    FIAS = "1255456",
                    ObjectType = "vid11",
                    Name = "Королевство Дания",
                    PostIndex = "614553",
                    Parent = new Territory
                    {
                        Guid = Guid.NewGuid()
                    }
                },
                Street = new Street
                {
                    Guid = Guid.NewGuid(),
                    FIAS = "123456",
                    ObjectType = "улица",
                    Name = "Запорожская",
                    PostIndex = "614083",
                    Territory = new Territory
                    {
                        Guid = Guid.NewGuid()
                    }
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(location).First(s => s.Destination.Name == typeof(Prozhivanie).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(location);
            Assert.AreEqual(resultList.Count(), 1);
            var prozhivanie = (Prozhivanie)resultList.First();
            ProzhivanieCompareToRegistration(prozhivanie, location);
            UlitcaCompareToStreet(prozhivanie.Ulitca, location.Street);
            TerritoriiaCompareToTerritory(prozhivanie.Territoriia, location.Territory);
        }

        [TestMethod]
        public void LeechnostToBeneficiaryMapperTest()
        {
            #region INIT

            var leechnost = PKHelper.CreateDataObject<Leechnost>(Guid.NewGuid());
            leechnost.Familiia = "Пупкин";
            leechnost.Imia = "Вася";
            leechnost.Otchestvo = "Петрович";
            leechnost.Pol = tPol.Zhenskii;
            leechnost.DataRozhdeniia = (NullableDateTime)DateTime.Now;
            leechnost.Snils = "1234567890";
            leechnost.INN = "234590";
            leechnost.Mail = "pupa@mail.ru";
            leechnost.Telefon = "88005353535";
            leechnost.Obrazovanie = tObrazovanieLeechn.SredneeProf;
            leechnost.StranaRozhdeniia = "Россия";
            leechnost.GorodRozhdeniia = "Пермь";
            leechnost.RaionRozhdeniia = "Пермский";
            leechnost.OblastRozhdeniia = "Пермский край";

            var prozhivanie = PKHelper.CreateDataObject<Prozhivanie>(Guid.NewGuid());
            prozhivanie.NomerDoma = 35;
            prozhivanie.NomerStroeniia = "61";
            prozhivanie.PochtIndeks = "450000";
            prozhivanie.Kvartira = "8";
            prozhivanie.Telefon = "88000353535";
            prozhivanie.Ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());
            prozhivanie.Ulitca.KodFIAS = "1456";
            prozhivanie.Ulitca.VidObekta = "город";
            prozhivanie.Ulitca.Naimenovanie = "Холмогорская";
            prozhivanie.Ulitca.PochtIndeks = "909090";
            prozhivanie.Ulitca.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Territoriia.KodFIAS = "444555";
            prozhivanie.Territoriia.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            prozhivanie.Territoriia.VidObekta = "вид34";
            prozhivanie.Territoriia.Naimenovanie = "Королевство Нидерланды";
            prozhivanie.Territoriia.PochtIndeks = "656565";
            prozhivanie.Territoriia.Ierarhiia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Stroenie = PKHelper.CreateDataObject<Stroenie>(Guid.NewGuid());
            prozhivanie.Stroenie.KodFIAS = "009988";
            prozhivanie.Stroenie.VidStroeniia = tVidStroeniia.Avariinoe;
            prozhivanie.Stroenie.Nomer = 4321;
            prozhivanie.Stroenie.DopStroenie = "stroenie";
            prozhivanie.Stroenie.PochtIndeks = "657811";
            prozhivanie.Stroenie.Raion = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            prozhivanie.Stroenie.Ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());

            leechnost.Prozhivanie = PKHelper.CreateDataObject<Iis.Eais.Leechnost.Prozhivanie>(prozhivanie);

            var propiska = PKHelper.CreateDataObject<Prozhivanie>(Guid.NewGuid());
            propiska.NomerDoma = 35;
            propiska.NomerStroeniia = "60";
            propiska.PochtIndeks = "456780";
            propiska.Kvartira = "7";
            propiska.Telefon = "88005353535";
            propiska.Ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());
            propiska.Ulitca.KodFIAS = "123456";
            propiska.Ulitca.VidObekta = "улица";
            propiska.Ulitca.Naimenovanie = "Запорожская";
            propiska.Ulitca.PochtIndeks = "614083";
            propiska.Ulitca.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            propiska.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            propiska.Territoriia.KodFIAS = "1234444";
            propiska.Territoriia.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            propiska.Territoriia.VidObekta = "vid11";
            propiska.Territoriia.Naimenovanie = "Королевство Дания";
            propiska.Territoriia.PochtIndeks = "614000";
            propiska.Territoriia.Ierarhiia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            propiska.Stroenie = PKHelper.CreateDataObject<Stroenie>(Guid.NewGuid());
            propiska.Stroenie.KodFIAS = "567890";
            propiska.Stroenie.VidStroeniia = tVidStroeniia.Obshchezhitie;
            propiska.Stroenie.Nomer = 1234;
            propiska.Stroenie.DopStroenie = "dopstr";
            propiska.Stroenie.PochtIndeks = "614083";
            propiska.Stroenie.Raion = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            propiska.Stroenie.Ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());

            leechnost.Propiska = PKHelper.CreateDataObject<Iis.Eais.Leechnost.Prozhivanie>(propiska);

            var udostDokument1 = PKHelper.CreateDataObject<UdostDokument>(Guid.NewGuid());
            udostDokument1.Seriia = "5715";
            udostDokument1.Nomer = "111222";
            udostDokument1.DataVydachi = (NullableDateTime)DateTime.UtcNow;
            udostDokument1.DataPrekrashcheniia = (NullableDateTime)DateTime.UtcNow.AddYears(10);
            udostDokument1.OrganVydDok = "organ 12345";
            var vid1 = PKHelper.CreateDataObject<VidUdostDok>(Guid.NewGuid());
            vid1.Naimenovanie = "vid222333";
            vid1.TipUdostDok = PKHelper.CreateDataObject<TipUdostDok>(Guid.NewGuid());
            vid1.TipUdostDok.Naimenovanie = "tip111777";
            udostDokument1.VidUdostDok = PKHelper.CreateDataObject<Iis.Eais.Leechnost.VidUdostDok>(vid1.__PrimaryKey);
            udostDokument1.Leechnost = leechnost;

            var udostDokument2 = PKHelper.CreateDataObject<UdostDokument>(Guid.NewGuid());
            udostDokument2.Seriia = "1234";
            udostDokument2.Nomer = "666777";
            udostDokument2.DataVydachi = (NullableDateTime)DateTime.UtcNow.AddYears(1);
            udostDokument2.DataPrekrashcheniia = (NullableDateTime)DateTime.UtcNow.AddYears(11);
            udostDokument2.OrganVydDok = "organnnn";
            var vid2 = PKHelper.CreateDataObject<VidUdostDok>(Guid.NewGuid());
            vid2.Naimenovanie = "vid new";
            vid2.TipUdostDok = PKHelper.CreateDataObject<TipUdostDok>(Guid.NewGuid());
            vid2.TipUdostDok.Naimenovanie = "tip new";
            udostDokument2.VidUdostDok = PKHelper.CreateDataObject<Iis.Eais.Leechnost.VidUdostDok>(vid2.__PrimaryKey);
            udostDokument2.Leechnost = leechnost;

            leechnost.UdostDokument = new DetailArrayOfUdostDokument(leechnost);
            leechnost.UdostDokument.AddRange(udostDokument1, udostDokument2);

            #endregion

            SyncSetting setting = SettingService.Current.GetSettings(leechnost).First(s => s.Destination.Name == typeof(Beneficiary).FullName);
            setting.Source.Owner.Name = "mock";
            
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var mock = new Mock<IDataService>();
            mock.Setup(ds =>
                    ds.GetObjectsCount(It.IsAny<LoadingCustomizationStruct>()))
                .Returns(1);
            mock.Setup(ds =>
                    ds.LoadObjects(
                        It.Is<LoadingCustomizationStruct>(lcs =>
                            PKHelper.EQPK(lcs.LimitFunction.Parameters[1], vid1))))
                .Returns(new[] { vid1 });

            mock.Setup(ds =>
                    ds.LoadObjects(
                        It.Is<LoadingCustomizationStruct>(lcs =>
                            PKHelper.EQPK(lcs.LimitFunction.Parameters[1], vid2))))
                .Returns(new[] { vid2 });

            mock.Setup(ds =>
                    ds.LoadObjects(
                        It.Is<LoadingCustomizationStruct>(lcs =>
                            PKHelper.EQPK(lcs.LimitFunction.Parameters[1], prozhivanie))))
                .Returns(new[] { prozhivanie });

            mock.Setup(ds =>
                    ds.LoadObjects(
                        It.Is<LoadingCustomizationStruct>(lcs =>
                            PKHelper.EQPK(lcs.LimitFunction.Parameters[1], propiska))))
                .Returns(new[] { propiska });

            DataServiceHelper.AddDataService("mock", mock.Object);

            var resultList = mapper.Map(leechnost);
            Assert.AreEqual(resultList.Count(), 1);
            var beneficiary = (Beneficiary)resultList.First();
            /*var docKind1 = (KindDocument)resultList.ElementAt(1);
            var docKind2 = (KindDocument)resultList.ElementAt(2);*/

            var docKind1 = beneficiary.Documents[0].DocKind;
            var docKind2 = beneficiary.Documents[1].DocKind;

            LeechnostCompareToBeneficiary(leechnost, beneficiary);

            ProzhivanieCompareToLocation(prozhivanie, beneficiary.Location);
            UlitcaCompareToStreet(prozhivanie.Ulitca, beneficiary.Location.Street);
            TerritoriiaCompareToTerritory(prozhivanie.Territoriia, beneficiary.Location.Territory);

            ProzhivanieCompareToRegistration(propiska, beneficiary.Registration);
            UlitcaCompareToStreet(propiska.Ulitca, beneficiary.Registration.Street);
            TerritoriiaCompareToTerritory(propiska.Territoriia, beneficiary.Registration.Territory);

            Assert.AreEqual(beneficiary.Documents.Length, leechnost.UdostDokument.Count);

            UdostDokumentCompareToDocument(udostDokument1, beneficiary.Documents[0]);
            VidUdostDokCompareToKindDocument(vid1, docKind1);
            UdostDokumentCompareToDocument(udostDokument2, beneficiary.Documents[1]);
            VidUdostDokCompareToKindDocument(vid2, docKind2);
        }

        [TestMethod]
        public void BeneficiaryToLeechnostMapperTest()
        {
            #region INIT

            var kind1 = new KindDocument
            {
                Guid = Guid.NewGuid(),
                KindDocName = "kind5566",
                TypeDoc = new TypeDocument
                {
                    Guid = Guid.NewGuid(),
                    TypeDocName = "type0099"
                }
            };

            var kind2 = new KindDocument
            {
                Guid = Guid.NewGuid(),
                KindDocName = "kind new",
                TypeDoc = new TypeDocument
                {
                    Guid = Guid.NewGuid(),
                    TypeDocName = "type new"
                }
            };

            var beneficiary = new Beneficiary
            {
                Guid = Guid.NewGuid(),
                FamilyName = "Пупкин",
                FirstName = "Вася",
                Patronymic = "Петрович",
                Gender =tGender.Муж,
                BirthDate = DateTime.Now,
                Snils = "12356789",
                INN = "67890",
                Email = "pupa@mail.ru",
                Phone = "88005353535",
                Education = tEducation.Высшее,
                BirthCountry = "Россия",
                BirthRegion = "Пермский край",
                BirthTown = "Пермь",
                BirthDistrict = "Пермский район",
                Location = new Location
                {
                    Guid = Guid.NewGuid(),
                    Number = 45,
                    HouseNumber = "567",
                    Index = "564322",
                    Appartment = "11",
                    Phone = "88005353535",
                    Territory = new Territory
                    {
                        Guid = Guid.NewGuid(),
                        FIAS = "1255456",
                        ObjectType = "vid11",
                        Name = "Королевство Дания",
                        PostIndex = "614553",
                        Parent = new Territory
                        {
                            Guid = Guid.NewGuid()
                        }

                    },
                    Street = new Street
                    {
                        Guid = Guid.NewGuid(),
                        FIAS = "123456",
                        ObjectType = "улица",
                        Name = "Запорожская",
                        PostIndex = "614083",
                        Territory = new Territory
                        {
                            Guid = Guid.NewGuid()
                        }
                    }
                },
                Registration = new Registration
                {
                    Guid = Guid.NewGuid(),
                    Number = 45,
                    HouseNumber = "566667",
                    Index = "777",
                    Appartment = "161",
                    Phone = "88009009999",
                    Territory = new Territory
                    {
                        Guid = Guid.NewGuid(),
                        FIAS = "67890",
                        ObjectType = "vid89",
                        Name = "Королевство Нидерланды",
                        PostIndex = "444555",
                        Parent = new Territory
                        {
                            Guid = Guid.NewGuid()
                        }
                    },
                    Street = new Street
                    {
                        Guid = Guid.NewGuid(),
                        FIAS = "888999",
                        ObjectType = "дом",
                        Name = "Дом Джека",
                        PostIndex = "614085",
                        Territory = new Territory
                        {
                            Guid = Guid.NewGuid()
                        }
                    }
                },
                Documents = new[]
                {
                    new Document
                    {
                        Guid = Guid.NewGuid(),
                        DocSeries = "5715",
                        DocNumber = "111222",
                        DocIssueDate = DateTime.Now,
                        DocEndDate = DateTime.Now.AddYears(10),
                        OrgName = "organization2233",
                        DocKind = kind1.Guid
                    },
                    new Document
                    {
                        Guid = Guid.NewGuid(),
                        DocSeries = "5666",
                        DocNumber = "444555",
                        DocIssueDate = DateTime.Now.AddYears(1),
                        DocEndDate = DateTime.Now.AddYears(11),
                        OrgName = "organization new",
                        DocKind = kind2.Guid
                    }
                }
            };

            #endregion

            var entity = new SyncDOEntity
            {
                Setting = new SyncSetting
                {
                    __PrimaryKey = PKHelper.GetGuidByObject("2edbc3f7-b1cf-4cff-9121-5f8bd9fcd92f")
                },
                ObjectStatus = ObjectStatus.Created,
                ObjectPrimaryKey = beneficiary.Guid
            };

            SyncSetting setting = SettingService.Current.GetSettings(beneficiary).First(s => s.Destination.Name == typeof(Leechnost).FullName);

            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(beneficiary);
            Assert.AreEqual(resultList.Count(), 3);
            var leechnost = (Leechnost)resultList.First();
            var prozhivanie = (Prozhivanie)resultList.ElementAt(1);
            var propiska = (Prozhivanie)resultList.ElementAt(2);
            LeechnostCompareToBeneficiary(leechnost, beneficiary);

            ProzhivanieCompareToLocation(prozhivanie, beneficiary.Location);
            UlitcaCompareToStreet(prozhivanie.Ulitca, beneficiary.Location.Street);
            TerritoriiaCompareToTerritory(prozhivanie.Territoriia, beneficiary.Location.Territory);

            ProzhivanieCompareToRegistration(propiska, beneficiary.Registration);
            UlitcaCompareToStreet(propiska.Ulitca, beneficiary.Registration.Street);
            TerritoriiaCompareToTerritory(propiska.Territoriia, beneficiary.Registration.Territory);

            Assert.AreEqual(beneficiary.Documents.Length, leechnost.UdostDokument.Count);

            UdostDokumentCompareToDocument(leechnost.UdostDokument[0], beneficiary.Documents[0]);
            UdostDokumentCompareToDocument(leechnost.UdostDokument[1], beneficiary.Documents[1]);
        }

        [TestMethod]
        public void UdostDokumentToDocumentMapperTest()
        {
            var udostDokument = PKHelper.CreateDataObject<UdostDokument>(Guid.NewGuid());
            udostDokument.Seriia = "5715";
            udostDokument.Nomer = "111222";
            udostDokument.DataVydachi = (NullableDateTime)DateTime.UtcNow;
            udostDokument.DataPrekrashcheniia = (NullableDateTime)DateTime.UtcNow.AddYears(10);
            udostDokument.OrganVydDok = "organ 12345";
            var vid = PKHelper.CreateDataObject<VidUdostDok>(Guid.NewGuid());
            vid.Naimenovanie = "vid222333";
            vid.TipUdostDok = PKHelper.CreateDataObject<TipUdostDok>(Guid.NewGuid());
            vid.TipUdostDok.Naimenovanie = "tip111777";
            udostDokument.VidUdostDok = PKHelper.CreateDataObject<Iis.Eais.Leechnost.VidUdostDok>(vid.__PrimaryKey);

            SyncSetting setting = SettingService.Current.GetSettings(udostDokument).First(s => s.Destination.Name == typeof(Document).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var mock = new Mock<IDataService>();
            mock.Setup(ds =>
                    ds.GetObjectsCount(It.IsAny<LoadingCustomizationStruct>()))
                .Returns(1);
            mock.Setup(ds => 
                ds.LoadObjects(
                    It.Is<LoadingCustomizationStruct>(lcs => 
                        lcs.LoadingTypes.Contains(typeof(VidUdostDok)))))
                .Returns(new[]{vid});

            var genericMapper = (AppToXMLMapper<UdostDokument, Document>)mapper;
            genericMapper.SourceDataService = mock.Object;

            var resultList = genericMapper.Map(udostDokument).ToList();
            Assert.AreEqual(resultList.Count, 1);
            var document = (Document)resultList.First();
            var kind = document.DocKind;
            UdostDokumentCompareToDocument(udostDokument, document);
            VidUdostDokCompareToKindDocument(vid, kind);
        }

        [TestMethod]
        public void DocumentToUdostDokumentMapperTest()
        {
            var docKind = new KindDocument
            {
                Guid = Guid.NewGuid(),
                KindDocName = "kind5566",
                TypeDoc = new TypeDocument
                {
                    Guid = Guid.NewGuid(),
                    TypeDocName = "type0099"
                }
            };

            var document = new Document
            {
                Guid = Guid.NewGuid(),
                DocSeries = "5715",
                DocNumber = "111222",
                DocIssueDate = DateTime.Now,
                DocEndDate = DateTime.Now.AddYears(10),
                OrgName = "organization2233",
                DocKind = docKind.Guid
            };

            SyncSetting setting = SettingService.Current.GetSettings(document).First(s => s.Destination.Name == typeof(UdostDokument).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(document);
            Assert.AreEqual(resultList.Count(), 1);
            var udostDokument = (UdostDokument)resultList.First();
            UdostDokumentCompareToDocument(udostDokument, document);
        }

        #region Compartments

        private void TipUdostDokCompareToTypeDocument(TipUdostDok tip, TypeDocument type)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(tip), type.Guid);
            Assert.AreEqual(tip.Naimenovanie, type.TypeDocName);
        }

        private void VidUdostDokCompareToKindDocument(VidUdostDok vid, Guid kind)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(vid), kind);
        }

        private void TerritoriiaCompareToTerritory(Territoriia territoriia, Territory territory, bool withoutParent = false)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(territoriia), territory.Guid);
            Assert.AreEqual(territoriia.KodFIAS, territory.FIAS);
            Assert.AreEqual(territoriia.Naimenovanie, territory.Name);
            Assert.AreEqual(territoriia.VidObekta, territory.ObjectType);
            Assert.AreEqual(territoriia.PochtIndeks, territory.PostIndex);
            if (!withoutParent)
            {
                Assert.AreEqual(PKHelper.GetGuidByObject(territoriia.Ierarhiia), territory.Parent?.Guid);
            }
        }

        private void UlitcaCompareToStreet(Ulitca ulitca, Street street)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(ulitca), street.Guid);
            Assert.AreEqual(ulitca.KodFIAS, street.FIAS);
            Assert.AreEqual(ulitca.VidObekta, street.ObjectType);
            Assert.AreEqual(ulitca.Naimenovanie, street.Name);
            Assert.AreEqual(ulitca.PochtIndeks, street.PostIndex);
            Assert.AreEqual(PKHelper.GetGuidByObject(ulitca.Territoriia), street.Territory.Guid);
        }

        private void ProzhivanieCompareToLocation(Prozhivanie prozhivanie, Location location)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie), location.Guid);
            Assert.AreEqual(prozhivanie.NomerDoma, location.Number);
            Assert.AreEqual(prozhivanie.NomerStroeniia, location.HouseNumber);
            Assert.AreEqual(prozhivanie.PochtIndeks, location.Index);
            Assert.AreEqual(prozhivanie.Kvartira, location.Appartment);
            Assert.AreEqual(prozhivanie.Telefon, location.Phone);
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie.Ulitca), location.Street.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie.Territoriia), location.Territory.Guid);
        }

        private void ProzhivanieCompareToRegistration(Prozhivanie prozhivanie, Registration registration)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie), registration.Guid);
            Assert.AreEqual(prozhivanie.NomerDoma, registration.Number);
            Assert.AreEqual(prozhivanie.NomerStroeniia, registration.HouseNumber);
            Assert.AreEqual(prozhivanie.PochtIndeks, registration.Index);
            Assert.AreEqual(prozhivanie.Kvartira, registration.Appartment);
            Assert.AreEqual(prozhivanie.Telefon, registration.Phone);
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie.Ulitca), registration.Street.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie.Territoriia), registration.Territory.Guid);
        }

        private void UdostDokumentCompareToDocument(UdostDokument udostDokument, Document document)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(udostDokument), document.Guid);
            Assert.AreEqual(udostDokument.Seriia, document.DocSeries);
            Assert.AreEqual(udostDokument.Nomer, document.DocNumber);
            Assert.AreEqual(udostDokument.DataVydachi, (NullableDateTime)document.DocIssueDate);
            Assert.AreEqual(udostDokument.DataPrekrashcheniia, (NullableDateTime)document.DocEndDate);
            Assert.AreEqual(udostDokument.OrganVydDok, document.OrgName);
            Assert.AreEqual(PKHelper.GetGuidByObject(udostDokument.VidUdostDok), document.DocKind);
        }

        private void LeechnostCompareToBeneficiary(Leechnost leechnost, Beneficiary beneficiary)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(leechnost), beneficiary.Guid);
            Assert.AreEqual(leechnost.Familiia, beneficiary.FamilyName);
            Assert.AreEqual(leechnost.Imia, beneficiary.FirstName);
            Assert.AreEqual(leechnost.Otchestvo, beneficiary.Patronymic);
            switch (beneficiary.Gender)
            {
                case tGender.Муж:
                    Assert.AreEqual(leechnost.Pol, tPol.Muzhskoi);
                    break;
                case tGender.Жен:
                    Assert.AreEqual(leechnost.Pol, tPol.Zhenskii);
                    break;
            }
            Assert.AreEqual(leechnost.DataRozhdeniia, (NullableDateTime)beneficiary.BirthDate);
            Assert.AreEqual(leechnost.Snils, beneficiary.Snils);
            Assert.AreEqual(leechnost.INN, beneficiary.INN);
            Assert.AreEqual(leechnost.Mail, beneficiary.Email);
            Assert.AreEqual(leechnost.Telefon, beneficiary.Phone);
            switch (beneficiary.Education)
            {
                case tEducation.Общее:
                    Assert.AreEqual(leechnost.Obrazovanie, tObrazovanieLeechn.Obshchee);
                    break;
                case tEducation.Среднеепрофессиональное:
                    Assert.AreEqual(leechnost.Obrazovanie, tObrazovanieLeechn.SredneeProf);
                    break;
                case tEducation.Высшее:
                    Assert.AreEqual(leechnost.Obrazovanie, tObrazovanieLeechn.Vysshee);
                    break;
            }
            Assert.AreEqual(leechnost.StranaRozhdeniia, beneficiary.BirthCountry);
            Assert.AreEqual(leechnost.GorodRozhdeniia, beneficiary.BirthTown);
            Assert.AreEqual(leechnost.RaionRozhdeniia, beneficiary.BirthDistrict);
            Assert.AreEqual(leechnost.OblastRozhdeniia, beneficiary.BirthRegion);
        }

        #endregion

        #region FromTU

        [TestMethod]
        public void FromTUAddressToProzhivanieMapperTest()
        {
            var adr = new FromTU.Address
            {
                Guid = new Guid("E47BB768-A7A3-447C-8529-8903F2A14DB9"),
                Number = 111,
                HouseNumber = "111",
                Appartment = "111",
                Territory = new SyncXMLDataObject
                {
                    Guid = new Guid("be2b05cf-9267-42a5-af6c-1ca7dddadc91"),
                },
                Street = new SyncXMLDataObject
                {
                    Guid = new Guid("6c68f702-0273-4d5f-8961-e2a54ec5bb9b")
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(adr).First(s => s.Destination.Name == typeof(Prozhivanie).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(adr);
            Assert.AreEqual(resultList.Count(), 1);
            var prozhivanie = (Prozhivanie)resultList.First();
            FromTUAddressToProzhivanieCompare(prozhivanie, adr);
        }

        private void FromTUAddressToProzhivanieCompare(Prozhivanie prozhivanie, FromTU.Address adr)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie), adr.Guid);
            Assert.AreEqual(prozhivanie.NomerDoma, adr.Number);
            Assert.AreEqual(prozhivanie.NomerStroeniia, adr.HouseNumber);
            Assert.AreEqual(prozhivanie.Kvartira, adr.Appartment);
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie.Territoriia), adr.Territory?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(prozhivanie.Ulitca), adr.Street?.Guid);
        }

        [TestMethod]
        public void FromTUBeneficiaryPreferencialCategoryToLgKatLeechnostiMapperTest()
        {
            var cat = new FromTU.BeneficiaryPreferentialCategory
            {
                Guid = new Guid("F94B32C8-BECD-497E-A802-63624C7012A4"),
                AppointmentDate = new DateTime(2015, 04, 04),
                CancellationDate = new DateTime(2016, 12, 12),
                Note = "note",
                Document = new SyncXMLDataObject
                {
                    Guid = new Guid("B0134607-6467-4BEF-B6DD-C355C6B81A73")
                },
                PreferentialCategory = new SyncXMLDataObject
                {
                    Guid = new Guid("24d7e719-ec1b-418f-8911-14b5486a425f")
                },
                ActDisability = new SyncXMLDataObject
                {
                    Guid = new Guid("18FCC3EF-2638-4770-BCF9-79A565AF481F")
                },
                Beneficiary = new SyncXMLDataObject
                {
                    Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(cat).First(s => s.Destination.Name == typeof(LgKatLeechnosti).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(cat);
            Assert.AreEqual(resultList.Count(), 1);
            var lgCat = (LgKatLeechnosti)resultList.First();
            FromTUBeneficiaryPreferencialCategoryToLgKatLeechnostiCompare(lgCat, cat);
        }

        private void FromTUBeneficiaryPreferencialCategoryToLgKatLeechnostiCompare(LgKatLeechnosti lgCat, FromTU.BeneficiaryPreferentialCategory cat)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(lgCat), cat.Guid);
            Assert.AreEqual(lgCat.DataNaznacheniia, (NullableDateTime)cat.AppointmentDate);
            Assert.AreEqual(lgCat.DataOtmeny, (NullableDateTime)cat.CancellationDate);
            Assert.AreEqual(lgCat.Primechanie, cat.Note);
            Assert.AreEqual(PKHelper.GetGuidByObject(lgCat.Dokument), cat.Document?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(lgCat.LgotKat), cat.PreferentialCategory?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(lgCat.AktInvalidnosti), cat.ActDisability?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(lgCat.Leechnost), cat.Beneficiary?.Guid);
        }

        [TestMethod]
        public void FromTUBeneficiaryToLeechnostMapperTest()
        {
            var obj = new FromTU.Beneficiary
            {
                Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A"),
                FamilyName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Gender = ServiceBus.ObjectDataModel.FromTU.tGender.Muzhskoi,
                BirthDate = new DateTime(1950, 01, 01),
                Snils = "000-000-000-00",
                INN = "590201234567",
                Email = "mail@mail.ru",
                Phone = "123456",
                Education = ServiceBus.ObjectDataModel.FromTU.tEducation.SredneeProf,
                BirthCountry = "Россия",
                BirthRegion = "Пермский край",
                BirthTown = "Оса",
                BirthDistrict = "Осинский район",
                TotalExperience = 30,
                AdditionalInformation = "Доп. сведения",
                Location = new ServiceBus.ObjectDataModel.FromTU.Address
                {
                    Guid = new Guid("E47BB768-A7A3-447C-8529-8903F2A14DB9"),
                    Number = 111,
                    HouseNumber = "111",
                    Appartment = "111",
                    Territory = new SyncXMLDataObject
                    {
                        Guid = new Guid("be2b05cf-9267-42a5-af6c-1ca7dddadc91"),
                    },
                    Street = new SyncXMLDataObject
                    {
                        Guid = new Guid("6c68f702-0273-4d5f-8961-e2a54ec5bb9b")
                    }
                },
                Registration = new ServiceBus.ObjectDataModel.FromTU.Address
                {
                    Guid = new Guid("A9D90541-799F-4824-9A73-85EAE3795A8E"),
                    Number = 111,
                    HouseNumber = "111",
                    Appartment = "111",
                    Territory = new SyncXMLDataObject
                    {
                        Guid = new Guid("5deca65d-3b69-41ab-89a0-b01f3c597b01"),
                    },
                    Street = new SyncXMLDataObject
                    {
                        Guid = new Guid("25fa5f54-8b78-4537-8890-6a109de916e0")
                    }
                },
                Citizenship = new SyncXMLDataObject
                {
                    Guid = new Guid("dcc6813f-c3c9-43f3-9511-507841e71ead")
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(obj).First(s => s.Destination.Name == typeof(Leechnost).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(obj);           
            Assert.AreEqual(resultList.Count(), 3);
            var leechnost = (Leechnost)resultList.First();
            var prozhivanie = (Prozhivanie)resultList.ElementAt(1);
            var propiska = (Prozhivanie)resultList.ElementAt(2);
            FromTUBeneficiaryToLeechnostCompare(leechnost, obj);
            FromTUAddressToProzhivanieCompare(prozhivanie, obj.Location);
            FromTUAddressToProzhivanieCompare(propiska, obj.Registration);
        }

        private void FromTUBeneficiaryToLeechnostCompare(Leechnost leechnost, FromTU.Beneficiary beneficiary)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(leechnost), beneficiary.Guid);
            Assert.AreEqual(leechnost.Familiia, beneficiary.FamilyName);
            Assert.AreEqual(leechnost.Imia, beneficiary.FirstName);
            Assert.AreEqual(leechnost.Otchestvo, beneficiary.Patronymic);
            switch (beneficiary.Gender)
            {
                case ServiceBus.ObjectDataModel.FromTU.tGender.Muzhskoi:
                    Assert.AreEqual(leechnost.Pol, tPol.Muzhskoi);
                    break;
                case ServiceBus.ObjectDataModel.FromTU.tGender.Zhenskii:
                    Assert.AreEqual(leechnost.Pol, tPol.Zhenskii);
                    break;
            }
            Assert.AreEqual(leechnost.DataRozhdeniia, (NullableDateTime)beneficiary.BirthDate);
            Assert.AreEqual(leechnost.Snils, beneficiary.Snils);
            Assert.AreEqual(leechnost.INN, beneficiary.INN);
            Assert.AreEqual(leechnost.Mail, beneficiary.Email);
            Assert.AreEqual(leechnost.Telefon, beneficiary.Phone);
            switch (beneficiary.Education)
            {
                case ServiceBus.ObjectDataModel.FromTU.tEducation.Obshchee:
                    Assert.AreEqual(leechnost.Obrazovanie, tObrazovanieLeechn.Obshchee);
                    break;
                case ServiceBus.ObjectDataModel.FromTU.tEducation.SredneeProf:
                    Assert.AreEqual(leechnost.Obrazovanie, tObrazovanieLeechn.SredneeProf);
                    break;
                case ServiceBus.ObjectDataModel.FromTU.tEducation.Vysshee:
                    Assert.AreEqual(leechnost.Obrazovanie, tObrazovanieLeechn.Vysshee);
                    break;
            }
            Assert.AreEqual(leechnost.StranaRozhdeniia, beneficiary.BirthCountry);
            Assert.AreEqual(leechnost.GorodRozhdeniia, beneficiary.BirthTown);
            Assert.AreEqual(leechnost.RaionRozhdeniia, beneficiary.BirthDistrict);
            Assert.AreEqual(leechnost.OblastRozhdeniia, beneficiary.BirthRegion);

            Assert.AreEqual(leechnost.ObshchiiStazh, beneficiary.TotalExperience);
            Assert.AreEqual(leechnost.DopSvedeniia, beneficiary.AdditionalInformation);
            Assert.AreEqual(PKHelper.GetGuidByObject(leechnost.Grazhdanstvo), beneficiary.Citizenship?.Guid);            
        }

        [TestMethod]
        public void FromTUChangeNameToIzmenenieFIOMapperTest()
        {
            var obj = new FromTU.ChangeName
            {
                Guid = new Guid("81B7947A-895B-4107-8EA0-4CFB23551D30"),
                FamilyName = "Ivanov",
                FirstName = "Ivan",
                Patronymic = "Ivanovich",
                ChangeDate = new DateTime(2010, 4, 5),
                Beneficiary = new SyncXMLDataObject
                {
                    Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(obj).First(s => s.Destination.Name == typeof(IzmenenieFIO).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(obj);
            Assert.AreEqual(resultList.Count(), 1);
            var dobj = (IzmenenieFIO)resultList.First();
            FromTUChangeNameToIzmenenieFIOCompare(dobj, obj);
        }

        private void FromTUChangeNameToIzmenenieFIOCompare(IzmenenieFIO dobj, FromTU.ChangeName obj)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj), obj.Guid);
            Assert.AreEqual(dobj.Familiia, obj.FamilyName);
            Assert.AreEqual(dobj.Imia, obj.FirstName);
            Assert.AreEqual(dobj.Otchestvo, obj.Patronymic);
            Assert.AreEqual(dobj.DataIzmeneniiaDannykh, (NullableDateTime)obj.ChangeDate);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.Leechnost), obj.Beneficiary?.Guid);            
        }

        [TestMethod]
        public void FromTUDisabilityToInvalidnostMapperTest()
        {
            var obj = new FromTU.Disability
            {
                Guid = new Guid("18FCC3EF-2638-4770-BCF9-79A565AF481F"),
                Group = ServiceBus.ObjectDataModel.FromTU.tGroupDisability.Вторая,
                ReferenceNumberVTEK = "111",
                IssueDateVTEK = new DateTime(2010, 10, 10),
                OrgName = "1111",
                DisabilityDegree = ServiceBus.ObjectDataModel.FromTU.tGroupDisability.Вторая,
                ReferenceIssuedBy = new SyncXMLDataObject
                {
                    Guid = new Guid("b760378a-0fd9-4bd2-a8fd-8ff59da6d5cd")
                },
                BeneficiaryPreferentialCategory = new SyncXMLDataObject
                {
                    Guid = new Guid("F94B32C8-BECD-497E-A802-63624C7012A4")
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(obj).First(s => s.Destination.Name == typeof(Invalidnost).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(obj);
            Assert.AreEqual(resultList.Count(), 1);
            var dobj = (Invalidnost)resultList.First();
            FromTUDisabilityToInvalidnostCompare(dobj, obj);
        }

        private void FromTUDisabilityToInvalidnostCompare(Invalidnost dobj, FromTU.Disability obj)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj), obj.Guid);
            switch(obj.Group)
            {
                case FromTU.tGroupDisability.Первая:
                    Assert.AreEqual(dobj.Gruppa, tGruppaInvalidnosti.Pervaia);
                    break;
                case FromTU.tGroupDisability.Вторая:
                    Assert.AreEqual(dobj.Gruppa, tGruppaInvalidnosti.Vtoraia);
                    break;
                case FromTU.tGroupDisability.Третья:
                    Assert.AreEqual(dobj.Gruppa, tGruppaInvalidnosti.Tretia);
                    break;
            }            
            Assert.AreEqual(dobj.NomerSpravkiVTEK, obj.ReferenceNumberVTEK);
            Assert.AreEqual(dobj.DataVydSpravVTEK, (NullableDateTime)obj.IssueDateVTEK);
            Assert.AreEqual(dobj.OrganVydSprav, obj.OrgName);
            switch (obj.DisabilityDegree)
            {
                case FromTU.tGroupDisability.Первая:
                    Assert.AreEqual(dobj.StepenOgranichTrudosp, tGruppaInvalidnosti.Pervaia);
                    break;
                case FromTU.tGroupDisability.Вторая:
                    Assert.AreEqual(dobj.StepenOgranichTrudosp, tGruppaInvalidnosti.Vtoraia);
                    break;
                case FromTU.tGroupDisability.Третья:
                    Assert.AreEqual(dobj.StepenOgranichTrudosp, tGruppaInvalidnosti.Tretia);
                    break;
            }            
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.KemVydSprMSE), obj.ReferenceIssuedBy?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.LgKatLeechnosti), obj.BeneficiaryPreferentialCategory?.Guid);
        }

        [TestMethod]
        public void FromTUDocumentToUdostDokumentMapperTest()
        {
            var obj = new FromTU.Document
            {
                Guid = new Guid("B0134607-6467-4BEF-B6DD-C355C6B81A73"),
                Series = "1111",
                Number = "111111",
                IssueDate = new DateTime(2010, 02, 02),
                OrgName = "111111111",
                Note = "11111111",
                KindDocument = new SyncXMLDataObject
                {
                    Guid = new Guid("2ccc1156-0144-40be-a6fd-f774f46c4cf5")
                },
                Beneficiary = new SyncXMLDataObject
                {
                    Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                },
                IssuedBy = new SyncXMLDataObject
                {
                    Guid = new Guid("4400ca96-ce67-419c-8285-6264724fb12a")
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(obj).First(s => s.Destination.Name == typeof(UdostDokument).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(obj);
            Assert.AreEqual(resultList.Count(), 1);
            var dobj = (UdostDokument)resultList.First();
            FromTUDocumentToUdostDokumentCompare(dobj, obj);
        }

        private void FromTUDocumentToUdostDokumentCompare(UdostDokument dobj, FromTU.Document obj)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj), obj.Guid);
            Assert.AreEqual(dobj.Seriia, obj.Series);
            Assert.AreEqual(dobj.Nomer, obj.Number);
            Assert.AreEqual(dobj.DataVydachi, (NullableDateTime)obj.IssueDate);
            Assert.AreEqual(dobj.DataPrekrashcheniia, (NullableDateTime)obj.EndDate);
            Assert.AreEqual(dobj.OrganVydDok, obj.OrgName);
            Assert.AreEqual(dobj.Primechanie, obj.Note);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.Leechnost), obj.Beneficiary?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.VidUdostDok), obj.KindDocument?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.KemVydan), obj.IssuedBy?.Guid);
        }

        [TestMethod]
        public void FromTUMovementToPeremeshchenieMapperTest()
        {
            var obj = new FromTU.Movement
            {
                Guid = new Guid("8512350B-5DB5-4AE0-BCCE-A0A918CC6106"),
                DepatureDate = new DateTime(2017, 01, 01),
                AddressType = ServiceBus.ObjectDataModel.FromTU.tAddressType.Prozhivanie,
                DepatureAddress = new ServiceBus.ObjectDataModel.FromTU.Address
                {
                    Guid = new Guid("A9D90541-799F-4824-9A73-85EAE3795A8E"),
                    Number = 111,
                    HouseNumber = "111",
                    Appartment = "111",
                    Territory = new SyncXMLDataObject
                    {
                        Guid = new Guid("5deca65d-3b69-41ab-89a0-b01f3c597b01"),
                    },
                    Street = new SyncXMLDataObject
                    {
                        Guid = new Guid("25fa5f54-8b78-4537-8890-6a109de916e0")
                    }
                },
                Beneficiary = new SyncXMLDataObject
                {
                    Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                },
                MovementCause = new SyncXMLDataObject
                {
                    Guid = new Guid("3532030b-353d-449c-b087-3073accfc1c5")
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(obj).First(s => s.Destination.Name == typeof(Peremeshchenie).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(obj);
            Assert.AreEqual(resultList.Count(), 2);
            var dobj = (Peremeshchenie)resultList.First();
            var adr = (Prozhivanie)resultList.ElementAt(1);
            FromTUMovementToPeremeshchenieCompare(dobj, obj);
            FromTUAddressToProzhivanieCompare(adr, obj.DepatureAddress);            
        }

        private void FromTUMovementToPeremeshchenieCompare(Peremeshchenie dobj, FromTU.Movement obj)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj), obj.Guid);
            Assert.AreEqual(dobj.DataUbytiia, (NullableDateTime)obj.DepatureDate);
            switch(obj.AddressType)
            {
                case FromTU.tAddressType.Pusto:
                    Assert.AreEqual(dobj.TipAdresa, tTipAdresa.Pusto);
                    break;
                case FromTU.tAddressType.Prozhivanie:
                    Assert.AreEqual(dobj.TipAdresa, tTipAdresa.Prozhivanie);
                    break;
                case FromTU.tAddressType.Propiska:
                    Assert.AreEqual(dobj.TipAdresa, tTipAdresa.Propiska);
                    break;
            }                       
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.Leechnost), obj.Beneficiary?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.PrichinaPeremeshcheniia), obj.MovementCause?.Guid);            
        }

        [TestMethod]
        public void FromTURegistrationBeneficiaryToUchetLeechnostiMapperTest()
        {
            var obj = new FromTU.RegistrationBeneficiary
            {
                Guid = new Guid("BB0746E6-3D07-4A0E-95F4-ABB919B28168"),
                RegistrationDate = new DateTime(2010, 10, 10),
                DeregistrationDate = new DateTime(2015, 10, 10),
                SocialProtectionAuthority = new SyncXMLDataObject
                {
                    Guid = new Guid("6b5c34fb-75e9-46bb-84c8-3a2387f4a87f")
                },
                Beneficiary = new SyncXMLDataObject
                {
                    Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                },
                DeregestrationReason = new SyncXMLDataObject
                {
                    Guid = new Guid("3c907ea5-7b67-47b7-927a-849722893765")
                }
            };

            SyncSetting setting = SettingService.Current.GetSettings(obj).First(s => s.Destination.Name == typeof(UchetLeechnosti).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(obj);
            Assert.AreEqual(resultList.Count(), 1);
            var dobj = (UchetLeechnosti)resultList.First();
            FromTURegistrationBeneficiaryToUchetLeechnostiCompare(dobj, obj);            
        }

        private void FromTURegistrationBeneficiaryToUchetLeechnostiCompare(UchetLeechnosti dobj, FromTU.RegistrationBeneficiary obj)
        {
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj), obj.Guid);
            Assert.AreEqual(dobj.DataPostNaUchet, obj.RegistrationDate);
            Assert.AreEqual(dobj.DataSnyatSUcheta, (NullableDateTime)obj.DeregistrationDate);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.Leechnost), obj.Beneficiary?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.OrganSZ), obj.SocialProtectionAuthority?.Guid);
            Assert.AreEqual(PKHelper.GetGuidByObject(dobj.PrichinaSnyatiya), obj.DeregestrationReason?.Guid);
        }

        [TestMethod]
        public void FromTUZaiavlenieNaGosUsluguToZaiavlenieNaGosUsluguMapperTest()
        {
            var zaiavlenie1 = new FromTU.ZaiavlenieNaGosUslugu()
            {
                Guid = Guid.NewGuid(),
                DataVremia = DateTime.Now,
                ZaprosPortalaGosUsl = "zapros",
                OtvetNaZapros = "otvet na zapros",
                SoobshchenieObOshibke = "error 404",
                SoobshchenieObOshibkeShiny = "error 500",
                DataVremiaZaprosa = DateTime.Today,
                NomerZaprosa = "404",
                IdentifikDannyeLeechnosti = "new leechnost",
                OtvetVSvobodnoiForme = "otvet",
                DataIspolneniia = DateTime.UtcNow,
                OriginalyDokPolucheny = FromTU.tBool.Да,
                ZaprosPortalaGosUslParsed = "parsed zapros",
                GosUsluga = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                Zaiavitel = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                Opekaemyi = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                Ispolnitel = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                OrganSZ = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                PrichinaOtkaza = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                Rezultat = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                CreateTime = DateTime.MaxValue,
                Creator = "admin",
                EditTime = DateTime.MinValue,
                Editor = "user"
            };
            SyncSetting setting = SettingService.Current.GetSettings(zaiavlenie1).First(s => s.Destination.Name == typeof(ZaiavlenieNaGosUslugu).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(zaiavlenie1);
            Assert.AreEqual(resultList.Count(), 1);
            var zaiavlenie2 = (ZaiavlenieNaGosUslugu)resultList.First();
            FromTUZaiavlenieNaGosUsluguToZaiavlenieNaGosUsluguCompare(zaiavlenie2, zaiavlenie1);
        }

        private void FromTUZaiavlenieNaGosUsluguToZaiavlenieNaGosUsluguCompare(
            ZaiavlenieNaGosUslugu zaiavlenie1,
            FromTU.ZaiavlenieNaGosUslugu zaiavlenie2)
        {
            Assert.IsTrue(PKHelper.EQPK(zaiavlenie1, zaiavlenie2.Guid));
            Assert.AreEqual(zaiavlenie1.DataVremia, zaiavlenie2.DataVremia);
            Assert.AreEqual(zaiavlenie1.ZaprosPortalaGosUsl, zaiavlenie2.ZaprosPortalaGosUsl);
            Assert.AreEqual(zaiavlenie1.OtvetNaZapros, zaiavlenie2.OtvetNaZapros);
            Assert.AreEqual(zaiavlenie1.SoobshchenieObOshibke, zaiavlenie2.SoobshchenieObOshibke);
            Assert.AreEqual(zaiavlenie1.SoobshchenieObOshibkeShiny, zaiavlenie2.SoobshchenieObOshibkeShiny);
            Assert.AreEqual(zaiavlenie1.DataVremiaZaprosa, zaiavlenie2.DataVremiaZaprosa);
            Assert.AreEqual(zaiavlenie1.NomerZaprosa, zaiavlenie2.NomerZaprosa);
            Assert.AreEqual(zaiavlenie1.IdentifikDannyeLeechnosti, zaiavlenie2.IdentifikDannyeLeechnosti);
            Assert.AreEqual(zaiavlenie1.OtvetVSvobodnoiForme, zaiavlenie2.OtvetVSvobodnoiForme);
            Assert.AreEqual(zaiavlenie1.DataIspolneniia, zaiavlenie2.DataIspolneniia);

            switch (zaiavlenie2.OriginalyDokPolucheny)
            {
                case FromTU.tBool.Да:
                    Assert.IsTrue(zaiavlenie1.OriginalyDokPolucheny);
                    break;
                case FromTU.tBool.Нет:
                    Assert.IsFalse(zaiavlenie1.OriginalyDokPolucheny);
                    break;
            }

            Assert.AreEqual(zaiavlenie1.ZaprosPortalaGosUslParsed, zaiavlenie2.ZaprosPortalaGosUslParsed);

            Assert.IsTrue(PKHelper.EQPK(zaiavlenie1.GosUsluga, zaiavlenie2.GosUsluga?.Guid));
            Assert.IsTrue(PKHelper.EQPK(zaiavlenie1.Zaiavitel, zaiavlenie2.Zaiavitel?.Guid));
            Assert.IsTrue(PKHelper.EQPK(zaiavlenie1.Opekaemyi, zaiavlenie2.Opekaemyi?.Guid));
            Assert.IsTrue(PKHelper.EQPK(zaiavlenie1.Ispolnitel, zaiavlenie2.Ispolnitel?.Guid));
            Assert.IsTrue(PKHelper.EQPK(zaiavlenie1.OrganSZ, zaiavlenie2.OrganSZ?.Guid));
            Assert.IsTrue(PKHelper.EQPK(zaiavlenie1.PrichinaOtkaza, zaiavlenie2.PrichinaOtkaza?.Guid));
            Assert.IsTrue(PKHelper.EQPK(zaiavlenie1.Rezultat, zaiavlenie2.Rezultat?.Guid));
            Assert.AreEqual(zaiavlenie1.CreateTime, zaiavlenie2.CreateTime);
            Assert.AreEqual(zaiavlenie1.Creator, zaiavlenie2.Creator);
            Assert.AreEqual(zaiavlenie1.EditTime, zaiavlenie2.EditTime);
            Assert.AreEqual(zaiavlenie1.Editor, zaiavlenie2.Editor);
        }

        [TestMethod]
        public void FromTUChlenSemiToChlenSemiMapperTest()
        {
            var obj = new FromTU.ChlenSemi()
            {
                Guid = Guid.NewGuid(),
                IdentifikDannyeLeechnosti = "dannyie",
                Shkolnik = FromTU.tSchoolChild.Работает,
                Zaiavlenie = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                Leechnost = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                RodstvOtn = new SyncXMLDataObject()
                {
                    Guid = Guid.NewGuid()
                },
                CreateTime = DateTime.MaxValue,
                Creator = "admin",
                EditTime = DateTime.MinValue,
                Editor = "user"
            };

            SyncSetting setting = SettingService.Current.GetSettings(obj).First(s => s.Destination.Name == typeof(ChlenSemi).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();

            var resultList = mapper.Map(obj);
            Assert.AreEqual(resultList.Count(), 1);
            var dobj = (ChlenSemi)resultList.First();
            FromTUChlenSemiToChlenSemiCompare(dobj, obj);
        }

        private void FromTUChlenSemiToChlenSemiCompare(ChlenSemi dobj, FromTU.ChlenSemi obj)
        {
            Assert.IsTrue(PKHelper.EQPK(dobj, obj.Guid));
            Assert.AreEqual(dobj.IdentifikDannyeLeechnosti, obj.IdentifikDannyeLeechnosti);
            switch (dobj.Shkolnik)
            {
                case tStatusUchashchegosia.Doshkolnik:
                    Assert.AreEqual(obj.Shkolnik, FromTU.tSchoolChild.Дошкольник);
                    break;
                case tStatusUchashchegosia.Uchashchiisia:
                    Assert.AreEqual(obj.Shkolnik, FromTU.tSchoolChild.Учащийся);
                    break;
                case tStatusUchashchegosia.Rabotaet:
                    Assert.AreEqual(obj.Shkolnik, FromTU.tSchoolChild.Работает);
                    break;
            }
            Assert.IsTrue(PKHelper.EQPK(dobj.Zaiavlenie, obj.Zaiavlenie?.Guid));
            Assert.IsTrue(PKHelper.EQPK(dobj.Leechnost, obj.Leechnost?.Guid));
            Assert.IsTrue(PKHelper.EQPK(dobj.RodstvOtn, obj.RodstvOtn?.Guid));
            Assert.AreEqual(dobj.CreateTime, obj.CreateTime);
            Assert.AreEqual(dobj.Creator, obj.Creator);
            Assert.AreEqual(dobj.EditTime, obj.EditTime);
            Assert.AreEqual(dobj.Editor, obj.Editor);
        }

        #endregion

        #region ToTU

        [TestMethod]
        public void ToTUTerritoriiaToTerritoryMapperTest()
        {
            var territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            territoriia.Oldid = 5;
            territoriia.KodFIAS = "122333444455555";
            territoriia.VidObekta = "vid4";
            territoriia.Naimenovanie = "terr123";
            territoriia.PochtIndeks = "614083";
            territoriia.Ierarhiia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            territoriia.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            territoriia.KodSZ = "1609";
            territoriia.KodCLADR = "56783344";
            territoriia.KodOKATO = "66778899";
            territoriia.GorRaion = tLogicheskii.Da;
            territoriia.KodRegionaPF = "123";
            territoriia.KodOKTMO = "12345678";
            territoriia.KodOPFR = "787";
            territoriia.CreateTime = DateTime.Now;
            territoriia.Creator = "admin";
            territoriia.EditTime = DateTime.UtcNow;
            territoriia.Editor = "user";

            SyncSetting setting = SettingService.Current.GetSettings(territoriia)
                .First(s => s.Destination.Name == typeof(ServiceBus.ObjectDataModel.ToTU.Territory).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(territoriia);
            Assert.AreEqual(resultList.Count(), 1);
            var territory = (ServiceBus.ObjectDataModel.ToTU.Territory)resultList.First();
            ToTUTerritoriiaToTerritoryCompare(territoriia, territory);
        }

        [TestMethod]
        public void ToTUOrganSZToSocialProtectionAuthorityMapperTest()
        {
            var organ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            organ.Oldid = 4;
            organ.Naimenovanie = "organ123";
            organ.Adres = "adres888999";
            organ.Telefon = "88005553535";
            organ.Kod = 5;
            organ.KratkNaim = "123";
            organ.KodPF = "55";
            organ.PolnoeNaimenovanie = "Organ Socialnoy Zaschity #123";
            organ.KodDliaSB = "SB1";
            organ.RaionKoef = 12;
            organ.KodFNSpoSONO = "SONO66";
            organ.INN = "1209876543";
            organ.KPP = "6677788889";
            organ.UchetPoFilialuBezOtdelnPoOSZ = tLogicheskii.Da;
            organ.KodOKPO = "666";
            organ.KodOKTMO = "777";
            organ.TerOrganFedKaznach = "Ter Organ FK";
            organ.KodTerOrganaFedKaznach = "99";
            organ.KodBP = "BP1";
            organ.NaimTU = "TU22";
            organ.KodTU = "22";
            organ.StrokaPodcliucheniia = "stroka podklyucheniya";
            organ.ObedinennyiOrganSZ = true;
            organ.OGRN = "8899";
            organ.RegNomerPF = "0011";
            organ.KodTerOrganaPF = "4433";
            organ.NaimTerOrganaPF = "Organ PF #4433";
            organ.Ierarhiia = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            organ.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            organ.CreateTime = DateTime.Now;
            organ.Creator = "admin";
            organ.EditTime = DateTime.UtcNow;
            organ.Editor = "user";

            SyncSetting setting = SettingService.Current.GetSettings(organ)
                .First(s => s.Destination.Name == typeof(SocialProtectionAuthority).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(organ);
            Assert.AreEqual(resultList.Count(), 1);
            var spa = (SocialProtectionAuthority)resultList.First();
            ToTUOrganSZToSocialProtectionAuthorityCompare(organ, spa);
        }

        [TestMethod]
        public void ToTUUlitcaToStreetMapperTest()
        {
            var ulitca = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());
            ulitca.Oldid = 6;
            ulitca.PochtIndeks = "614000";
            ulitca.KodCLADR = "555666";
            ulitca.Naimenovanie = "Lenina";
            ulitca.KodGR = 33;
            ulitca.VidObekta = "obj1";
            ulitca.KodFIAS = "5566778899";
            ulitca.NovoeNazv = PKHelper.CreateDataObject<Ulitca>(Guid.NewGuid());
            ulitca.Territoriia = PKHelper.CreateDataObject<Territoriia>(Guid.NewGuid());
            ulitca.CreateTime = DateTime.Now;
            ulitca.Creator = "admin";
            ulitca.EditTime = DateTime.UtcNow;
            ulitca.Editor = "user";

            SyncSetting setting = SettingService.Current.GetSettings(ulitca)
                .First(s => s.Destination.Name == typeof(ServiceBus.ObjectDataModel.ToTU.Street).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(ulitca);
            Assert.AreEqual(resultList.Count(), 1);
            var street = (ServiceBus.ObjectDataModel.ToTU.Street)resultList.First();
            ToTUUlitcaToStreetCompare(ulitca, street);
        }

        [TestMethod]
        public void ToTUStranaToCountryMapperTest()
        {
            var strana = PKHelper.CreateDataObject<Strana>(Guid.NewGuid());
            strana.Oldid = 4;
            strana.PolnoeNaimenovanie = "Germany";
            strana.KratkoeNaimenovanie = "Ger";
            strana.TcifrKod = 43;
            strana.BukvKodAlfa2 = "22";
            strana.BukvKodAlfa3 = "33";
            strana.CreateTime = DateTime.Now;
            strana.Creator = "admin";
            strana.EditTime = DateTime.UtcNow;
            strana.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(strana)
                .First(s => s.Destination.Name == typeof(Country).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(strana);
            Assert.AreEqual(resultList.Count(), 1);
            var country = (Country)resultList.First();
            ToTUStranaToCountryCompare(strana, country);
        }

        [TestMethod]
        public void ToTULgotKatToPreferentialCategoryMapperTest()
        {
            var lgotKat = PKHelper.CreateDataObject<LgotKat>(Guid.NewGuid());
            lgotKat.Oldid = 3;
            lgotKat.Naimenovanie = "name44";
            lgotKat.Invalidnost = tLogicheskii.Da;
            lgotKat.Ierarhiia = PKHelper.CreateDataObject<LgotKat>(Guid.NewGuid());
            lgotKat.CreateTime = DateTime.Now;
            lgotKat.Creator = "admin";
            lgotKat.EditTime = DateTime.UtcNow;
            lgotKat.Editor = "user";

            SyncSetting setting = SettingService.Current.GetSettings(lgotKat)
                .First(s => s.Destination.Name == typeof(PreferentialCategory).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(lgotKat);
            Assert.AreEqual(resultList.Count(), 1);
            var category = (PreferentialCategory)resultList.First();
            ToTULgotKatToPreferentialCategoryCompare(lgotKat, category);
        }

        [TestMethod]
        public void ToTULgotaDliaKatToBenefitForCategoryMapperTest()
        {
            var lgotKat = PKHelper.CreateDataObject<LgotaDliaKat>(Guid.NewGuid());
            lgotKat.Oldid = 6;
            lgotKat.DataNaznacheniia = DateTime.UtcNow;
            lgotKat.DataOtmeny = DateTime.Now;
            lgotKat.PeriodPredost = tTipPerioda.Kvartal;
            lgotKat.TipVyplaty = tTipVyplaty.NaChlenaSemi;
            lgotKat.Lgota = PKHelper.CreateDataObject<Lgota>(Guid.NewGuid());
            lgotKat.IstochnikFin = PKHelper.CreateDataObject<IstochnikFin>(Guid.NewGuid());
            lgotKat.Osnovanie = PKHelper.CreateDataObject<StatiaAkta>(Guid.NewGuid());
            lgotKat.Kategoriia = PKHelper.CreateDataObject<LgotKat>(Guid.NewGuid());
            lgotKat.CreateTime = DateTime.Now;
            lgotKat.Creator = "admin";
            lgotKat.EditTime = DateTime.UtcNow;
            lgotKat.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(lgotKat)
                .First(s => s.Destination.Name == typeof(BenefitForCategory).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(lgotKat);
            Assert.AreEqual(resultList.Count(), 1);
            var category = (BenefitForCategory)resultList.First();
            ToTULgotDliaKatToBenefitForCategoryCompare(lgotKat, category);
        }

        [TestMethod]
        public void ToTULgotaToBenefitMapperTest()
        {
            var lgota = PKHelper.CreateDataObject<Lgota>(Guid.NewGuid());
            lgota.Oldid = 8;
            lgota.Naimenovanie = "lgota5";
            lgota.VclVSotcPaket = tLogicheskii.Da;
            lgota.KodDohoda = "999";
            lgota.OblagNDFL = tLogicheskii.Da;
            lgota.OblagESN = tLogicheskii.Da;
            lgota.Ierarhiia = PKHelper.CreateDataObject<Lgota>(Guid.NewGuid());
            lgota.Tip = PKHelper.CreateDataObject<TipLgoty>(Guid.NewGuid());
            lgota.CreateTime = DateTime.Now;
            lgota.Creator = "admin";
            lgota.EditTime = DateTime.UtcNow;
            lgota.Editor = "user";

            SyncSetting setting = SettingService.Current.GetSettings(lgota)
                .First(s => s.Destination.Name == typeof(Benefit).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(lgota);
            Assert.AreEqual(resultList.Count(), 1);
            var benefit = (Benefit)resultList.First();
            ToTULgotaToBenefitCompare(lgota, benefit);
        }

        [TestMethod]
        public void ToTUTipLgotyToTypeBenefitMapperTest()
        {
            var tip = PKHelper.CreateDataObject<TipLgoty>(Guid.NewGuid());
            tip.Oldid = 23;
            tip.Naimenovanie = "tip90";
            tip.CreateTime = DateTime.Now;
            tip.Creator = "admin";
            tip.EditTime = DateTime.UtcNow;
            tip.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(tip)
                .First(s => s.Destination.Name == typeof(TypeBenefit).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(tip);
            Assert.AreEqual(resultList.Count(), 1);
            var type = (TypeBenefit)resultList.First();
            ToTUTipLgotyToTypeBenefitCompare(tip, type);
        }

        [TestMethod]
        public void ToTUIstochnikFinToFundingSourceMapperTest()
        {
            var istochnikFin = PKHelper.CreateDataObject<IstochnikFin>(Guid.NewGuid());
            istochnikFin.Oldid = 23;
            istochnikFin.Naimenovanie = "istochnik888";
            istochnikFin.CreateTime = DateTime.Now;
            istochnikFin.Creator = "admin";
            istochnikFin.EditTime = DateTime.UtcNow;
            istochnikFin.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(istochnikFin)
                .First(s => s.Destination.Name == typeof(FundingSource).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(istochnikFin);
            Assert.AreEqual(resultList.Count(), 1);
            var source = (FundingSource)resultList.First();
            ToTUIstochnikFinToFundingSourceCompare(istochnikFin, source);
        }

        [TestMethod]
        public void ToTUNormAktToLegalActMapperTest()
        {
            var akt = PKHelper.CreateDataObject<NormAkt>(Guid.NewGuid());
            akt.Oldid = 90;
            akt.Naimenovanie = "akt55";
            akt.Nomer = "#33";
            akt.DataPodpisaniia = DateTime.Now;
            akt.KodOtchFedKaznach = "#444";
            akt.Tip = PKHelper.CreateDataObject<TipNormAkta>(Guid.NewGuid());
            akt.Izdatel = PKHelper.CreateDataObject<UrovenVlasti>(Guid.NewGuid());
            akt.CreateTime = DateTime.Now;
            akt.Creator = "admin";
            akt.EditTime = DateTime.UtcNow;
            akt.Editor = "user";

            SyncSetting setting = SettingService.Current.GetSettings(akt)
                .First(s => s.Destination.Name == typeof(LegalAct).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(akt);
            Assert.AreEqual(resultList.Count(), 1);
            var act = (LegalAct)resultList.First();
            ToTUNormAktToLegalActCompare(akt, act);
        }

        [TestMethod]
        public void ToTUStatiaAktaToActMapperTest()
        {
            var statia = PKHelper.CreateDataObject<StatiaAkta>(Guid.NewGuid());
            statia.Oldid = 7;
            statia.Nomer = "67890";
            statia.Kommentarii = "kommentatiy #1";
            statia.Lgota = "lgota5";
            statia.Kod = "567";
            statia.Akt = PKHelper.CreateDataObject<NormAkt>(Guid.NewGuid());
            statia.CreateTime = DateTime.Now;
            statia.Creator = "admin";
            statia.EditTime = DateTime.UtcNow;
            statia.Editor = "user";

            SyncSetting setting = SettingService.Current.GetSettings(statia)
                .First(s => s.Destination.Name == typeof(Act).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(statia);
            Assert.AreEqual(resultList.Count(), 1);
            var act = (Act)resultList.First();
            ToTUStatiaAktaToActCompare(statia, act);
        }

        [TestMethod]
        public void ToTUTipNormAktaToTypeLegalActMapperTest()
        {
            var tip = PKHelper.CreateDataObject<TipNormAkta>(Guid.NewGuid());
            tip.Oldid = 23;
            tip.Naimenovanie = "tip90";
            tip.CreateTime = DateTime.Now;
            tip.Creator = "admin";
            tip.EditTime = DateTime.UtcNow;
            tip.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(tip)
                .First(s => s.Destination.Name == typeof(TypeLegalAct).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(tip);
            Assert.AreEqual(resultList.Count(), 1);
            var type = (TypeLegalAct)resultList.First();
            ToTUTipNormAktaToTypeLegalActCompare(tip, type);
        }

        [TestMethod]
        public void ToTUUrovenVlastiToGovernmentLevelMapperTest()
        {
            var uroven = PKHelper.CreateDataObject<UrovenVlasti>(Guid.NewGuid());
            uroven.Oldid = 23;
            uroven.Naimenovanie = "uroven1";
            uroven.CreateTime = DateTime.Now;
            uroven.Creator = "admin";
            uroven.EditTime = DateTime.UtcNow;
            uroven.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(uroven)
                .First(s => s.Destination.Name == typeof(GovernmentLevel).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(uroven);
            Assert.AreEqual(resultList.Count(), 1);
            var level = (GovernmentLevel)resultList.First();
            ToTUUrovenVlastiToGovernmentLevelCompare(uroven, level);
        }

        [TestMethod]
        public void ToTUOrganVydDokToAuthorityIssuedDocumentMapperTest()
        {
            var organ = PKHelper.CreateDataObject<OrganVydDok>(Guid.NewGuid());
            organ.Oldid = 23;
            organ.Naimenovanie = "organ4";
            organ.Adres = "address11";
            organ.Telefon = "88005553535";
            organ.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            organ.CreateTime = DateTime.Now;
            organ.Creator = "admin";
            organ.EditTime = DateTime.UtcNow;
            organ.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(organ)
                .First(s => s.Destination.Name == typeof(AuthorityIssuedDocument).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(organ);
            Assert.AreEqual(resultList.Count(), 1);
            var aid = (AuthorityIssuedDocument)resultList.First();
            ToTUOrganVydDokToAuthorityIssuedDocumentCompare(organ, aid);
        }

        [TestMethod]
        public void ToTUSpecialistToSpecialistMapperTest()
        {
            var specialist = PKHelper.CreateDataObject<Specialist>(Guid.NewGuid());
            specialist.Oldid = 23;
            specialist.Familiya = "Petrov";
            specialist.Imya = "Ivan";
            specialist.Otchestvo = "Petrovich";
            specialist.RukOrganaCZ = tLogicheskii.Da;
            specialist.OrganSZ = PKHelper.CreateDataObject<OrganSZ>(Guid.NewGuid());
            specialist.Agent = new Agent()
            {
                Login = "ivan44"
            };
            specialist.CreateTime = DateTime.Now;
            specialist.Creator = "admin";
            specialist.EditTime = DateTime.UtcNow;
            specialist.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(specialist)
                .First(s => s.Destination.Name == typeof(ServiceBus.ObjectDataModel.ToTU.Specialist).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(specialist);
            Assert.AreEqual(resultList.Count(), 1);
            var spec = (ServiceBus.ObjectDataModel.ToTU.Specialist)resultList.First();
            ToTUSpecialistToSpecialistCompare(specialist, spec);
        }

        [TestMethod]
        public void ToTUPeriodToPeriodMapperTest()
        {
            var period = PKHelper.CreateDataObject<Period>(Guid.NewGuid());
            period.Oldid = 23;
            period.Naimenovanie = "naim11";
            period.DataNachala = DateTime.UtcNow;
            period.DataKontca = DateTime.Now;
            period.Tip = tTipPerioda.God;
            period.Znachenie = 44;
            period.Ierarhiia = PKHelper.CreateDataObject<Period>(Guid.NewGuid());
            period.CreateTime = DateTime.Now;
            period.Creator = "admin";
            period.EditTime = DateTime.UtcNow;
            period.Editor = "user";

            SyncSetting setting = SettingService.Current.GetSettings(period)
                .First(s => s.Destination.Name == typeof(ServiceBus.ObjectDataModel.ToTU.Period).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(period);
            Assert.AreEqual(resultList.Count(), 1);
            var per = (ServiceBus.ObjectDataModel.ToTU.Period)resultList.First();
            ToTUPeriodToPeriodCompare(period, per);
        }

        [TestMethod]
        public void ToTUPrichinaSnyatiyaToDeregestrationReasonMapperTest()
        {
            var prichina = PKHelper.CreateDataObject<PrichinaSnyatiya>(Guid.NewGuid());
            prichina.Oldid = 23;
            prichina.Naimenovanie = "prichina5";
            prichina.PrekraschVyiplatyi = tLogicheskii.Da;
            prichina.CreateTime = DateTime.Now;
            prichina.Creator = "admin";
            prichina.EditTime = DateTime.UtcNow;
            prichina.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(prichina)
                .First(s => s.Destination.Name == typeof(DeregestrationReason).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(prichina);
            Assert.AreEqual(resultList.Count(), 1);
            var reason = (DeregestrationReason)resultList.First();
            ToTUPrichinaSnyatiyaToDeregestrationReasonCompare(prichina, reason);
        }

        [TestMethod]
        public void ToTUPrichinaPeremeshcheniiaToDisplacementReasonMapperTest()
        {
            var prichina = PKHelper.CreateDataObject<PrichinaPeremeshcheniia>(Guid.NewGuid());
            prichina.Oldid = 23;
            prichina.Naimenovanie = "prichina11";
            prichina.CreateTime = DateTime.Now;
            prichina.Creator = "admin";
            prichina.EditTime = DateTime.UtcNow;
            prichina.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(prichina)
                .First(s => s.Destination.Name == typeof(DisplacementReason).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(prichina);
            Assert.AreEqual(resultList.Count(), 1);
            var reason = (DisplacementReason)resultList.First();
            ToTUPrichinaPeremeshcheniiaToDisplacementReasonCompare(prichina, reason);
        }

        [TestMethod]
        public void ToTURodstvOtnToFamilyRelationMapperTest()
        {
            var rodstvOtn = PKHelper.CreateDataObject<RodstvOtn>(Guid.NewGuid());
            rodstvOtn.Oldid = 23;
            rodstvOtn.Naimenovanie = "rodstv otn";
            rodstvOtn.Pol = Iis.Eais.Catalogs.tPol.Zhenskii;
            rodstvOtn.CreateTime = DateTime.Now;
            rodstvOtn.Creator = "admin";
            rodstvOtn.EditTime = DateTime.UtcNow;
            rodstvOtn.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(rodstvOtn)
                .First(s => s.Destination.Name == typeof(FamilyRelation).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(rodstvOtn);
            Assert.AreEqual(resultList.Count(), 1);
            var relation = (FamilyRelation)resultList.First();
            ToTURodstvOtnToFamilyRelationCompare(rodstvOtn, relation);
        }

        [TestMethod]
        public void ToTUVidUdostDokToKindDocumentMapperTest()
        {
            var vid = PKHelper.CreateDataObject<VidUdostDok>(Guid.NewGuid());
            vid.Oldid = 23;
            vid.Naimenovanie = "vid8";
            vid.KratkoeNaimenovanie = "888";
            vid.KodPF = "kod 666777";
            vid.Prioritet = 89;
            vid.KodVidaDokumenta = "999";
            vid.PrioritetDliaFNS = 90;
            vid.TipUdostDok = PKHelper.CreateDataObject<TipUdostDok>(Guid.NewGuid());
            vid.CreateTime = DateTime.Now;
            vid.Creator = "admin";
            vid.EditTime = DateTime.UtcNow;
            vid.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(vid)
                .First(s => s.Destination.Name == typeof(ServiceBus.ObjectDataModel.ToTU.KindDocument).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(vid);
            Assert.AreEqual(resultList.Count(), 1);
            var kind = (ServiceBus.ObjectDataModel.ToTU.KindDocument)resultList.First();
            ToTUVidUdostDokToKindDocumentCompare(vid, kind);
        }

        [TestMethod]
        public void ToTUTipUdostDokToTypeDocumentMapperTest()
        {
            var tip = PKHelper.CreateDataObject<TipUdostDok>(Guid.NewGuid());
            tip.Oldid = 23;
            tip.Naimenovanie = "tip89";
            tip.CreateTime = DateTime.Now;
            tip.Creator = "admin";
            tip.EditTime = DateTime.UtcNow;
            tip.Editor = "user";
            SyncSetting setting = SettingService.Current.GetSettings(tip)
                .First(s => s.Destination.Name == typeof(ServiceBus.ObjectDataModel.ToTU.TypeDocument).FullName);
            var mapper = setting.ExtractMapper<IPropertyMapper>();
            var resultList = mapper.Map(tip);
            Assert.AreEqual(resultList.Count(), 1);
            var type = (ServiceBus.ObjectDataModel.ToTU.TypeDocument)resultList.First();
            ToTUTipUdostDokToTypeDocumentCompare(tip, type);
        }

        #endregion

        #region ToTU Compartments

        public void ToTUTerritoriiaToTerritoryCompare(Territoriia territoriia, ServiceBus.ObjectDataModel.ToTU.Territory territory)
        {
            Assert.IsTrue(PKHelper.EQPK(territoriia, territory.Guid));
            Assert.AreEqual(territoriia.Oldid, territory.Id);
            Assert.AreEqual(territoriia.KodFIAS, territory.FIAS);
            Assert.AreEqual(territoriia.VidObekta, territory.ObjectType);
            Assert.AreEqual(territoriia.Naimenovanie, territory.Name);
            Assert.AreEqual(territoriia.PochtIndeks, territory.PostIndex);
            Assert.IsTrue(PKHelper.EQPK(territoriia.Ierarhiia, territory.Parent.Guid));
            Assert.IsTrue(PKHelper.EQPK(territoriia.OrganSZ, territory.SocialProtectionAuthority.Guid));
            Assert.AreEqual(territoriia.KodSZ, territory.CodeSPA);
            Assert.AreEqual(territoriia.KodCLADR, territory.CodeKLADR);
            Assert.AreEqual(territoriia.KodOKATO, territory.CodeOKATO);

            switch (territoriia.GorRaion)
            {
                case tLogicheskii.Net:
                    Assert.AreEqual(territory.UrbanArea, FromTU.tBool.Нет);
                    break;
                case tLogicheskii.Da:
                    Assert.AreEqual(territory.UrbanArea, FromTU.tBool.Да);
                    break;
            }

            Assert.AreEqual(territoriia.KodRegionaPF, territory.RegionCodePF);
            Assert.AreEqual(territoriia.KodOKTMO, territory.CodeOKTMO);
            Assert.AreEqual(territoriia.KodOPFR, territory.CodeOPFR);
            Assert.AreEqual(territoriia.CreateTime, territory.CreateTime);
            Assert.AreEqual(territoriia.Creator, territory.Creator);
            Assert.AreEqual(territoriia.EditTime, territory.EditTime);
            Assert.AreEqual(territoriia.Editor, territory.Editor);
        }

        public void ToTUOrganSZToSocialProtectionAuthorityCompare(OrganSZ organ, SocialProtectionAuthority spa)
        {
            Assert.IsTrue(PKHelper.EQPK(organ, spa.Guid));
            Assert.AreEqual(organ.Oldid, spa.Id);
            Assert.AreEqual(organ.Naimenovanie, spa.Name);
            Assert.AreEqual(organ.Adres, spa.Address);
            Assert.AreEqual(organ.Telefon, spa.Phone);
            Assert.AreEqual(organ.Kod, (uint)spa.Code);
            Assert.AreEqual(organ.KratkNaim, spa.ShortName);
            Assert.AreEqual(organ.KodPF, spa.CodePF);
            Assert.AreEqual(organ.PolnoeNaimenovanie, spa.FullName);
            Assert.AreEqual(organ.KodDliaSB, spa.CodeSB);
            Assert.AreEqual(organ.RaionKoef, (uint)spa.DistrictCoefficient);
            Assert.AreEqual(organ.KodFNSpoSONO, spa.SONOCodeFNS);
            Assert.AreEqual(organ.INN, spa.INN);
            Assert.AreEqual(organ.KPP, spa.KPP);

            switch (organ.UchetPoFilialuBezOtdelnPoOSZ)
            {
                case tLogicheskii.Net:
                    Assert.AreEqual(spa.BranchAccouningWithoutSeparateSPA, FromTU.tBool.Нет);
                    break;
                case tLogicheskii.Da:
                    Assert.AreEqual(spa.BranchAccouningWithoutSeparateSPA, FromTU.tBool.Да);
                    break;
            }

            Assert.AreEqual(organ.KodOKPO, spa.CodeOKPO);
            Assert.AreEqual(organ.KodOKTMO, spa.CodeOKTMO);
            Assert.AreEqual(organ.TerOrganFedKaznach, spa.TerritorialAuthorityFT);
            Assert.AreEqual(organ.KodTerOrganaFedKaznach, spa.CodeTerritorialAuthorityFT);
            Assert.AreEqual(organ.KodBP, spa.CodeBP);
            Assert.AreEqual(organ.NaimTU, spa.NameTU);
            Assert.AreEqual(organ.KodTU, spa.CodeTU);
            Assert.AreEqual(organ.StrokaPodcliucheniia, spa.ConnectionString);

            if (organ.ObedinennyiOrganSZ)
            {
                Assert.AreEqual(spa.UnitedSPA, FromTU.tBool.Да);
            }
            else
            {
                Assert.AreEqual(spa.UnitedSPA, FromTU.tBool.Нет);
            }

            Assert.AreEqual(organ.OGRN, spa.OGRN);
            Assert.AreEqual(organ.RegNomerPF, spa.RegNumberPF);
            Assert.AreEqual(organ.KodTerOrganaPF, spa.CodeTerAuthorityPF);
            Assert.AreEqual(organ.NaimTerOrganaPF, spa.NameTerAuthorityPF);
            Assert.IsTrue(PKHelper.EQPK(organ.Ierarhiia, spa.Parent.Guid));
            Assert.IsTrue(PKHelper.EQPK(organ.Territoriia, spa.Territory.Guid));
            Assert.AreEqual(organ.CreateTime, spa.CreateTime);
            Assert.AreEqual(organ.Creator, spa.Creator);
            Assert.AreEqual(organ.EditTime, spa.EditTime);
            Assert.AreEqual(organ.Editor, spa.Editor);
        }

        public void ToTUUlitcaToStreetCompare(Ulitca ulitca, ServiceBus.ObjectDataModel.ToTU.Street street)
        {
            Assert.IsTrue(PKHelper.EQPK(ulitca, street.Guid));
            Assert.AreEqual(ulitca.Oldid, street.Id);
            Assert.AreEqual(ulitca.PochtIndeks, street.PostIndex);
            Assert.AreEqual(ulitca.KodCLADR, street.CodeCLADR);
            Assert.AreEqual(ulitca.Naimenovanie, street.Name);
            Assert.AreEqual(ulitca.KodGR, (uint)street.CodeGR);
            Assert.AreEqual(ulitca.VidObekta, street.ObjectType);
            Assert.AreEqual(ulitca.KodFIAS, street.CodeFIAS);
            Assert.IsTrue(PKHelper.EQPK(ulitca.NovoeNazv, street.NewName.Guid));
            Assert.IsTrue(PKHelper.EQPK(ulitca.Territoriia, street.Territory.Guid));
            Assert.AreEqual(ulitca.CreateTime, street.CreateTime);
            Assert.AreEqual(ulitca.Creator, street.Creator);
            Assert.AreEqual(ulitca.EditTime, street.EditTime);
            Assert.AreEqual(ulitca.Editor, street.Editor);
        }

        public void ToTUStranaToCountryCompare(Strana strana, Country country)
        {
            Assert.IsTrue(PKHelper.EQPK(strana, country.Guid));
            Assert.AreEqual(strana.Oldid, country.Id);
            Assert.AreEqual(strana.PolnoeNaimenovanie, country.FullName);
            Assert.AreEqual(strana.KratkoeNaimenovanie, country.ShortName);
            Assert.AreEqual(strana.TcifrKod, (uint)country.NumericCode);
            Assert.AreEqual(strana.BukvKodAlfa2, country.CodeAlpha2);
            Assert.AreEqual(strana.BukvKodAlfa3, country.CodeAlpha3);
            Assert.AreEqual(strana.CreateTime, country.CreateTime);
            Assert.AreEqual(strana.Creator, country.Creator);
            Assert.AreEqual(strana.EditTime, country.EditTime);
            Assert.AreEqual(strana.Editor, country.Editor);
        }

        public void ToTULgotKatToPreferentialCategoryCompare(LgotKat lgotKat, PreferentialCategory category)
        {
            Assert.IsTrue(PKHelper.EQPK(lgotKat, category.Guid));
            Assert.AreEqual(lgotKat.Oldid, category.Id);
            Assert.AreEqual(lgotKat.Naimenovanie, category.Name);

            switch (lgotKat.Invalidnost)
            {
                case tLogicheskii.Net:
                    Assert.AreEqual(category.Disability, FromTU.tBool.Нет);
                    break;
                case tLogicheskii.Da:
                    Assert.AreEqual(category.Disability, FromTU.tBool.Да);
                    break;
            }

            Assert.IsTrue(PKHelper.EQPK(lgotKat.Ierarhiia, category.Parent.Guid));
            Assert.AreEqual(lgotKat.CreateTime, category.CreateTime);
            Assert.AreEqual(lgotKat.Creator, category.Creator);
            Assert.AreEqual(lgotKat.EditTime, category.EditTime);
            Assert.AreEqual(lgotKat.Editor, category.Editor);
        }

        public void ToTULgotDliaKatToBenefitForCategoryCompare(LgotaDliaKat lgotKat, BenefitForCategory benefit)
        {
            Assert.IsTrue(PKHelper.EQPK(lgotKat, benefit.Guid));
            Assert.AreEqual(lgotKat.Oldid, benefit.Id);
            Assert.AreEqual(lgotKat.DataNaznacheniia, benefit.AppointmentDate);
            Assert.AreEqual(lgotKat.DataOtmeny, benefit.CancellationDate);

            switch (lgotKat.PeriodPredost)
            {
                case Iis.Eais.Catalogs.tTipPerioda.pusto:
                    Assert.AreEqual(benefit.Period, FromTU.tPeriodType.pusto);
                    break;
                case Iis.Eais.Catalogs.tTipPerioda.Mesiatc:
                    Assert.AreEqual(benefit.Period, FromTU.tPeriodType.Mesiatc);
                    break;
                case Iis.Eais.Catalogs.tTipPerioda.Kvartal:
                    Assert.AreEqual(benefit.Period, FromTU.tPeriodType.Kvartal);
                    break;
                case Iis.Eais.Catalogs.tTipPerioda.Polugodie:
                    Assert.AreEqual(benefit.Period, FromTU.tPeriodType.Polugodie);
                    break;
                case Iis.Eais.Catalogs.tTipPerioda.God:
                    Assert.AreEqual(benefit.Period, FromTU.tPeriodType.God);
                    break;
            }

            Assert.AreEqual(lgotKat.TipVyplaty, benefit.PaymentType);
            Assert.IsTrue(PKHelper.EQPK(lgotKat.Lgota, benefit.Benefit.Guid));
            Assert.IsTrue(PKHelper.EQPK(lgotKat.IstochnikFin, benefit.FundingSource.Guid));
            Assert.IsTrue(PKHelper.EQPK(lgotKat.Osnovanie, benefit.Reason.Guid));
            Assert.IsTrue(PKHelper.EQPK(lgotKat.Kategoriia, benefit.PreferentialCategory.Guid));
            Assert.AreEqual(lgotKat.CreateTime, benefit.CreateTime);
            Assert.AreEqual(lgotKat.Creator, benefit.Creator);
            Assert.AreEqual(lgotKat.EditTime, benefit.EditTime);
            Assert.AreEqual(lgotKat.Editor, benefit.Editor);
        }

        public void ToTULgotaToBenefitCompare(Lgota lgota, Benefit benefit)
        {
            Assert.IsTrue(PKHelper.EQPK(lgota, benefit.Guid));
            Assert.AreEqual(lgota.Oldid, benefit.Id);
            Assert.AreEqual(lgota.Naimenovanie, benefit.Name);

            switch (lgota.VclVSotcPaket)
            {
                case tLogicheskii.Net:
                    Assert.AreEqual(benefit.InSocialPackage, FromTU.tBool.Нет);
                    break;
                case tLogicheskii.Da:
                    Assert.AreEqual(benefit.InSocialPackage, FromTU.tBool.Да);
                    break;
            }

            Assert.AreEqual(lgota.KodDohoda, benefit.CodeIncome);

            switch (lgota.OblagNDFL)
            {
                case tLogicheskii.Net:
                    Assert.AreEqual(benefit.TaxedNDFL, FromTU.tBool.Нет);
                    break;
                case tLogicheskii.Da:
                    Assert.AreEqual(benefit.TaxedNDFL, FromTU.tBool.Да);
                    break;
            }

            switch (lgota.OblagESN)
            {
                case tLogicheskii.Net:
                    Assert.AreEqual(benefit.TaxedESN, FromTU.tBool.Нет);
                    break;
                case tLogicheskii.Da:
                    Assert.AreEqual(benefit.TaxedESN, FromTU.tBool.Да);
                    break;
            }

            Assert.IsTrue(PKHelper.EQPK(lgota.Ierarhiia, benefit.Parent.Guid));
            Assert.IsTrue(PKHelper.EQPK(lgota.Tip, benefit.TypeBenefit.Guid));
            Assert.AreEqual(lgota.CreateTime, benefit.CreateTime);
            Assert.AreEqual(lgota.Creator, benefit.Creator);
            Assert.AreEqual(lgota.EditTime, benefit.EditTime);
            Assert.AreEqual(lgota.Editor, benefit.Editor);
        }

        public void ToTUTipLgotyToTypeBenefitCompare(TipLgoty tipLgoty, TypeBenefit typeBenefit)
        {
            Assert.IsTrue(PKHelper.EQPK(tipLgoty, typeBenefit.Guid));
            Assert.AreEqual(tipLgoty.Oldid, typeBenefit.Id);
            Assert.AreEqual(tipLgoty.Naimenovanie, typeBenefit.Name);
            Assert.AreEqual(tipLgoty.CreateTime, typeBenefit.CreateTime);
            Assert.AreEqual(tipLgoty.Creator, typeBenefit.Creator);
            Assert.AreEqual(tipLgoty.EditTime, typeBenefit.EditTime);
            Assert.AreEqual(tipLgoty.Editor, typeBenefit.Editor);
        }

        public void ToTUIstochnikFinToFundingSourceCompare(IstochnikFin istochnik, FundingSource source)
        {
            Assert.IsTrue(PKHelper.EQPK(istochnik, source.Guid));
            Assert.AreEqual(istochnik.Oldid, source.Id);
            Assert.AreEqual(istochnik.Naimenovanie, source.Name);
            Assert.AreEqual(istochnik.CreateTime, source.CreateTime);
            Assert.AreEqual(istochnik.Creator, source.Creator);
            Assert.AreEqual(istochnik.EditTime, source.EditTime);
            Assert.AreEqual(istochnik.Editor, source.Editor);
        }

        public void ToTUNormAktToLegalActCompare(NormAkt akt, LegalAct act)
        {
            Assert.IsTrue(PKHelper.EQPK(akt, act.Guid));
            Assert.AreEqual(akt.Oldid, act.Id);
            Assert.AreEqual(akt.Naimenovanie, act.Name);
            Assert.AreEqual(akt.Nomer, act.Number);
            Assert.AreEqual(akt.DataPodpisaniia, act.SignatureDate);
            Assert.AreEqual(akt.KodOtchFedKaznach, act.CodeReportFK);
            Assert.IsTrue(PKHelper.EQPK(akt.Tip, act.TypeLegalAct.Guid));
            Assert.IsTrue(PKHelper.EQPK(akt.Izdatel, act.NamePublisher.Guid));
            Assert.AreEqual(akt.CreateTime, act.CreateTime);
            Assert.AreEqual(akt.Creator, act.Creator);
            Assert.AreEqual(akt.EditTime, act.EditTime);
            Assert.AreEqual(akt.Editor, act.Editor);
        }

        public void ToTUStatiaAktaToActCompare(StatiaAkta akt, Act act)
        {
            Assert.IsTrue(PKHelper.EQPK(akt, act.Guid));
            Assert.AreEqual(akt.Oldid, act.Id);
            Assert.AreEqual(akt.Nomer, act.Number);
            Assert.AreEqual(akt.Kommentarii, act.Comments);
            Assert.AreEqual(akt.Lgota, act.Benefit);
            Assert.AreEqual(akt.Kod, act.Code);
            Assert.IsTrue(PKHelper.EQPK(akt.Akt, act.LegalAct.Guid));
            Assert.AreEqual(akt.CreateTime, act.CreateTime);
            Assert.AreEqual(akt.Creator, act.Creator);
            Assert.AreEqual(akt.EditTime, act.EditTime);
            Assert.AreEqual(akt.Editor, act.Editor);
        }

        public void ToTUTipNormAktaToTypeLegalActCompare(TipNormAkta tip, TypeLegalAct type)
        {
            Assert.IsTrue(PKHelper.EQPK(tip, type.Guid));
            Assert.AreEqual(tip.Oldid, type.Id);
            Assert.AreEqual(tip.Naimenovanie, type.Name);
            Assert.AreEqual(tip.CreateTime, type.CreateTime);
            Assert.AreEqual(tip.Creator, type.Creator);
            Assert.AreEqual(tip.EditTime, type.EditTime);
            Assert.AreEqual(tip.Editor, type.Editor);
        }

        public void ToTUUrovenVlastiToGovernmentLevelCompare(UrovenVlasti uroven, GovernmentLevel level)
        {
            Assert.IsTrue(PKHelper.EQPK(uroven, level.Guid));
            Assert.AreEqual(uroven.Oldid, level.Id);
            Assert.AreEqual(uroven.Naimenovanie, level.Name);
            Assert.AreEqual(uroven.CreateTime, level.CreateTime);
            Assert.AreEqual(uroven.Creator, level.Creator);
            Assert.AreEqual(uroven.EditTime, level.EditTime);
            Assert.AreEqual(uroven.Editor, level.Editor);
        }

        public void ToTUOrganVydDokToAuthorityIssuedDocumentCompare(OrganVydDok organ, AuthorityIssuedDocument authority)
        {
            Assert.IsTrue(PKHelper.EQPK(organ, authority.Guid));
            Assert.AreEqual(organ.Oldid, authority.Id);
            Assert.AreEqual(organ.Naimenovanie, authority.Name);
            Assert.AreEqual(organ.Adres, authority.Address);
            Assert.AreEqual(organ.Telefon, authority.PhoneNumber);
            Assert.IsTrue(PKHelper.EQPK(organ.OrganSZ, authority.SocialProtectionAuthority.Guid));
            Assert.AreEqual(organ.CreateTime, authority.CreateTime);
            Assert.AreEqual(organ.Creator, authority.Creator);
            Assert.AreEqual(organ.EditTime, authority.EditTime);
            Assert.AreEqual(organ.Editor, authority.Editor);
        }

        public void ToTUSpecialistToSpecialistCompare(Specialist specialist1, ServiceBus.ObjectDataModel.ToTU.Specialist specialist2)
        {
            Assert.IsTrue(PKHelper.EQPK(specialist1, specialist2.Guid));
            Assert.AreEqual(specialist1.Oldid, specialist2.Id);
            Assert.AreEqual(specialist1.Familiya, specialist2.FamilyName);
            Assert.AreEqual(specialist1.Imya, specialist2.FirstName);
            Assert.AreEqual(specialist1.Otchestvo, specialist2.Patronymic);

            switch (specialist1.RukOrganaCZ)
            {
                case tLogicheskii.Net:
                    Assert.AreEqual(specialist2.ChiefSPA, FromTU.tBool.Нет);
                    break;
                case tLogicheskii.Da:
                    Assert.AreEqual(specialist2.ChiefSPA, FromTU.tBool.Да);
                    break;
            }

            Assert.IsTrue(PKHelper.EQPK(specialist1.OrganSZ, specialist2.SocialProtectionAuthority.Guid));
            Assert.AreEqual(specialist1.Agent.Login, specialist2.Login);
            Assert.AreEqual(specialist1.CreateTime, specialist2.CreateTime);
            Assert.AreEqual(specialist1.Creator, specialist2.Creator);
            Assert.AreEqual(specialist1.EditTime, specialist2.EditTime);
            Assert.AreEqual(specialist1.Editor, specialist2.Editor);
        }

        public void ToTUPeriodToPeriodCompare(Period period1, ServiceBus.ObjectDataModel.ToTU.Period period2)
        {
            Assert.IsTrue(PKHelper.EQPK(period1, period2.Guid));
            Assert.AreEqual(period1.Oldid, period2.Id);
            Assert.AreEqual(period1.Naimenovanie, period2.Name);
            Assert.AreEqual(period1.DataNachala, period2.StartDate);
            Assert.AreEqual(period1.DataKontca, period2.EndDate);

            switch (period1.Tip)
            {
                case Iis.Eais.Catalogs.tTipPerioda.pusto:
                    Assert.AreEqual(period2.PeriodType, FromTU.tPeriodType.pusto);
                    break;
                case Iis.Eais.Catalogs.tTipPerioda.Mesiatc:
                    Assert.AreEqual(period2.PeriodType, FromTU.tPeriodType.Mesiatc);
                    break;
                case Iis.Eais.Catalogs.tTipPerioda.Kvartal:
                    Assert.AreEqual(period2.PeriodType, FromTU.tPeriodType.Kvartal);
                    break;
                case Iis.Eais.Catalogs.tTipPerioda.Polugodie:
                    Assert.AreEqual(period2.PeriodType, FromTU.tPeriodType.Polugodie);
                    break;
                case Iis.Eais.Catalogs.tTipPerioda.God:
                    Assert.AreEqual(period2.PeriodType, FromTU.tPeriodType.God);
                    break;
            }

            Assert.AreEqual(period1.Znachenie, (uint)period2.Value);
            Assert.IsTrue(PKHelper.EQPK(period1.Ierarhiia, period2.Parent.Guid));
            Assert.AreEqual(period1.CreateTime, period2.CreateTime);
            Assert.AreEqual(period1.Creator, period2.Creator);
            Assert.AreEqual(period1.EditTime, period2.EditTime);
            Assert.AreEqual(period1.Editor, period2.Editor);
        }

        public void ToTUPrichinaSnyatiyaToDeregestrationReasonCompare(PrichinaSnyatiya prichina, DeregestrationReason reason)
        {
            Assert.IsTrue(PKHelper.EQPK(prichina, reason.Guid));
            Assert.AreEqual(prichina.Oldid, reason.Id);
            Assert.AreEqual(prichina.Naimenovanie, reason.Name);

            switch (prichina.PrekraschVyiplatyi)
            {
                case tLogicheskii.Net:
                    Assert.AreEqual(reason.Discontinuation, FromTU.tBool.Нет);
                    break;
                case tLogicheskii.Da:
                    Assert.AreEqual(reason.Discontinuation, FromTU.tBool.Да);
                    break;
            }

            Assert.AreEqual(prichina.CreateTime, reason.CreateTime);
            Assert.AreEqual(prichina.Creator, reason.Creator);
            Assert.AreEqual(prichina.EditTime, reason.EditTime);
            Assert.AreEqual(prichina.Editor, reason.Editor);
        }

        public void ToTUPrichinaPeremeshcheniiaToDisplacementReasonCompare(PrichinaPeremeshcheniia prichina, DisplacementReason reason)
        {
            Assert.IsTrue(PKHelper.EQPK(prichina, reason.Guid));
            Assert.AreEqual(prichina.Oldid, reason.Id);
            Assert.AreEqual(prichina.Naimenovanie, reason.Name);
            Assert.AreEqual(prichina.CreateTime, reason.CreateTime);
            Assert.AreEqual(prichina.Creator, reason.Creator);
            Assert.AreEqual(prichina.EditTime, reason.EditTime);
            Assert.AreEqual(prichina.Editor, reason.Editor);
        }

        public void ToTURodstvOtnToFamilyRelationCompare(RodstvOtn rodstvOtn, FamilyRelation relation)
        {
            Assert.IsTrue(PKHelper.EQPK(rodstvOtn, relation.Guid));
            Assert.AreEqual(rodstvOtn.Oldid, relation.Id);
            Assert.AreEqual(rodstvOtn.Naimenovanie, relation.Name);

            switch (rodstvOtn.Pol)
            {
                case Iis.Eais.Catalogs.tPol.Muzhskoi:
                    Assert.AreEqual(relation.Gender, FromTU.tGender.Muzhskoi);
                    break;
                case Iis.Eais.Catalogs.tPol.Zhenskii:
                    Assert.AreEqual(relation.Gender, FromTU.tGender.Zhenskii);
                    break;
            }

            Assert.AreEqual(rodstvOtn.CreateTime, relation.CreateTime);
            Assert.AreEqual(rodstvOtn.Creator, relation.Creator);
            Assert.AreEqual(rodstvOtn.EditTime, relation.EditTime);
            Assert.AreEqual(rodstvOtn.Editor, relation.Editor);
        }

        public void ToTUVidUdostDokToKindDocumentCompare(VidUdostDok vid, ServiceBus.ObjectDataModel.ToTU.KindDocument kind)
        {
            Assert.IsTrue(PKHelper.EQPK(vid, kind.Guid));
            Assert.AreEqual(vid.Oldid, kind.Id);
            Assert.AreEqual(vid.Naimenovanie, kind.Name);
            Assert.AreEqual(vid.KratkoeNaimenovanie, kind.ShortName);
            Assert.AreEqual(vid.KodPF, kind.CodePF);
            Assert.AreEqual(vid.Prioritet, (uint)kind.Priority);
            Assert.AreEqual(vid.KodVidaDokumenta, kind.CodeKindDocument);
            Assert.AreEqual(vid.PrioritetDliaFNS, (uint)kind.PriorityFNS);
            Assert.IsTrue(PKHelper.EQPK(vid.TipUdostDok, kind.TypeDocument.Guid));
            Assert.AreEqual(vid.CreateTime, kind.CreateTime);
            Assert.AreEqual(vid.Creator, kind.Creator);
            Assert.AreEqual(vid.EditTime, kind.EditTime);
            Assert.AreEqual(vid.Editor, kind.Editor);
        }

        public void ToTUTipUdostDokToTypeDocumentCompare(TipUdostDok tip, ServiceBus.ObjectDataModel.ToTU.TypeDocument type)
        {
            Assert.IsTrue(PKHelper.EQPK(tip, type.Guid));
            Assert.AreEqual(tip.Oldid, type.Id);
            Assert.AreEqual(tip.Naimenovanie, type.Name);
            Assert.AreEqual(tip.CreateTime, type.CreateTime);
            Assert.AreEqual(tip.Creator, type.Creator);
            Assert.AreEqual(tip.EditTime, type.EditTime);
            Assert.AreEqual(tip.Editor, type.Editor);
        }

        #endregion
    }
}
