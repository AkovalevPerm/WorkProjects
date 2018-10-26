CREATE TABLE [ICS_SyncEntity] (

  [primaryKey] UNIQUEIDENTIFIER NOT NULL
 ,[ObjectPK] UNIQUEIDENTIFIER NOT NULL
 ,[Date] DATETIME NOT NULL
 ,[ObjectPrimaryKey] UNIQUEIDENTIFIER NOT NULL
 ,[ObjectStatus] VARCHAR(9) NOT NULL
 ,[Setting] UNIQUEIDENTIFIER NOT NULL
 ,PRIMARY KEY ([primaryKey])
)

CREATE TABLE [ICS_SyncSystem] (

  [primaryKey] UNIQUEIDENTIFIER NOT NULL
 ,[Name] VARCHAR(255) NOT NULL
 ,[Assembly] VARCHAR(255) NOT NULL
 ,PRIMARY KEY ([primaryKey])
)

CREATE TABLE [ICS_SyncType] (

  [primaryKey] UNIQUEIDENTIFIER NOT NULL
 ,[Name] VARCHAR(255) NOT NULL
 ,[Owner] UNIQUEIDENTIFIER NOT NULL
 ,PRIMARY KEY ([primaryKey])
)

CREATE TABLE [ICS_SyncSetting] (

  [primaryKey] UNIQUEIDENTIFIER NOT NULL
 ,[MapperName] VARCHAR(255) NOT NULL
 ,[ObserverName] VARCHAR(255) NOT NULL
 ,[Source] UNIQUEIDENTIFIER NOT NULL
 ,[Destination] UNIQUEIDENTIFIER NOT NULL
 ,PRIMARY KEY ([primaryKey])
)

CREATE TABLE [ICS_SyncSubsetting] (

  [primaryKey] UNIQUEIDENTIFIER NOT NULL
 ,[PropertyName] VARCHAR(255) NOT NULL
 ,[Subsetting] UNIQUEIDENTIFIER NOT NULL
 ,[Setting] UNIQUEIDENTIFIER NOT NULL
 ,PRIMARY KEY ([primaryKey])
)

ALTER TABLE [ICS_SyncEntity]
ADD CONSTRAINT [ICS_SyncEntity_FICS_SyncSetting_0] FOREIGN KEY ([Setting])
REFERENCES [ICS_SyncSetting]

CREATE INDEX ICS_SyncEntity_ISetting ON [ICS_SyncEntity] ([Setting])

ALTER TABLE [ICS_SyncType]
ADD CONSTRAINT [ICS_SyncType_FICS_SyncSystem_0] FOREIGN KEY ([Owner])
REFERENCES [ICS_SyncSystem]

CREATE INDEX ICS_SyncType_IOwner ON [ICS_SyncType] ([Owner])

ALTER TABLE [ICS_SyncSetting]
ADD CONSTRAINT [ICS_SyncSetting_FICS_SyncType_0] FOREIGN KEY ([Source])
REFERENCES [ICS_SyncType]

CREATE INDEX ICS_SyncSetting_ISource ON [ICS_SyncSetting] ([Source])

ALTER TABLE [ICS_SyncSetting]
ADD CONSTRAINT [ICS_SyncSetting_FICS_SyncType_1] FOREIGN KEY ([Destination])
REFERENCES [ICS_SyncType]

CREATE INDEX ICS_SyncSetting_IDestination ON [ICS_SyncSetting] ([Destination])

ALTER TABLE [ICS_SyncSubsetting]
ADD CONSTRAINT [ICS_SyncSubsetting_FICS_SyncSetting_0] FOREIGN KEY ([Subsetting])
REFERENCES [ICS_SyncSetting]

CREATE INDEX ICS_SyncSubsetting_ISubsetting ON [ICS_SyncSubsetting] ([Subsetting])

ALTER TABLE [ICS_SyncSubsetting]
ADD CONSTRAINT [ICS_SyncSubsetting_FICS_SyncSetting_1] FOREIGN KEY ([Setting])
REFERENCES [ICS_SyncSetting]

CREATE INDEX ICS_SyncSubsetting_ISetting ON [ICS_SyncSubsetting] ([Setting])