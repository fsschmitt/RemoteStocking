using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

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
            cbCurrency.Items.AddRange(proxy.GetAllCurrency());
            cbCurrency.SelectedIndex = 0;
            
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
             RegexUtilities util = new RegexUtilities();
             if (txtPrice.Text != "" && txtEmail.Text != "" && txtIDClient.Text != "")
            {
                if (!util.IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email is not recognized as valid!", "Invalid email!", MessageBoxButtons.OK);
                    return;
                }
                
                Stock.transactionType type = cbType.SelectedIndex == 1 ? type = Stock.transactionType.Sell : type = Stock.transactionType.Buy;
                Stock stock = new Stock(Stock.GenerateId(), Convert.ToInt32(txtIDClient.Text), txtEmail.Text, type, Convert.ToInt32(numQuantity.Value), Convert.ToString(cbShareType.SelectedItem.ToString()), DateTime.Now, Convert.ToDouble(txtPrice.Text), false, Convert.ToString(cbCurrency.SelectedItem.ToString()));
                MessageBox.Show(proxy.AddStock(stock), "Server response:", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("All fields must be filled!", "Field is empty!", MessageBoxButtons.OK);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                Stock[] stocks = proxy.GetAllStocksByClient(Convert.ToInt32(txtSearch.Text));
                foreach (Stock s in stocks)
                {
                    lbSearch.Items.Add(s.ToString());
                }
            }
            else
                MessageBox.Show("All fields must be filled!", "Field is empty!", MessageBoxButtons.OK);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.StopApplication();
        }

        

    }



public class RegexUtilities
{
   bool invalid = false;

   public bool IsValidEmail(string strIn)
   {
       invalid = false;
       if (String.IsNullOrEmpty(strIn))
          return false;

       // Use IdnMapping class to convert Unicode domain names.
       strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper);
       if (invalid) 
          return false;

       // Return true if strIn is in valid e-mail format.
       return Regex.IsMatch(strIn, 
              @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + 
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", 
              RegexOptions.IgnoreCase);
   }

   private string DomainMapper(Match match)
   {
      // IdnMapping class with default property values.
      IdnMapping idn = new IdnMapping();

      string domainName = match.Groups[2].Value;
      try {
         domainName = idn.GetAscii(domainName);
      }
      catch (ArgumentException) {
         invalid = true;      
      }      
      return match.Groups[1].Value + domainName;
   }
}


}
