using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServerOps" in both code and config file together.
    public class ServerOps : IServerOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["ServerDB"].ToString();
        public int DoWork(int num)
        {
            return num * 2;
        }

        public string GetEmail(int id){
            string res = "No results.";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT Email FROM StockTransaction WHERE IDTransaction=" + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                res = Convert.ToString(cmd.ExecuteScalar());
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        /*public void saveToDB(object obj)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "insert into Transaction values ";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
            }
            finally
            {
                conn.Close();
            }
        }*/
    }
}
