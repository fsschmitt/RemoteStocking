using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace StockBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stock Broker Initializing");
            ServiceHost host = new ServiceHost(typeof(StockBroker.StockBrokerOps));
            host.Open();
            Console.WriteLine("Press <Enter> to terminate.");
            Console.ReadLine();
            host.Close();
        }
    }
}
