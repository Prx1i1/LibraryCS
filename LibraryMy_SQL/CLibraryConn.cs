using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CringLibrary
{
    public class CLibraryConn
    {
        public static string server;
        public static string db;
        public static string user;
        public static string table;

        public static MySqlConnection connect()
        {
            string myConnection =
                "Server=" + server + ";" +
                "Database=" + db + ";" +
                "User=" + user + ";" +
                "Password= ;";
            MySqlConnection connection = new MySqlConnection(myConnection);
            try
            {
                return connection;
            }
            catch
            { return null; }

        }


    }
}