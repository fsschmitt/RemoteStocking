using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

[DataContract]
public class Stock
{
    public enum transactionType
    {
        Buy, Sell
    }

    [DataMember]
    public int client { get; set; }

    [DataMember]
    public String email { get; set; }

    [DataMember]
    public transactionType type { get; set; }

    [DataMember]
    public int quantity { get; set; }

    [DataMember]
    public String sType { get; set; }

    [DataMember]
    public DateTime time { get; set; }

    [DataMember]
    public double price { get; set; }

    [DataMember]
    public double opPrice { get; set; }

    [DataMember]
    public bool executed { get; set; }

    public Stock(int c, String e, transactionType t, int q, string st, DateTime ti, double p, double op, bool ex)
    {
        this.client = c;
        this.email = e;
        this.type = t;
        this.quantity = q;
        this.sType = st;
        this.time = ti;
        this.price = p;
        this.opPrice = op;
        this.executed = ex;
    }

}