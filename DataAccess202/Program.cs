using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess202
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = 
                    ConfigurationManager.ConnectionStrings["c"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Select ProductName from products";
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine(reader["ProductName"]);
                        }
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
