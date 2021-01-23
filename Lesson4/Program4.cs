using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    class Program4
    {
        static void Main(string[] args)
        {

            var rectangle2 = new Rectange(5, 10);
            //write(rectangle2.Area);
            //write(rectangle2.GetDiagonal());


            var triangle = new Triangle(5, 10);
            //write(triangle.Area);
            //write(triangle.GetDiagonal());

            var square1 = new Square(5);

            var list = new List<Figure> { rectangle2, triangle };
            
            list.Add(square1);

            foreach(var o in list)
            {
                write(o.ToString());
                
                writeNewLine();
            }



            writeNewLine();


            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
        }

        abstract class Figure
        {
            public int Lenght1 { get; set; }
            public int Lenght2 { get; set; }

            public decimal Area { get => GetArea(); }

            protected abstract decimal GetArea();
            public abstract double GetDiagonal();
        }

        class Triangle : Rectange
        {
            public Triangle(int v1, int v2) : base(v1, v2) { }

            protected override decimal GetArea()
            {
                return Lenght1 * Lenght2 / 2m;
            }

            public override string ToString()
            {
                return $"Triangle Area={Area} Diagonal={GetDiagonal()}";
            }
        }


        class Rectange : Figure
        {
            public Rectange()
            {
            }

            public Rectange(int v1, int v2)
            {
                Lenght1 = v1;
                Lenght2 = v2;
            }

            public override double GetDiagonal()
            {
                var d = Math.Sqrt(Lenght1 * Lenght1 + Lenght2 * Lenght2);
                return d;
            }

            protected override decimal GetArea()
            {
                return Lenght1 * Lenght2;
            }

            public override string ToString()
            {
                return $"Rectange Area={Area} Diagonal={GetDiagonal()}";
            }
        }

        class Square : Rectange
        {
            public Square(int v) : base(v, v)
            {
            }

            public override string ToString()
            {
                return $"Square Area={Area} Diagonal={GetDiagonal()}";
            }
        }


        private static void writeNewLine()
        {
            Console.WriteLine();
        }

        private static void write(string v)
        {
            Console.WriteLine(v);
        }

        private static void write(int v)
        {
            Console.WriteLine($"Value = {v}");
        }

        private static void write(decimal v)
        {
            Console.WriteLine($"Value = {v}");
        }

        private static void write(double v)
        {
            Console.WriteLine($"D = {v}");
        }
    }
}
