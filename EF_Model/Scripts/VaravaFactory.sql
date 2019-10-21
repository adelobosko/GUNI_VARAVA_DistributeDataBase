EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'VaravaFactory'
GO

USE [master]
GO
ALTER DATABASE [VaravaFactory] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

USE [master]
GO
DROP DATABASE [VaravaFactory]
GO
CREATE DATABASE [VaravaFactory]
GO
SET QUOTED_IDENTIFIER OFF;
GO
USE [VaravaFactory];
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

-- Creating table 'RawMaterialProviderContracts'
CREATE TABLE [dbo].[RawMaterialProviderContracts] (
    [ID_Contract] uniqueidentifier  NOT NULL,
    [ID_RawMaterial] uniqueidentifier  NOT NULL,
    [ID_MeasurementUnit] uniqueidentifier  NOT NULL,
    [ManufactureDate] datetime  NOT NULL,
    [Count] int  NOT NULL,
    [PricePerCount] int  NOT NULL,
    [ID_StatusContract] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'StockRawMaterials'
CREATE TABLE [dbo].[StockRawMaterials] (
    [ID_StockRawMaterial] uniqueidentifier  NOT NULL,
    [ID_RawMaterial] uniqueidentifier  NOT NULL,
    [ID_MeasurementUnit] uniqueidentifier  NOT NULL,
    [ManufactureDate] datetime  NOT NULL,
    [Count] int  NOT NULL,
    [PricePerGramm] int  NOT NULL
);
GO

-- Creating table 'RawMaterials'
CREATE TABLE [dbo].[RawMaterials] (
    [ID_RawMaterial] uniqueidentifier  NOT NULL,
    [RawMaterialName] nvarchar(max)  NOT NULL,
    [ExpirationDate] datetime  NOT NULL,
    [MinTemperature] int  NULL,
    [MaxTemperature] int  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'MeasurementUnits'
CREATE TABLE [dbo].[MeasurementUnits] (
    [ID_MeasurementUnit] uniqueidentifier  NOT NULL,
    [NameMeasurementUnit] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Components'
CREATE TABLE [dbo].[Components] (
    [ID_Product] uniqueidentifier  NOT NULL,
    [ID_RawMaterial] uniqueidentifier  NOT NULL,
    [ID_MeasurementUnit] uniqueidentifier  NOT NULL,
    [Count] int  NOT NULL
);
GO

-- Creating table 'Merchandises'
CREATE TABLE [dbo].[Merchandises] (
    [ID_Merchandise] uniqueidentifier  NOT NULL,
    [ID_Product] uniqueidentifier  NOT NULL,
    [ID_RealEstate] uniqueidentifier  NOT NULL,
    [Weight] int  NOT NULL,
    [ManufactureDate] datetime  NOT NULL,
    [PricePerGramm] int  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ID_Product] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Recipe] nvarchar(max)  NULL,
    [CalorieContent] int  NULL,
    [Proteins] int  NULL,
    [Fats] int  NULL,
    [Carbohydrates] int  NULL,
    [ExpirationDate] datetime  NOT NULL,
    [MinTemperature] int  NULL,
    [MaxTemperature] int  NULL,
    [Photo] nvarchar(max)  NULL
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

-- Creating table 'StatusOrders'
CREATE TABLE [dbo].[StatusOrders] (
    [ID_StatusOrder] uniqueidentifier  NOT NULL,
    [NameStatusOrder] nvarchar(max)  NOT NULL
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

-- Creating primary key on [ID_Contract] in table 'RawMaterialProviderContracts'
ALTER TABLE [dbo].[RawMaterialProviderContracts]
ADD CONSTRAINT [PK_RawMaterialProviderContracts]
    PRIMARY KEY CLUSTERED ([ID_Contract] ASC);
GO

-- Creating primary key on [ID_StockRawMaterial] in table 'StockRawMaterials'
ALTER TABLE [dbo].[StockRawMaterials]
ADD CONSTRAINT [PK_StockRawMaterials]
    PRIMARY KEY CLUSTERED ([ID_StockRawMaterial] ASC);
GO

-- Creating primary key on [ID_RawMaterial] in table 'RawMaterials'
ALTER TABLE [dbo].[RawMaterials]
ADD CONSTRAINT [PK_RawMaterials]
    PRIMARY KEY CLUSTERED ([ID_RawMaterial] ASC);
GO

-- Creating primary key on [ID_MeasurementUnit] in table 'MeasurementUnits'
ALTER TABLE [dbo].[MeasurementUnits]
ADD CONSTRAINT [PK_MeasurementUnits]
    PRIMARY KEY CLUSTERED ([ID_MeasurementUnit] ASC);
GO

-- Creating primary key on [ID_Product], [ID_RawMaterial] in table 'Components'
ALTER TABLE [dbo].[Components]
ADD CONSTRAINT [PK_Components]
    PRIMARY KEY CLUSTERED ([ID_Product], [ID_RawMaterial] ASC);
GO

-- Creating primary key on [ID_Merchandise] in table 'Merchandises'
ALTER TABLE [dbo].[Merchandises]
ADD CONSTRAINT [PK_Merchandises]
    PRIMARY KEY CLUSTERED ([ID_Merchandise] ASC);
GO

-- Creating primary key on [ID_Product] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ID_Product] ASC);
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

-- Creating primary key on [ID_StatusOrder] in table 'StatusOrders'
ALTER TABLE [dbo].[StatusOrders]
ADD CONSTRAINT [PK_StatusOrders]
    PRIMARY KEY CLUSTERED ([ID_StatusOrder] ASC);
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

-- Creating primary key on [ID_Table], [ID_Position] in table 'AccessTables'
ALTER TABLE [dbo].[AccessTables]
ADD CONSTRAINT [PK_AccessTables]
    PRIMARY KEY CLUSTERED ([ID_Table], [ID_Position] ASC);
GO


-- Creating primary key on [ID_ConnectingString] in table 'ConnectingStrings'
ALTER TABLE [dbo].[ConnectingStrings]
ADD CONSTRAINT [PK_ConnectingStrings]
    PRIMARY KEY CLUSTERED ([ID_ConnectingString] ASC);
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

-- Creating foreign key on [ID_RawMaterial] in table 'RawMaterialProviderContracts'
ALTER TABLE [dbo].[RawMaterialProviderContracts]
ADD CONSTRAINT [FK_RawMaterialRawMaterialProviderContract]
    FOREIGN KEY ([ID_RawMaterial])
    REFERENCES [dbo].[RawMaterials]
        ([ID_RawMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RawMaterialRawMaterialProviderContract'
CREATE INDEX [IX_FK_RawMaterialRawMaterialProviderContract]
ON [dbo].[RawMaterialProviderContracts]
    ([ID_RawMaterial]);
GO

-- Creating foreign key on [ID_MeasurementUnit] in table 'RawMaterialProviderContracts'
ALTER TABLE [dbo].[RawMaterialProviderContracts]
ADD CONSTRAINT [FK_MeasurementUnitRawMaterialProviderContract]
    FOREIGN KEY ([ID_MeasurementUnit])
    REFERENCES [dbo].[MeasurementUnits]
        ([ID_MeasurementUnit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MeasurementUnitRawMaterialProviderContract'
CREATE INDEX [IX_FK_MeasurementUnitRawMaterialProviderContract]
ON [dbo].[RawMaterialProviderContracts]
    ([ID_MeasurementUnit]);
GO

-- Creating foreign key on [ID_StatusContract] in table 'RawMaterialProviderContracts'
ALTER TABLE [dbo].[RawMaterialProviderContracts]
ADD CONSTRAINT [FK_StatusOrderRawMaterialProviderContract]
    FOREIGN KEY ([ID_StatusContract])
    REFERENCES [dbo].[StatusOrders]
        ([ID_StatusOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StatusOrderRawMaterialProviderContract'
CREATE INDEX [IX_FK_StatusOrderRawMaterialProviderContract]
ON [dbo].[RawMaterialProviderContracts]
    ([ID_StatusContract]);
GO

-- Creating foreign key on [ID_RawMaterial] in table 'StockRawMaterials'
ALTER TABLE [dbo].[StockRawMaterials]
ADD CONSTRAINT [FK_RawMaterialStockRawMaterial]
    FOREIGN KEY ([ID_RawMaterial])
    REFERENCES [dbo].[RawMaterials]
        ([ID_RawMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RawMaterialStockRawMaterial'
CREATE INDEX [IX_FK_RawMaterialStockRawMaterial]
ON [dbo].[StockRawMaterials]
    ([ID_RawMaterial]);
GO

-- Creating foreign key on [ID_MeasurementUnit] in table 'StockRawMaterials'
ALTER TABLE [dbo].[StockRawMaterials]
ADD CONSTRAINT [FK_MeasurementUnitStockRawMaterial]
    FOREIGN KEY ([ID_MeasurementUnit])
    REFERENCES [dbo].[MeasurementUnits]
        ([ID_MeasurementUnit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MeasurementUnitStockRawMaterial'
CREATE INDEX [IX_FK_MeasurementUnitStockRawMaterial]
ON [dbo].[StockRawMaterials]
    ([ID_MeasurementUnit]);
GO

-- Creating foreign key on [ID_RawMaterial] in table 'Components'
ALTER TABLE [dbo].[Components]
ADD CONSTRAINT [FK_RawMaterialComponent]
    FOREIGN KEY ([ID_RawMaterial])
    REFERENCES [dbo].[RawMaterials]
        ([ID_RawMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RawMaterialComponent'
CREATE INDEX [IX_FK_RawMaterialComponent]
ON [dbo].[Components]
    ([ID_RawMaterial]);
GO

-- Creating foreign key on [ID_MeasurementUnit] in table 'Components'
ALTER TABLE [dbo].[Components]
ADD CONSTRAINT [FK_MeasurementUnitComponent]
    FOREIGN KEY ([ID_MeasurementUnit])
    REFERENCES [dbo].[MeasurementUnits]
        ([ID_MeasurementUnit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MeasurementUnitComponent'
CREATE INDEX [IX_FK_MeasurementUnitComponent]
ON [dbo].[Components]
    ([ID_MeasurementUnit]);
GO

-- Creating foreign key on [ID_Product] in table 'Components'
ALTER TABLE [dbo].[Components]
ADD CONSTRAINT [FK_ProductComponent]
    FOREIGN KEY ([ID_Product])
    REFERENCES [dbo].[Products]
        ([ID_Product])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_RealEstate] in table 'Merchandises'
ALTER TABLE [dbo].[Merchandises]
ADD CONSTRAINT [FK_RealEstateMerchandise]
    FOREIGN KEY ([ID_RealEstate])
    REFERENCES [dbo].[RealEstates]
        ([ID_RealEstate])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RealEstateMerchandise'
CREATE INDEX [IX_FK_RealEstateMerchandise]
ON [dbo].[Merchandises]
    ([ID_RealEstate]);
GO

-- Creating foreign key on [ID_Product] in table 'Merchandises'
ALTER TABLE [dbo].[Merchandises]
ADD CONSTRAINT [FK_ProductMerchandise]
    FOREIGN KEY ([ID_Product])
    REFERENCES [dbo].[Products]
        ([ID_Product])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMerchandise'
CREATE INDEX [IX_FK_ProductMerchandise]
ON [dbo].[Merchandises]
    ([ID_Product]);
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



-- Creating default data
INSERT INTO ConnectingStrings (ID_ConnectingString, DataSource, InitialCatalog, UserId, UserPassword, ConnectionType)
VALUES 
(NEWID(), '(localdb)\MSSQLLocalDB', 'VaravaStore', 'sa', '2584744', 'Host'),
(NEWID(), '(localdb)\MSSQLLocalDB', 'VaravaStore', 'sa', '2584744', 'Local'),
(NEWID(), '(localdb)\MSSQLLocalDB', 'VaravaStore', 'sa', '2584744', 'Global'),
(NEWID(), '127.0.0.1,31340', 'VaravaFactory', 'sa', '2584744', 'Host'),
(NEWID(), '192.168.1.100,31340', 'VaravaFactory', 'sa', '2584744', 'Local'),
(NEWID(), '93.74.213.211,31340', 'VaravaFactory', 'sa', '2584744', 'Global'),
(NEWID(), '127.0.0.1,31340', 'VaravaMainOffice', 'sa', '2584744', 'Host'),
(NEWID(), '192.168.1.100,31340', 'VaravaMainOffice', 'sa', '2584744', 'Local'),
(NEWID(), '93.74.213.211,31340', 'VaravaMainOffice', 'sa', '2584744', 'Global');
GO


INSERT INTO DataBaseTables (ID_Table, TableName)
VALUES 
('d701252b-618a-4123-9544-44a9a5233d9b', 'RealEstateTypes'),
('99133287-1910-4e42-8db6-c3aa53a6fb11', 'RealEstates'),
('751eec3e-33df-401f-9e2f-33c8615dd1c6', 'RealEstateContacts'),
('6a93815b-e291-411a-b457-78c3b01b6f84', 'Departaments'),
('83e709b5-cf67-4e6a-9572-73788563cd74', 'Positions'),
('39de7b41-1940-4547-9d6c-73de9e09d20b', 'StatusOrders'),

('a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'Employees'),
('cebc6bb4-1626-438a-8c27-595fcd62373e', 'EmployeeWorkLogs'),
('a723e6a4-d1a7-4f82-8acb-552b3623d1c7', 'ConnectingStrings'),
('a82c98e0-711c-44c4-bf22-1093f86426b3', 'SQLLogs'),
('5687e06a-9d81-464a-8dfc-7ac07a0d9b37', 'DataBaseTables'),
('cb48e617-dfed-44ee-b734-af6ba82fc212', 'TableStructures'),
('ec95849b-ea79-4bec-917b-e0e33d0b0fc5', 'AccessTables'),
('aefa774a-5ad0-4281-a9ce-d8093287a08d', 'Users'),
('8ad8a2ed-e206-41f0-bca4-aa34fe0e2eea', 'RawMaterialProviderContracts'),
('1a70ebac-6165-4c53-aead-6171453f75e7', 'StockRawMaterials'),
('1ca661c2-c390-4619-91f2-704822cfc3ce', 'RawMaterials'),
('99515ff2-b2b6-459e-9497-5217e8689573', 'MeasurementUnits'),
('f8004800-d2fe-49a6-bf68-a2e1e969c0f8', 'Components'),
('59e656db-ac03-416d-b2bf-145674aab0d4', 'Merchandises'),
('2f86402c-a36d-4744-bc55-006d135e9cac', 'Products');
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
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'Guid', 'ID_Employee'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'Guid', 'ID_Position'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'Guid', 'ID_RealEstate'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'String', 'FirstName'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'String', 'SecondName'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'String', 'MiddleName'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'String', 'Telephone'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'String', 'Passport'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'String', 'IDK'),
(NEWID(), 'a2120f90-3a60-4d4a-b353-e9b168ecaba7', 'bool', 'IsEnabled'),
(NEWID(), 'cebc6bb4-1626-438a-8c27-595fcd62373e', 'Guid', 'ID_EmployeeWorkLog'),
(NEWID(), 'cebc6bb4-1626-438a-8c27-595fcd62373e', 'Guid', 'ID_Employee'),
(NEWID(), 'cebc6bb4-1626-438a-8c27-595fcd62373e', 'DateTime', 'DateTimeStart'),
(NEWID(), 'cebc6bb4-1626-438a-8c27-595fcd62373e', 'DateTime', 'DateTimeEnd'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 'Guid', 'DateTimeEnd'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 'String', 'NamePosition'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 'String', 'Description'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 'int', 'PaymentHrnPerHour'),
(NEWID(), '39de7b41-1940-4547-9d6c-73de9e09d20b', 'Guid', 'ID_StatusOrder'),
(NEWID(), '39de7b41-1940-4547-9d6c-73de9e09d20b', 'String', 'NameStatusOrder'),
(NEWID(), 'a723e6a4-d1a7-4f82-8acb-552b3623d1c7', 'Guid', 'ID_ConnectingString'),
(NEWID(), 'a723e6a4-d1a7-4f82-8acb-552b3623d1c7', 'String', 'DataSource'),
(NEWID(), 'a723e6a4-d1a7-4f82-8acb-552b3623d1c7', 'String', 'InitialCatalog'),
(NEWID(), 'a723e6a4-d1a7-4f82-8acb-552b3623d1c7', 'String', 'UserId'),
(NEWID(), 'a723e6a4-d1a7-4f82-8acb-552b3623d1c7', 'String', 'UserPassword'),
(NEWID(), 'a723e6a4-d1a7-4f82-8acb-552b3623d1c7', 'String', 'ConnectionType'),
(NEWID(), 'a82c98e0-711c-44c4-bf22-1093f86426b3', 'Guid', 'ID_SQLLog'),
(NEWID(), 'a82c98e0-711c-44c4-bf22-1093f86426b3', 'Guid', 'ID_Employee'),
(NEWID(), 'a82c98e0-711c-44c4-bf22-1093f86426b3', 'String', 'Description'),
(NEWID(), 'a82c98e0-711c-44c4-bf22-1093f86426b3', 'DateTime', 'DateExecution'),
(NEWID(), '5687e06a-9d81-464a-8dfc-7ac07a0d9b37', 'Guid', 'ID_Table'),
(NEWID(), '5687e06a-9d81-464a-8dfc-7ac07a0d9b37', 'String', 'TableName'),
(NEWID(), 'cb48e617-dfed-44ee-b734-af6ba82fc212', 'Guid', 'ID_TableStructure'),
(NEWID(), 'cb48e617-dfed-44ee-b734-af6ba82fc212', 'Guid', 'ID_Table'),
(NEWID(), 'cb48e617-dfed-44ee-b734-af6ba82fc212', 'String', 'ColumnName'),
(NEWID(), 'cb48e617-dfed-44ee-b734-af6ba82fc212', 'String', 'ColumnType'),
(NEWID(), 'ec95849b-ea79-4bec-917b-e0e33d0b0fc5', 'Guid', 'ID_Table'),
(NEWID(), 'ec95849b-ea79-4bec-917b-e0e33d0b0fc5', 'Guid', 'ID_Position'),
(NEWID(), 'ec95849b-ea79-4bec-917b-e0e33d0b0fc5', 'String', 'AccessType'),
(NEWID(), 'aefa774a-5ad0-4281-a9ce-d8093287a08d', 'Guid', 'ID_Employee'),
(NEWID(), 'aefa774a-5ad0-4281-a9ce-d8093287a08d', 'String', 'UserLogin'),
(NEWID(), 'aefa774a-5ad0-4281-a9ce-d8093287a08d', 'String', 'UserPassword'),
(NEWID(), '8ad8a2ed-e206-41f0-bca4-aa34fe0e2eea', 'Guid', 'ID_Contract'),
(NEWID(), '8ad8a2ed-e206-41f0-bca4-aa34fe0e2eea', 'Guid', 'ID_RawMaterial'),
(NEWID(), '8ad8a2ed-e206-41f0-bca4-aa34fe0e2eea', 'Guid', 'ID_MeasurementUnit'),
(NEWID(), '8ad8a2ed-e206-41f0-bca4-aa34fe0e2eea', 'Guid', 'ID_StatusContract'),
(NEWID(), '8ad8a2ed-e206-41f0-bca4-aa34fe0e2eea', 'DateTime', 'ManufactureDate'),
(NEWID(), '8ad8a2ed-e206-41f0-bca4-aa34fe0e2eea', 'int', 'Count'),
(NEWID(), '8ad8a2ed-e206-41f0-bca4-aa34fe0e2eea', 'int', 'PricePerCount'),
(NEWID(), '1a70ebac-6165-4c53-aead-6171453f75e7', 'Guid', 'ID_StockRawMaterial'),
(NEWID(), '1a70ebac-6165-4c53-aead-6171453f75e7', 'Guid', 'ID_RawMaterial'),
(NEWID(), '1a70ebac-6165-4c53-aead-6171453f75e7', 'Guid', 'ID_MeasurementUnit'),
(NEWID(), '1a70ebac-6165-4c53-aead-6171453f75e7', 'DateTime', 'ManufactureDate'),
(NEWID(), '1a70ebac-6165-4c53-aead-6171453f75e7', 'int', 'Count'),
(NEWID(), '1a70ebac-6165-4c53-aead-6171453f75e7', 'int', 'PricePerGramm'),
(NEWID(), '1ca661c2-c390-4619-91f2-704822cfc3ce', 'Guid', 'ID_RawMaterial'),
(NEWID(), '1ca661c2-c390-4619-91f2-704822cfc3ce', 'String', 'RawMaterialName'),
(NEWID(), '1ca661c2-c390-4619-91f2-704822cfc3ce', 'String', 'Description'),
(NEWID(), '1ca661c2-c390-4619-91f2-704822cfc3ce', 'DateTime', 'ExpirationDate'),
(NEWID(), '1ca661c2-c390-4619-91f2-704822cfc3ce', 'int', 'MinTemperature'),
(NEWID(), '1ca661c2-c390-4619-91f2-704822cfc3ce', 'int', 'MaxTemperature'),
(NEWID(), '99515ff2-b2b6-459e-9497-5217e8689573', 'Guid', 'ID_MeasurementUnit'),
(NEWID(), '99515ff2-b2b6-459e-9497-5217e8689573', 'String', 'NameMeasurementUnit'),
(NEWID(), 'f8004800-d2fe-49a6-bf68-a2e1e969c0f8', 'Guid', 'ID_Product'),
(NEWID(), 'f8004800-d2fe-49a6-bf68-a2e1e969c0f8', 'Guid', 'ID_RawMaterial'),
(NEWID(), 'f8004800-d2fe-49a6-bf68-a2e1e969c0f8', 'Guid', 'ID_MeasurementUnit'),
(NEWID(), 'f8004800-d2fe-49a6-bf68-a2e1e969c0f8', 'int', 'Count'),
(NEWID(), '59e656db-ac03-416d-b2bf-145674aab0d4', 'Guid', 'ID_Merchandise'),
(NEWID(), '59e656db-ac03-416d-b2bf-145674aab0d4', 'Guid', 'ID_Product'),
(NEWID(), '59e656db-ac03-416d-b2bf-145674aab0d4', 'Guid', 'ID_RealEstate'),
(NEWID(), '59e656db-ac03-416d-b2bf-145674aab0d4', 'int', 'Weight'),
(NEWID(), '59e656db-ac03-416d-b2bf-145674aab0d4', 'int', 'PricePerGramm'),
(NEWID(), '59e656db-ac03-416d-b2bf-145674aab0d4', 'DateTime', 'ManufactureDate'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'Guide', 'ID_Product'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'String', 'ProductName'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'String', 'Description'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'String', 'Recipe'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'String', 'Photo'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'int', 'CalorieContent'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'int', 'Proteins'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'int', 'Fats'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'int', 'Carbohydrates'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'int', 'MinTemperature'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'int', 'MaxTemperature'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 'DateTime', 'ExpirationDate');
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------