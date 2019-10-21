EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'VaravaMainOffice'
GO

USE [master]
GO
ALTER DATABASE [VaravaMainOffice] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

USE [master]
GO
DROP DATABASE [VaravaMainOffice]
GO
CREATE DATABASE [VaravaMainOffice]
GO
SET QUOTED_IDENTIFIER OFF;
GO
USE [VaravaMainOffice];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RealEstateTypeRealEstate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RealEstates] DROP CONSTRAINT [FK_RealEstateTypeRealEstate];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartamentRealEstateContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RealEstateContacts] DROP CONSTRAINT [FK_DepartamentRealEstateContact];
GO
IF OBJECT_ID(N'[dbo].[FK_RealEstateRealEstateContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RealEstateContacts] DROP CONSTRAINT [FK_RealEstateRealEstateContact];
GO
IF OBJECT_ID(N'[dbo].[FK_RawMaterialRawMaterialProviderContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RawMaterialProviderContracts] DROP CONSTRAINT [FK_RawMaterialRawMaterialProviderContract];
GO
IF OBJECT_ID(N'[dbo].[FK_MeasurementUnitRawMaterialProviderContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RawMaterialProviderContracts] DROP CONSTRAINT [FK_MeasurementUnitRawMaterialProviderContract];
GO
IF OBJECT_ID(N'[dbo].[FK_StatusOrderRawMaterialProviderContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RawMaterialProviderContracts] DROP CONSTRAINT [FK_StatusOrderRawMaterialProviderContract];
GO
IF OBJECT_ID(N'[dbo].[FK_RawMaterialStockRawMaterial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockRawMaterials] DROP CONSTRAINT [FK_RawMaterialStockRawMaterial];
GO
IF OBJECT_ID(N'[dbo].[FK_MeasurementUnitStockRawMaterial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockRawMaterials] DROP CONSTRAINT [FK_MeasurementUnitStockRawMaterial];
GO
IF OBJECT_ID(N'[dbo].[FK_RawMaterialComponent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Components] DROP CONSTRAINT [FK_RawMaterialComponent];
GO
IF OBJECT_ID(N'[dbo].[FK_MeasurementUnitComponent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Components] DROP CONSTRAINT [FK_MeasurementUnitComponent];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductComponent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Components] DROP CONSTRAINT [FK_ProductComponent];
GO
IF OBJECT_ID(N'[dbo].[FK_MerchandisePurchase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [FK_MerchandisePurchase];
GO
IF OBJECT_ID(N'[dbo].[FK_RealEstateMerchandise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Merchandises] DROP CONSTRAINT [FK_RealEstateMerchandise];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMerchandise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Merchandises] DROP CONSTRAINT [FK_ProductMerchandise];
GO
IF OBJECT_ID(N'[dbo].[FK_CashRegisterAccessEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashRegisterAccesses] DROP CONSTRAINT [FK_CashRegisterAccessEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_PositionEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeEmployeeWorkLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeWorkLogs] DROP CONSTRAINT [FK_EmployeeEmployeeWorkLog];
GO
IF OBJECT_ID(N'[dbo].[FK_RealEstateEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_RealEstateEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeStoreOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StoreOrders] DROP CONSTRAINT [FK_EmployeeStoreOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeMerchandiseAcceptanceLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MerchandiseAcceptanceLogs] DROP CONSTRAINT [FK_EmployeeMerchandiseAcceptanceLog];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeePerformedHeadOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedHeadOrders] DROP CONSTRAINT [FK_EmployeePerformedHeadOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeePerformedStoreOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedStoreOrders] DROP CONSTRAINT [FK_EmployeePerformedStoreOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeePerformedStoreOrder1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedStoreOrders] DROP CONSTRAINT [FK_EmployeePerformedStoreOrder1];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionHeadOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HeadOrders] DROP CONSTRAINT [FK_PositionHeadOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_CashRegisterCashRegisterAccess]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashRegisterAccesses] DROP CONSTRAINT [FK_CashRegisterCashRegisterAccess];
GO
IF OBJECT_ID(N'[dbo].[FK_RealEstateCashRegister]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashRegisters] DROP CONSTRAINT [FK_RealEstateCashRegister];
GO
IF OBJECT_ID(N'[dbo].[FK_CashRegisterOperationCashRegisterAccess]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashRegisterAccesses] DROP CONSTRAINT [FK_CashRegisterOperationCashRegisterAccess];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadOrderStatusOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HeadOrders] DROP CONSTRAINT [FK_HeadOrderStatusOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_CashRegisterAccessPurchase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [FK_CashRegisterAccessPurchase];
GO
IF OBJECT_ID(N'[dbo].[FK_RealEstateStoreOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StoreOrders] DROP CONSTRAINT [FK_RealEstateStoreOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_MerchandiseAcceptanceLogLackLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LackLogs] DROP CONSTRAINT [FK_MerchandiseAcceptanceLogLackLog];
GO
IF OBJECT_ID(N'[dbo].[FK_HeadOrderPerformedHeadOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedHeadOrders] DROP CONSTRAINT [FK_HeadOrderPerformedHeadOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_StoreOrderPerformedStoreOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedStoreOrders] DROP CONSTRAINT [FK_StoreOrderPerformedStoreOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_StatusOrderStoreOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StoreOrders] DROP CONSTRAINT [FK_StatusOrderStoreOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_StoreOrderMerchandiseAcceptanceLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MerchandiseAcceptanceLogs] DROP CONSTRAINT [FK_StoreOrderMerchandiseAcceptanceLog];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductStoreOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StoreOrders] DROP CONSTRAINT [FK_ProductStoreOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeSQLLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SQLLogs] DROP CONSTRAINT [FK_EmployeeSQLLog];
GO
IF OBJECT_ID(N'[dbo].[FK_DataBaseTableTableStructure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TableStructures] DROP CONSTRAINT [FK_DataBaseTableTableStructure];
GO
IF OBJECT_ID(N'[dbo].[FK_DataBaseTableAccessTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccessTables] DROP CONSTRAINT [FK_DataBaseTableAccessTable];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionAccessTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccessTables] DROP CONSTRAINT [FK_PositionAccessTable];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RealEstateTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RealEstateTypes];
GO
IF OBJECT_ID(N'[dbo].[RealEstates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RealEstates];
GO
IF OBJECT_ID(N'[dbo].[RealEstateContacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RealEstateContacts];
GO
IF OBJECT_ID(N'[dbo].[Departaments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departaments];
GO
IF OBJECT_ID(N'[dbo].[RawMaterialProviderContracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RawMaterialProviderContracts];
GO
IF OBJECT_ID(N'[dbo].[StockRawMaterials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockRawMaterials];
GO
IF OBJECT_ID(N'[dbo].[RawMaterials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RawMaterials];
GO
IF OBJECT_ID(N'[dbo].[MeasurementUnits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MeasurementUnits];
GO
IF OBJECT_ID(N'[dbo].[Components]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Components];
GO
IF OBJECT_ID(N'[dbo].[Merchandises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Merchandises];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[EmployeeWorkLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeWorkLogs];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Positions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Positions];
GO
IF OBJECT_ID(N'[dbo].[CashRegisters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CashRegisters];
GO
IF OBJECT_ID(N'[dbo].[CashRegisterOperations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CashRegisterOperations];
GO
IF OBJECT_ID(N'[dbo].[HeadOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeadOrders];
GO
IF OBJECT_ID(N'[dbo].[Purchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchases];
GO
IF OBJECT_ID(N'[dbo].[CashRegisterAccesses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CashRegisterAccesses];
GO
IF OBJECT_ID(N'[dbo].[StoreOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StoreOrders];
GO
IF OBJECT_ID(N'[dbo].[MerchandiseAcceptanceLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MerchandiseAcceptanceLogs];
GO
IF OBJECT_ID(N'[dbo].[LackLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LackLogs];
GO
IF OBJECT_ID(N'[dbo].[StatusOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatusOrders];
GO
IF OBJECT_ID(N'[dbo].[PerformedHeadOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerformedHeadOrders];
GO
IF OBJECT_ID(N'[dbo].[PerformedStoreOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerformedStoreOrders];
GO
IF OBJECT_ID(N'[dbo].[SQLLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SQLLogs];
GO
IF OBJECT_ID(N'[dbo].[ConnectingStrings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConnectingStrings];
GO
IF OBJECT_ID(N'[dbo].[DataBaseTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataBaseTables];
GO
IF OBJECT_ID(N'[dbo].[TableStructures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TableStructures];
GO
IF OBJECT_ID(N'[dbo].[AccessTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessTables];
GO


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RealEstateTypes'
CREATE TABLE [dbo].[RealEstateTypes] (
    [ID_RealEstateType] uniqueidentifier  NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'RealEstates'
CREATE TABLE [dbo].[RealEstates] (
    [ID_RealEstate] uniqueidentifier  NOT NULL,
    [ID_RealEstateType] uniqueidentifier  NOT NULL,
    [NameRealEstate] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [BuildingNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RealEstateContacts'
CREATE TABLE [dbo].[RealEstateContacts] (
    [ID_RealEstateContact] uniqueidentifier  NOT NULL,
    [ID_RealEstate] uniqueidentifier  NOT NULL,
    [ID_Departament] uniqueidentifier  NOT NULL,
    [Telephone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL
);
GO

-- Creating table 'Departaments'
CREATE TABLE [dbo].[Departaments] (
    [ID_Departament] uniqueidentifier  NOT NULL,
    [NameDepartament] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [ID_Employee] uniqueidentifier  NOT NULL,
    [ID_Position] uniqueidentifier  NOT NULL,
    [ID_RealEstate] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [SecondName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL,
    [Passport] nvarchar(max)  NOT NULL,
    [IDK] nvarchar(max)  NOT NULL,
    [IsEnabled] bit  NOT NULL
);
GO

-- Creating table 'EmployeeWorkLogs'
CREATE TABLE [dbo].[EmployeeWorkLogs] (
    [ID_EmployeeWorkLog] uniqueidentifier  NOT NULL,
    [ID_Employee] uniqueidentifier  NOT NULL,
    [DateTimeStart] datetime  NOT NULL,
    [DateTimeEnd] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserLogin] nvarchar(max)  NOT NULL,
    [ID_Employee] uniqueidentifier  NOT NULL,
    [UserPassword] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [ID_Position] uniqueidentifier  NOT NULL,
    [NamePosition] nvarchar(max)  NOT NULL,
    [PaymentHrnPerHour] int  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'HeadOrders'
CREATE TABLE [dbo].[HeadOrders] (
    [ID_HeadOrder] uniqueidentifier  NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [ID_Position] uniqueidentifier  NOT NULL,
    [ID_StatusOrder] uniqueidentifier  NOT NULL,
    [AssignFor] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StatusOrders'
CREATE TABLE [dbo].[StatusOrders] (
    [ID_StatusOrder] uniqueidentifier  NOT NULL,
    [NameStatusOrder] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PerformedHeadOrders'
CREATE TABLE [dbo].[PerformedHeadOrders] (
    [ID_HeadOrder] uniqueidentifier  NOT NULL,
    [ID_Employee] uniqueidentifier  NOT NULL,
    [ID_PerformedOrder] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ConnectingStrings'
CREATE TABLE [dbo].[ConnectingStrings] (
    [ID_ConnectingString] uniqueidentifier  NOT NULL,
    [DataSource] nvarchar(max)  NOT NULL,
	[InitialCatalog] nvarchar(max)  NOT NULL,
	[UserId] nvarchar(max)  NOT NULL,
	[UserPassword] nvarchar(max)  NOT NULL,
	[ConnectionType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SQLLogs'
CREATE TABLE [dbo].[SQLLogs] (
    [ID_SQLLog] uniqueidentifier  NOT NULL,
    [ID_Employee] uniqueidentifier  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [DateExecution] datetime  NOT NULL
);
GO

-- Creating table 'DataBaseTables'
CREATE TABLE [dbo].[DataBaseTables] (
    [ID_Table] uniqueidentifier  NOT NULL,
    [TableName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TableStructures'
CREATE TABLE [dbo].[TableStructures] (
    [ID_Table] uniqueidentifier  NOT NULL,
    [ColumnName] nvarchar(max)  NOT NULL,
    [ColumnType] nvarchar(max)  NOT NULL,
    [ID_TableStructure] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'AccessTables'
CREATE TABLE [dbo].[AccessTables] (
    [ID_Table] uniqueidentifier  NOT NULL,
    [ID_Position] uniqueidentifier  NOT NULL,
    [AccessType] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID_RealEstateType] in table 'RealEstateTypes'
ALTER TABLE [dbo].[RealEstateTypes]
ADD CONSTRAINT [PK_RealEstateTypes]
    PRIMARY KEY CLUSTERED ([ID_RealEstateType] ASC);
GO

-- Creating primary key on [ID_RealEstate] in table 'RealEstates'
ALTER TABLE [dbo].[RealEstates]
ADD CONSTRAINT [PK_RealEstates]
    PRIMARY KEY CLUSTERED ([ID_RealEstate] ASC);
GO

-- Creating primary key on [ID_RealEstateContact] in table 'RealEstateContacts'
ALTER TABLE [dbo].[RealEstateContacts]
ADD CONSTRAINT [PK_RealEstateContacts]
    PRIMARY KEY CLUSTERED ([ID_RealEstateContact] ASC);
GO

-- Creating primary key on [ID_Departament] in table 'Departaments'
ALTER TABLE [dbo].[Departaments]
ADD CONSTRAINT [PK_Departaments]
    PRIMARY KEY CLUSTERED ([ID_Departament] ASC);
GO

-- Creating primary key on [ID_Employee] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([ID_Employee] ASC);
GO

-- Creating primary key on [ID_EmployeeWorkLog] in table 'EmployeeWorkLogs'
ALTER TABLE [dbo].[EmployeeWorkLogs]
ADD CONSTRAINT [PK_EmployeeWorkLogs]
    PRIMARY KEY CLUSTERED ([ID_EmployeeWorkLog] ASC);
GO

-- Creating primary key on [ID_Employee] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID_Employee] ASC);
GO

-- Creating primary key on [ID_Position] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([ID_Position] ASC);
GO

-- Creating primary key on [ID_HeadOrder] in table 'HeadOrders'
ALTER TABLE [dbo].[HeadOrders]
ADD CONSTRAINT [PK_HeadOrders]
    PRIMARY KEY CLUSTERED ([ID_HeadOrder] ASC);
GO

-- Creating primary key on [ID_StatusOrder] in table 'StatusOrders'
ALTER TABLE [dbo].[StatusOrders]
ADD CONSTRAINT [PK_StatusOrders]
    PRIMARY KEY CLUSTERED ([ID_StatusOrder] ASC);
GO

-- Creating primary key on [ID_ConnectingString] in table 'ConnectingStrings'
ALTER TABLE [dbo].[ConnectingStrings]
ADD CONSTRAINT [PK_ConnectingStrings]
    PRIMARY KEY CLUSTERED ([ID_ConnectingString] ASC);
GO

-- Creating primary key on [ID_PerformedOrder] in table 'PerformedHeadOrders'
ALTER TABLE [dbo].[PerformedHeadOrders]
ADD CONSTRAINT [PK_PerformedHeadOrders]
    PRIMARY KEY CLUSTERED ([ID_PerformedOrder] ASC);
GO

-- Creating primary key on [ID_Table] in table 'DataBaseTables'
ALTER TABLE [dbo].[DataBaseTables]
ADD CONSTRAINT [PK_DataBaseTables]
    PRIMARY KEY CLUSTERED ([ID_Table] ASC);
GO

-- Creating primary key on [ID_TableStructure] in table 'TableStructures'
ALTER TABLE [dbo].[TableStructures]
ADD CONSTRAINT [PK_TableStructures]
    PRIMARY KEY CLUSTERED ([ID_TableStructure] ASC);
GO

-- Creating primary key on [ID_SQLLog] in table 'SQLLogs'
ALTER TABLE [dbo].[SQLLogs]
ADD CONSTRAINT [PK_SQLLogs]
    PRIMARY KEY CLUSTERED ([ID_SQLLog] ASC);
GO

-- Creating primary key on [ID_Table], [ID_Position] in table 'AccessTables'
ALTER TABLE [dbo].[AccessTables]
ADD CONSTRAINT [PK_AccessTables]
    PRIMARY KEY CLUSTERED ([ID_Table], [ID_Position] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ID_RealEstateType] in table 'RealEstates'
ALTER TABLE [dbo].[RealEstates]
ADD CONSTRAINT [FK_RealEstateTypeRealEstate]
    FOREIGN KEY ([ID_RealEstateType])
    REFERENCES [dbo].[RealEstateTypes]
        ([ID_RealEstateType])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RealEstateTypeRealEstate'
CREATE INDEX [IX_FK_RealEstateTypeRealEstate]
ON [dbo].[RealEstates]
    ([ID_RealEstateType]);
GO

-- Creating foreign key on [ID_Departament] in table 'RealEstateContacts'
ALTER TABLE [dbo].[RealEstateContacts]
ADD CONSTRAINT [FK_DepartamentRealEstateContact]
    FOREIGN KEY ([ID_Departament])
    REFERENCES [dbo].[Departaments]
        ([ID_Departament])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentRealEstateContact'
CREATE INDEX [IX_FK_DepartamentRealEstateContact]
ON [dbo].[RealEstateContacts]
    ([ID_Departament]);
GO

-- Creating foreign key on [ID_RealEstate] in table 'RealEstateContacts'
ALTER TABLE [dbo].[RealEstateContacts]
ADD CONSTRAINT [FK_RealEstateRealEstateContact]
    FOREIGN KEY ([ID_RealEstate])
    REFERENCES [dbo].[RealEstates]
        ([ID_RealEstate])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RealEstateRealEstateContact'
CREATE INDEX [IX_FK_RealEstateRealEstateContact]
ON [dbo].[RealEstateContacts]
    ([ID_RealEstate]);
GO

-- Creating foreign key on [ID_Position] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_PositionEmployee]
    FOREIGN KEY ([ID_Position])
    REFERENCES [dbo].[Positions]
        ([ID_Position])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionEmployee'
CREATE INDEX [IX_FK_PositionEmployee]
ON [dbo].[Employees]
    ([ID_Position]);
GO

-- Creating foreign key on [ID_Employee] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserEmployee]
    FOREIGN KEY ([ID_Employee])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_Employee] in table 'EmployeeWorkLogs'
ALTER TABLE [dbo].[EmployeeWorkLogs]
ADD CONSTRAINT [FK_EmployeeEmployeeWorkLog]
    FOREIGN KEY ([ID_Employee])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeEmployeeWorkLog'
CREATE INDEX [IX_FK_EmployeeEmployeeWorkLog]
ON [dbo].[EmployeeWorkLogs]
    ([ID_Employee]);
GO

-- Creating foreign key on [ID_RealEstate] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_RealEstateEmployee]
    FOREIGN KEY ([ID_RealEstate])
    REFERENCES [dbo].[RealEstates]
        ([ID_RealEstate])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RealEstateEmployee'
CREATE INDEX [IX_FK_RealEstateEmployee]
ON [dbo].[Employees]
    ([ID_RealEstate]);
GO

-- Creating foreign key on [ID_Employee] in table 'PerformedHeadOrders'
ALTER TABLE [dbo].[PerformedHeadOrders]
ADD CONSTRAINT [FK_EmployeePerformedHeadOrder]
    FOREIGN KEY ([ID_Employee])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeePerformedHeadOrder'
CREATE INDEX [IX_FK_EmployeePerformedHeadOrder]
ON [dbo].[PerformedHeadOrders]
    ([ID_Employee]);
GO

-- Creating foreign key on [ID_Position] in table 'HeadOrders'
ALTER TABLE [dbo].[HeadOrders]
ADD CONSTRAINT [FK_PositionHeadOrder]
    FOREIGN KEY ([ID_Position])
    REFERENCES [dbo].[Positions]
        ([ID_Position])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionHeadOrder'
CREATE INDEX [IX_FK_PositionHeadOrder]
ON [dbo].[HeadOrders]
    ([ID_Position]);
GO

-- Creating foreign key on [ID_StatusOrder] in table 'HeadOrders'
ALTER TABLE [dbo].[HeadOrders]
ADD CONSTRAINT [FK_HeadOrderStatusOrder]
    FOREIGN KEY ([ID_StatusOrder])
    REFERENCES [dbo].[StatusOrders]
        ([ID_StatusOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadOrderStatusOrder'
CREATE INDEX [IX_FK_HeadOrderStatusOrder]
ON [dbo].[HeadOrders]
    ([ID_StatusOrder]);
GO

-- Creating foreign key on [ID_HeadOrder] in table 'PerformedHeadOrders'
ALTER TABLE [dbo].[PerformedHeadOrders]
ADD CONSTRAINT [FK_HeadOrderPerformedHeadOrder]
    FOREIGN KEY ([ID_HeadOrder])
    REFERENCES [dbo].[HeadOrders]
        ([ID_HeadOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HeadOrderPerformedHeadOrder'
CREATE INDEX [IX_FK_HeadOrderPerformedHeadOrder]
ON [dbo].[PerformedHeadOrders]
    ([ID_HeadOrder]);
GO

-- Creating foreign key on [ID_Employee] in table 'SQLLogs'
ALTER TABLE [dbo].[SQLLogs]
ADD CONSTRAINT [FK_EmployeeSQLLog]
    FOREIGN KEY ([ID_Employee])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeSQLLog'
CREATE INDEX [IX_FK_EmployeeSQLLog]
ON [dbo].[SQLLogs]
    ([ID_Employee]);
GO

-- Creating foreign key on [ID_Table] in table 'TableStructures'
ALTER TABLE [dbo].[TableStructures]
ADD CONSTRAINT [FK_DataBaseTableTableStructure]
    FOREIGN KEY ([ID_Table])
    REFERENCES [dbo].[DataBaseTables]
        ([ID_Table])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataBaseTableTableStructure'
CREATE INDEX [IX_FK_DataBaseTableTableStructure]
ON [dbo].[TableStructures]
    ([ID_Table]);
GO

-- Creating foreign key on [ID_Table] in table 'AccessTables'
ALTER TABLE [dbo].[AccessTables]
ADD CONSTRAINT [FK_DataBaseTableAccessTable]
    FOREIGN KEY ([ID_Table])
    REFERENCES [dbo].[DataBaseTables]
        ([ID_Table])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_Position] in table 'AccessTables'
ALTER TABLE [dbo].[AccessTables]
ADD CONSTRAINT [FK_PositionAccessTable]
    FOREIGN KEY ([ID_Position])
    REFERENCES [dbo].[Positions]
        ([ID_Position])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionAccessTable'
CREATE INDEX [IX_FK_PositionAccessTable]
ON [dbo].[AccessTables]
    ([ID_Position]);
GO

-- Droping linked Servers
sp_dropserver 'Global', 'droplogins';
GO
sp_dropserver 'Local', 'droplogins';
GO
sp_dropserver 'Host', 'droplogins';
GO

-- Creating linked Servers
EXEC sp_addlinkedserver 'Global', '', 'SQLNCLI', '93.74.213.211,31340'
GO
EXEC sp_addlinkedsrvlogin 'Global', 'FALSE', NULL, 'sa', '2584744'
GO
EXEC sp_addlinkedserver 'Local', '', 'SQLNCLI', '192.168.1.31,31340'
GO
EXEC sp_addlinkedsrvlogin 'Local', 'FALSE', NULL, 'sa', '2584744'
GO
EXEC sp_addlinkedserver 'Host', '', 'SQLNCLI', '127.0.0.1,31340'
GO
EXEC sp_addlinkedsrvlogin 'Host', 'FALSE', NULL, 'sa', '2584744'
GO

-- Creating default data
INSERT INTO ConnectingStrings (ID_ConnectingString, DataSource, InitialCatalog, UserId, UserPassword, ConnectionType)
VALUES 
(NEWID(), '(localdb)\MSSQLLocalDB', 'VaravaStore', 'sa', '2584744', 'Host'),
(NEWID(), '(localdb)\MSSQLLocalDB', 'VaravaStore', 'sa', '2584744', 'Local'),
(NEWID(), '(localdb)\MSSQLLocalDB', 'VaravaStore', 'sa', '2584744', 'Global'),
(NEWID(), '127.0.0.1,31340', 'VaravaFactory', 'sa', '2584744', 'Host'),
(NEWID(), '192.168.1.31,31340', 'VaravaFactory', 'sa', '2584744', 'Local'),
(NEWID(), '93.74.213.211,31340', 'VaravaFactory', 'sa', '2584744', 'Global'),
(NEWID(), '127.0.0.1,31340', 'VaravaMainOffice', 'sa', '2584744', 'Host'),
(NEWID(), '192.168.1.31,31340', 'VaravaMainOffice', 'sa', '2584744', 'Local'),
(NEWID(), '93.74.213.211,31340', 'VaravaMainOffice', 'sa', '2584744', 'Global');
GO


INSERT INTO Positions (ID_Position, NamePosition, PaymentHrnPerHour, Description)
VALUES ('7a58fc5f-fc33-4d95-99e9-a8abaf2aa092', 'Admin', 70, 'Operate with data');
GO

INSERT INTO RealEstateTypes (ID_RealEstateType, TypeName, Description)
VALUES ('af67fc81-e6aa-4307-b228-1e2aa58c80e2', 'MainOffice', 'None');
GO

INSERT INTO RealEstates (ID_RealEstate, ID_RealEstateType, NameRealEstate, Country, Region, City, Street, BuildingNumber)
VALUES ('907158ab-6c11-478a-8e96-5d7941b1641b', 'af67fc81-e6aa-4307-b228-1e2aa58c80e2', 'The Crotchet Office', 'Ukraine', 'Kiev', 'Kiev', 'Evropeyska', '10');
GO

INSERT INTO Employees (ID_Employee, ID_Position, ID_RealEstate, FirstName, SecondName, MiddleName, Telephone, Passport, IDK, IsEnabled)
VALUES ('6341fc00-a547-4fc0-b315-0d4ab07269ca', '7a58fc5f-fc33-4d95-99e9-a8abaf2aa092', '907158ab-6c11-478a-8e96-5d7941b1641b', 'Alex', 'Del', 'Pablo', '0934126749', 'TT883478', '2145896530', 1);
GO

INSERT INTO Users (UserLogin, ID_Employee, UserPassword)
VALUES ('admin', '6341fc00-a547-4fc0-b315-0d4ab07269ca', 'admin');
GO


INSERT INTO DataBaseTables (ID_Table, TableName)
VALUES 
('d701252b-618a-4123-9544-44a9a5233d9b', 'RealEstateTypes'),
('99133287-1910-4e42-8db6-c3aa53a6fb11', 'RealEstates'),
('751eec3e-33df-401f-9e2f-33c8615dd1c6', 'RealEstateContacts'),
('6a93815b-e291-411a-b457-78c3b01b6f84', 'Departaments'),
('c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'Employees'),
('4b082d0a-6aa4-411c-a7d3-0f41f933562d', 'EmployeeWorkLogs'),
('83e709b5-cf67-4e6a-9572-73788563cd74', 'Positions'),
('ec33e7a0-d58e-4225-9c21-1ee7a40d8167', 'HeadOrders'),
('39de7b41-1940-4547-9d6c-73de9e09d20b', 'StatusOrders'),
('94f0ea37-b1ff-4565-82cf-de4e3aa5f5d5', 'PerformedHeadOrders'),
('6952159c-f31e-4ac7-aff6-e81ddbff5f29', 'ConnectingStrings'),
('363c9398-dd81-4730-b91f-8fcddac22e0f', 'SQLLogs'),
('24e0f236-b5a2-4b12-87df-99fe4bccf08e', 'DataBaseTables'),
('a184fed4-abbd-42ad-9f72-4c02988a3485', 'TableStructures'),
('04e467b8-999c-4789-8ac0-dea25a62c1c6', 'AccessTables'),
('b972f6a4-2ec9-4616-a0e1-a628771c539e', 'Users');
GO
INSERT INTO TableStructures (ID_TableStructure, ID_Table, ColumnType, ColumnName)
VALUES 
(NEWID(), 'd701252b-618a-4123-9544-44a9a5233d9b', 'Guid', 'ID_RealEstateType'),
(NEWID(), 'd701252b-618a-4123-9544-44a9a5233d9b', 'String', 'TypeName'),
(NEWID(), 'd701252b-618a-4123-9544-44a9a5233d9b', 'String', 'Description'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 'Guid', 'ID_RealEstate'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 'Guid', 'ID_RealEstateType'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 'String', 'NameRealEstate'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 'String', 'Country'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 'String', 'Region'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 'String', 'City'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 'String', 'Street'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 'String', 'BuildingNumber'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 'Guid', 'ID_RealEstateContact'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 'Guid', 'ID_RealEstate'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 'Guid', 'ID_Departament'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 'String', 'Telephone'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 'String', 'Email'),
(NEWID(), '6a93815b-e291-411a-b457-78c3b01b6f84', 'Guid', 'ID_Departament'),
(NEWID(), '6a93815b-e291-411a-b457-78c3b01b6f84', 'Guid', 'NameDepartament'),
(NEWID(), '6a93815b-e291-411a-b457-78c3b01b6f84', 'String', 'Description'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'Guid', 'ID_Employee'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'Guid', 'ID_Position'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'Guid', 'ID_RealEstate'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'String', 'FirstName'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'String', 'SecondName'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'String', 'MiddleName'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'String', 'Telephone'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'String', 'Passport'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'String', 'IDK'),
(NEWID(), 'c2c83e1f-35c8-4cab-ae4d-1ddb5945f2d6', 'bool', 'IsEnabled'),
(NEWID(), '4b082d0a-6aa4-411c-a7d3-0f41f933562d', 'Guid', 'ID_EmployeeWorkLog'),
(NEWID(), '4b082d0a-6aa4-411c-a7d3-0f41f933562d', 'Guid', 'ID_Employee'),
(NEWID(), '4b082d0a-6aa4-411c-a7d3-0f41f933562d', 'DateTime', 'DateTimeStart'),
(NEWID(), '4b082d0a-6aa4-411c-a7d3-0f41f933562d', 'DateTime', 'DateTimeEnd'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 'Guid', 'DateTimeEnd'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 'String', 'NamePosition'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 'String', 'Description'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 'int', 'PaymentHrnPerHour'),
(NEWID(), 'ec33e7a0-d58e-4225-9c21-1ee7a40d8167', 'Guid', 'ID_HeadOrder'),
(NEWID(), 'ec33e7a0-d58e-4225-9c21-1ee7a40d8167', 'Guid', 'ID_Position'),
(NEWID(), 'ec33e7a0-d58e-4225-9c21-1ee7a40d8167', 'Guid', 'ID_StatusOrder'),
(NEWID(), 'ec33e7a0-d58e-4225-9c21-1ee7a40d8167', 'String', 'AssignFor'),
(NEWID(), 'ec33e7a0-d58e-4225-9c21-1ee7a40d8167', 'String', 'Description'),
(NEWID(), 'ec33e7a0-d58e-4225-9c21-1ee7a40d8167', 'DateTime', 'Date'),
(NEWID(), '39de7b41-1940-4547-9d6c-73de9e09d20b', 'Guid', 'ID_StatusOrder'),
(NEWID(), '39de7b41-1940-4547-9d6c-73de9e09d20b', 'String', 'NameStatusOrder'),
(NEWID(), '94f0ea37-b1ff-4565-82cf-de4e3aa5f5d5', 'Guid', 'ID_HeadOrder'),
(NEWID(), '94f0ea37-b1ff-4565-82cf-de4e3aa5f5d5', 'Guid', 'ID_Employee'),
(NEWID(), '94f0ea37-b1ff-4565-82cf-de4e3aa5f5d5', 'Guid', 'ID_PerformedOrder'),
(NEWID(), '6952159c-f31e-4ac7-aff6-e81ddbff5f29', 'Guid', 'ID_ConnectingString'),
(NEWID(), '6952159c-f31e-4ac7-aff6-e81ddbff5f29', 'String', 'DataSource'),
(NEWID(), '6952159c-f31e-4ac7-aff6-e81ddbff5f29', 'String', 'InitialCatalog'),
(NEWID(), '6952159c-f31e-4ac7-aff6-e81ddbff5f29', 'String', 'UserId'),
(NEWID(), '6952159c-f31e-4ac7-aff6-e81ddbff5f29', 'String', 'UserPassword'),
(NEWID(), '6952159c-f31e-4ac7-aff6-e81ddbff5f29', 'String', 'ConnectionType'),
(NEWID(), '363c9398-dd81-4730-b91f-8fcddac22e0f', 'Guid', 'ID_SQLLog'),
(NEWID(), '363c9398-dd81-4730-b91f-8fcddac22e0f', 'Guid', 'ID_Employee'),
(NEWID(), '363c9398-dd81-4730-b91f-8fcddac22e0f', 'String', 'Description'),
(NEWID(), '363c9398-dd81-4730-b91f-8fcddac22e0f', 'DateTime', 'DateExecution'),
(NEWID(), '24e0f236-b5a2-4b12-87df-99fe4bccf08e', 'Guid', 'ID_Table'),
(NEWID(), '24e0f236-b5a2-4b12-87df-99fe4bccf08e', 'String', 'TableName'),
(NEWID(), 'a184fed4-abbd-42ad-9f72-4c02988a3485', 'Guid', 'ID_TableStructure'),
(NEWID(), 'a184fed4-abbd-42ad-9f72-4c02988a3485', 'Guid', 'ID_Table'),
(NEWID(), 'a184fed4-abbd-42ad-9f72-4c02988a3485', 'String', 'ColumnName'),
(NEWID(), 'a184fed4-abbd-42ad-9f72-4c02988a3485', 'String', 'ColumnType'),
(NEWID(), '04e467b8-999c-4789-8ac0-dea25a62c1c6', 'Guid', 'ID_Table'),
(NEWID(), '04e467b8-999c-4789-8ac0-dea25a62c1c6', 'Guid', 'ID_Position'),
(NEWID(), '04e467b8-999c-4789-8ac0-dea25a62c1c6', 'String', 'AccessType'),
(NEWID(), 'b972f6a4-2ec9-4616-a0e1-a628771c539e', 'Guid', 'ID_Employee'),
(NEWID(), 'b972f6a4-2ec9-4616-a0e1-a628771c539e', 'String', 'UserLogin'),
(NEWID(), 'b972f6a4-2ec9-4616-a0e1-a628771c539e', 'String', 'UserPassword');
GO
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------