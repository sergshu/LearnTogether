using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program3
    {
        static void Main(string[] args)
        {
            //var rectangle1 = new Rectange();
            //write(rectangle1.Area);

            var rectangle2 = new Rectange(5, 10);
            write(rectangle2.Area);
            write(rectangle2.GetDiagonal());

            writeNewLine();

            var square1 = new Square(5);
            write(square1.Area);
            write(square1.GetDiagonal());

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

        private static void write(int v)
        {
            Console.WriteLine($"Value = {v}");
        }

        private static void write(double v)
        {
            Console.WriteLine($"D = {v}");
        }

    }

    class Rectange
    {
        public Rectange()
        {
        }

        public Rectange(int v1, int v2)
        {
            Lenght1 = v1;
            Lenght2 = v2;
        }

        public int Lenght1 { get; set; }
        public int Lenght2 { get; set; }

        public int Area { get { return Lenght1 * Lenght2; } }
        
        public double GetDiagonal()
        {
            var d = Math.Sqrt(Lenght1 * Lenght1 + Lenght2 * Lenght2);
            return d;
        }
    }

    class Square : Rectange
    {
        public Square(int v)
        {
            Lenght1 = Lenght2 = v;
        }
    }
}
