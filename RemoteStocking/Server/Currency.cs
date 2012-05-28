using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public class Rates
    {
        public double AED { get; set; }
        public double AFN { get; set; }
        public double ALL { get; set; }
        public double AMD { get; set; }
        public double ANG { get; set; }
        public double AOA { get; set; }
        public double ARS { get; set; }
        public double AUD { get; set; }
        public double AWG { get; set; }
        public double AZN { get; set; }
        public double BAM { get; set; }
        public double BBD { get; set; }
        public double BDT { get; set; }
        public double BGN { get; set; }
        public double BHD { get; set; }
        public double BIF { get; set; }
        public double BMD { get; set; }
        public double BND { get; set; }
        public double BOB { get; set; }
        public double BRL { get; set; }
        public double BSD { get; set; }
        public double BTN { get; set; }
        public double BWP { get; set; }
        public double BYR { get; set; }
        public double BZD { get; set; }
        public double CAD { get; set; }
        public double CDF { get; set; }
        public double CHF { get; set; }
        public double CLF { get; set; }
        public double CLP { get; set; }
        public double CNH { get; set; }
        public double CNY { get; set; }
        public double COP { get; set; }
        public double CRC { get; set; }
        public double CUP { get; set; }
        public double CVE { get; set; }
        public double CZK { get; set; }
        public double DJF { get; set; }
        public double DKK { get; set; }
        public double DOP { get; set; }
        public double DZD { get; set; }
        public double EGP { get; set; }
        public double ETB { get; set; }
        public double EUR { get; set; }
        public double FJD { get; set; }
        public double FKP { get; set; }
        public double GBP { get; set; }
        public double GEL { get; set; }
        public double GHS { get; set; }
        public double GIP { get; set; }
        public double GMD { get; set; }
        public double GNF { get; set; }
        public double GTQ { get; set; }
        public double GYD { get; set; }
        public double HKD { get; set; }
        public double HNL { get; set; }
        public double HRK { get; set; }
        public double HTG { get; set; }
        public double HUF { get; set; }
        public double IDR { get; set; }
        public double IEP { get; set; }
        public double ILS { get; set; }
        public double INR { get; set; }
        public double IQD { get; set; }
        public double IRR { get; set; }
        public double ISK { get; set; }
        public double JMD { get; set; }
        public double JOD { get; set; }
        public double JPY { get; set; }
        public double KES { get; set; }
        public double KGS { get; set; }
        public double KHR { get; set; }
        public double KMF { get; set; }
        public double KPW { get; set; }
        public double KRW { get; set; }
        public double KWD { get; set; }
        public double KZT { get; set; }
        public double LAK { get; set; }
        public double LBP { get; set; }
        public double LKR { get; set; }
        public double LRD { get; set; }
        public double LSL { get; set; }
        public double LTL { get; set; }
        public double LVL { get; set; }
        public double LYD { get; set; }
        public double MAD { get; set; }
        public double MDL { get; set; }
        public double MGA { get; set; }
        public double MKD { get; set; }
        public double MMK { get; set; }
        public double MNT { get; set; }
        public double MOP { get; set; }
        public double MRO { get; set; }
        public double MUR { get; set; }
        public double MVR { get; set; }
        public double MWK { get; set; }
        public double MXN { get; set; }
        public double MYR { get; set; }
        public double MZN { get; set; }
        public double NAD { get; set; }
        public double NGN { get; set; }
        public double NIO { get; set; }
        public double NOK { get; set; }
        public double NPR { get; set; }
        public double NZD { get; set; }
        public double OMR { get; set; }
        public double PAB { get; set; }
        public double PEN { get; set; }
        public double PGK { get; set; }
        public double PHP { get; set; }
        public double PKR { get; set; }
        public double PLN { get; set; }
        public double PYG { get; set; }
        public double QAR { get; set; }
        public double RON { get; set; }
        public double RSD { get; set; }
        public double RUB { get; set; }
        public double RWF { get; set; }
        public double SAR { get; set; }
        public double SBD { get; set; }
        public double SCR { get; set; }
        public double SDG { get; set; }
        public double SEK { get; set; }
        public double SGD { get; set; }
        public double SHP { get; set; }
        public double SLL { get; set; }
        public double SOS { get; set; }
        public double SRD { get; set; }
        public double STD { get; set; }
        public double SVC { get; set; }
        public double SYP { get; set; }
        public double SZL { get; set; }
        public double THB { get; set; }
        public double TJS { get; set; }
        public double TMT { get; set; }
        public double TND { get; set; }
        public double TOP { get; set; }
        public double TRY { get; set; }
        public double TTD { get; set; }
        public double TWD { get; set; }
        public double TZS { get; set; }
        public double UAH { get; set; }
        public double UGX { get; set; }
        public double USD { get; set; }
        public double UYU { get; set; }
        public double UZS { get; set; }
        public double VEF { get; set; }
        public double VND { get; set; }
        public double VUV { get; set; }
        public double WST { get; set; }
        public double XAF { get; set; }
        public double XCD { get; set; }
        public double XDR { get; set; }
        public double XOF { get; set; }
        public double XPF { get; set; }
        public double YER { get; set; }
        public double ZAR { get; set; }
        public double ZMK { get; set; }
        public double ZWL { get; set; }
    }

    public class Currency
    {
        public string disclaimer { get; set; }
        public string license { get; set; }
        public int timestamp { get; set; }
        public string @base { get; set; }
        public Rates rates { get; set; }

        public double getRate(string rate)
        {
            if(rate == "AED") return rates.AED;
            if(rate == "AFN") return rates.AFN;
            if(rate == "ALL") return rates.ALL;
            if(rate == "AMD") return rates.AMD;
            if(rate == "ANG") return rates.ANG;
            if(rate == "AOA") return rates.AOA;
            if(rate == "ARS") return rates.ARS;
            if(rate == "AUD") return rates.AUD;
            if(rate == "AWG") return rates.AWG;
            if(rate == "AZN") return rates.AZN;
            if(rate == "BAM") return rates.BAM;
            if(rate == "BBD") return rates.BBD;
            if(rate == "BDT") return rates.BDT;
            if(rate == "BGN") return rates.BGN;
            if(rate == "BHD") return rates.BHD;
            if(rate == "BIF") return rates.BIF;
            if(rate == "BMD") return rates.BMD;
            if(rate == "BND") return rates.BND;
            if(rate == "BOB") return rates.BOB;
            if(rate == "BRL") return rates.BRL;
            if(rate == "BSD") return rates.BSD;
            if(rate == "BTN") return rates.BTN;
            if(rate == "BWP") return rates.BWP;
            if(rate == "BYR") return rates.BYR;
		    if(rate == "BZD") return rates.BZD;
		    if(rate == "CAD") return rates.CAD;
		    if(rate == "CDF") return rates.CDF;
		    if(rate == "CHF") return rates.CHF;
		    if(rate == "CLF") return rates.CLF;
		    if(rate == "CLP") return rates.CLP;
		    if(rate == "CNH") return rates.CNH;
		    if(rate == "CNY") return rates.CNY;
		    if(rate == "COP") return rates.COP;
		    if(rate == "CRC") return rates.CRC;
		    if(rate == "CUP") return rates.CUP;
		    if(rate == "CVE") return rates.CVE;
		    if(rate == "CZK") return rates.CZK;
		    if(rate == "DJF") return rates.DJF;
		    if(rate == "DKK") return rates.DKK;
		    if(rate == "DOP") return rates.DOP;
		    if(rate == "DZD") return rates.DZD;
		    if(rate == "EGP") return rates.EGP;
		    if(rate == "ETB") return rates.ETB;
		    if(rate == "EUR") return rates.EUR;
		    if(rate == "FJD") return rates.FJD;
		    if(rate == "FKP") return rates.FKP;
		    if(rate == "GBP") return rates.GBP;
		    if(rate == "GEL") return rates.GEL;
		    if(rate == "GHS") return rates.GHS;
		    if(rate == "GIP") return rates.GIP;
		    if(rate == "GMD") return rates.GMD;
		    if(rate == "GNF") return rates.GNF;
		    if(rate == "GTQ") return rates.GTQ;
		    if(rate == "GYD") return rates.GYD;
		    if(rate == "HKD") return rates.HKD;
		    if(rate == "HNL") return rates.HNL;
		    if(rate == "HRK") return rates.HRK;
		    if(rate == "HTG") return rates.HTG;
		    if(rate == "HUF") return rates.HUF;
		    if(rate == "IDR") return rates.IDR;
		    if(rate == "IEP") return rates.IEP;
		    if(rate == "ILS") return rates.ILS;
		    if(rate == "INR") return rates.INR;
		    if(rate == "IQD") return rates.IQD;
		    if(rate == "IRR") return rates.IRR;
		    if(rate == "ISK") return rates.ISK;
		    if(rate == "JMD") return rates.JMD;
		    if(rate == "JOD") return rates.JOD;
		    if(rate == "JPY") return rates.JPY;
		    if(rate == "KES") return rates.KES;
		    if(rate == "KGS") return rates.KGS;
		    if(rate == "KHR") return rates.KHR;
		    if(rate == "KMF") return rates.KMF;
		    if(rate == "KPW") return rates.KPW;
		    if(rate == "KRW") return rates.KRW;
		    if(rate == "KWD") return rates.KWD;
		    if(rate == "KZT") return rates.KZT;
		    if(rate == "LAK") return rates.LAK;
		    if(rate == "LBP") return rates.LBP;
		    if(rate == "LKR") return rates.LKR;
		    if(rate == "LRD") return rates.LRD;
		    if(rate == "LSL") return rates.LSL;
		    if(rate == "LTL") return rates.LTL;
		    if(rate == "LVL") return rates.LVL;
		    if(rate == "LYD") return rates.LYD;
		    if(rate == "MAD") return rates.MAD;
		    if(rate == "MDL") return rates.MDL;
		    if(rate == "MGA") return rates.MGA;
		    if(rate == "MKD") return rates.MKD;
		    if(rate == "MMK") return rates.MMK;
		    if(rate == "MNT") return rates.MNT;
		    if(rate == "MOP") return rates.MOP;
		    if(rate == "MRO") return rates.MRO;
		    if(rate == "MUR") return rates.MUR;
		    if(rate == "MVR") return rates.MVR;
		    if(rate == "MWK") return rates.MWK;
		    if(rate == "MXN") return rates.MXN;
		    if(rate == "MYR") return rates.MYR;
		    if(rate == "MZN") return rates.MZN;
		    if(rate == "NAD") return rates.NAD;
		    if(rate == "NGN") return rates.NGN;
		    if(rate == "NIO") return rates.NIO;
		    if(rate == "NOK") return rates.NOK;
		    if(rate == "NPR") return rates.NPR;
		    if(rate == "NZD") return rates.NZD;
		    if(rate == "OMR") return rates.OMR;
		    if(rate == "PAB") return rates.PAB;
		    if(rate == "PEN") return rates.PEN;
		    if(rate == "PGK") return rates.PGK;
		    if(rate == "PHP") return rates.PHP;
		    if(rate == "PKR") return rates.PKR;
		    if(rate == "PLN") return rates.PLN;
		    if(rate == "PYG") return rates.PYG;
		    if(rate == "QAR") return rates.QAR;
		    if(rate == "RON") return rates.RON;
		    if(rate == "RSD") return rates.RSD;
		    if(rate == "RUB") return rates.RUB;
		    if(rate == "RWF") return rates.RWF;
		    if(rate == "SAR") return rates.SAR;
		    if(rate == "SBD") return rates.SBD;
		    if(rate == "SCR") return rates.SCR;
		    if(rate == "SDG") return rates.SDG;
		    if(rate == "SEK") return rates.SEK;
		    if(rate == "SGD") return rates.SGD;
		    if(rate == "SHP") return rates.SHP;
		    if(rate == "SLL") return rates.SLL;
		    if(rate == "SOS") return rates.SOS;
		    if(rate == "SRD") return rates.SRD;
		    if(rate == "STD") return rates.STD;
		    if(rate == "SVC") return rates.SVC;
		    if(rate == "SYP") return rates.SYP;
		    if(rate == "SZL") return rates.SZL;
		    if(rate == "THB") return rates.THB;
		    if(rate == "TJS") return rates.TJS;
		    if(rate == "TMT") return rates.TMT;
		    if(rate == "TND") return rates.TND;
		    if(rate == "TOP") return rates.TOP;
		    if(rate == "TRY") return rates.TRY;
		    if(rate == "TTD") return rates.TTD;
		    if(rate == "TWD") return rates.TWD;
		    if(rate == "TZS") return rates.TZS;
		    if(rate == "UAH") return rates.UAH;
		    if(rate == "UGX") return rates.UGX;
		    if(rate == "USD") return rates.USD;
		    if(rate == "UYU") return rates.UYU;
		    if(rate == "UZS") return rates.UZS;
		    if(rate == "VEF") return rates.VEF;
		    if(rate == "VND") return rates.VND;
		    if(rate == "VUV") return rates.VUV;
		    if(rate == "WST") return rates.WST;
		    if(rate == "XAF") return rates.XAF;
		    if(rate == "XCD") return rates.XCD;
		    if(rate == "XDR") return rates.XDR;
		    if(rate == "XOF") return rates.XOF;
		    if(rate == "XPF") return rates.XPF;
		    if(rate == "YER") return rates.YER;
		    if(rate == "ZAR") return rates.ZAR;
		    if(rate == "ZMK") return rates.ZMK;
            if (rate == "ZWL") return rates.ZWL;
            else return 1.0;
        }
    }
}
