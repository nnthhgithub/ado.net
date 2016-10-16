using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConnectionObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=AutoLot;Integrated Security=True";
                connection.Open();
                ShowConnectionStatus(connection);
                connection.Close();
                ShowConnectionStatus(connection);
            }
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
