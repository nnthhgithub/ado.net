﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static System.Console;
using System.Data.SqlClient;

namespace DataProviderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            Console.WriteLine(sqlFactory);

            //---

            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            string connectionString2 = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString; //Also able to use ConnectionStrings as well as AppSettings
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("Command");
                    return;
                }


                WriteLine($"Your connection object is a: {connection.GetType().Name}");

                connection.ConnectionString = connectionString;
                connection.Open();
                var sqlConnection = connection as SqlConnection;
                if (sqlConnection != null)
                {
                    WriteLine(sqlConnection.ServerVersion);
                }
                connection.Close();

                connection.ConnectionString = connectionString2;
                connection.Open();
                var sqlConnection2 = connection as SqlConnection;
                if (sqlConnection2 != null)
                {
                    WriteLine(sqlConnection.ServerVersion);
                }

                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }

                WriteLine($"Your command object is a {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * from Inventory";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine($"Your data reader is a {dataReader.GetType().Name}");

                    while (dataReader.Read())
                    {
                        WriteLine($"Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
                    }
                }
                ReadLine();
            }
        }
        public static void ShowError(string objectName)
        {
            WriteLine($"There were an issue creating {objectName}");
            ReadLine();
        }
    }
}
