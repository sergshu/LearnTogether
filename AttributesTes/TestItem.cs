using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesTes
{
    [TestClass]
    class TestItem : ITestItem
    {
        public int Id { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(DateCustomConverter))]
        public DateTime Date { get; set; }
    }
}
