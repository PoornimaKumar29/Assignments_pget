using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TicketBookingSystem.util
{
    public class DatabaseConnection
    {
        private static string connectionString = "Server=POORNIMA\\SQLSERVER2022;Database=TicketBookingSystem;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
