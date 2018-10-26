--права для администраторов
INSERT INTO storms VALUES ('e83c9792-98af-4138-9a1a-b10976cd2ab9', 'Iis.Eais.Synchronization.Uslovie', NULL, false, false, false, true, true, NULL, NULL, NULL, NULL) ON CONFLICT (primarykey) DO NOTHING;
INSERT INTO stormp VALUES ('a545c7cc-947d-4667-ae34-6c22373eca5b', 'e83c9792-98af-4138-9a1a-b10976cd2ab9', '3d2e3a47-07e6-47b4-8d12-3de62e19c56f', NULL, NULL, NULL, NULL) ON CONFLICT (primarykey) DO NOTHING;
INSERT INTO STORMAC VALUES ('e090b713-66b3-4a85-ba5b-d77e8874e3f2','Full', null, 'a545c7cc-947d-4667-ae34-6c22373eca5b', null, null, null, null) ON CONFLICT (primarykey) DO NOTHING;
