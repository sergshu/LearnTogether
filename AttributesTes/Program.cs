using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesTes
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new TestItem { Id = 1, Date = DateTime.Now };
            if(Helper.HasCustomAttribute(o))
            {
                Console.WriteLine("Has custom");
            }
            else
            {
                Console.WriteLine("Has NOT custom");
            }

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(o);
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
