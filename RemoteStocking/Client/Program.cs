﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Initializing");
            ServerOps.ServerOpsClient proxy = new ServerOps.ServerOpsClient();
            Console.WriteLine(proxy.DoWork(2));
            Console.WriteLine(proxy.GetEmail(1));
            Console.WriteLine(proxy.AddStock(new Stock(123,"novoemail@gmail.com",Stock.transactionType.Sell,2,"Apple", DateTime.Now, 2.34, 6,false)));
            Console.WriteLine("Press <Enter> to terminate.");
            Console.ReadLine();
        }
    }
}
