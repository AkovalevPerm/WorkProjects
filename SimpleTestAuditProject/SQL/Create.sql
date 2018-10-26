CREATE TABLE [DetailObj] (
	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,
	 [DetailName] VARCHAR(255)  NULL,
	 [DetailField] INT  NULL,
	 [CreateTime] DATETIME  NULL,
	 [Creator] VARCHAR(255)  NULL,
	 [EditTime] DATETIME  NULL,
	 [Editor] VARCHAR(255)  NULL,
	 [DetailMaster] UNIQUEIDENTIFIER  NULL,
	 [MainObj] UNIQUEIDENTIFIER  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [MainObj] (
	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,
	 [Name] VARCHAR(255)  NULL,
	 [Field] INT  NULL,
	 [CreateTime] DATETIME  NULL,
	 [Creator] VARCHAR(255)  NULL,
	 [EditTime] DATETIME  NULL,
	 [Editor] VARCHAR(255)  NULL,
	 [MasterObj] UNIQUEIDENTIFIER  NOT NULL,
	 [Hierarchy] UNIQUEIDENTIFIER  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [MasterObj] (
	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,
	 [MasterName] VARCHAR(255)  NULL,
	 [MasterField] INT  NULL,
	 [CreateTime] DATETIME  NULL,
	 [Creator] VARCHAR(255)  NULL,
	 [EditTime] DATETIME  NULL,
	 [Editor] VARCHAR(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [MasterDetail] (
	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,
	 [Field] VARCHAR(255)  NULL,
	 [CreateTime] DATETIME  NULL,
	 [Creator] VARCHAR(255)  NULL,
	 [EditTime] DATETIME  NULL,
	 [Editor] VARCHAR(255)  NULL,
	 [MasterObj] UNIQUEIDENTIFIER  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [DetailMaster] (
	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,
	 [Name] VARCHAR(255)  NULL,
	 [Field1] INT  NULL,
	 [Field2] VARCHAR(255)  NULL,
	 [CreateTime] DATETIME  NULL,
	 [Creator] VARCHAR(255)  NULL,
	 [EditTime] DATETIME  NULL,
	 [Editor] VARCHAR(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMNETLOCKDATA] (
	 [LockKey] VARCHAR(300)  NOT NULL,
	 [UserName] VARCHAR(300)  NOT NULL,
	 [LockDate] DATETIME  NULL,
	 PRIMARY KEY ([LockKey])
) 
GO

CREATE TABLE [STORMSETTINGS] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Module] varchar(1000)  NULL,
	 [Name] varchar(255)  NULL,
	 [Value] text  NULL,
	 [User] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMAdvLimit] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [User] varchar(255)  NULL,
	 [Published] bit  NULL,
	 [Module] varchar(255)  NULL,
	 [Name] varchar(255)  NULL,
	 [Value] text  NULL,
	 [HotKeyData] int  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMFILTERSETTING] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Name] varchar(255)  NOT NULL,
	 [DataObjectView] varchar(255)  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMWEBSEARCH] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Name] varchar(255)  NOT NULL,
	 [Order] INT  NOT NULL,
	 [PresentView] varchar(255)  NOT NULL,
	 [DetailedView] varchar(255)  NOT NULL,
	 [FilterSetting_m0] uniqueidentifier  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMFILTERDETAIL] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Caption] varchar(255)  NOT NULL,
	 [DataObjectView] varchar(255)  NOT NULL,
	 [ConnectMasterProp] varchar(255)  NOT NULL,
	 [OwnerConnectProp] varchar(255)  NULL,
	 [FilterSetting_m0] uniqueidentifier  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMFILTERLOOKUP] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [DataObjectType] varchar(255)  NOT NULL,
	 [Container] varchar(255)  NULL,
	 [ContainerTag] varchar(255)  NULL,
	 [FieldsToView] varchar(255)  NULL,
	 [FilterSetting_m0] uniqueidentifier  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [UserSetting] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [AppName] varchar(256)  NULL,
	 [UserName] varchar(512)  NULL,
	 [UserGuid] uniqueidentifier  NULL,
	 [ModuleName] varchar(1024)  NULL,
	 [ModuleGuid] uniqueidentifier  NULL,
	 [SettName] varchar(256)  NULL,
	 [SettGuid] uniqueidentifier  NULL,
	 [SettLastAccessTime] DATETIME  NULL,
	 [StrVal] varchar(256)  NULL,
	 [TxtVal] varchar(max)  NULL,
	 [IntVal] int  NULL,
	 [BoolVal] bit  NULL,
	 [GuidVal] uniqueidentifier  NULL,
	 [DecimalVal] decimal(20,10)  NULL,
	 [DateTimeVal] DATETIME  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [ApplicationLog] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Category] varchar(64)  NULL,
	 [EventId] INT  NULL,
	 [Priority] INT  NULL,
	 [Severity] varchar(32)  NULL,
	 [Title] varchar(256)  NULL,
	 [Timestamp] DATETIME  NULL,
	 [MachineName] varchar(32)  NULL,
	 [AppDomainName] varchar(512)  NULL,
	 [ProcessId] varchar(256)  NULL,
	 [ProcessName] varchar(512)  NULL,
	 [ThreadName] varchar(512)  NULL,
	 [Win32ThreadId] varchar(128)  NULL,
	 [Message] varchar(2500)  NULL,
	 [FormattedMessage] varchar(max)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMAG] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Name] varchar(80)  NOT NULL,
	 [Login] varchar(50)  NULL,
	 [Pwd] varchar(50)  NULL,
	 [IsUser] bit  NOT NULL,
	 [IsGroup] bit  NOT NULL,
	 [IsRole] bit  NOT NULL,
	 [ConnString] varchar(255)  NULL,
	 [Enabled] bit  NULL,
	 [Email] varchar(80)  NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMLG] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Group_m0] uniqueidentifier  NOT NULL,
	 [User_m0] uniqueidentifier  NOT NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMAuObjType] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Name] nvarchar(255)  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMAuEntity] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [ObjectPrimaryKey] nvarchar(38)  NOT NULL,
	 [OperationTime] DATETIME  NOT NULL,
	 [OperationType] nvarchar(100)  NOT NULL,
	 [ExecutionResult] nvarchar(12)  NOT NULL,
	 [Source] nvarchar(255)  NOT NULL,
	 [SerializedField] nvarchar(max)  NULL,
	 [User_m0] uniqueidentifier  NOT NULL,
	 [ObjectType_m0] uniqueidentifier  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMAuField] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Field] nvarchar(100)  NOT NULL,
	 [OldValue] nvarchar(max)  NULL,
	 [NewValue] nvarchar(max)  NULL,
	 [MainChange_m0] uniqueidentifier  NULL,
	 [AuditEntity_m0] uniqueidentifier  NOT NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMI] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [User_m0] uniqueidentifier  NOT NULL,
	 [Agent_m0] uniqueidentifier  NOT NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [Session] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [UserKey] uniqueidentifier  NULL,
	 [StartedAt] datetime  NULL,
	 [LastAccess] datetime  NULL,
	 [Closed] bit  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMS] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Name] varchar(100)  NOT NULL,
	 [Type] varchar(100)  NULL,
	 [IsAttribute] bit  NOT NULL,
	 [IsOperation] bit  NOT NULL,
	 [IsView] bit  NOT NULL,
	 [IsClass] bit  NOT NULL,
	 [SharedOper] bit  NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMP] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Subject_m0] uniqueidentifier  NOT NULL,
	 [Agent_m0] uniqueidentifier  NOT NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMF] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [FilterText] varchar(MAX)  NULL,
	 [Name] varchar(255)  NULL,
	 [FilterTypeNView] varchar(255)  NULL,
	 [Subject_m0] uniqueidentifier  NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMAC] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [TypeAccess] varchar(7)  NULL,
	 [Filter_m0] uniqueidentifier  NULL,
	 [Permition_m0] uniqueidentifier  NOT NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMLO] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Class_m0] uniqueidentifier  NOT NULL,
	 [Operation_m0] uniqueidentifier  NOT NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMLA] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [View_m0] uniqueidentifier  NOT NULL,
	 [Attribute_m0] uniqueidentifier  NOT NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMLV] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [Class_m0] uniqueidentifier  NOT NULL,
	 [View_m0] uniqueidentifier  NOT NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

CREATE TABLE [STORMLR] (
	 [primaryKey] uniqueidentifier  NOT NULL,
	 [StartDate] datetime  NULL,
	 [EndDate] datetime  NULL,
	 [Agent_m0] uniqueidentifier  NOT NULL,
	 [Role_m0] uniqueidentifier  NOT NULL,
	 [CreateTime] datetime  NULL,
	 [Creator] varchar(255)  NULL,
	 [EditTime] datetime  NULL,
	 [Editor] varchar(255)  NULL,
	 PRIMARY KEY ([primaryKey])
) 
GO

ALTER TABLE [DetailObj]
	 ADD CONSTRAINT [DetailObj_FDetailMaster_0] FOREIGN KEY ([DetailMaster])
	 REFERENCES [DetailMaster]

GO

CREATE INDEX DetailObj_IDetailMaster on [DetailObj] ([DetailMaster])

GO

ALTER TABLE [DetailObj]
	 ADD CONSTRAINT [DetailObj_FMainObj_0] FOREIGN KEY ([MainObj])
	 REFERENCES [MainObj]

GO

CREATE INDEX DetailObj_IMainObj on [DetailObj] ([MainObj])

GO

ALTER TABLE [MainObj]
	 ADD CONSTRAINT [MainObj_FMasterObj_0] FOREIGN KEY ([MasterObj])
	 REFERENCES [MasterObj]

GO

CREATE INDEX MainObj_IMasterObj on [MainObj] ([MasterObj])

GO

ALTER TABLE [MainObj]
	 ADD CONSTRAINT [MainObj_FMainObj_0] FOREIGN KEY ([Hierarchy])
	 REFERENCES [MainObj]

GO

CREATE INDEX MainObj_IHierarchy on [MainObj] ([Hierarchy])

GO

ALTER TABLE [MasterDetail]
	 ADD CONSTRAINT [MasterDetail_FMasterObj_0] FOREIGN KEY ([MasterObj])
	 REFERENCES [MasterObj]

GO

CREATE INDEX MasterDetail_IMasterObj on [MasterDetail] ([MasterObj])

GO

ALTER TABLE [STORMWEBSEARCH]
	 ADD CONSTRAINT [STORMWEBSEARCH_FSTORMFILTERSETTING_0] FOREIGN KEY ([FilterSetting_m0])
	 REFERENCES [STORMFILTERSETTING]

GO

ALTER TABLE [STORMFILTERDETAIL]
	 ADD CONSTRAINT [STORMFILTERDETAIL_FSTORMFILTERSETTING_0] FOREIGN KEY ([FilterSetting_m0])
	 REFERENCES [STORMFILTERSETTING]

GO

ALTER TABLE [STORMFILTERLOOKUP]
	 ADD CONSTRAINT [STORMFILTERLOOKUP_FSTORMFILTERSETTING_0] FOREIGN KEY ([FilterSetting_m0])
	 REFERENCES [STORMFILTERSETTING]

GO

ALTER TABLE [STORMLG]
	 ADD CONSTRAINT [STORMLG_FSTORMAG_0] FOREIGN KEY ([Group_m0])
	 REFERENCES [STORMAG]

GO

ALTER TABLE [STORMLG]
	 ADD CONSTRAINT [STORMLG_FSTORMAG_1] FOREIGN KEY ([User_m0])
	 REFERENCES [STORMAG]

GO

ALTER TABLE [STORMAuEntity]
	 ADD CONSTRAINT [STORMAuEntity_FSTORMAG_0] FOREIGN KEY ([User_m0])
	 REFERENCES [STORMAG]

GO

ALTER TABLE [STORMAuEntity]
	 ADD CONSTRAINT [STORMAuEntity_FSTORMAuObjType_0] FOREIGN KEY ([ObjectType_m0])
	 REFERENCES [STORMAuObjType]

GO

ALTER TABLE [STORMAuField]
	 ADD CONSTRAINT [STORMAuField_FSTORMAuField_0] FOREIGN KEY ([MainChange_m0])
	 REFERENCES [STORMAuField]

GO

ALTER TABLE [STORMAuField]
	 ADD CONSTRAINT [STORMAuField_FSTORMAuEntity_0] FOREIGN KEY ([AuditEntity_m0])
	 REFERENCES [STORMAuEntity]

GO

ALTER TABLE [STORMI]
	 ADD CONSTRAINT [STORMI_FSTORMAG_0] FOREIGN KEY ([User_m0])
	 REFERENCES [STORMAG]

GO

ALTER TABLE [STORMI]
	 ADD CONSTRAINT [STORMI_FSTORMAG_1] FOREIGN KEY ([Agent_m0])
	 REFERENCES [STORMAG]

GO

ALTER TABLE [STORMP]
	 ADD CONSTRAINT [STORMP_FSTORMS_0] FOREIGN KEY ([Subject_m0])
	 REFERENCES [STORMS]

GO

ALTER TABLE [STORMP]
	 ADD CONSTRAINT [STORMP_FSTORMAG_0] FOREIGN KEY ([Agent_m0])
	 REFERENCES [STORMAG]

GO

ALTER TABLE [STORMF]
	 ADD CONSTRAINT [STORMF_FSTORMS_0] FOREIGN KEY ([Subject_m0])
	 REFERENCES [STORMS]

GO

ALTER TABLE [STORMAC]
	 ADD CONSTRAINT [STORMAC_FSTORMF_0] FOREIGN KEY ([Filter_m0])
	 REFERENCES [STORMF]

GO

ALTER TABLE [STORMAC]
	 ADD CONSTRAINT [STORMAC_FSTORMP_0] FOREIGN KEY ([Permition_m0])
	 REFERENCES [STORMP]

GO

ALTER TABLE [STORMLO]
	 ADD CONSTRAINT [STORMLO_FSTORMS_0] FOREIGN KEY ([Class_m0])
	 REFERENCES [STORMS]

GO

ALTER TABLE [STORMLO]
	 ADD CONSTRAINT [STORMLO_FSTORMS_1] FOREIGN KEY ([Operation_m0])
	 REFERENCES [STORMS]

GO

ALTER TABLE [STORMLA]
	 ADD CONSTRAINT [STORMLA_FSTORMS_0] FOREIGN KEY ([View_m0])
	 REFERENCES [STORMS]

GO

ALTER TABLE [STORMLA]
	 ADD CONSTRAINT [STORMLA_FSTORMS_1] FOREIGN KEY ([Attribute_m0])
	 REFERENCES [STORMS]

GO

ALTER TABLE [STORMLV]
	 ADD CONSTRAINT [STORMLV_FSTORMS_0] FOREIGN KEY ([Class_m0])
	 REFERENCES [STORMS]

GO

ALTER TABLE [STORMLV]
	 ADD CONSTRAINT [STORMLV_FSTORMS_1] FOREIGN KEY ([View_m0])
	 REFERENCES [STORMS]

GO

ALTER TABLE [STORMLR]
	 ADD CONSTRAINT [STORMLR_FSTORMAG_0] FOREIGN KEY ([Agent_m0])
	 REFERENCES [STORMAG]

GO

ALTER TABLE [STORMLR]
	 ADD CONSTRAINT [STORMLR_FSTORMAG_1] FOREIGN KEY ([Role_m0])
	 REFERENCES [STORMAG]

GO


