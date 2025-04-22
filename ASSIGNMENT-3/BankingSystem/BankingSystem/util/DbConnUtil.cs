

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace BankingSystem.util
{
    public class DBUtil
    {
        public static SqlConnection GetConnection()
        {
            string connStr = "Server=POORNIMA\\SQLSERVER2022;Database=HMBANK;Trusted_Connection=True;";
            return new SqlConnection(connStr);
        }
    }
}