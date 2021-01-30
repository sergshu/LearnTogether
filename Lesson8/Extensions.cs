using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public static class Extensions
    {
        public static string ToFormatedString(this Models.Currency currency)
        {
            return string.Format("Id: {0}\nDate:{1}\nValue:{2}\nRatio: {3}", currency.CurrencyId, currency.Date, currency.Value, currency.Ratio);
        }
    }
}
