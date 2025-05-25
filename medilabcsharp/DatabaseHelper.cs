using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilabcsharp
{
    internal class DatabaseHelper
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["MedicalCenterDB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
            catch (Exception ex)
            {
                // Log error if needed
                throw new ApplicationException("Failed to establish database connection", ex);
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Log error if needed
                throw new ApplicationException("Failed to close database connection", ex);
            }
        }
    }
}
