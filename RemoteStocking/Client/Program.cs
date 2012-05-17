using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        static void Main(string[] args)
        {
            Console.WriteLine("Client Initializing");
            ServerOps.ServerOpsClient proxy = new ServerOps.ServerOpsClient();
            //Console.WriteLine(proxy.GetEmailTransaction(1));
            //Console.WriteLine(proxy.AddStock(new Stock(123,"novoemail@gmail.com",Stock.transactionType.Sell,2,"IBM", DateTime.Now, 2.34,true)));
            //Console.WriteLine("StockID: "+ 1 +" executed? "+proxy.IsExecuted(1));
            //Console.WriteLine("StockID: " + 2174563 + " executed? " + proxy.IsExecuted(2174563));
            //Console.WriteLine(proxy.ChangeStockRate(2,2.3));
            //testStocksWaiting(proxy);

            Console.WriteLine("Press <Enter> to terminate.");
            Console.ReadLine();
        }
    }
}
