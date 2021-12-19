using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeUsage.BO
{
    public class Settings
    {
        public List<(string name, string value)> dataFromTable =
            new List<(string name, string value)>
            {
                ("finance:vat", "21.00"),
                ("api:url", "https://api.localhost:5555"),
                ("finance:profit", "44.444"),
            };

        [KeyName("finance:vat")]
        public string VAT { get; set; }

        [KeyName("api:url")]
        public string Url { get; set; }

        [KeyName("finance:profit")]
        public string Profit { get; set; }

        internal void Load()
        {
            var typ = this.GetType();
            var properties = typ.GetProperties();
            foreach(var property in properties)
            {
                var atrrs = property.GetCustomAttributes(false);
                foreach(var attr in atrrs)
                {
                    if(attr.GetType() == typeof(KeyNameAttribute))
                    {
                        var keyName = ((KeyNameAttribute)attr).Name;
                        var value = dataFromTable.First(d => d.name == keyName).value;
                        property.SetValue(this, value);
                    }
                }
            }
        }

        internal List<(string name, string value)> GetData()
        {
            var result = new List<(string name, string value)>();

            var typ = this.GetType();
            var properties = typ.GetProperties();
            foreach(var property in properties)
            {
                var atrrs = property.GetCustomAttributes(false);
                foreach(var attr in atrrs)
                {
                    if(attr.GetType() == typeof(KeyNameAttribute))
                    {
                        var keyName = ((KeyNameAttribute)attr).Name;
                        var value = property.GetValue(this).ToString();

                        result.Add((keyName, value));
                    }
                }
            }

            return result;
        }
    }
}
