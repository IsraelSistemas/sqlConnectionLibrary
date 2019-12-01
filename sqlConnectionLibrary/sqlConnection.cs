using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sqlConnectionLibrary
{
    public class sqlConnection
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SU6PUUVF\\SQLEXPRESS;Initial Catalog=demo;Integrated Security=True");

        public bool TestConnection()
        {
            bool success = false;

            try
            {
                con.Open();
                success = true;
                Console.WriteLine("Connection OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: \n" + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return success;
        }
    }
}
