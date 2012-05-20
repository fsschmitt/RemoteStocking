using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockBroker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeStocks();
        }

        public delegate void InitializeStocksDelegate();
        private void InitializeStocks()
        {
            if (lbStocks.InvokeRequired)
            {
                this.BeginInvoke(new InitializeStocksDelegate(InitializeStocks));
                return;
            }
            List<Stock> stocks = StockBrokerOps.GetAllWaitingStock();
            foreach (Stock s in stocks)
            {
                lbStocks.Items.Add(s);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Stock stock = (Stock)lbStocks.SelectedItem;
            Console.WriteLine("ID: "+stock.id);
        }

        public delegate void addNewStockDelegate(Stock stock);
        public void addNewStock(Stock stock)
        {
            if (lbStocks.InvokeRequired)
            {
                this.BeginInvoke(new addNewStockDelegate(addNewStock), stock);
                return;
            }

            lbStocks.Items.Add(stock);
        }
    }
}
