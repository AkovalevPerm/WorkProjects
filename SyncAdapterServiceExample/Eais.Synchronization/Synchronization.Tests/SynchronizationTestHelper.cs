namespace Synchronization.SyncAdapter.Tests
{
    using System;
    using System.Collections.Generic;

    using Iis.Eais.Catalogs;

    using ServiceBus.ObjectDataModel.BeneficiaryData;
    using ServiceBus.ObjectDataModel.CatalogData;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.FromTU;
    using ServiceBus.ObjectDataModel.ToTU;
    using ServiceBus.ObjectMessageModel;

    using Beneficiary = ServiceBus.ObjectDataModel.BeneficiaryData.Beneficiary;
    using Document = ServiceBus.ObjectDataModel.BeneficiaryData.Document;
    using Location = ServiceBus.ObjectDataModel.BeneficiaryData.Location;
    using Street = ServiceBus.ObjectDataModel.BeneficiaryData.Street;
    using tEducation = ServiceBus.ObjectDataModel.BeneficiaryData.tEducation;
    using tGender = ServiceBus.ObjectDataModel.BeneficiaryData.tGender;
    using Territory = ServiceBus.ObjectDataModel.BeneficiaryData.Territory;

    public static class SynchronizationTestHelper
    {
        public static ToMsrFromReestrMspCatalogDataChanges GetToMsrFromReestrMspCatalogDataMessage()
        {
            return new ToMsrFromReestrMspCatalogDataChanges
            {
                RequestInfo = "test",
                Items = new List<CatalogDataDefinition>
                {
                    new CatalogDataDefinition
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018, 01, 01, 12, 05, 35, 185),
                        Classifier = new Classifier
                        {
                            Guid = new Guid("6e758c67-8264-4b6a-85d2-45df998c516d"),
                            Code = "1234",
                            Social = new Social
                            {
                                Guid = new Guid("6e758c67-8264-4b6a-85d2-45df998c517d"),
                                Code = "123",
                                Name = "TestSocName"
                            },
                            Category = new Category
                            {
                                Guid = new Guid("6e858c67-8264-4b6a-85d2-45df998c517d"),
                                Code = "1",
                                Name = "Category 1",
                                Note = "Category 1 Note"
                            },
                            Provision = new Provision
                            {
                                Guid = new Guid("7e858c67-8264-4b6a-85d2-45df998c517d"),
                                Code = "1",
                                Name = "ProvisionDefinition 1"
                            }
                        }
                    }
                }
            };
        }

        public static ToMsrFromReestrMspCatalogItemsResponse GetToMsrFromReestrMspCatalogItemsResponseMessage()
        {
            return new ToMsrFromReestrMspCatalogItemsResponse
            {
                RequestInfo = "test",
                Items = new List<CatalogItemDefinition>
                {
                    new CatalogItemDefinition
                    {
                        Classifier = new Classifier
                        {
                            Guid = new Guid("380140bd-399e-40b1-b641-19e39485679a"),
                            Code = "1",
                            Social = new Social
                            {
                                Guid = new Guid("664f364c-54a8-4193-b584-1d274be030fb"),
                                Code = "1",
                                Name = "Пенсия по государственному пенсионному обеспечению по старости"
                            },
                            Category = new Category
                            {
                                Guid = new Guid("6e758c67-8264-4b6a-85d2-45df998c516d"),
                                Code = "1",
                                Name = "Граждане из подразделений особого риска из числа военнослужащих и вольнонаемного состава Вооруженных Сил СССР, войск и органов Комитета государственной безопасности СССР, внутренних войск, железнодорожных войск и других воинских формирований, лиц начальствующего и рядового состава органов внутренних дел личный состав отдельных подразделений по сборке ядерных зарядов из числа военнослужащих",
                                Note = "Category 1 Note"
                            },
                            LegalLevel = new LegalLevel
                            {
                                Guid = new Guid("6282decd-e5c7-4ce2-8fec-3f19c0a432b1"),
                                Code = "01",
                                Name = "Федеральный уровень"
                            },
                            FinSource = new FinSource
                            {
                                Guid = new Guid("cd9beee7-bad6-437f-93bc-d852d45684f7"),
                                Code = "0010",
                                Name = "финансирование только за счет средств федерального бюджета"
                            },
                            Provision = new Provision
                            {
                                Guid = new Guid("dfe7f294-0d8e-46ec-b46a-664be201bff3"),
                                Code = "01",
                                Name = "Денежная"
                            },
                            Section = new Section
                            {
                                Guid = new Guid("106fe774-3cca-4326-8420-5a71178bf6ed"),
                                Code = "010101",
                                Name = "Пенсии по государственному пенсионному обеспечению (государственные пенсии)"
                            }
                        }
                    }
                }
            };
        }

        public static ToReestrMspFromMsrDataChanges GetToReestrMspFromMsrDataChangesMessage()
        {
            return new ToReestrMspFromMsrDataChanges
            {
                RequestInfo = "1234decd-e5c7-4ce2-8fec-3f19c0a432b1",
                Items = new List<DataChangesDefinition>
                {
                    new DataChangesDefinition
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018, 01, 01, 12, 05, 35, 185, DateTimeKind.Utc),
                        СhangedAttributes = null,
                        Beneficiary = new Beneficiary
                        {
                            Guid = new Guid("6e758c67-8264-4b6a-85d2-45df998c516d"),
                            FamilyName = "Иванов",
                            FirstName = "Иван",
                            Patronymic = "Иванович",
                            Gender = tGender.Муж,
                            BirthDate = new DateTime(1986, 12, 01),
                            Snils = "206-990-531-80",
                            INN = "403183646797",
                            Email = "Ivanov86@mail.ru",
                            Phone = "123456789",
                            Education = tEducation.Высшее,
                            BirthCountry = "Россия",
                            BirthRegion = "Пермский край",
                            BirthTown = "Оса",
                            BirthDistrict = "Осинский район",
                            Location = new Location
                            {
                                Guid = new Guid("6282decd-e5c7-4ce2-8fec-3f19c0a432b1"),
                                Territory = new Territory
                                {
                                    Guid = new Guid("cd9beee7-bad6-437f-93bc-d852d45684f7"),
                                    FIAS = "456",
                                    ObjectType = "г",
                                    Name = "Пермь",
                                    PostIndex = "614000",
                                    Parent = new Territory
                                    {
                                       Guid = new Guid("dfac4cbf-65d0-4cc7-a7b6-41ebc4d004e3")
                                    }
                                },
                                Street = new Street
                                {
                                    Guid = new Guid("664f364c-54a8-4193-b584-1d274be030fb"),
                                    FIAS = "123",
                                    ObjectType = "ул",
                                    Name = "Сиреневая",
                                    PostIndex = "614000",
                                    Territory = new Territory
                                    {
                                       Guid = new Guid("cd9beee7-bad6-437f-93bc-d852d45684f7")
                                    }
                                },
                                Number = 27,
                                HouseNumber = "",
                                Index = "614000",
                                Appartment = "5",
                                Phone = "2658941"
                            },
                            Registration = new Registration
                            {
                                Guid = new Guid("7645decd-e5c7-4ce2-8fec-3f19c0a432b1"),
                                Territory = new Territory
                                {
                                    Guid = new Guid("cd9beee7-bad6-437f-93bc-d852d45684f7"),
                                    FIAS = "456",
                                    ObjectType = "г",
                                    Name = "Пермь",
                                    PostIndex = "614000",
                                    Parent = new Territory
                                    {
                                       Guid = new Guid("dfac4cbf-65d0-4cc7-a7b6-41ebc4d004e3")
                                    }
                                },
                                Street = new Street
                                {
                                    Guid = new Guid("664f364c-54a8-4193-b584-1d274be030fb"),
                                    FIAS = "123",
                                    ObjectType = "ул",
                                    Name = "Сиреневая",
                                    PostIndex = "614000",
                                    Territory = new Territory
                                    {
                                       Guid = new Guid("cd9beee7-bad6-437f-93bc-d852d45684f7")
                                    }
                                },
                                Number = 27,
                                HouseNumber = "",
                                Index = "614000",
                                Appartment = "5",
                                Phone = "2658941"
                            },
                            Died = true,
                            DieDate = new DateTime(2018, 01, 01, 00, 00, 00, 00),
                            Documents = new[]
                            {
                                new Document
                                {
                                    Guid = new Guid("55ba897a-65f3-4c10-975b-852628a5394b"),
                                    DocSeries = "",
                                    DocNumber = "",
                                    DocIssueDate = new DateTime(2003, 12, 23, 00, 00, 00, 00),
                                    DocEndDate = null,
                                    OrgName = "ОУФМС России по Пермскому краю",
                                    DocKind = new Guid("a27e99e1-52cc-44c4-8a12-aa6effb7d7e3")
                                }
                            }
                        }
                    }
                }
            };
        }

        public static ToMsrFromReestrMspFiasDataChanges GetToMsrFromReestrMspFiasDataChangesMessage()
        {
            return new ToMsrFromReestrMspFiasDataChanges
            {
                RequestInfo = "RequestInfo",
                Items = new List<ServiceBus.ObjectDataModel.FIAS.FiasDataDefinition>
                {
                    new ServiceBus.ObjectDataModel.FIAS.FiasDataDefinition
                    {

                                State = tState.updated,
                                Timestamp = new DateTime(2017,12,31,23,59,59),
                                FiasAddressObjects = new ServiceBus.ObjectDataModel.FIAS.FiasAddressObjects
                                {
                                    AOGUID = "ba96b481-06d9-4e54-a980-ecd6aa8d3315",
                                    FORMALNAME = "Прямой",
                                    REGIONCODE = "01",
                                    AUTOCODE = "0",
                                    AREACODE = "000",
                                    CITYCODE = "001",
                                    CTARCODE = "000",
                                    PLACECODE = "017",
                                    PLANCODE = "PLANCODE1",
                                    STREETCODE = "0028",
                                    EXTRCODE = "0000",
                                    SEXTCODE = "000",
                                    OFFNAME = "Прямой",
                                    POSTALCODE = "385750",
                                    IFNSFL = "0105",
                                    TERRIFNSFL = "0104",
                                    IFNSUL = "0105",
                                    TERRIFNSUL = "0104",
                                    OKATO = "79222555000",
                                    OKTMO = "79622155",
                                    UPDATEDATE = new DateTime(2015,02,03),
                                    SHORTNAME = "пер",
                                    AOLEVEL = 7,
                                    PARENTGUID = "ff08620b-ae89-45ab-a1e0-7e7b48b4dd4a",
                                    AOID = "f21725a7-43d2-4290-a5b6-697b88c47659",
                                    PREVID = "PREVID1",
                                    NEXTID = "18f6710d-b12f-4b42-9413-3ea816c8d07c",
                                    PLAINCODE = "010040000150077",
                                    ACTSTATUS = 1,
                                    LIVESTATUS = 0,
                                    CENTSTATUS = 2,
                                    OPERSTATUS = 1,
                                    CURRSTATUS = 1,
                                    STARTDATE = new DateTime(1900,01,01),
                                    ENDDATE = new DateTime(2013,02,14),
                                    NORMDOC = "NORMDOC1",
                                    CADNUM = "CADNUM1",
                                    DIVTYPE = 1,
                                }
                    },

                       new ServiceBus.ObjectDataModel.FIAS.FiasDataDefinition
                       {
                                State = tState.updated,
                                Timestamp = new DateTime(2017,12,31,23,59,59),
                                FiasHousesStructures = new ServiceBus.ObjectDataModel.FIAS.FiasHousesStructures
                                {
                                    POSTALCODE = "404130",
                                    IFNSFL = "3435",
                                    TERRIFNSFL = "TERRIFNSFL3",
                                    IFNSUL = "3435",
                                    TERRIFNSUL = "TERRIFNSUL3",
                                    UPDATEDATE = DateTime.Parse("2018-02-21"),
                                    HOUSENUM = "1",
                                    ESTSTATUS = 0,
                                    BUILDNUM = "0",
                                    STRUCNUM = "1",
                                    STRSTATUS = 1,
                                    HOUSEID = "bdc067b7-f010-48a5-a9cf-006576cb2773",
                                    HOUSEGUID = "1d6d3bdd-0565-4074-ad71-539548e96eac",
                                    AOGUID = "ec16acca-b798-4cf8-af75-6c0c7ee6a849",
                                    STARTDATE = DateTime.Parse("2017-12-01"),
                                    ENDDATE = DateTime.Parse("2079-06-06"),
                                    STATSTATUS = 777,
                                    NORMDOC = "0",
                                    COUNTER = 18,
                                    CADNUM = "1",
                                    DIVTYPE = 1,
                                }
                       }

                }
            };
        }

        public static ToMsrFromReestrMspFiasItemsResponse GetToMsrFromReestrMspFiasItemsMessage()
        {
            return new ToMsrFromReestrMspFiasItemsResponse
            {
                RequestInfo = "RequestInfo",
                Items = new List<ServiceBus.ObjectDataModel.FIAS.FiasItemsDataDefinition>
                {

                        new ServiceBus.ObjectDataModel.FIAS.FiasItemsDataDefinition
                        {
                                FiasAddressObjects = new ServiceBus.ObjectDataModel.FIAS.FiasAddressObjects
                                {
                                    AOGUID = "ba96b481-06d9-4e54-a980-ecd6aa8d3315",
                                    FORMALNAME = "Прямой",
                                    REGIONCODE = "01",
                                    AUTOCODE = "0",
                                    AREACODE = "000",
                                    CITYCODE = "001",
                                    CTARCODE = "000",
                                    PLACECODE = "017",
                                    PLANCODE = "PLANCODE1",
                                    STREETCODE = "0028",
                                    EXTRCODE = "0000",
                                    SEXTCODE = "000",
                                    OFFNAME = "Прямой",
                                    POSTALCODE = "385750",
                                    IFNSFL = "0105",
                                    TERRIFNSFL = "0104",
                                    IFNSUL = "0105",
                                    TERRIFNSUL = "0104",
                                    OKATO = "79222555000",
                                    OKTMO = "79622155",
                                    UPDATEDATE = new DateTime(2015,02,03),
                                    SHORTNAME = "пер",
                                    AOLEVEL = 7,
                                    PARENTGUID = "ff08620b-ae89-45ab-a1e0-7e7b48b4dd4a",
                                    AOID = "f21725a7-43d2-4290-a5b6-697b88c47659",
                                    PREVID = "PREVID1",
                                    NEXTID = "18f6710d-b12f-4b42-9413-3ea816c8d07c",
                                    PLAINCODE = "010040000150077",
                                    ACTSTATUS = 1,
                                    LIVESTATUS = 0,
                                    CENTSTATUS = 2,
                                    OPERSTATUS = 1,
                                    CURRSTATUS = 1,
                                    STARTDATE = new DateTime(1900,01,01),
                                    ENDDATE = new DateTime(2013,02,14),
                                    NORMDOC = "NORMDOC1",
                                    CADNUM = "CADNUM1",
                                    DIVTYPE = 1,
                                }
                        },

                       new ServiceBus.ObjectDataModel.FIAS.FiasItemsDataDefinition
                       {
                                FiasHousesStructures = new ServiceBus.ObjectDataModel.FIAS.FiasHousesStructures
                                {
                                    POSTALCODE = "404130",
                                    IFNSFL = "3435",
                                    TERRIFNSFL = "TERRIFNSFL3",
                                    IFNSUL = "3435",
                                    TERRIFNSUL = "TERRIFNSUL3",
                                    UPDATEDATE = DateTime.Parse("2018-02-21"),
                                    HOUSENUM = "1",
                                    ESTSTATUS = 0,
                                    BUILDNUM = "0",
                                    STRUCNUM = "1",
                                    STRSTATUS = 1,
                                    HOUSEID = "bdc067b7-f010-48a5-a9cf-006576cb2773",
                                    HOUSEGUID = "1d6d3bdd-0565-4074-ad71-539548e96eac",
                                    AOGUID = "ec16acca-b798-4cf8-af75-6c0c7ee6a849",
                                    STARTDATE = DateTime.Parse("2017-12-01"),
                                    ENDDATE = DateTime.Parse("2079-06-06"),
                                    STATSTATUS = 777,
                                    NORMDOC = "0",
                                    COUNTER = 18,
                                    CADNUM = "1",
                                    DIVTYPE = 1,
                                }
                       }

                }
            };
        }

        public static ToMsrFromReestrMspMergedItemsResponse GetToMsrFromReestrMspMergeItemsMessage()
        {
            return new ToMsrFromReestrMspMergedItemsResponse
            {
                RequestInfo = "RequestInfo2",
                Items = new List<MergeItemDefinition>
                {
                    new MergeItemDefinition
                    {
                        Sources = new List<SourceKeyDefinition>
                        {
                            new SourceKeyDefinition
                            {
                                Key = Guid.Parse("7e4ddbf4-a9fa-49bb-b465-16fd8d757537")
                            },
                            new SourceKeyDefinition
                            {
                                Key = Guid.Parse("f8428d4f-cea8-4d4c-9200-02d6584e776f")
                            }
                        },
                        Beneficiary = new Beneficiary
                        {
                            Guid = Guid.Parse("6e758c67-8264-4b6a-85d2-45df998c516d"),
                            FamilyName = "Иванов",
                            FirstName = "Иван",
                            Patronymic = "Иванович",
                            Gender = tGender.Муж,
                            BirthDate = DateTime.Parse("1986-12-01"),
                            Snils = "206-990-531-80",
                            INN = "403183646797",
                            Email = "Ivanov86@mail.ru",
                            Phone = "123456789",
                            Education = tEducation.Высшее,
                            BirthCountry = "Россия",
                            BirthRegion = "Пермский край",
                            BirthTown = "Оса",
                            BirthDistrict = "Осинский район",
                            Location = new Location
                            {
                                Guid = Guid.Parse("6282decd-e5c7-4ce2-8fec-3f19c0a432b1"),
                                Territory = new Territory
                                {
                                    Guid = Guid.Parse("cd9beee7-bad6-437f-93bc-d852d45684f7"),
                                    FIAS = "456",
                                    ObjectType = "г",
                                    Name = "Пермь",
                                    PostIndex = "614000",
                                    Parent = new Territory
                                    {
                                       Guid = Guid.Parse("094be3a3-7538-463a-b8fb-03187f4d5c7c")
                                    }
                                },
                                Street = new Street
                                {
                                    Guid = Guid.Parse("664f364c-54a8-4193-b584-1d274be030fb"),
                                    FIAS = "123",
                                    ObjectType = "ул",
                                    Name = "Сиреневая",
                                    PostIndex = "614000",
                                    Territory = new Territory
                                    {
                                       Guid = Guid.Parse("cb8e705b-b22f-4ab5-b515-85df867d91bd")
                                    }
                                },
                                Number = 27,
                                Index = "614000",
                                Appartment = "5",
                                Phone = "2658941"
                            },
                            Registration = new Registration
                            {
                                Guid = Guid.Parse("7645decd-e5c7-4ce2-8fec-3f19c0a432b1"),
                                Territory = new Territory
                                {
                                    Guid = Guid.Parse("cd9beee7-bad6-437f-93bc-d852d45684f7"),
                                    FIAS = "456",
                                    ObjectType = "г",
                                    Name = "Пермь",
                                    PostIndex = "614000",
                                    Parent = new Territory
                                    {
                                       Guid = Guid.Parse("094be3a3-7538-463a-b8fb-03187f4d5c7c")
                                    }
                                },
                                Street = new Street
                                {
                                    Guid = Guid.Parse("664f364c-54a8-4193-b584-1d274be030fb"),
                                    FIAS = "123",
                                    ObjectType = "ул",
                                    Name = "Сиреневая",
                                    PostIndex = "614000",
                                    Territory = new Territory
                                    {
                                       Guid = Guid.Parse("cb8e705b-b22f-4ab5-b515-85df867d91bd")
                                    }
                                },
                                Number = 27,
                                Index = "614000",
                                Appartment = "5",
                                Phone = "2658941"
                            },
                            Documents = new Document[]
                            {
                                new Document
                                {
                                    Guid = Guid.Parse("55ba897a-65f3-4c10-975b-852628a5394b"),
                                    DocSeries = "5703",
                                    DocNumber = "598236",
                                    DocIssueDate = DateTime.Parse("2003-12-23"),
                                    OrgName = "ОУФМС России по Пермскому краю",
                                    DocKind = Guid.Parse("a27e99e1-52cc-44c4-8a12-aa6effb7d7e3")
                                }
                            }
                        }
                    }
                }
            };
        }

        public static ToMsrFromTUResponse GetToMsrFromTUMessage()
        {
            return new ToMsrFromTUResponse
            {
                RequestInfo = "test",
                Items = new List<ServiceBus.ObjectDataModel.FromTU.ChangedItem>
                {
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,14,10,50,00),
                        Beneficiary = new ServiceBus.ObjectDataModel.FromTU.Beneficiary
                        {
                            Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A"),
                            FamilyName = "Иванов",
                            FirstName = "Иван",
                            Patronymic = "Иванович",
                            Gender = ServiceBus.ObjectDataModel.FromTU.tGender.Muzhskoi,
                            BirthDate = new DateTime(1950,01,01),
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
                            },
                            CreateTime = new DateTime(2018,04,25,0,0,0),
                            Creator = "1",
                            EditTime = new DateTime(2018,04,25,0,0,0),
                            Editor = "2"
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,16,11,30,00),
                        Movement = new ServiceBus.ObjectDataModel.FromTU.Movement
                        {
                            Guid = new Guid("8512350B-5DB5-4AE0-BCCE-A0A918CC6106"),
                            DepatureDate = new DateTime(2017,01,01),
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
                            },
                            CreateTime = new DateTime(2018,04,25,0,0,0),
                            Creator = "1",
                            EditTime = new DateTime(2018,04,25,0,0,0),
                            Editor = "2"
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,16,11,34,00),
                        Document = new ServiceBus.ObjectDataModel.FromTU.Document
                        {
                            Guid = new Guid("B0134607-6467-4BEF-B6DD-C355C6B81A73"),
                            Series = "1111",
                            Number = "111111",
                            IssueDate = new DateTime(2010,02,02),
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
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,16,11,41,00),
                        ChangeName = new ServiceBus.ObjectDataModel.FromTU.ChangeName
                        {
                            Guid = new Guid("81B7947A-895B-4107-8EA0-4CFB23551D30"),
                            FamilyName = "Ivanov",
                            FirstName = "Ivan",
                            Patronymic = "Ivanovich",
                            ChangeDate = new DateTime(2010,4,5),
                            Beneficiary = new SyncXMLDataObject
                            {
                                    Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                            }
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,16,11,44,00),
                        BeneficiaryPreferentialCategory = new ServiceBus.ObjectDataModel.FromTU.BeneficiaryPreferentialCategory
                        {
                            Guid = new Guid("F94B32C8-BECD-497E-A802-63624C7012A4"),
                            AppointmentDate = new DateTime(2015,04,04),
                            CancellationDate = new DateTime(2016,12,12),
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
                            },
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,16,11,50,00),
                        Disability = new ServiceBus.ObjectDataModel.FromTU.Disability
                        {
                            Guid = new Guid("18FCC3EF-2638-4770-BCF9-79A565AF481F"),
                            Group = ServiceBus.ObjectDataModel.FromTU.tGroupDisability.Вторая,
                            ReferenceNumberVTEK = "111",
                            IssueDateVTEK = new DateTime(2010,10,10),
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
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,16,11,50,00),
                        RegistrationBeneficiary = new ServiceBus.ObjectDataModel.FromTU.RegistrationBeneficiary
                        {
                            Guid = new Guid("BB0746E6-3D07-4A0E-95F4-ABB919B28168"),
                            RegistrationDate = new DateTime(2010,10,10),
                            DeregistrationDate = new DateTime(2015,10,10),
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
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.updated,
                        ChangeDate = new DateTime(2018,4,25,12,0,0),
                        PaymentAppointment = new ServiceBus.ObjectDataModel.FromTU.PaymentAppointment
                        {
                            Guid = new Guid("1D90EE8E-C576-40A4-B68D-14C2BC8E5457"),
                            Confirmed = ServiceBus.ObjectDataModel.FromTU.tBool.Да,
                            Benefit = new SyncXMLDataObject
                            {
                                Guid = new Guid("7528b96a-b91b-4017-85a4-0b6bf539eaae")
                            },
                            Medium = new SyncXMLDataObject
                            {
                                    Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                            },
                            Dependent = new SyncXMLDataObject
                            {
                                    Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                            }
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,25,12,30,30),
                        ChangeAppointmentPayment = new ServiceBus.ObjectDataModel.FromTU.ChangeAppointmentPayment
                        {
                            Guid = new Guid("EA4578C9-878D-4F4E-8309-612C83BCCBAB"),
                            AppointmentDate = new DateTime(2018,3,20),
                            CancellationDate = new DateTime(2018,4,20),
                            PaymentType = ServiceBus.ObjectDataModel.FromTU.tPaymentType.Периодическая,
                            Period = ServiceBus.ObjectDataModel.FromTU.tPeriodType.God,
                            Amount = 100.5m,
                            Note = "2",
                            SocialProtectionAuthority = new SyncXMLDataObject
                            {
                                Guid = new Guid("6b5c34fb-75e9-46bb-84c8-3a2387f4a87f")
                            },
                            BeneficiaryPreferentialCategory = new SyncXMLDataObject
                            {
                                Guid = new Guid("F94B32C8-BECD-497E-A802-63624C7012A4")
                            },
                            Recipient = new SyncXMLDataObject
                            {
                                Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                            },
                            PaymentAppointment = new SyncXMLDataObject
                            {
                                    Guid = new Guid("1D90EE8E-C576-40A4-B68D-14C2BC8E5457"),
                            }
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,25,11,20,30),
                        FactBenefits = new ServiceBus.ObjectDataModel.FromTU.FactBenefits
                        {
                            Guid = new Guid("C5FBE096-28AC-41B5-AF6E-F37650D9AEBF"),
                            AccrualDate = new DateTime(2018,2,20),
                            ReceiveDate = new DateTime(2018,3,20),
                            Amount = 100.23m,
                            AmountSocialPackage = 200.20m,
                            Comments = "1",
                            PaymentMethod = ServiceBus.ObjectDataModel.FromTU.tPaymentMethod.AlterBankPerevod,
                            OverpaymentDateFrom = new DateTime(2018,1,1),
                            OverpaymentDateTo = new DateTime(2018,12,31),
                            MediumBenefit = new SyncXMLDataObject
                            {
                                    Guid = new Guid("F94B32C8-BECD-497E-A802-63624C7012A4")
                            },
                            Dependent = new SyncXMLDataObject
                            {
                                Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                            },
                            Recipient = new SyncXMLDataObject
                            {
                                Guid = new Guid("B399A518-28A7-444B-A822-069747E3952A")
                            },
                            Benefit = new SyncXMLDataObject
                            {
                                Guid = new Guid("7528b96a-b91b-4017-85a4-0b6bf539eaae")
                            },
                                SocialProtectionAuthority = new SyncXMLDataObject
                            {
                                Guid = new Guid("6b5c34fb-75e9-46bb-84c8-3a2387f4a87f")
                            },
                                Period = new SyncXMLDataObject
                                {
                                    Guid = new Guid("faaa6443-5efa-4487-9a48-8669fff8b09c")
                                }
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,4,25),
                        Location = new ServiceBus.ObjectDataModel.FromTU.Location
                        {
                            Guid = new Guid("31AA64E2-5D8D-4FA3-B0E0-D76D4BED9687"),
                            Structure = new SyncXMLDataObject
                            {
                                Guid = new Guid("A66AA31B-86E6-4359-83DA-CD2302199A95")
                            },
                            Territory = new SyncXMLDataObject
                            {
                                Guid = new Guid("5deca65d-3b69-41ab-89a0-b01f3c597b01")
                            },
                            Street = new SyncXMLDataObject
                            {
                                Guid = new Guid("25fa5f54-8b78-4537-8890-6a109de916e0")
                            },
                            Number = 1,
                            HouseNumber = "2",
                            Index = "123",
                            Appartment = "123",
                            Phone = "123",
                            Area = 123,
                            NumberRooms = 1,
                            Deterioration = 1,
                            NumberResidents = 2,
                            OtherCharacteristics = "123"
                        }
                    },
                    new ServiceBus.ObjectDataModel.FromTU.ChangedItem
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        Structure = new ServiceBus.ObjectDataModel.FromTU.Structure
                        {
                            Guid = new Guid("A66AA31B-86E6-4359-83DA-CD2302199A95"),
                            FIAS = "12",
                            TypeStructure = ServiceBus.ObjectDataModel.FromTU.tTypeStructure.Avariinoe,
                            Number = 1,
                            PostIndex = "123",
                            Additional = "2",
                            VerificationCode = 123,
                            Area = new SyncXMLDataObject
                            {
                                Guid = new Guid("5deca65d-3b69-41ab-89a0-b01f3c597b01")
                            },
                            Street = new SyncXMLDataObject
                            {
                                Guid = new Guid("25fa5f54-8b78-4537-8890-6a109de916e0")
                            }
                        }

                    },
                    new ChangedItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ZaiavlenieNaGosUslugu = new ZaiavlenieNaGosUslugu()
                        {
                            Guid = new Guid("6d15be60-cf94-451d-8853-46944086f87f"),
                            DataVremia = new DateTime(2018,1,2),
                            ZaprosPortalaGosUsl = "zapros",
                            OtvetNaZapros = "otvet",
                            SoobshchenieObOshibke = "error 404",
                            SoobshchenieObOshibkeShiny = "error 505",
                            DataVremiaZaprosa = new DateTime(2018,1,3),
                            NomerZaprosa = "404",
                            IdentifikDannyeLeechnosti = "new leechnost",
                            OtvetVSvobodnoiForme = "otvet new",
                            DataIspolneniia = new DateTime(2018,1,4),
                            OriginalyDokPolucheny = tBool.Да,
                            ZaprosPortalaGosUslParsed = "zapros parsed",
                            GosUsluga = new SyncXMLDataObject()
                            {
                                Guid = new Guid("a6ab1f4f-a29f-4b31-adce-5ee52dce43b9")
                            },
                            Zaiavitel = new SyncXMLDataObject()
                            {
                                Guid = new Guid("d7ddb5dc-e63e-45e3-99b3-942fcd5c5822")
                            },
                            Opekaemyi = new SyncXMLDataObject()
                            {
                                Guid = new Guid("04d210ce-056f-40b9-b2fb-422be0afb088")
                            },
                            Ispolnitel = new SyncXMLDataObject()
                            {
                                Guid = new Guid("7ca966ea-9ccf-4b12-93c6-800c14fc613c")
                            },
                            OrganSZ = new SyncXMLDataObject()
                            {
                                Guid = new Guid("0ec4e370-463c-4c4d-a22f-313ce68c5af0")
                            }, 
                            PrichinaOtkaza = new SyncXMLDataObject()
                            {
                                Guid = new Guid("30ab568d-605a-4139-a16a-e858590b176f")
                            },
                            Rezultat = new SyncXMLDataObject()
                            {
                                Guid = new Guid("3cb1ef1b-3776-43e9-9511-3f4af661f80a")
                            },
                            CreateTime = new DateTime(2018,2,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,2,1),
                            Editor = "user"
                        }
                    },
                    new ChangedItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChlenSemi = new ChlenSemi()
                        {
                            Guid = new Guid("a446df9c-5c33-4018-bcb8-0bda8f8cc797"),
                            IdentifikDannyeLeechnosti = "new leechnost",
                            Shkolnik = tSchoolChild.Работает,
                            Zaiavlenie = new SyncXMLDataObject()
                            {
                                Guid = new Guid("8e8d494f-a6a1-41ea-8cf9-52e7c99eb9e1")
                            },
                            Leechnost = new SyncXMLDataObject()
                            {
                                Guid = new Guid("dd0797b1-487f-4fbb-b255-1457403b11fb")
                            },
                            RodstvOtn = new SyncXMLDataObject()
                            {
                                Guid = new Guid("94379609-6841-4b30-9068-9bfeb5d097ba")
                            },
                            CreateTime = new DateTime(2018,2,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,2,1),
                            Editor = "user"
                        }
                    }
                }
            };
        }

        public static ToReestrMspFromMsrCatalogItemsRequest GetToReestrMspFromMsrCatalogItemsRequestMessage()
        {
            return new ToReestrMspFromMsrCatalogItemsRequest
            {
                RequestInfo = "1234decd-e5c7-4ce2-8fec-3f19c0a432b1",
                Criteria = new CriteriaDefinition
                {
                    Type = "and",
                    Condition = new ConditionDefinition[3]
                    {
                        new ConditionDefinition {Attribute = "FORMALNAME", Operator = "equals", Value = "Аналитика Афанасьевой"},
                        new ConditionDefinition {Attribute = "SHORTNAME", Operator = "equals", Value = "ул"},
                        new ConditionDefinition {Attribute = "SyncXMLDataObject", Operator = "equals", Value = "95a2d110-4322-4076-bcc9-6fb7f560eaaf" }
                    }
                },
                Type = "fiasAddressObject"
            };
        }

        public static ToTUFromMsrResponse GetToTUFromMsrResponseMessage()
        {
            return new ToTUFromMsrResponse()
            {
                RequestInfo = "test",
                Items = new List<ToTUChangeItem>
                {
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "territory",
                        Territory = new ServiceBus.ObjectDataModel.ToTU.Territory()
                        {
                            Guid = new Guid("aa302222-7cb0-46c6-aeb8-1695aedabd39"),
                            Id = 5,
                            FIAS = "1234567890987654321",
                            ObjectType = "type1",
                            Name = "territory5",
                            PostIndex = "614083",
                            Parent = new SyncXMLDataObject()
                            {
                                Guid = new Guid("f51cbd5a-626b-4154-b440-d9a8d29438fe")
                            },
                            SocialProtectionAuthority = new SyncXMLDataObject()
                            {
                                Guid = new Guid("d312c5fb-435e-4eb6-9771-eea28b0de21a")
                            },
                            CodeSPA = "456",
                            CodeKLADR = "667",
                            CodeOKATO = "888999",
                            UrbanArea = tBool.Да,
                            RegionCodePF = "5566",
                            CodeOKTMO = "88",
                            CodeOPFR = "90",
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user"
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "socialProtectionAuthority",
                        SocialProtectionAuthority = new SocialProtectionAuthority()
                            {
                                Guid = new Guid("d312c5fb-435e-4eb6-9771-eea28b0de21a"),
                                Id = 5,
                                CreateTime = new DateTime(2018,1,2),
                                Creator = "admin",
                                EditTime = new DateTime(2018,1,1),
                                Editor = "user",
                                Name = "SPA",
                                Address = "address45",
                                Phone = "88005553535",
                                Code = 90,
                                ShortName = "name55",
                                CodePF = "pf55",
                                FullName = "name 6677",
                                CodeSB = "2345",
                                DistrictCoefficient = 9,
                                SONOCodeFNS = "sono",
                                INN = "inn666777888",
                                KPP = "123456789",
                                BranchAccouningWithoutSeparateSPA = tBool.Да,
                                CodeOKPO = "4455",
                                CodeOKTMO = "OKTMO66",
                                TerritorialAuthorityFT = "ter authority FT 88",
                                CodeTerritorialAuthorityFT = "567",
                                CodeBP = "123",
                                NameTU = "TU 90",
                                CodeTU = "90",
                                UnitedSPA = tBool.Да,
                                OGRN = "1234567890",
                                RegNumberPF = "76",
                                CodeTerAuthorityPF = "23",
                                NameTerAuthorityPF = "Ter Authority",
                                Parent = new SyncXMLDataObject()
                                {
                                    Guid = new Guid("2381333b-1386-4c5f-b5f8-87937e222cfa")
                                }
                            }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "street",
                        Street = new ServiceBus.ObjectDataModel.ToTU.Street()
                        {
                            Guid = new Guid("9a71a6a3-5c0d-4311-a5f0-d669c76e260a"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "Lenina",
                            PostIndex = "614083",
                            CodeCLADR = "645",
                            CodeGR = 7,
                            ObjectType = "type 89",
                            CodeFIAS = "55777",
                            NewName = new SyncXMLDataObject()
                            {
                                Guid = new Guid("ff7cd1e7-c2fa-40cd-9388-b5f9bcd8f0b5")
                            },
                            Territory = new SyncXMLDataObject()
                            {
                                Guid = new Guid("0bed57f0-6ca4-4e10-8112-3f75e82f0073")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "country",
                        Country = new Country()
                        {
                            Guid = new Guid("a1c519d2-ee50-4bdc-9e57-d67cc30869bd"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            FullName = "Canada",
                            ShortName = "CA",
                            NumericCode = 77,
                            CodeAlpha2 = "34",
                            CodeAlpha3 = "353"
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "preferentialCategory",
                        PreferentialCategory = new PreferentialCategory()
                        {
                            Guid = new Guid("49040e3a-086f-4c70-8271-84f701da2fb8"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "category1",
                            Disability = tBool.Да,
                            Parent = new SyncXMLDataObject()
                            {
                                Guid = new Guid("90103000-d056-4ffe-b656-54cb2ca26f7a")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "benefitForCategory",
                        BenefitForCategory = new BenefitForCategory()
                        {
                            Guid = new Guid("94f58466-2bb3-48f8-abfc-6eeef47df529"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            AppointmentDate = new DateTime(2018,2,1),
                            CancellationDate = new DateTime(2018,3,1),
                            Period = tPeriodType.Mesiatc,
                            PaymentType = tTipVyplaty.NaChlenaSemi,
                            Benefit = new SyncXMLDataObject()
                            {
                                Guid = new Guid("ed242341-5d86-4533-b130-b005d45cdd7a")
                            },
                            FundingSource = new SyncXMLDataObject()
                            {
                                Guid = new Guid("55670d98-305c-4f33-a5d1-7463ca333f55")
                            },
                            Reason = new SyncXMLDataObject()
                            {
                                Guid = new Guid("68c14034-f3ab-4cd8-8386-9bd0dba9a51c")
                            },
                            PreferentialCategory = new SyncXMLDataObject()
                            {
                                Guid = new Guid("f71087b1-8b17-4be0-8545-04be58f5c150")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "benefit",
                        Benefit = new Benefit()
                        {
                            Guid = new Guid("b5c44361-b638-4a51-ac05-90eaa1caa324"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "benefit 67",
                            InSocialPackage = tBool.Да,
                            CodeIncome = "8899",
                            TaxedNDFL = tBool.Да,
                            TaxedESN = tBool.Да,
                            Parent = new SyncXMLDataObject()
                            {
                                Guid = new Guid("7d72816d-c0ef-42e2-aa69-49f7508b2b4a")
                            },
                            TypeBenefit = new SyncXMLDataObject()
                            {
                                Guid = new Guid("0f4b4ded-c4ad-4784-8580-c4051396f1cf")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "typeBenefit",
                        TypeBenefit = new TypeBenefit()
                        {
                            Guid = new Guid("3d94d48f-4413-4b0b-9fc1-f82cabd7b148"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "type 67"
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "fundingSource",
                        FundingSource = new FundingSource()
                        {
                            Guid = new Guid("b17b790b-0d37-491a-896c-b05e31183f96"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "source 67"
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "legalAct",
                        LegalAct = new LegalAct()
                        {
                            Guid = new Guid("66e735c3-1330-43fe-8659-07d36c727736"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "act 67",
                            Number = "5577",
                            SignatureDate = new DateTime(2018,1,1),
                            CodeReportFK = "123",
                            TypeLegalAct = new SyncXMLDataObject()
                            {
                                Guid = new Guid("373e558b-25dc-4a89-8acf-a86138f33895")
                            },
                            NamePublisher = new SyncXMLDataObject()
                            {
                                Guid = new Guid("b95a2682-362f-4455-ac66-c227e34b9169")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "act",
                        Act = new Act()
                        {
                            Guid = new Guid("c4a19b59-46fb-4806-847a-fabb0ed51518"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Number = "890",
                            Comments = "comments",
                            Benefit = "benefit78",
                            Code = "567890",
                            LegalAct = new SyncXMLDataObject()
                            {
                                Guid = new Guid("30837a63-843b-4b7f-9a57-b26751870a04")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "typeLegalAct",
                        TypeLegalAct = new TypeLegalAct()
                        {
                            Guid = new Guid("bbaddf16-ebbe-4325-8cc6-ae7f886e0262"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "type 676"
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "governmentLevel",
                        GovernmentLevel = new GovernmentLevel()
                        {
                            Guid = new Guid("dc095b0a-835c-494c-a13e-e8df69c393f5"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "level 676"
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "authorityIssuedDocument",
                        AuthorityIssuedDocument = new AuthorityIssuedDocument()
                        {
                            Guid = new Guid("7e120a09-7ad8-406c-a1fe-f76aea071a31"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "AID 676",
                            Address = "address11",
                            PhoneNumber = "88005553535",
                            SocialProtectionAuthority = new SyncXMLDataObject()
                            {
                                Guid = new Guid("1a432161-e257-45c9-a6a8-1396d53fdbc6")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "specialist",
                        Specialist = new ServiceBus.ObjectDataModel.ToTU.Specialist()
                        {
                            Guid = new Guid("105f6660-cfba-4b7c-8327-681fb75259b3"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            FamilyName = "Ivanov",
                            FirstName = "Ivan",
                            Patronymic = "ivanovich",
                            ChiefSPA = tBool.Да,
                            Login = "ivan44",
                            SocialProtectionAuthority = new SyncXMLDataObject()
                            {
                                Guid = new Guid("90b20133-5a51-4220-a096-f631338f510a")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "period",
                        Period = new ServiceBus.ObjectDataModel.ToTU.Period()
                        {
                            Guid = new Guid("fc14e20c-e685-4bf5-bcbc-9f18f2dfa87a"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "Period 676",
                            StartDate = new DateTime(2018,2,1),
                            EndDate = new DateTime(2018,3,1),
                            PeriodType = tPeriodType.Mesiatc,
                            Value = 13,
                            Parent = new SyncXMLDataObject()
                            {
                                Guid = new Guid("30bdbfdb-1da0-434b-ad0e-fab0dfc8207b")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "deregestrationReason",
                        DeregestrationReason = new DeregestrationReason()
                        {
                            Guid = new Guid("75193fe3-66d3-49cc-97cc-f9ebe5cdc825"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "Reason 676",
                            Discontinuation = tBool.Да
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "displacementReason",
                        DisplacementReason = new DisplacementReason()
                        {
                            Guid = new Guid("e7e9436d-1269-4835-bc90-d25bcd1fcad7"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "Reason 67"
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "familyRelation",
                        FamilyRelation = new FamilyRelation()
                        {
                            Guid = new Guid("ad0ff379-0438-4775-ab19-18ce3a4bb88b"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "Relation 67",
                            Gender = ServiceBus.ObjectDataModel.FromTU.tGender.Muzhskoi
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "kindDocument",
                        KindDocument = new ServiceBus.ObjectDataModel.ToTU.KindDocument()
                        {
                            Guid = new Guid("53f1b8d8-f4cb-4d5b-99e1-42dbcb379fb7"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "kind 67",
                            ShortName = "67",
                            CodePF = "89",
                            Priority = 1,
                            CodeKindDocument = "76",
                            PriorityFNS = 2,
                            TypeDocument = new SyncXMLDataObject()
                            {
                                Guid = new Guid("6b03e220-a436-4e87-96e0-b944f5730acb")
                            }
                        }
                    },
                    new ToTUChangeItem()
                    {
                        State = tState.created,
                        ChangeDate = new DateTime(2018,1,1),
                        ChangedObjectType = "typeDocument",
                        TypeDocument = new ServiceBus.ObjectDataModel.ToTU.TypeDocument()
                        {
                            Guid = new Guid("78d19116-7289-4deb-8a35-27a4b1a62d3c"),
                            Id = 5,
                            CreateTime = new DateTime(2018,1,2),
                            Creator = "admin",
                            EditTime = new DateTime(2018,1,1),
                            Editor = "user",
                            Name = "type 678"
                        }
                    }
                }
            };
        }
    }
}

