using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data
{
    internal class Database
    {
        private string connectionString =
        @"Server=JAMES-PC\SQLDEVELOPER;
          Database=StudentManagementSystem;
          Trusted_Connection=True;
          TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
