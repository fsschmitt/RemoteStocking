using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;

namespace StockBroker
{
    class Program
    {
        public static bool Debug = true;
        public static MainForm mf;
        private static ServiceHost host;

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Stock Broker Initializing");
            host = new ServiceHost(typeof(StockBroker.StockBrokerOps));
            host.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mf = new MainForm();
            Application.Run(mf);
            
        }

        public static void StopApplication()
        {
            host.Close();
            Application.Exit();
        }
    }
}
