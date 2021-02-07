using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    class Program12
    {
        static void Main(string[] args)
        {
            var list = new FigureList<Figure>();

            list.Add(new Rectangle(5, 10));
            list.Add(new Triangle(5, 10));
            list.Add(new Square(5));

            printList(list.Items);

            writeNewLine();

            IEnumerable<Figure> linq = list.Items
                .Where(i => i.Area > 25)
                .OrderBy(i => i.Area);

            list.Add(new Square(7));
            list.Add(new Triangle(10, 8));

            Console.WriteLine("linq");

            printList(linq);

            IEnumerable<Tuple<double, decimal>> linqTuple = list.Items
                .Where(i => i.Area > 25)
                .OrderBy(i => i.Area)
                .Select(i => new Tuple<double, decimal>(((IPerimetr)i).Perimetr, i.Area));

            list.Add(new Square(11));

            Console.WriteLine("linqTuple");

            printList(linqTuple);

            Console.WriteLine("linq25");
            var linq25 = list.Items.FirstOrDefault(i => i.Area == 30);
            if (linq25 != null)
            {
                Console.WriteLine(linq25.ToString());
            }
            else
            {
                Console.WriteLine("linq30 not found");
            }


            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
        }

        private static void printList(IEnumerable<Tuple<double, decimal>> items)
        {
            foreach (var o in items)
            {
                write(o.ToFormatedString());
            }
            writeNewLine();
        }

        private static void printList(IEnumerable<Figure> items)
        {
            foreach (var o in items)
            {
                write(o.ToString());
                write(o.GetPerimetr());

                writeNewLine();
            }
        }

        private static void write(int v)
        {
            Console.WriteLine($"Value = {v}");
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
