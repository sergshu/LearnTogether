using System;

namespace BankiRuJsonParsing
{
    public class CandleData
    {
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal value { get; set; }
        public decimal volume { get; set; }
        public DateTime begin { get; set; }
        public DateTime end { get; set; }

        public CandleData(object[] r)
        {
            open = decimal.Parse(r[0].ToString());
            close = decimal.Parse(r[1].ToString());
            high = decimal.Parse(r[2].ToString());
            low = decimal.Parse(r[3].ToString());
            value = decimal.Parse(r[4].ToString());
            volume = decimal.Parse(r[5].ToString());

            begin = DateTime.ParseExact(r[6]?.ToString(), "yyyy-MM-dd HH:mm:ss", null);
            end = DateTime.ParseExact(r[7]?.ToString(), "yyyy-MM-dd HH:mm:ss", null);
        }
    }
}