EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'VaravaStore'
GO

USE [master]
GO
ALTER DATABASE [VaravaStore] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

USE [master]
GO
DROP DATABASE [VaravaStore]
GO
CREATE DATABASE [VaravaStore]
GO
SET QUOTED_IDENTIFIER OFF;
GO
USE [VaravaStore];
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

-- Creating table 'CashRegisters'
CREATE TABLE [dbo].[CashRegisters] (
    [ID_CashRegister] uniqueidentifier  NOT NULL,
    [ID_RealEstate] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CashRegisterOperations'
CREATE TABLE [dbo].[CashRegisterOperations] (
    [ID_Operation] uniqueidentifier  NOT NULL,
    [NameOperation] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [ID_Purchase] uniqueidentifier  NOT NULL,
    [ID_Merchandise] uniqueidentifier  NOT NULL,
    [ID_CashRegisterAccess] uniqueidentifier  NOT NULL,
    [Weight] int  NOT NULL,
    [PurchaseDate] datetime  NOT NULL
);
GO

-- Creating table 'CashRegisterAccesses'
CREATE TABLE [dbo].[CashRegisterAccesses] (
    [ID_CashRegisterAccess] uniqueidentifier  NOT NULL,
    [ID_CashRegister] uniqueidentifier  NOT NULL,
    [ID_EmployeeSeller] uniqueidentifier  NOT NULL,
    [ID_Operation] uniqueidentifier  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'StoreOrders'
CREATE TABLE [dbo].[StoreOrders] (
    [ID_StoreOrder] uniqueidentifier  NOT NULL,
    [ID_Product] uniqueidentifier  NOT NULL,
    [ID_RealEstateStore] uniqueidentifier  NOT NULL,
    [ID_StoreManager] uniqueidentifier  NOT NULL,
    [ID_StatusOrder] uniqueidentifier  NOT NULL,
    [InitialDate] datetime  NOT NULL,
    [Weight] int  NOT NULL
);
GO

-- Creating table 'MerchandiseAcceptanceLogs'
CREATE TABLE [dbo].[MerchandiseAcceptanceLogs] (
    [ID_StoreOrder] uniqueidentifier  NOT NULL,
    [ID_AcceptManager] uniqueidentifier  NOT NULL,
    [AcceptDate] datetime  NOT NULL,
    [Weight] int  NOT NULL
);
GO

-- Creating table 'LackLogs'
CREATE TABLE [dbo].[LackLogs] (
    [ID_StoreOrder] uniqueidentifier  NOT NULL,
    [WeightOfLack] int  NOT NULL
);
GO

-- Creating table 'StatusOrders'
CREATE TABLE [dbo].[StatusOrders] (
    [ID_StatusOrder] uniqueidentifier  NOT NULL,
    [NameStatusOrder] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PerformedStoreOrders'
CREATE TABLE [dbo].[PerformedStoreOrders] (
    [ID_StoreOrder] uniqueidentifier  NOT NULL,
    [ID_FactoryManager] uniqueidentifier  NOT NULL,
    [ID_Carrier] uniqueidentifier  NOT NULL,
    [ShippingDate] datetime  NOT NULL,
    [Weight] int  NOT NULL
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
    [ID_TableStructure] uniqueidentifier  NOT NULL,
    [IsPrimary] bit  NOT NULL
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

-- Creating primary key on [ID_Merchandise] in table 'Merchandises'
ALTER TABLE [dbo].[Merchandises]
ADD CONSTRAINT [PK_Merchandises]
    PRIMARY KEY CLUSTERED ([ID_Merchandise] ASC);
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

-- Creating primary key on [ID_Product] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ID_Product] ASC);
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

-- Creating primary key on [ID_CashRegister] in table 'CashRegisters'
ALTER TABLE [dbo].[CashRegisters]
ADD CONSTRAINT [PK_CashRegisters]
    PRIMARY KEY CLUSTERED ([ID_CashRegister] ASC);
GO

-- Creating primary key on [ID_Operation] in table 'CashRegisterOperations'
ALTER TABLE [dbo].[CashRegisterOperations]
ADD CONSTRAINT [PK_CashRegisterOperations]
    PRIMARY KEY CLUSTERED ([ID_Operation] ASC);
GO

-- Creating primary key on [ID_Purchase] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([ID_Purchase] ASC);
GO

-- Creating primary key on [ID_CashRegisterAccess] in table 'CashRegisterAccesses'
ALTER TABLE [dbo].[CashRegisterAccesses]
ADD CONSTRAINT [PK_CashRegisterAccesses]
    PRIMARY KEY CLUSTERED ([ID_CashRegisterAccess] ASC);
GO

-- Creating primary key on [ID_StoreOrder] in table 'StoreOrders'
ALTER TABLE [dbo].[StoreOrders]
ADD CONSTRAINT [PK_StoreOrders]
    PRIMARY KEY CLUSTERED ([ID_StoreOrder] ASC);
GO

-- Creating primary key on [ID_StoreOrder] in table 'MerchandiseAcceptanceLogs'
ALTER TABLE [dbo].[MerchandiseAcceptanceLogs]
ADD CONSTRAINT [PK_MerchandiseAcceptanceLogs]
    PRIMARY KEY CLUSTERED ([ID_StoreOrder] ASC);
GO

-- Creating primary key on [ID_StoreOrder] in table 'LackLogs'
ALTER TABLE [dbo].[LackLogs]
ADD CONSTRAINT [PK_LackLogs]
    PRIMARY KEY CLUSTERED ([ID_StoreOrder] ASC);
GO

-- Creating primary key on [ID_StatusOrder] in table 'StatusOrders'
ALTER TABLE [dbo].[StatusOrders]
ADD CONSTRAINT [PK_StatusOrders]
    PRIMARY KEY CLUSTERED ([ID_StatusOrder] ASC);
GO

-- Creating primary key on [ID_StoreOrder] in table 'PerformedStoreOrders'
ALTER TABLE [dbo].[PerformedStoreOrders]
ADD CONSTRAINT [PK_PerformedStoreOrders]
    PRIMARY KEY CLUSTERED ([ID_StoreOrder] ASC);
GO

-- Creating primary key on [ID_SQLLog] in table 'SQLLogs'
ALTER TABLE [dbo].[SQLLogs]
ADD CONSTRAINT [PK_SQLLogs]
    PRIMARY KEY CLUSTERED ([ID_SQLLog] ASC);
GO-- Creating primary key on [ID_Table] in table 'DataBaseTables'
ALTER TABLE [dbo].[DataBaseTables]
ADD CONSTRAINT [PK_DataBaseTables]
    PRIMARY KEY CLUSTERED ([ID_Table] ASC);
GO

-- Creating primary key on [ID_TableStructure] in table 'TableStructures'
ALTER TABLE [dbo].[TableStructures]
ADD CONSTRAINT [PK_TableStructures]
    PRIMARY KEY CLUSTERED ([ID_TableStructure] ASC);
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

-- Creating foreign key on [ID_Merchandise] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_MerchandisePurchase]
    FOREIGN KEY ([ID_Merchandise])
    REFERENCES [dbo].[Merchandises]
        ([ID_Merchandise])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
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

-- Creating non-clustered index for FOREIGN KEY 'FK_MerchandisePurchase'
CREATE INDEX [IX_FK_MerchandisePurchase]
ON [dbo].[Purchases]
    ([ID_Merchandise]);
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

-- Creating foreign key on [ID_EmployeeSeller] in table 'CashRegisterAccesses'
ALTER TABLE [dbo].[CashRegisterAccesses]
ADD CONSTRAINT [FK_CashRegisterAccessEmployee]
    FOREIGN KEY ([ID_EmployeeSeller])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CashRegisterAccessEmployee'
CREATE INDEX [IX_FK_CashRegisterAccessEmployee]
ON [dbo].[CashRegisterAccesses]
    ([ID_EmployeeSeller]);
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

-- Creating foreign key on [ID_StoreManager] in table 'StoreOrders'
ALTER TABLE [dbo].[StoreOrders]
ADD CONSTRAINT [FK_EmployeeStoreOrder]
    FOREIGN KEY ([ID_StoreManager])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeStoreOrder'
CREATE INDEX [IX_FK_EmployeeStoreOrder]
ON [dbo].[StoreOrders]
    ([ID_StoreManager]);
GO

-- Creating foreign key on [ID_AcceptManager] in table 'MerchandiseAcceptanceLogs'
ALTER TABLE [dbo].[MerchandiseAcceptanceLogs]
ADD CONSTRAINT [FK_EmployeeMerchandiseAcceptanceLog]
    FOREIGN KEY ([ID_AcceptManager])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeMerchandiseAcceptanceLog'
CREATE INDEX [IX_FK_EmployeeMerchandiseAcceptanceLog]
ON [dbo].[MerchandiseAcceptanceLogs]
    ([ID_AcceptManager]);
GO

-- Creating foreign key on [ID_FactoryManager] in table 'PerformedStoreOrders'
ALTER TABLE [dbo].[PerformedStoreOrders]
ADD CONSTRAINT [FK_EmployeePerformedStoreOrder]
    FOREIGN KEY ([ID_FactoryManager])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeePerformedStoreOrder'
CREATE INDEX [IX_FK_EmployeePerformedStoreOrder]
ON [dbo].[PerformedStoreOrders]
    ([ID_FactoryManager]);
GO

-- Creating foreign key on [ID_Carrier] in table 'PerformedStoreOrders'
ALTER TABLE [dbo].[PerformedStoreOrders]
ADD CONSTRAINT [FK_EmployeePerformedStoreOrder1]
    FOREIGN KEY ([ID_Carrier])
    REFERENCES [dbo].[Employees]
        ([ID_Employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeePerformedStoreOrder1'
CREATE INDEX [IX_FK_EmployeePerformedStoreOrder1]
ON [dbo].[PerformedStoreOrders]
    ([ID_Carrier]);
GO

-- Creating foreign key on [ID_CashRegister] in table 'CashRegisterAccesses'
ALTER TABLE [dbo].[CashRegisterAccesses]
ADD CONSTRAINT [FK_CashRegisterCashRegisterAccess]
    FOREIGN KEY ([ID_CashRegister])
    REFERENCES [dbo].[CashRegisters]
        ([ID_CashRegister])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CashRegisterCashRegisterAccess'
CREATE INDEX [IX_FK_CashRegisterCashRegisterAccess]
ON [dbo].[CashRegisterAccesses]
    ([ID_CashRegister]);
GO

-- Creating foreign key on [ID_RealEstate] in table 'CashRegisters'
ALTER TABLE [dbo].[CashRegisters]
ADD CONSTRAINT [FK_RealEstateCashRegister]
    FOREIGN KEY ([ID_RealEstate])
    REFERENCES [dbo].[RealEstates]
        ([ID_RealEstate])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RealEstateCashRegister'
CREATE INDEX [IX_FK_RealEstateCashRegister]
ON [dbo].[CashRegisters]
    ([ID_RealEstate]);
GO

-- Creating foreign key on [ID_Operation] in table 'CashRegisterAccesses'
ALTER TABLE [dbo].[CashRegisterAccesses]
ADD CONSTRAINT [FK_CashRegisterOperationCashRegisterAccess]
    FOREIGN KEY ([ID_Operation])
    REFERENCES [dbo].[CashRegisterOperations]
        ([ID_Operation])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CashRegisterOperationCashRegisterAccess'
CREATE INDEX [IX_FK_CashRegisterOperationCashRegisterAccess]
ON [dbo].[CashRegisterAccesses]
    ([ID_Operation]);
GO

-- Creating foreign key on [ID_CashRegisterAccess] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_CashRegisterAccessPurchase]
    FOREIGN KEY ([ID_CashRegisterAccess])
    REFERENCES [dbo].[CashRegisterAccesses]
        ([ID_CashRegisterAccess])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CashRegisterAccessPurchase'
CREATE INDEX [IX_FK_CashRegisterAccessPurchase]
ON [dbo].[Purchases]
    ([ID_CashRegisterAccess]);
GO

-- Creating foreign key on [ID_RealEstateStore] in table 'StoreOrders'
ALTER TABLE [dbo].[StoreOrders]
ADD CONSTRAINT [FK_RealEstateStoreOrder]
    FOREIGN KEY ([ID_RealEstateStore])
    REFERENCES [dbo].[RealEstates]
        ([ID_RealEstate])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RealEstateStoreOrder'
CREATE INDEX [IX_FK_RealEstateStoreOrder]
ON [dbo].[StoreOrders]
    ([ID_RealEstateStore]);
GO

-- Creating foreign key on [ID_StoreOrder] in table 'LackLogs'
ALTER TABLE [dbo].[LackLogs]
ADD CONSTRAINT [FK_MerchandiseAcceptanceLogLackLog]
    FOREIGN KEY ([ID_StoreOrder])
    REFERENCES [dbo].[MerchandiseAcceptanceLogs]
        ([ID_StoreOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_StoreOrder] in table 'PerformedStoreOrders'
ALTER TABLE [dbo].[PerformedStoreOrders]
ADD CONSTRAINT [FK_StoreOrderPerformedStoreOrder]
    FOREIGN KEY ([ID_StoreOrder])
    REFERENCES [dbo].[StoreOrders]
        ([ID_StoreOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_StatusOrder] in table 'StoreOrders'
ALTER TABLE [dbo].[StoreOrders]
ADD CONSTRAINT [FK_StatusOrderStoreOrder]
    FOREIGN KEY ([ID_StatusOrder])
    REFERENCES [dbo].[StatusOrders]
        ([ID_StatusOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
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

-- Creating non-clustered index for FOREIGN KEY 'FK_StatusOrderStoreOrder'
CREATE INDEX [IX_FK_StatusOrderStoreOrder]
ON [dbo].[StoreOrders]
    ([ID_StatusOrder]);
GO

-- Creating foreign key on [ID_StoreOrder] in table 'MerchandiseAcceptanceLogs'
ALTER TABLE [dbo].[MerchandiseAcceptanceLogs]
ADD CONSTRAINT [FK_StoreOrderMerchandiseAcceptanceLog]
    FOREIGN KEY ([ID_StoreOrder])
    REFERENCES [dbo].[StoreOrders]
        ([ID_StoreOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
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


INSERT INTO DataBaseTables (ID_Table, TableName)
VALUES 
('d701252b-618a-4123-9544-44a9a5233d9b', 'RealEstateTypes'),
('99133287-1910-4e42-8db6-c3aa53a6fb11', 'RealEstates'),
('751eec3e-33df-401f-9e2f-33c8615dd1c6', 'RealEstateContacts'),
('6a93815b-e291-411a-b457-78c3b01b6f84', 'Departaments'),
('83e709b5-cf67-4e6a-9572-73788563cd74', 'Positions'),
('39de7b41-1940-4547-9d6c-73de9e09d20b', 'StatusOrders'),


('2f86402c-a36d-4744-bc55-006d135e9cac', 'Products'),

('bec77c93-d95c-4ba6-9fc5-8e1b41e2791a', 'Merchandises'),
('d08eed5b-dfaf-457b-92bc-bd1ecf096b84', 'Employees'),
('b8a98e35-2d50-4142-80cb-f7d8a67390dc', 'EmployeeWorkLogs'),
('7d19c4b3-485e-4384-9ee4-299143277371', 'ConnectingStrings'),
('57608aa4-8b31-4116-981a-952bf9983e73', 'SQLLogs'),
('4aceeb3e-d8ea-45d0-adc3-e8628a567aa5', 'DataBaseTables'),
('c1fbc683-a51e-4ad1-8249-8e318e1f3bca', 'TableStructures'),
('742ef5f8-3fc3-4c23-85a8-d770f9b432fa', 'Users'),
('0e1b9bfc-e347-463a-b017-eae50483c671', 'CashRegisters'),
('0343a9c0-8e1d-4efa-9eb0-d83ac84f6c3a', 'CashRegisterOperations'),
('8488e2f5-97f3-4d74-90c8-0704b8fda279', 'Purchases'),
('3f34b2c4-facb-4c57-9654-59bc27135e27', 'CashRegisterAccesses'),
('a1a16436-c1f7-4ec1-bdcd-4768909d2e5a', 'StoreOrders'),
('b8d2c22d-b5e5-412e-83a9-10f30804c60f', 'MerchandiseAcceptanceLogs'),
('e22534aa-b217-4936-9ac1-83265f8d3e9f', 'LackLogs');
GO
INSERT INTO TableStructures (ID_TableStructure, ID_Table, IsPrimary, ColumnType, ColumnName)
VALUES 
(NEWID(), 'd701252b-618a-4123-9544-44a9a5233d9b', 1, 'Guid', 'ID_RealEstateType'),
(NEWID(), 'd701252b-618a-4123-9544-44a9a5233d9b', 0, 'String', 'TypeName'),
(NEWID(), 'd701252b-618a-4123-9544-44a9a5233d9b', 0, 'String', 'Description'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 1, 'Guid', 'ID_RealEstate'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 0, 'Guid', 'ID_RealEstateType'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 0, 'String', 'NameRealEstate'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 0, 'String', 'Country'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 0, 'String', 'Region'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 0, 'String', 'City'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 0, 'String', 'Street'),
(NEWID(), '99133287-1910-4e42-8db6-c3aa53a6fb11', 0, 'String', 'BuildingNumber'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 1, 'Guid', 'ID_RealEstateContact'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 0, 'Guid', 'ID_RealEstate'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 0, 'Guid', 'ID_Departament'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 0, 'String', 'Telephone'),
(NEWID(), '751eec3e-33df-401f-9e2f-33c8615dd1c6', 0, 'String', 'Email'),
(NEWID(), '6a93815b-e291-411a-b457-78c3b01b6f84', 1, 'Guid', 'ID_Departament'),
(NEWID(), '6a93815b-e291-411a-b457-78c3b01b6f84', 0, 'Guid', 'NameDepartament'),
(NEWID(), '6a93815b-e291-411a-b457-78c3b01b6f84', 0, 'String', 'Description'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 1, 'Guid', 'ID_Employee'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'Guid', 'ID_Position'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'Guid', 'ID_RealEstate'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'String', 'FirstName'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'String', 'SecondName'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'String', 'MiddleName'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'String', 'Telephone'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'String', 'Passport'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'String', 'IDK'),
(NEWID(), 'd08eed5b-dfaf-457b-92bc-bd1ecf096b84', 0, 'bool', 'IsEnabled'),
(NEWID(), 'b8a98e35-2d50-4142-80cb-f7d8a67390dc', 0, 'Guid', 'ID_EmployeeWorkLog'),
(NEWID(), 'b8a98e35-2d50-4142-80cb-f7d8a67390dc', 0, 'Guid', 'ID_Employee'),
(NEWID(), 'b8a98e35-2d50-4142-80cb-f7d8a67390dc', 0, 'DateTime', 'DateTimeStart'),
(NEWID(), 'b8a98e35-2d50-4142-80cb-f7d8a67390dc', 0, 'DateTime', 'DateTimeEnd'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 1, 'Guid', 'ID_Position'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 0, 'String', 'NamePosition'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 0, 'String', 'Description'),
(NEWID(), '83e709b5-cf67-4e6a-9572-73788563cd74', 0, 'int', 'PaymentHrnPerHour'),
(NEWID(), '39de7b41-1940-4547-9d6c-73de9e09d20b', 1, 'Guid', 'ID_StatusOrder'),
(NEWID(), '39de7b41-1940-4547-9d6c-73de9e09d20b', 0, 'String', 'NameStatusOrder'),
(NEWID(), '7d19c4b3-485e-4384-9ee4-299143277371', 1, 'Guid', 'ID_ConnectingString'),
(NEWID(), '7d19c4b3-485e-4384-9ee4-299143277371', 0, 'String', 'DataSource'),
(NEWID(), '7d19c4b3-485e-4384-9ee4-299143277371', 0, 'String', 'InitialCatalog'),
(NEWID(), '7d19c4b3-485e-4384-9ee4-299143277371', 0, 'String', 'UserId'),
(NEWID(), '7d19c4b3-485e-4384-9ee4-299143277371', 0, 'String', 'UserPassword'),
(NEWID(), '7d19c4b3-485e-4384-9ee4-299143277371', 0, 'String', 'ConnectionType'),
(NEWID(), '57608aa4-8b31-4116-981a-952bf9983e73', 1, 'Guid', 'ID_SQLLog'),
(NEWID(), '57608aa4-8b31-4116-981a-952bf9983e73', 0, 'Guid', 'ID_Employee'),
(NEWID(), '57608aa4-8b31-4116-981a-952bf9983e73', 0, 'String', 'Description'),
(NEWID(), '57608aa4-8b31-4116-981a-952bf9983e73', 0, 'DateTime', 'DateExecution'),
(NEWID(), '4aceeb3e-d8ea-45d0-adc3-e8628a567aa5', 1, 'Guid', 'ID_Table'),
(NEWID(), '4aceeb3e-d8ea-45d0-adc3-e8628a567aa5', 0, 'String', 'TableName'),
(NEWID(), 'c1fbc683-a51e-4ad1-8249-8e318e1f3bca', 1, 'Guid', 'ID_TableStructure'),
(NEWID(), 'c1fbc683-a51e-4ad1-8249-8e318e1f3bca', 0, 'Guid', 'ID_Table'),
(NEWID(), 'c1fbc683-a51e-4ad1-8249-8e318e1f3bca', 0, 'String', 'ColumnName'),
(NEWID(), 'c1fbc683-a51e-4ad1-8249-8e318e1f3bca', 0, 'String', 'ColumnType'),
(NEWID(), 'c1fbc683-a51e-4ad1-8249-8e318e1f3bca', 0, 'bool', 'IsPrimary'),
(NEWID(), '742ef5f8-3fc3-4c23-85a8-d770f9b432fa', 1, 'Guid', 'ID_Employee'),
(NEWID(), '742ef5f8-3fc3-4c23-85a8-d770f9b432fa', 0, 'String', 'UserLogin'),
(NEWID(), '742ef5f8-3fc3-4c23-85a8-d770f9b432fa', 0, 'String', 'UserPassword'),
(NEWID(), 'bec77c93-d95c-4ba6-9fc5-8e1b41e2791a', 1, 'Guid', 'ID_Merchandise'),
(NEWID(), 'bec77c93-d95c-4ba6-9fc5-8e1b41e2791a', 0, 'Guid', 'ID_Product'),
(NEWID(), 'bec77c93-d95c-4ba6-9fc5-8e1b41e2791a', 0, 'Guid', 'ID_RealEstate'),
(NEWID(), 'bec77c93-d95c-4ba6-9fc5-8e1b41e2791a', 0, 'int', 'Weight'),
(NEWID(), 'bec77c93-d95c-4ba6-9fc5-8e1b41e2791a', 0, 'int', 'PricePerGramm'),
(NEWID(), 'bec77c93-d95c-4ba6-9fc5-8e1b41e2791a', 0, 'DateTime', 'ManufactureDate'),
(NEWID(), '0e1b9bfc-e347-463a-b017-eae50483c671', 1, 'Guid', 'ID_CashRegister'),
(NEWID(), '0e1b9bfc-e347-463a-b017-eae50483c671', 0, 'Guid', 'ID_RealEstate'),
(NEWID(), '0343a9c0-8e1d-4efa-9eb0-d83ac84f6c3a', 1, 'Guid', 'ID_Operation'),
(NEWID(), '0343a9c0-8e1d-4efa-9eb0-d83ac84f6c3a', 0, 'String', 'NameOperation'),
(NEWID(), '0343a9c0-8e1d-4efa-9eb0-d83ac84f6c3a', 0, 'String', 'Description'),
(NEWID(), '8488e2f5-97f3-4d74-90c8-0704b8fda279', 1, 'Guid', 'ID_Purchase'),
(NEWID(), '8488e2f5-97f3-4d74-90c8-0704b8fda279', 0, 'Guid', 'ID_Merchandise'),
(NEWID(), '8488e2f5-97f3-4d74-90c8-0704b8fda279', 0, 'Guid', 'ID_CashRegisterAccess'),
(NEWID(), '8488e2f5-97f3-4d74-90c8-0704b8fda279', 0, 'int', 'Weight'),
(NEWID(), '8488e2f5-97f3-4d74-90c8-0704b8fda279', 0, 'DateTime', 'PurchaseDate'),
(NEWID(), '3f34b2c4-facb-4c57-9654-59bc27135e27', 1, 'Guid', 'ID_CashRegisterAccess'),
(NEWID(), '3f34b2c4-facb-4c57-9654-59bc27135e27', 0, 'Guid', 'ID_CashRegister'),
(NEWID(), '3f34b2c4-facb-4c57-9654-59bc27135e27', 0, 'Guid', 'ID_EmployeeSeller'),
(NEWID(), '3f34b2c4-facb-4c57-9654-59bc27135e27', 0, 'Guid', 'ID_Operation'),
(NEWID(), '3f34b2c4-facb-4c57-9654-59bc27135e27', 0, 'DateTime', 'Date'),
(NEWID(), 'a1a16436-c1f7-4ec1-bdcd-4768909d2e5a', 1, 'Guid', 'ID_StoreOrder'),
(NEWID(), 'a1a16436-c1f7-4ec1-bdcd-4768909d2e5a', 0, 'Guid', 'ID_Product'),
(NEWID(), 'a1a16436-c1f7-4ec1-bdcd-4768909d2e5a', 0, 'Guid', 'ID_RealEstateStore'),
(NEWID(), 'a1a16436-c1f7-4ec1-bdcd-4768909d2e5a', 0, 'Guid', 'ID_StoreManager'),
(NEWID(), 'a1a16436-c1f7-4ec1-bdcd-4768909d2e5a', 0, 'Guid', 'ID_StatusOrder'),
(NEWID(), 'a1a16436-c1f7-4ec1-bdcd-4768909d2e5a', 0, 'DateTime', 'InitialDate'),
(NEWID(), 'a1a16436-c1f7-4ec1-bdcd-4768909d2e5a', 0, 'int', 'Weight'),
(NEWID(), 'b8d2c22d-b5e5-412e-83a9-10f30804c60f', 1, 'Guid', 'ID_StoreOrder'),
(NEWID(), 'b8d2c22d-b5e5-412e-83a9-10f30804c60f', 0, 'Guid', 'ID_AcceptManager'),
(NEWID(), 'b8d2c22d-b5e5-412e-83a9-10f30804c60f', 0, 'DateTime', 'AcceptDate'),
(NEWID(), 'b8d2c22d-b5e5-412e-83a9-10f30804c60f', 0, 'int', 'Weight'),
(NEWID(), 'e22534aa-b217-4936-9ac1-83265f8d3e9f', 1, 'Guid', 'ID_StoreOrder'),
(NEWID(), 'e22534aa-b217-4936-9ac1-83265f8d3e9f', 0, 'int', 'WeightOfLack'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 1, 'Guide', 'ID_Product'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'String', 'ProductName'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'String', 'Description'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'String', 'Recipe'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'String', 'Photo'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'int', 'CalorieContent'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'int', 'Proteins'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'int', 'Fats'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'int', 'Carbohydrates'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'int', 'MinTemperature'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'int', 'MaxTemperature'),
(NEWID(), '2f86402c-a36d-4744-bc55-006d135e9cac', 0, 'DateTime', 'ExpirationDate');
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------