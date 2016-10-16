using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AutoLotDAL.Models;

namespace AutoLotDAL.ConnectedLayer
{
    public class InventoryDAL
    {
        private SqlConnection _sqlConnection = null;
        public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection() { ConnectionString = connectionString};
            _sqlConnection.Open();
        }
        public void CloseConnection()
        {
            _sqlConnection.Close();
        }
        public void InsertAuto(int id, string color, string make, string petName)
        {
            string sql = "Insert Into Inventory" +
                $"(Make, Color, PetName) Values('{make}','{color}','{petName}')";
            using(SqlCommand command = new SqlCommand(sql,_sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }
        public void InsertAuto(NewCar car)
        {
            string sql = "Insert Into Inventory" +
                   $"(Make, Color, PetName) Values('{car.Make}','{car.Color}','{car.PetName}')";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }
        public void DeleteCar(int id)
        {
            string sql = $"Delete from Inventory where CarID = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                }
                catch
                {

                }
            }
        }
    }
}
