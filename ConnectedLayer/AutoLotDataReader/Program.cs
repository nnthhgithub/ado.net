using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=AutoLot;Integrated Security=True";
                connection.Open();

                string sql = "Select * from Inventory";
                SqlCommand command = new SqlCommand(sql,connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WriteLine($"-> Make: {reader["Make"]}, PetName: {reader["PetName"]}, Color: { reader["Color"]}.");
                    }
                }
            }
            ReadLine();
        }
    }
}
