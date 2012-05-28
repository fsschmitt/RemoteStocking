using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace StockBroker
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StockBrokerOps" in both code and config file together.
    public class StockBrokerOps : IStockBrokerOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["StockBrokerDB"].ToString();

        //Gets the DateTime.Now parsed for the SQLServer
        private static string getSQLFormatDateNow()
        {
            return String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
        }

        //Casts an SqlDataReader to a Stock object
        private static Stock getStockFromReader(SqlDataReader reader)
        {
            string IDTransaction = Convert.ToString(reader["IDTransaction"]);
            int IDClient = Convert.ToInt32(reader["IDClient"]);
            string Email = Convert.ToString(reader["Email"]);
            Stock.transactionType type = Convert.ToBoolean(reader["ActionType"]) ? type = Stock.transactionType.Sell : type = Stock.transactionType.Buy;
            int quantity = Convert.ToInt32(reader["Quantity"]);
            string shareType = Convert.ToString(reader["ShareType"]);
            DateTime sqlDate = Convert.ToDateTime(reader["TransactionTime"]);
            double price = Convert.ToDouble(reader["Rate"]);
            bool exec = Convert.ToBoolean(reader["Executed"]);
            string currency = Convert.ToString(reader["Currency"]);
            return new Stock(IDTransaction, IDClient, Email, type, quantity, shareType, sqlDate, price, exec,currency);
        }

        //Report to the StockBroker the arrival of a new stock
        public void ReportNewStock(Stock stock)
        {
            SqlConnection conn = new SqlConnection(connString);
            string result = "";
            int rows = 0;
            try
            {
                conn.Open();
                string date = getSQLFormatDateNow();
                /* Create the insert query */
                string sqlcmd = "insert into StockTransaction (IDTransaction,IDClient,Email,Quantity,ShareType,ActionType,TransactionTime,Rate,Executed,Currency)";
                sqlcmd += "values (" + "'" + stock.id + "'" + "," + "'" + stock.client + "'" + "," + "'" + stock.email + "'" + "," + stock.quantity + ",";
                sqlcmd += "'" + stock.sType + "'" + "," + ((int)stock.type) + "," + "'" + date + "'" + "," + stock.price.ToString(CultureInfo.InvariantCulture) + ",";
                if (stock.executed)
                    sqlcmd += 1 + ",'" + stock.currency + "');";
                else
                    sqlcmd += 0 + ",'" + stock.currency + "');";
                Console.WriteLine(sqlcmd);
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();

                if (rows == 1)
                {
                    try
                    {
                        StockBroker.Program.mf.addNewStock(stock);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("GUI isn't open.");
                    }
                    result = "200: The Stock has been added successfully!";
                }
            }
            catch (Exception e)
            {
                result = "500: " + e.Message;
            }
            finally
            {
                conn.Close();
            }

            if (StockBroker.Program.Debug) Console.WriteLine(result);
        }

        //Removes a stock from the DB
        private static void RemoveStockDB(string id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string result = "";
            int rows = 0;
            try
            {
                conn.Open();
                string date = getSQLFormatDateNow();
                /* Create the insert query */
                string sqlcmd = "delete from StockTransaction where IDTransaction="+"'"+id+"';";

                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();

                if (rows == 1)
                {
                    result = "200: The Stock has been removed successfully!";
                }
            }
            catch (Exception e)
            {
                result = "500: " + e.Message;
            }
            finally
            {
                conn.Close();
            }

            if (StockBroker.Program.Debug) Console.WriteLine(result);
        }

        // Get all orders still waiting to execute
        public static List<Stock> GetAllWaitingStock()
        {
            SqlConnection conn = new SqlConnection(connString);
            List<Stock> stocks = new List<Stock>();
            try
            {
                conn.Open();
                string date = getSQLFormatDateNow();
                string sqlcmd = "SELECT * FROM StockTransaction WHERE Executed=0;";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stocks.Add(getStockFromReader(reader));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return stocks;
        }

        // Determines the rate for a stock with the given id
        public static void ExecuteStockRate(string id, double rate)
        {
            ServerOps.ServerOpsClient serverOps = new ServerOps.ServerOpsClient();
            serverOps.ChangeStockRate(id, rate);
            RemoveStockDB(id);
        }
    }
}
