using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            decimal m = decimal.MaxValue;
            var d = double.MinValue;

            i = 5;

            if (i < 5)
            {
                Console.WriteLine("Меньше 5");
            }
            else
            {
                Console.WriteLine("Больше или равно 5");
            }

            switch (i)
            {
                case 5:
                    Console.WriteLine("равно 5");
                    break;
                case 3:
                    Console.WriteLine("равно 3");
                    break;
                default:
                    Console.WriteLine("другое");
                    break;
                case 4:
                    Console.WriteLine("равно 4");
                    break;
            }

            Console.WriteLine();

            for (int x = 0; x <= 5; x++)
            {
                Console.WriteLine($"x={x}");
            }

            Console.WriteLine();

            foreach (var y in new decimal[] { 3, 7, 9, 1, 0 })
            {
                Console.WriteLine($"y={y}");
            }

            Console.WriteLine();

            int yy = 0;
            while (yy < 10)
            {
                Console.WriteLine($"yy={yy}");
                yy++;
            }

            Console.WriteLine();

            while (yy < 20)
            {
                Console.WriteLine($"yy={yy}");

                if (DateTime.Now.Second % 2 == 0)
                {
                    Console.WriteLine("Exit");
                    break;
                }

                System.Threading.Thread.Sleep(100);

                yy++;
            }

            Console.WriteLine();

            yy = 20;
            do
            {
                Console.WriteLine($"yy={yy}");

                yy++;
            }
            while (yy < 30);

            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
        }
    }
}