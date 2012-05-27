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
    public string id { get; set; }

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
    public bool executed { get; set; }

    [DataMember]
    public string currency { get; set; }

    public Stock(string id, int c, String e, transactionType t, int q, string st, DateTime ti, double p, bool ex, string cu)
    {
        this.id = id;
        this.client = c;
        this.email = e;
        this.type = t;
        this.quantity = q;
        this.sType = st;
        this.time = ti;
        this.price = p;
        this.executed = ex;
        this.currency = cu;
    }

    override
    public string ToString()
    {
        if(executed)
            return "[" + type + "]Share: " + sType + " | rate: " + String.Format("{0:0.0000}", price) + " " + currency + " | quantity: " + quantity + " | true";
        else
            return "[" + type + "]Share: " + sType + " | rate: " + String.Format("{0:0.0000}", price) + " " + currency + " | quantity: " + quantity + " | false";
    }

    public static string GenerateId()
    {
        long i = 1;
        foreach (byte b in Guid.NewGuid().ToByteArray())
        {
            i *= ((int)b + 1);
        }
        return string.Format("{0:x}", i - DateTime.Now.Ticks);
    }
}