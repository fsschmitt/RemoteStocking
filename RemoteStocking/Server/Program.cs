using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        public static bool Debug = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Server Initializing");
            ServiceHost host = new ServiceHost(typeof(Server.ServerOps));
            host.Open();
            Console.WriteLine("Press <Enter> to terminate.");
            Console.ReadLine();
            host.Close();
            
        }
    }
}
