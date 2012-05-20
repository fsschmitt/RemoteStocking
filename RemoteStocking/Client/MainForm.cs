using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        ServerOps.ServerOpsClient proxy;
        public MainForm()
        {
            proxy = new ServerOps.ServerOpsClient();
            InitializeComponent();
            cbType.SelectedIndex = 0;
            cbShareType.Items.AddRange(proxy.GetAllSharesType());
            cbShareType.SelectedIndex = 0;
            
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

        private void txtIDClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            Stock.transactionType type = cbType.SelectedIndex == 1? type = Stock.transactionType.Sell : type = Stock.transactionType.Buy;
            Stock stock = new Stock(Stock.GenerateId(),Convert.ToInt32(txtIDClient.Text), txtEmail.Text, type, Convert.ToInt32(numQuantity.Value), Convert.ToString(cbShareType.SelectedItem.ToString()), DateTime.Now, Convert.ToDouble(txtPrice.Text), false);
            MessageBox.Show(proxy.AddStock(stock), "Server response:", MessageBoxButtons.OK);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Stock[] stocks = proxy.GetAllStocksByClient(Convert.ToInt32(txtSearch.Text));
            foreach (Stock s in stocks)
            {
                lbSearch.Items.Add(s.ToString());
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

    }
}
