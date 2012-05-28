using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;
namespace WebSite
{
    public partial class _default : System.Web.UI.Page
    {
        ServerOps.ServerOpsClient proxy;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddShare.Items.Count <= 1)
            {
                ddShare.Items.Clear();
                ddCurrency.Items.Clear();
                ddShare.Items.Add("None available!");
                ddCurrency.Items.Add("None available!");
                proxy = new ServerOps.ServerOpsClient();
                try
                {
                    proxy.Open();
                    String[] types = proxy.GetAllSharesType();
                    String[] currencies = proxy.GetAllCurrency();
                    ddShare.Items.Clear();
                    ddCurrency.Items.Clear();
                    if(types.Count() == 0)
                        ddShare.Items.Add("None available!");
                    else
                        foreach (String s in types)
                        {
                            ddShare.Items.Add(s);
                        }

                    if (currencies.Count() == 0)
                        ddCurrency.Items.Add("None available!");
                    else
                        foreach (String s in currencies)
                        {
                            ddCurrency.Items.Add(s);
                        }
                }
                catch (Exception ex){}
                finally
                {
                    if (!proxy.State.ToString().Equals("Faulted"))
                        proxy.Close();
                    else
                        lblServer.Text = " - Server is down!";
                }
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
               
                RegexUtilities util = new RegexUtilities();
                proxy = new ServerOps.ServerOpsClient();
                if (!util.IsValidEmail(txtEmail.Text))
                {
                    throw new Exception("Invalid Email");
                   
                }
              
                Stock.transactionType type = ddType.SelectedIndex == 1 ? type = Stock.transactionType.Sell : type = Stock.transactionType.Buy;
                Stock stock = new Stock(Stock.GenerateId(), Convert.ToInt32(txtIDClient.Text), txtEmail.Text, type, Convert.ToInt32(txtQuantity.Text), Convert.ToString(ddShare.SelectedItem.Text), DateTime.Now, Convert.ToDouble(txtPrice.Text), false, Convert.ToString(ddCurrency.SelectedItem.Text));
                lblStatus.Text = "Status:\n" + proxy.AddStock(stock);
            }
            catch (Exception ex) {
                lblStatus.Text = "Status:\n"+ex.Message;
            }
            finally
            {
                if (!proxy.State.ToString().Equals("Faulted"))
                    proxy.Close();
                else
                    lblServer.Text = " - Server is down!";
            }
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                proxy = new ServerOps.ServerOpsClient();
                Stock[] stocks = proxy.GetAllStocksByClient(Convert.ToInt32(txtSearch.Text));
                lbHistory.Items.Clear();
                if (stocks.Count() == 0)
                {
                    lbHistory.Items.Add(string.Format("No results found for {0}!", txtSearch.Text));
                }
                else
                    foreach (Stock s in stocks)
                    {
                        lbHistory.Items.Add(s.ToString());
                    }
            }
            catch (Exception ex)
            {
                lbHistory.Items.Clear();
                lbHistory.Items.Add(ex.Message);
            }
            finally
            {
                if (!proxy.State.ToString().Equals("Faulted"))
                    proxy.Close();
                else
                    lblServer.Text = " - Server is down!";
            }

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
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }

}