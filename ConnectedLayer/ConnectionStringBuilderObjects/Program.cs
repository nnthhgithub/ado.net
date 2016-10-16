using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ConnectionStringBuilderObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var cnStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "AutoLot",
                DataSource = @"(local)\sqlexpress",
                ConnectTimeout = 30,
                IntegratedSecurity = true
            };

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnStringBuilder.ConnectionString;
                connection.Open();
                ShowConnectionStatus(connection);
            }
            ReadLine();
        }
        public static void ShowConnectionStatus(SqlConnection connection)
        {
            WriteLine("Info about your connection");
            WriteLine($"Database location {connection.DataSource}");
            WriteLine($"Database name {connection.Database}");
            WriteLine($"Time out {connection.ConnectionTimeout}");
            WriteLine($"Connection state {connection.State}");
        }
    }
}
