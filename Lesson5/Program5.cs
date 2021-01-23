using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    static class Extension
    {
        public static string GetPerimetr(this IPerimetr v)
        {
            return $"Perimetr = {v.Perimetr}";
        }
    }

    interface IPerimetr
    {
        double Perimetr { get; }
    }


    class Program5
    {
        static void Main(string[] args)
        {
            var list = new List<IPerimetr>
            {
                new Rectangle(5, 10),
                new Triangle(5, 10),
                new Square(5),
                new TriangleTrivial(5, 3, 7),
            };

            foreach (var o in list)
            {
                write(o.ToString());
                write(o.GetPerimetr());

                writeNewLine();
            }

            writeNewLine();

            write(new Rectangle(5, 7).GetPerimetr());

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

        class Triangle : Rectangle, IPerimetr
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

            public new double Perimetr => Lenght1 + Lenght2 + GetDiagonal();
        }

        class Rectangle : Figure, IPerimetr
        {
            public Rectangle()
            {
            }

            public Rectangle(int v1, int v2)
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

            public double Perimetr => Lenght1 * 2 + Lenght2 * 2;
        }

        class Square : Rectangle
        {
            public Square(int v) : base(v, v)
            {
            }

            public override string ToString()
            {
                return $"Square Area={Area} Diagonal={GetDiagonal()}";
            }
        }

        class TriangleTrivial : IPerimetr
        {
            public TriangleTrivial(int v1, int v2, int v3)
            {
                Lenght1 = v1;
                Lenght2 = v2;
                Lenght3 = v3;
            }

            public int Lenght1 { get; set; }
            public int Lenght2 { get; set; }
            public int Lenght3 { get; set; }

            public double Perimetr => Lenght1 + Lenght2 + Lenght3;
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
