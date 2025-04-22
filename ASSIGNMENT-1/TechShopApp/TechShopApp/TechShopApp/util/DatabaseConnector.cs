using System;
using Microsoft.Data.SqlClient;

namespace TechShopApp.util
{
    public static class DatabaseConnector
    {
        private static SqlConnection connection;

        // ✅ Clear and readable connection string using Windows Authentication
        private static readonly string connectionString =
            "Server=POORNIMA\\SQLSERVER2022;Database=TechShop;Trusted_Connection=True;";

        // ✅ Open connection method
        public static SqlConnection OpenConnection()
        {
            if (connection == null || connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }

            return connection;
        }

        // ✅ Close connection method
        public static void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
    }
}
