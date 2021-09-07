using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace kursOOP
{
    static class DBUtils
    {
        static string server = "localhost";
        static int port = 3306;
        static string database = "kursoop";
        static string username = "root";
        static string password = "";
        public static MySqlConnection GetDBConnection()
        {
            String connString = $"server={server};database={database};port={port};user={username};password={password};SslMode=none;";
            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
