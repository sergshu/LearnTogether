using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    class Program11
    {
        static void Main(string[] args)
        {
            //var list = new FigureList<IPerimetr>();

            //list.Add(new Rectangle(5, 10));
            //list.Add(new Triangle(5, 10));
            //list.Add(new Square(5));
            //list.Add(new TriangleTrivial(5, 3, 7));

            //foreach (var o in list.Items)
            //{
            //    write(o.ToString());
            //    write(o.GetPerimetr());

            //    writeNewLine();
            //}

            var list = new FigureList<Figure>();

            list.Add(new Rectangle(5, 10));
            list.Add(new Triangle(5, 10));
            list.Add(new Square(5));

            //list.Add(new TriangleTrivial(5, 3, 7));

            //foreach (var o in list.Items)
            //{
            //    write(o.ToString());
            //    write(o.GetPerimetr());

            //    writeNewLine();
            //}
            //writeNewLine();

            //write(new Rectangle(5, 7).GetPerimetr());

            var square = list.Get<Square>();
            if (square != null)
            {
                write(square?.ToString());
            }
            else
            {
                Console.WriteLine("Square not found");
            }


            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
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
