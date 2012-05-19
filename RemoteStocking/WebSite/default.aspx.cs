using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class _default : System.Web.UI.Page
    {
        ServerOps.ServerOpsClient proxy; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddShare.Items.Count <= 1)
            {
                ddShare.Items.Add("None available!");
                proxy = new ServerOps.ServerOpsClient();
                try
                {
                    proxy.Open();
                    String[] types = proxy.GetAllSharesType();
                    ddShare.Items.Clear();
                    if(types.Count() == 0)
                        ddShare.Items.Add("None available!");
                    else
                        foreach (String s in types)
                        {
                            ddShare.Items.Add(s);
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
                proxy = new ServerOps.ServerOpsClient();
                Stock.transactionType type = ddType.SelectedIndex == 1 ? type = Stock.transactionType.Sell : type = Stock.transactionType.Buy;
                Stock stock = new Stock(Convert.ToInt32(txtIDClient.Text), txtEmail.Text, type, Convert.ToInt32(txtQuantity.Text), Convert.ToString(ddShare.SelectedItem.Text), DateTime.Now, Convert.ToDouble(txtPrice.Text), false);
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
}