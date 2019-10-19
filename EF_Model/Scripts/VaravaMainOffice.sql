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
    [Description] nvarchar(max)  NOT NULL
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

-- Creating primary key on [ID_SQLLog] in table 'SQLLogs'
ALTER TABLE [dbo].[SQLLogs]
ADD CONSTRAINT [PK_SQLLogs]
    PRIMARY KEY CLUSTERED ([ID_SQLLog] ASC);
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeSQLLog'
CREATE INDEX [IX_FK_EmployeeSQLLog]
ON [dbo].[SQLLogs]
    ([ID_Employee]);
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
EXEC sp_addlinkedserver 'Local', '', 'SQLNCLI', '192.168.1.100,31340'
GO
EXEC sp_addlinkedsrvlogin 'Local', 'FALSE', NULL, 'sa', '2584744'
GO
EXEC sp_addlinkedserver 'Host', '', 'SQLNCLI', '127.0.0.1,31340'
GO
EXEC sp_addlinkedsrvlogin 'Host', 'FALSE', NULL, 'sa', '2584744'
GO

-- Creating default data
INSERT INTO ConnectingStrings (ID_ConnectingString, DataSource, InitialCatalog, UserId, UserPassword, ConnectionType)
VALUES (NEWID(), '127.0.0.1,31340', 'VaravaStore', 'sa', '2584744', 'Host');
GO
INSERT INTO ConnectingStrings (ID_ConnectingString, DataSource, InitialCatalog, UserId, UserPassword, ConnectionType)
VALUES (NEWID(), '192.168.1.100,31340', 'VaravaStore', 'sa', '2584744', 'Local');
GO
INSERT INTO ConnectingStrings (ID_ConnectingString, DataSource, InitialCatalog, UserId, UserPassword, ConnectionType)
VALUES (NEWID(), '93.74.213.211,31340', 'VaravaStore', 'sa', '2584744', 'Global');
GO


INSERT INTO ConnectingStrings (ID_ConnectingString, DataSource, InitialCatalog, UserId, UserPassword, ConnectionType)
VALUES (NEWID(), '127.0.0.1,31340', 'VaravaFactory', 'sa', '2584744', 'Host');
GO
INSERT INTO ConnectingStrings (ID_ConnectingString, DataSource, InitialCatalog, UserId, UserPassword, ConnectionType)
VALUES (NEWID(), '192.168.1.100,31340', 'VaravaFactory', 'sa', '2584744', 'Local');
GO
INSERT INTO ConnectingStrings (ID_ConnectingString, DataSource, InitialCatalog, UserId, UserPassword, ConnectionType)
VALUES (NEWID(), '93.74.213.211,31340', 'VaravaFactory', 'sa', '2584744', 'Global');
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
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------