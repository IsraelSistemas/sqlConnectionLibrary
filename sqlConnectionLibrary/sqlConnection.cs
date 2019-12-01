using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace sqlConnectionLibrary
{
    public class sqlConnection
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dataSource"].Replace("\\\\", "\\"));

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
