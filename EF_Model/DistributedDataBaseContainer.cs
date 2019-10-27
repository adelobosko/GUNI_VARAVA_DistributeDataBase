using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Model
{
    public partial class DistributedDataBaseContainer
    {
        public DistributedDataBaseContainer(string connectingString)
            : base(connectingString)
        {
        }


        public enum ConnectionType
        {
            Host,
            Local,
            Global
        }


        public enum DataBaseType
        {
            Store,
            Factory,
            MainOffice
        }

        public static class DomesticDataBase
        {
            public static string DataSource { get; set; } = @"(localdb)\MSSQLLocalDB";
            public static string InitialCatalog { get; set; } = @"VaravaStore";
            public static string UserId { get; set; } = @"sa";
            public static string UserPassword { get; set; } = @"2584744";
        }


        public static DistributedDataBaseContainer GenerateConnection(DataBaseType dataBaseType, ConnectionType connectionType)
        {
            var dataSource = DomesticDataBase.DataSource;
            var initialCatalog = DomesticDataBase.InitialCatalog;
            var userId = DomesticDataBase.UserId;
            var userPassword = DomesticDataBase.UserPassword;

            var connectionString = $"metadata = res://*/DistributedDataBase.csdl|res://*/DistributedDataBase.ssdl|res://*/DistributedDataBase.msl;provider=System.Data.SqlClient;provider connection string=\"data source={dataSource};initial catalog={initialCatalog};User ID={userId};Password={userPassword};integrated security=False;MultipleActiveResultSets=True;App=EntityFramework\"";

            var localDb = new DistributedDataBaseContainer(connectionString);

            var hostType = Enum.GetName(typeof(ConnectionType), connectionType);
            initialCatalog = $"Varava{Enum.GetName(typeof(DataBaseType), dataBaseType)}";

            var res = localDb.ConnectingStrings
                .FirstOrDefault(cs =>
                    cs.ConnectionType == hostType &&
                    cs.InitialCatalog == initialCatalog
                    );

            dataSource = res.DataSource;
            initialCatalog = res.InitialCatalog;
            userId = res.UserId;
            userPassword = res.UserPassword;

            connectionString = $"metadata = res://*/DistributedDataBase.csdl|res://*/DistributedDataBase.ssdl|res://*/DistributedDataBase.msl;provider=System.Data.SqlClient;provider connection string=\"data source={dataSource};initial catalog={initialCatalog};User ID={userId};Password={userPassword};integrated security=False;MultipleActiveResultSets=True;App=EntityFramework\"";


            return new DistributedDataBaseContainer(connectionString);
        }

        //var dataBase = GenerateConnection(DataBaseType.Store, ConnectionType.Host);
    }
}
