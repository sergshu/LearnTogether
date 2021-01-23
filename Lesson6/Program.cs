using Lesson6.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Program
    {
        const string FILE_NAME = "Contacts.txt";

        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, FILE_NAME);
            string[] lines = File.ReadAllLines(path);
            
            var list = new List<Models.ContactModel>();

            foreach(var line in lines)
            {
                var contact = Models.ContactModel.Create(line);
                if(contact != null)
                {
                    list.Add(contact);
                }
                else
                {
                    write($"Line `{line}` not contains Contact");
                }
            }

            foreach(var c in list)
            {
                write(c.GetFormatedString());
            }

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
