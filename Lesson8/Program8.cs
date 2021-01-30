using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    class Program8
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "json.txt");
            string json = File.ReadAllText(path);

            Models.Currency currency = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Currency>(json);

            write(currency.ToFormatedString());

            var jsonOut = Newtonsoft.Json.JsonConvert.SerializeObject(currency);
            var pathOut = Path.Combine(Environment.CurrentDirectory, "jsonOut.txt");
            File.WriteAllText(pathOut, jsonOut);

            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
        }

        private static void writeNewLine()
        {
            Console.WriteLine();
        }

        private static void write(string v)
        {
            Console.WriteLine(v);
        }
    }
}
