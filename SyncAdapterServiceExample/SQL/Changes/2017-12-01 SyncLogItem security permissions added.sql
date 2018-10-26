INSERT INTO storms VALUES ('eb7bdcec-2235-4078-8a85-4ab61d3271d4', 'Iis.Eais.Synchronization.SyncLogItem', NULL, false, false, false, true, true, NULL, NULL, NULL, NULL) ON CONFLICT (primarykey) DO NOTHING;
INSERT INTO stormp VALUES ('3f0ca48f-84c8-4806-8511-d139b3031101', 'eb7bdcec-2235-4078-8a85-4ab61d3271d4', '3d2e3a47-07e6-47b4-8d12-3de62e19c56f', NULL, NULL, NULL, NULL) ON CONFLICT (primarykey) DO NOTHING;
INSERT INTO STORMAC VALUES ('da3bf8dd-376b-4158-9bdb-f1db1e71b59e','Full', null, '3f0ca48f-84c8-4806-8511-d139b3031101', null, null, null, null) ON CONFLICT (primarykey) DO NOTHING;
