using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace StockBroker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeStocks();
            btnExecute.Enabled = false;
            btnFinance.Enabled = false;
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
            if (lbStocks.SelectedIndex != -1 && txtPrice.Text != "")
                btnExecute.Enabled = true;
            else
                btnExecute.Enabled = false;

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
            ThreadStart processTaskThread = delegate { StockBroker.StockBrokerOps.ExecuteStockRate(stock.id, Convert.ToDouble(txtPrice.Text)); };
            new Thread(processTaskThread).Start();
            lbStocks.Items.RemoveAt(lbStocks.SelectedIndex);
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

        private void lbStocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbStocks.SelectedIndex != -1)
                btnFinance.Enabled = true;
            else
                btnFinance.Enabled = false;

            if (lbStocks.SelectedIndex != -1 && txtPrice.Text != "")
                btnExecute.Enabled = true;
            else
                btnExecute.Enabled = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.StopApplication();
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            Stock stock = (Stock)lbStocks.SelectedItem;
            System.Diagnostics.Process.Start("http://www.google.com/finance?q="+stock.sType);
        }

    }
}
