﻿using System;
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

        private static string getSQLFormatDateNow()
        {
            return String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
        }

        private static Stock getStockFromReader(SqlDataReader reader)
        {
            int IDClient = Convert.ToInt32(reader["IDClient"]);
            string Email = Convert.ToString(reader["Email"]);
            Stock.transactionType type = Convert.ToBoolean(reader["ActionType"]) ? type = Stock.transactionType.Sell : type = Stock.transactionType.Buy;
            int quantity = Convert.ToInt32(reader["Quantity"]);
            string shareType = Convert.ToString(reader["ShareType"]);
            DateTime sqlDate = Convert.ToDateTime(reader["TransactionTime"]);
            double price = Convert.ToDouble(reader["Rate"]);
            bool exec = Convert.ToBoolean(reader["Executed"]);
            return new Stock(IDClient, Email, type, quantity, shareType, sqlDate, price, exec);
        }

        public static string connString = ConfigurationManager.ConnectionStrings["ServerDB"].ToString();

        // Get client email given an transaction id
        public string GetEmailTransaction(int id)
        {
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

        // Add a stock to the database
        public string AddStock(Stock stock)
        {
            SqlConnection conn = new SqlConnection(connString);
            string result = "";
            int rows = 0;
            try
            {
                conn.Open();
                int transactionID = stock.GetHashCode();
                string date = getSQLFormatDateNow();
                /* Create the insert query */
                string sqlcmd = "insert into StockTransaction (IDTransaction,IDClient,Email,Quantity,ShareType,ActionType,TransactionTime,Rate,Executed)";
                sqlcmd += "values (" + transactionID + "," + "'" + stock.client + "'" + "," + "'" + stock.email + "'" + "," + stock.quantity + ",";
                sqlcmd += "'" + stock.sType + "'" + "," + ((int)stock.type) + "," + "'" + date + "'" + "," + stock.price + ",";
                if (stock.executed)
                    sqlcmd += 1 + ");";
                else
                    sqlcmd += 0 + ");";

                //if (Server.Program.Debug) Console.WriteLine("Query: " + sqlcmd);

                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = "500: " + e.Message;
            }
            finally
            {
                conn.Close();
            }

            if (rows == 1)
                result = "200: The Stock has been added successfully!";

            if (Server.Program.Debug) Console.WriteLine(result);

            return result;
        }

        //  Check stock status
        public bool IsExecuted(int id)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT Executed FROM StockTransaction WHERE IDTransaction=" + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                res = Convert.ToBoolean(cmd.ExecuteScalar());
                if (Server.Program.Debug) Console.WriteLine("StockID: "+id+" executed? "+res);
            }
            catch (Exception e)
            {
                if (Server.Program.Debug) Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        // Change the state of a stock for a given share and time
        public string ChangeStockRate(int id, double rate)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows = 0;
            string result = "";
            try
            {
                conn.Open();
                string date = getSQLFormatDateNow();
                string sqlcmd = "UPDATE StockTransaction SET Rate=" + rate + ", TransactionTime=" + "'" + date + "'" + "WHERE IDTransaction = " + id + ";";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                conn.Close();
            }

            if (rows == 1)
                return "200: Stock has been updated successfully!";
            else
                return "500: " + result;
        }

        // Get all orders still waiting to execute
        public List<Stock> GetAllWaitingStock()
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

        // Get all stocks to a given client id
        public List<Stock> GetAllStocksByClient(int IDClient)
        {
            SqlConnection conn = new SqlConnection(connString);
            List<Stock> stocks = new List<Stock>();
            try
            {
                conn.Open();
                string date = getSQLFormatDateNow();
                string sqlcmd = "SELECT * FROM StockTransaction WHERE IDClient=" + IDClient + ";";
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
    }
}