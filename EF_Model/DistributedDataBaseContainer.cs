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


        public static DistributedDataBaseContainer GenerateConnection(DataBaseType dataBaseType, ConnectionType connectionType)
        {
            var dataSource = "(localdb)\\MSSQLLocalDB";
            var initialCatalog = $"VaravaMainOffice";
            var userId = "sa";
            var userPassword = "2584744";

            var connectionString = $"metadata = res://*/DistributedDataBase.csdl|res://*/DistributedDataBase.ssdl|res://*/DistributedDataBase.msl;provider=System.Data.SqlClient;provider connection string=\"data source={dataSource};initial catalog={initialCatalog};User ID={userId};Password={userPassword};integrated security=False;MultipleActiveResultSets=True;App=EntityFramework\"";

            var localDb = new DistributedDataBaseContainer(connectionString);

            if (dataBaseType == DataBaseType.MainOffice)
            {
                return localDb;
            }

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
