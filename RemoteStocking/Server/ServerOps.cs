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
    [DataContract]
    public class ServerOps : IServerOps
    {

        public static string connString = ConfigurationManager.ConnectionStrings["ServerDB"].ToString();
        
        public int DoWork(int num)
        {
            return num * 2;
        }

        public string AddStock(Stock stock)
        {
            SqlConnection conn = new SqlConnection(connString);
            string result = "";
            int rows = 0;
            try
            {
                conn.Open();
                int transactionID = stock.GetHashCode();
                
                /* Create the insert query */
                string date = String.Format("{0:yyyy-MM-dd hh:mm:ss.fff}", DateTime.Now);
                string sqlcmd = "insert into StockTransaction (IDTransaction,IDClient,Email,Quantity,ShareType,ActionType,TransactionTime,Rate,Executed)";
                sqlcmd += "values (" + transactionID + "," + "'" + stock.client + "'" + "," + "'" + stock.email + "'" + "," + stock.quantity + ",";
                sqlcmd += "'" + stock.sType + "'" + "," + ((int)stock.type) + "," + "'" + date + "'" + "," + stock.price + ",";
                if(stock.executed)
                    sqlcmd += 1 + ");";
                else
                    sqlcmd += 0 + ");";

                //if (Server.Program.Debug) Console.WriteLine("Query: " + sqlcmd);

                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = "DB response: "+e.Message;
            }
            finally
            {
                conn.Close();
            }

            if (rows == 1)
                result = "DB response: The Stock has been added successfully!";

            if (Server.Program.Debug) Console.WriteLine(result);

            return result;
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
