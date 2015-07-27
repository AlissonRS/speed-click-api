using Alisson.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedClick.Logic.Database
{
    public class ConnectionConfigSI : ConnectionConfig
    {

        protected static string databaseName = "speedclick";
        protected static string password = "a2xl67*bxY";
        protected static string serverName = "localhost";
        protected static string userID = "Alisson";

        public static void configure()
        {
            config(new MySqlConn(), databaseName, password, serverName, userID).Start();
        }
    }
}
