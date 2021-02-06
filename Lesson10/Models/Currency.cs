using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Models
{
    public class Currency
    {
        [Newtonsoft.Json.JsonProperty("currency_id")]
        public CurrencyEnum CurrencyId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        [Newtonsoft.Json.JsonConverter(typeof(CustomDateConverter))]
        public DateTime? Date { get; set; }
        
        [Newtonsoft.Json.JsonProperty("value")]
        public decimal Value { get; set; }
        
        [Newtonsoft.Json.JsonProperty("ratio")]
        public int Ratio { get; set; }
    }

}
