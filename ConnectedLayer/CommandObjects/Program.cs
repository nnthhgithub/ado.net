using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace CommandObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=AutoLot;Integrated Security=True";
                string sql = "Select * from Inventory";
                connection.Open();
                SqlCommand myCommand = new SqlCommand(sql, connection);
                SqlCommand testCommand = new SqlCommand();
                testCommand.Connection = connection;
                testCommand.CommandText = sql;

                using (SqlDataReader reader1 = myCommand.ExecuteReader())
                { 
                    while (reader1.Read())
                    {
                        WriteLine(reader1["Make"]);
                    }
                }
                WriteLine("---");
                using (SqlDataReader reader2 = testCommand.ExecuteReader())
                {  
                    while (reader2.Read())
                    {
                        WriteLine(reader2["Make"]);
                    }
                }
                WriteLine("---");
                using (SqlDataReader reader3 = myCommand.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        for (int i = 0; i < reader3.FieldCount; i++)
                        {
                            WriteLine($"{reader3.GetName(i)} -> {reader3.GetValue(i)} ");
                        }
                    }
                }

                string sql2 = "Select * from Inventory; Select * from Customers";
                SqlCommand command3 = new SqlCommand(sql2, connection);
                using (SqlDataReader reader4 = command3.ExecuteReader())
                {
                    do
                    {
                        while (reader4.Read())
                        {
                            for (int i = 0; i < reader4.FieldCount; i++)
                            {
                                WriteLine($"{reader4.GetName(i)} -> {reader4.GetValue(i)} ");
                            }
                        }
                    } while (reader4.NextResult());
                }
            }
        }
    }
}
