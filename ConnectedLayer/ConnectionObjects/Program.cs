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
        }
        public static void ShowConnectionStatus(SqlConnection connection)
        {
            WriteLine("Info about your connection");
            WriteLine($"Database");
        }
    }
}
