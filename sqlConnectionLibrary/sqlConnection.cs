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
        private DataTable dt;
        private SqlDataAdapter da;

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
        
         private SqlConnection OpenConnection()
        {
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something goes wrong: " + ex);
                }
            }

            return con;
        }

        private void CloseConnection()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }

        public DataTable ShowDataByQuery(string query)
        {
            dt = new DataTable();

            try
            {
                OpenConnection();
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something goes wrong: " + ex);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }
    }
}
