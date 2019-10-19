SET QUOTED_IDENTIFIER OFF;
GO
USE [VaravaFactory];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [IDK] nvarchar(max)  NOT NULL
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------