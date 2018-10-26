--ics_syncsystem
INSERT INTO public.ics_syncsystem (primarykey, name, assembly) VALUES ('6c3724f1-e7ce-41ae-b2a7-9197e76501dd', 'DefConnStr', 'Eais.GosUslugi.Objects, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null');

--ics_synctype
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('774c0db3-c228-4bac-8ddd-1d302d008c59', 'Iis.Eais.GosUslugi.GosUsluga', '6c3724f1-e7ce-41ae-b2a7-9197e76501dd');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('a0020625-276b-4f46-b57b-1faa5d12bd3a', 'Iis.Eais.GosUslugi.NaimOperRassmotrVedom', '6c3724f1-e7ce-41ae-b2a7-9197e76501dd');
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('84d48731-4d42-421a-b6c6-2d3711375c75', 'Iis.Eais.GosUslugi.PrichinaOtkazaPoZaprosuPortalaGosUslug', '6c3724f1-e7ce-41ae-b2a7-9197e76501dd');

--ics_syncsetting
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('5a3847fc-e0a1-484a-9c05-fc556d865074', 'mappername', 'Eais.Observers.Core.ObserversForCatalogsGU.NaimOperRassmotrVedomObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', 'a0020625-276b-4f46-b57b-1faa5d12bd3a', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('f7c6d30a-d053-49f5-93ae-8633b0972379', 'mappername', 'Eais.Observers.Core.ObserversForCatalogsGU.GosUslugaObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '774c0db3-c228-4bac-8ddd-1d302d008c59', '04447242-c166-4cae-bb6e-e32b820644c0');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('96362ca1-c0a6-4322-9651-04b073b93294', 'mappername', 'Eais.Observers.Core.ObserversForCatalogsGU.PrichinaOtkazaPoZaprosuPortalaGosUslugObserver, Eais.Observers.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '84d48731-4d42-421a-b6c6-2d3711375c75', '04447242-c166-4cae-bb6e-e32b820644c0');