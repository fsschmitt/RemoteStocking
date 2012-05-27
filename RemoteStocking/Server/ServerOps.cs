using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServerOps" in both code and config file together.
    [DataContract]
    public class ServerOps : IServerOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["ServerDB"].ToString();
        private StockBroker.StockBrokerOpsClient stockBroker = new StockBroker.StockBrokerOpsClient();

        private static string getSQLFormatDateNow()
        {
            return String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
        }

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
            return new Stock(IDTransaction,IDClient, Email, type, quantity, shareType, sqlDate, price, exec, currency);
        }

        private static string UserAgent = @"Mozilla/5.0 (Windows; Windows NT 6.1) AppleWebKit/534.23 (KHTML, like Gecko) Chrome/11.0.686.3 Safari/534.23";
        private static CookieContainer cJar;
        private static string httpRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cJar;
            request.UserAgent = UserAgent;
            request.KeepAlive = false;
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }

        private static double convertCurrencyToUSD(String from, Double money)
        {

            JavaScriptSerializer ser = new JavaScriptSerializer();
            Currency foo = ser.Deserialize<Currency>(httpRequest("https://raw.github.com/currencybot/open-exchange-rates/master/latest.json"));
            if (Server.Program.Debug) Console.WriteLine(from + ": " + money);
            if (Server.Program.Debug) Console.WriteLine("USD: " + money/foo.getRate(from));
            return money/foo.getRate(from);

        }

        private static double convertCurrencyFromUSD(String to, Double money)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Currency foo = ser.Deserialize<Currency>(httpRequest("https://raw.github.com/currencybot/open-exchange-rates/master/latest.json"));
            if (Server.Program.Debug) Console.WriteLine("USD: " + money);
            if (Server.Program.Debug) Console.WriteLine(to + ": " + money * foo.getRate(to));
            return money*foo.getRate(to);
        }

        // Get client email given an transaction id
        public string GetEmailTransaction(string id)
        {
            string res = "No results.";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT Email FROM StockTransaction WHERE IDTransaction='" + id + "';";
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
                string date = getSQLFormatDateNow();
                /* Create the insert query */
                string sqlcmd = "insert into StockTransaction (IDTransaction,IDClient,Email,Quantity,ShareType,ActionType,TransactionTime,Rate,Executed,Currency)";
                sqlcmd += "values (" + "'" + stock.id + "'" + "," + "'" + stock.client + "'" + "," + "'" + stock.email + "'" + "," + stock.quantity + ",";
                sqlcmd += "'" + stock.sType + "'" + "," + ((int)stock.type) + "," + "'" + date + "'" + "," + stock.price + ",";
                if (stock.executed)
                    sqlcmd += 1 + ",'" + stock.currency + "');";
                else
                    sqlcmd += 0 + ",'" + stock.currency + "');";

                if (Server.Program.Debug) Console.WriteLine("Query: " + sqlcmd);

                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();

                if (rows == 1)
                {
                    result = "200: The Stock has been added successfully!";
                    stock.price = convertCurrencyToUSD(stock.currency, stock.price);
                    stock.currency = "USD";
                    stockBroker.ReportNewStock(stock);
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

            if (Server.Program.Debug) Console.WriteLine(result);

            return result;
        }

        private Stock GetStock(string id)
        {
            Stock stock = null;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM StockTransaction WHERE IDTransaction='" + id + "';";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stock = getStockFromReader(reader);
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
            return stock;
        }

        //  Check stock status
        public bool IsExecuted(string id)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT Executed FROM StockTransaction WHERE IDTransaction='" +id+"';";
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
        public string ChangeStockRate(string id, double rate)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows = 0;
            string result = "";
            try
            {
                
                Stock s = GetStock(id);
                if (s != null)
                {
                    //Convert back to original currency
                    rate = convertCurrencyFromUSD(s.currency, rate);
                    conn.Open();
                    string date = getSQLFormatDateNow();
                    string sqlcmd = "UPDATE StockTransaction SET Rate=" + rate + ", TransactionTime=" + "'" + date + "'" + "," + "Executed=1" + "WHERE IDTransaction = '" + id + "';";
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {

                        SendEmail(id);
                        return "200: Stock has been updated successfully!";
                    }
                }
                else
                    result = "500: User not found!";
            }
            catch (Exception e)
            {
                result = "500:"+e.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
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

        // Get all shares type
        public List<String> GetAllSharesType()
        {
            return new List<String> {
            "Apple",
            "IBM",
            "Microsoft",
            "Toshiba",
            "LG",
            "Google"};
        }

        // Get all the currencies
        public List<String> GetAllCurrency()
        {
            return new List<String> {
            "AED",
            "AFN",
            "ALL",
            "AMD",
            "ANG",
            "AOA",
            "ARS",
            "AUD",
            "AWG",
            "AZN",
            "BAM",
            "BBD",
            "BDT",
            "BGN",
            "BHD",
            "BIF",
            "BMD",
            "BND",
            "BOB",
            "BRL",
            "BSD",
            "BTN",
            "BWP",
            "BYR",
		    "BZD",
		    "CAD",
		    "CDF",
		    "CHF",
		    "CLF",
		    "CLP",
		    "CNH",
		    "CNY",
		    "COP",
		    "CRC",
		    "CUP",
		    "CVE",
		    "CZK",
		    "DJF",
		    "DKK",
		    "DOP",
		    "DZD",
		    "EGP",
		    "ETB",
		    "EUR",
		    "FJD",
		    "FKP",
		    "GBP",
		    "GEL",
		    "GHS",
		    "GIP",
		    "GMD",
		    "GNF",
		    "GTQ",
		    "GYD",
		    "HKD",
		    "HNL",
		    "HRK",
		    "HTG",
		    "HUF",
		    "IDR",
		    "IEP",
		    "ILS",
		    "INR",
		    "IQD",
		    "IRR",
		    "ISK",
		    "JMD",
		    "JOD",
		    "JPY",
		    "KES",
		    "KGS",
		    "KHR",
		    "KMF",
		    "KPW",
		    "KRW",
		    "KWD",
		    "KZT",
		    "LAK",
		    "LBP",
		    "LKR",
		    "LRD",
		    "LSL",
		    "LTL",
		    "LVL",
		    "LYD",
		    "MAD",
		    "MDL",
		    "MGA",
		    "MKD",
		    "MMK",
		    "MNT",
		    "MOP",
		    "MRO",
		    "MUR",
		    "MVR",
		    "MWK",
		    "MXN",
		    "MYR",
		    "MZN",
		    "NAD",
		    "NGN",
		    "NIO",
		    "NOK",
		    "NPR",
		    "NZD",
		    "OMR",
		    "PAB",
		    "PEN",
		    "PGK",
		    "PHP",
		    "PKR",
		    "PLN",
		    "PYG",
		    "QAR",
		    "RON",
		    "RSD",
		    "RUB",
		    "RWF",
		    "SAR",
		    "SBD",
		    "SCR",
		    "SDG",
		    "SEK",
		    "SGD",
		    "SHP",
		    "SLL",
		    "SOS",
		    "SRD",
		    "STD",
		    "SVC",
		    "SYP",
		    "SZL",
		    "THB",
		    "TJS",
		    "TMT",
		    "TND",
		    "TOP",
		    "TRY",
		    "TTD",
		    "TWD",
		    "TZS",
		    "UAH",
		    "UGX",
		    "USD",
		    "UYU",
		    "UZS",
		    "VEF",
		    "VND",
		    "VUV",
		    "WST",
		    "XAF",
		    "XCD",
		    "XDR",
		    "XOF",
		    "XPF",
		    "YER",
		    "ZAR",
		    "ZMK",
		    "ZWL"};
        }

        // Send e-mail
        public void SendEmail(string id)
        {
            Stock stock = GetStock(id);
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();

            m.From = new MailAddress("remote.stocks@gmail.com", "Remote Stocks");
            m.To.Add(new MailAddress(stock.email, ""));
            m.Subject = "The "+ stock.sType + " stock has been executed!" ;
            m.Body = "\n\nThe "+ stock.sType + " stock has been executed, stock full description are the following:";
            m.Body += "\n\n\nType: "+stock.sType; 
            m.Body += "\nAction: "+stock.type;
            m.Body += "\nQuantity: "+stock.quantity;
            m.Body += "\nPrice: "+stock.price + " " + stock.currency;
            m.Body += "\nTotal cost: " + String.Format("{0:0.00}", (stock.price * stock.quantity)) + " " + stock.currency;
            m.Body += "\n\nBest regards,\nRemote Stocks Team";

            sc.Host = "smtp.gmail.com";
            sc.Port = 587;
            sc.Credentials = new
            System.Net.NetworkCredential("remote.stocks@gmail.com","remotestockstdin");
            sc.EnableSsl = true;
            sc.Send(m);
        }
    }
}
