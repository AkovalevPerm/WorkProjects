INSERT INTO public.ics_syncsubsetting (primarykey, sourcepropertyname, subsetting, setting, destinationpropertyname, "Order", isseparatedmaster, isdetail, isnotcontainer) VALUES ('417c1a74-4ccd-4cc2-ba2c-8ae97eb68fd1', 'Ierarhiia', '9f40a530-2b25-4325-ad8f-265d08f329ac', '9f40a530-2b25-4325-ad8f-265d08f329ac', 'Parent', 1, false, false, false);
INSERT INTO public.ics_syncsubsetting (primarykey, sourcepropertyname, subsetting, setting, destinationpropertyname, "Order", isseparatedmaster, isdetail, isnotcontainer) VALUES ('83f60c6d-d48b-4906-87f2-915abe050c7f', 'Parent', 'e7d58a47-3ab2-4a23-bfb0-53979d003957', 'e7d58a47-3ab2-4a23-bfb0-53979d003957', 'Ierarhiia', 1, false, false, false);
INSERT INTO public.ics_synctype (primarykey, name, owner) VALUES ('c3e48225-15a1-4c9e-bc40-430f911cbcea', 'NullType', '9bed662c-c72c-4198-bcbb-f3da5cad1150');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('8e505425-4dd8-4a8a-99c2-e076b6cd917d', 'Mappers.APPtoXML.TerritoriiaToTerritoryMapperWithoutParent, Mappers.APPtoXML, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', 'observername', 'c3e48225-15a1-4c9e-bc40-430f911cbcea', 'c3e48225-15a1-4c9e-bc40-430f911cbcea');
INSERT INTO public.ics_syncsetting (primarykey, mappername, observername, source, destination) VALUES ('df6c240d-87bb-4ff7-8adc-10b03b9b45e7', 'Mappers.XMLtoAPP.TerritoryToTerritoriiaMapperWithoutParent, Mappers.XMLtoAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', 'observername', 'c3e48225-15a1-4c9e-bc40-430f911cbcea', 'c3e48225-15a1-4c9e-bc40-430f911cbcea');
INSERT INTO public.ics_syncsubsetting (primarykey, sourcepropertyname, subsetting, setting, destinationpropertyname, "Order", isseparatedmaster, isdetail, isnotcontainer) VALUES ('810298aa-fb32-4799-a75d-00eba92f60f1', 'Territoriia', '8e505425-4dd8-4a8a-99c2-e076b6cd917d', '98fdb6cf-716f-488e-a4ce-b0fd4965892c', 'Territory', 1, false, false, false);
INSERT INTO public.ics_syncsubsetting (primarykey, sourcepropertyname, subsetting, setting, destinationpropertyname, "Order", isseparatedmaster, isdetail, isnotcontainer) VALUES ('2a835a75-b80b-44a2-969b-2f2cfd3a15b8', 'Territory', 'df6c240d-87bb-4ff7-8adc-10b03b9b45e7', '328331a0-bf3c-4e14-a6b6-6d0eae5ab79c', 'Territoriia', 1, false, false, false);

UPDATE public.ics_syncsubsetting SET subsetting = '8e505425-4dd8-4a8a-99c2-e076b6cd917d' WHERE primarykey = 'c25b7db8-5f73-4a38-931c-98b3931486ba';
UPDATE public.ics_syncsubsetting SET subsetting = '8e505425-4dd8-4a8a-99c2-e076b6cd917d' WHERE primarykey = '3bbd13f9-3dd2-4f7a-aa01-606adc6030fc';

UPDATE public.ics_syncsubsetting SET subsetting = 'df6c240d-87bb-4ff7-8adc-10b03b9b45e7' WHERE primarykey = 'd1debe99-dd61-48e5-95ed-4c9b32abd821';
UPDATE public.ics_syncsubsetting SET subsetting = 'df6c240d-87bb-4ff7-8adc-10b03b9b45e7' WHERE primarykey = '746dbc95-d478-4a05-b519-9add85ce3bcf';