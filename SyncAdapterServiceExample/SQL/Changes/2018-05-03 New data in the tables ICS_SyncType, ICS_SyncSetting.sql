--ICS_SYNCTYPE:
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('6d9bfe00-d645-4622-9edd-95b1117121b3', 'Iis.Eais.Catalogs.OrganSZ', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('7d5da28b-70aa-4f3e-8455-54e2ec3ecbd8', 'Iis.Eais.Catalogs.LgotKat', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('763878bb-8104-4b1e-af46-50a8ebacb31f', 'Iis.Eais.Catalogs.LgotaDliaKat', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('6a3536b5-c3b5-4462-a538-411e8d49a20c', 'Iis.Eais.Catalogs.Lgota', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('58997646-b5a6-4ae3-b30b-5637621988c6', 'Iis.Eais.Catalogs.TipLgoty', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('f80494e5-cc8f-4bf5-8011-002aef817b3f', 'Iis.Eais.Catalogs.IstochnikFin', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('45230a0e-9157-4e30-a191-0ca02cd77ef4', 'Iis.Eais.Catalogs.NormAkt', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('36a7f741-3754-4d10-8f84-0bdbe83781a7', 'Iis.Eais.Catalogs.StatiaAkta', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('fbe29912-f2f9-4210-80eb-f7d951e3db23', 'Iis.Eais.Catalogs.TipNormAkta', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('0e05293e-e8cb-41cd-97d2-04ff0d61ffba', 'Iis.Eais.Catalogs.UrovenVlasti', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('1c680ff3-0d89-4af6-bd36-55cd5028e496', 'Iis.Eais.Catalogs.OrganVydDok', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('7b2d472e-8588-4376-bb50-a51e113a6da9', 'Iis.Eais.Catalogs.Specialist', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('90ffea0a-7dfd-4700-8935-65e6305a57dc', 'Iis.Eais.Catalogs.Period', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('00709562-9893-492b-9cf5-9de5a86464f8', 'Iis.Eais.Catalogs.PrichinaSnyatiya', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('b7fad185-5ab6-4a47-9518-c791fa3368a9', 'Iis.Eais.Catalogs.PrichinaPeremeshcheniia', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('e30ace3b-730a-46e2-a43e-2b79c82ab8c7', 'Iis.Eais.Catalogs.RodstvOtn', '9bed662c-c72c-4198-bcbb-f3da5cad1150');

--TEST TYPE
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('04447242-C166-4CAE-BB6E-E32B820644C0', 'TestTypeForObservers', '9bed662c-c72c-4198-bcbb-f3da5cad1150');

--ICS_SYNCSETTING:
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('c8a058dd-8ee5-4562-b424-f3a9d9f0ddc3', 'mappername', 'Eais.Observers.Core.ObserversForTU.StatiaAktaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '36a7f741-3754-4d10-8f84-0bdbe83781a7', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('d08515f3-8a16-44e4-ade1-4ddd4ebf806e', 'mappername', 'Eais.Observers.Core.ObserversForTU.OrganVydDokObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '1c680ff3-0d89-4af6-bd36-55cd5028e496', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('dd3546d4-2cf4-4c8d-98f5-c6c327e2157e', 'mappername', 'Eais.Observers.Core.ObserversForTU.TipNormAktaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', 'fbe29912-f2f9-4210-80eb-f7d951e3db23', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('a19ff11b-c4ac-4155-b1f8-2676be36a8ae', 'mappername', 'Eais.Observers.Core.ObserversForTU.TipLgotyObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '58997646-b5a6-4ae3-b30b-5637621988c6', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('0ccfb3c1-1002-4dc2-b150-677be87ece27', 'mappername', 'Eais.Observers.Core.ObserversForTU.SpecialistObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '7b2d472e-8588-4376-bb50-a51e113a6da9', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('da11004d-cf19-4ffe-a18a-b895ab089cb7', 'mappername', 'Eais.Observers.Core.ObserversForTU.NormAktObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '45230a0e-9157-4e30-a191-0ca02cd77ef4', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('ac19c0db-6a3a-46e8-8c81-4b356438fc9e', 'mappername', 'Eais.Observers.Core.ObserversForTU.LgotKatObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '7d5da28b-70aa-4f3e-8455-54e2ec3ecbd8', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('85cc1ca1-0701-42e9-8eb8-b41e7cabbfc8', 'mappername', 'Eais.Observers.Core.ObserversForTU.UrovenVlastiObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '0e05293e-e8cb-41cd-97d2-04ff0d61ffba', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('0dd946d2-7058-4961-83ac-423f7b13bca0', 'mappername', 'Eais.Observers.Core.ObserversForTU.TerritoriiaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '6919a3f6-b2b2-470e-a18d-e386c9b7d692', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('d41efc96-1c19-411c-b95b-2446b96de2c5', 'mappername', 'Eais.Observers.Core.ObserversForTU.LgotaDliaKatObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '763878bb-8104-4b1e-af46-50a8ebacb31f', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('81720666-4d46-4694-8fda-f4f8623cc342', 'mappername', 'Eais.Observers.Core.ObserversForTU.TipUdostDokObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '726d310c-12d6-4a3a-bcad-202400e079f5', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('47e342c5-fe06-4dab-bf78-5c8366316dfe', 'mappername', 'Eais.Observers.Core.ObserversForTU.PrichinaPeremeshcheniiaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', 'b7fad185-5ab6-4a47-9518-c791fa3368a9', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('544e8951-030c-4909-88e2-80cd25602d32', 'mappername', 'Eais.Observers.Core.ObserversForTU.VidUdostDokObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '9d381a44-7ba6-47b6-a41f-05c76b2cfec7', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('c941fad5-8982-495e-989e-1a18c0f1ad8a', 'mappername', 'Eais.Observers.Core.ObserversForTU.UlitcaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', 'db79a3d6-0399-4b8e-8254-dfb16575239d', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('8f54d98f-f3fa-459c-b9b6-7a573ead17b4', 'mappername', 'Eais.Observers.Core.ObserversForTU.StranaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '321735f4-851c-4adf-bc71-94df6bfb5f27', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('14238295-a2e5-4831-9406-936a4944af3b', 'mappername', 'Eais.Observers.Core.ObserversForTU.IstochnikFinObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', 'f80494e5-cc8f-4bf5-8011-002aef817b3f', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('2a368c01-a4e8-4897-9492-2930ab49ae7a', 'mappername', 'Eais.Observers.Core.ObserversForTU.RodstvOtnObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', 'e30ace3b-730a-46e2-a43e-2b79c82ab8c7', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('0701a40a-f9ab-410a-aee2-3863dc926e7e', 'mappername', 'Eais.Observers.Core.ObserversForTU.LgotaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '6a3536b5-c3b5-4462-a538-411e8d49a20c', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('80cc43ad-dcdc-4edf-88ee-bbc26cf002e4', 'mappername', 'Eais.Observers.Core.ObserversForTU.OrganSZObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '6d9bfe00-d645-4622-9edd-95b1117121b3', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('c5bbe398-319e-448d-a6f3-5abdd32a3b1d', 'mappername', 'Eais.Observers.Core.ObserversForTU.PrichinaSnyatiyaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '00709562-9893-492b-9cf5-9de5a86464f8', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('ec3e4f00-104c-40a1-b49e-ea231c361eca', 'mappername', 'Eais.Observers.Core.ObserversForTU.PeriodObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '90ffea0a-7dfd-4700-8935-65e6305a57dc', '04447242-c166-4cae-bb6e-e32b820644c0');