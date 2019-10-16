﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom;
using System.Configuration;

namespace EF_Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public enum ConnectionType
    {
        Local,
        Global,
        Host
    }

    public enum DataBaseType
    {
        MainOffice,
        Store,
        Factory
    }


    public partial class DistributedDataBaseContainer : DbContext
    {
        public DistributedDataBaseContainer()
            : base("name=DistributedDataBaseContainer")
        {
        }

        public DistributedDataBaseContainer(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }


        public static DistributedDataBaseContainer GenerateConnection(DataBaseType dataBaseType, ConnectionType connectionType)
        {
            var nameConnectionString = "";
            switch (dataBaseType)
            {
                case DataBaseType.MainOffice:
                {
                    nameConnectionString += $"{Enum.GetName(typeof(DataBaseType), DataBaseType.MainOffice)}";
                    break;
                }
                default:
                {
                    nameConnectionString += $"{Enum.GetName(typeof(ConnectionType), connectionType)}{Enum.GetName(typeof(DataBaseType), dataBaseType)}";
                    break;
                }
            }

            var connectionString = "";
            switch (nameConnectionString)
            {
                case "MainOffice":
                {
                    connectionString =
                        "metadata=res://*/DistributedDataBase.csdl|res://*/DistributedDataBase.ssdl|res://*/DistributedDataBase.msl;provider=System.Data.SqlClient;provider connection string=\"data source=(localdb)\\MSSQLLocalDB;initial catalog=MainOffice;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework\"";
                    break;
                }
                case "LocalStore":
                {
                    connectionString =
                        "metadata=res://*/DistributedDataBase.csdl|res://*/DistributedDataBase.ssdl|res://*/DistributedDataBase.msl;provider=System.Data.SqlClient;provider connection string=\"data source=192.168.1.100,31340;initial catalog=VaravaStore;User ID=sa;password=2584744;integrated security=False;MultipleActiveResultSets=True;App=EntityFramework\"";
                    break;
                }
                case "GlobalStore":
                {
                    connectionString =
                        "metadata=res://*/DistributedDataBase.csdl|res://*/DistributedDataBase.ssdl|res://*/DistributedDataBase.msl;provider=System.Data.SqlClient;provider connection string=\"data source=93.74.213.211,31340;initial catalog=VaravaStore;User ID=sa;password=2584744;integrated security=False;MultipleActiveResultSets=True;App=EntityFramework\"";
                    break;
                }
                case "HostStore":
                {
                    connectionString =
                        "metadata=res://*/DistributedDataBase.csdl|res://*/DistributedDataBase.ssdl|res://*/DistributedDataBase.msl;provider=System.Data.SqlClient;provider connection string=\"data source=127.0.0.1,31340;initial catalog=VaravaStore;User ID=sa;password=2584744;integrated security=False;MultipleActiveResultSets=True;App=EntityFramework\"";
                    break;
                }
            }

            return new DistributedDataBaseContainer(connectionString);
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<RealEstateType> RealEstateTypes { get; set; }
    public virtual DbSet<RealEstate> RealEstates { get; set; }
    public virtual DbSet<RealEstateContact> RealEstateContacts { get; set; }
    public virtual DbSet<Departament> Departaments { get; set; }
    public virtual DbSet<RawMaterialProviderContract> RawMaterialProviderContracts { get; set; }
    public virtual DbSet<StockRawMaterial> StockRawMaterials { get; set; }
    public virtual DbSet<RawMaterial> RawMaterials { get; set; }
    public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
    public virtual DbSet<Component> Components { get; set; }
    public virtual DbSet<Merchandise> Merchandises { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeWorkLog> EmployeeWorkLogs { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
    public virtual DbSet<CashRegister> CashRegisters { get; set; }
    public virtual DbSet<CashRegisterOperation> CashRegisterOperations { get; set; }
    public virtual DbSet<HeadOrder> HeadOrders { get; set; }
    public virtual DbSet<Purchase> Purchases { get; set; }
    public virtual DbSet<CashRegisterAccess> CashRegisterAccesses { get; set; }
    public virtual DbSet<StoreOrder> StoreOrders { get; set; }
    public virtual DbSet<MerchandiseAcceptanceLog> MerchandiseAcceptanceLogs { get; set; }
    public virtual DbSet<LackLog> LackLogs { get; set; }
    public virtual DbSet<StatusOrder> StatusOrders { get; set; }
    public virtual DbSet<PerformedHeadOrder> PerformedHeadOrders { get; set; }
    public virtual DbSet<PerformedStoreOrder> PerformedStoreOrders { get; set; }
}
}
