using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    class Program
    {
        static void testStocksWaiting(ServerOps.ServerOpsClient proxy)
        {
            Stock[] stocks = proxy.GetAllWaitingStock();
            Console.WriteLine("Stocks waiting to execute:");
            foreach (Stock s in stocks)
            {
                Console.WriteLine(s);
            }
        }
        static void testHistoryClient(ServerOps.ServerOpsClient proxy, int IDClient)
        {
            Stock[] stocks = proxy.GetAllStocksByClient(IDClient);
            Console.WriteLine("Stocks from user: " + IDClient);
            foreach (Stock s in stocks)
            {
                Console.WriteLine(s);
            }
        }
        
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Client Initializing");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //ServerOps.ServerOpsClient proxy = new ServerOps.ServerOpsClient();
            //Console.WriteLine(proxy.GetEmailTransaction(1));
            //Console.WriteLine(proxy.AddStock(new Stock(123,"novoemail@gmail.com",Stock.transactionType.Buy,2,"Microsoft", DateTime.Now, 21.34,false)));
            //Console.WriteLine("StockID: "+ 1 +" executed? "+proxy.IsExecuted(1));
            //Console.WriteLine("StockID: " + 2174563 + " executed? " + proxy.IsExecuted(2174563));
            //Console.WriteLine(proxy.ChangeStockRate(2,2.3));
            //testStocksWaiting(proxy);
            //testHistoryClient(proxy, 123);
            Console.WriteLine("Press <Enter> to terminate.");
            Console.ReadLine();
        }
    }
}
