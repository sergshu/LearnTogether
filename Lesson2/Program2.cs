using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;

            //method1(i);

            //method2(10);

            //method3();

            //method3(1);

            //method4(10);

            //method4(10, 11);

            //method5(10, funcEven, funcOdd);
            //method5(1, funcEven, funcOdd);
            //method5(0, funcEven, funcOdd);

            //method5(10, ()=>write($"even {10}"), () => write($"odd {10}"));

            //method6(1, 2, 3, 4, 1.5, 2.3m);

            //method6(1, 2, 3, 4, 1.5, 2.3m);
            
            method6_1(1, 2, 3, 4, 1.5, 2.3m);

            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
        }

        private static void method6(params object[] p)
        {
            foreach (var o in p)
            {
                try
                {
                    int i = (int)o;
                    method5(i, () => write($"even {i}"), () => write($"odd {i}"));
                }
                catch (Exception ex) { write(ex.Message); }
            }
        }

        private static void method6_1(params object[] p)
        {
            foreach (var o in p)
            {
                try
                {
                    int i = (int)o;
                    method5(i, () => funcEven(i), () => funcOdd(i));
                }
                catch (Exception ex) { write(ex.Message); }
            }
        }

        private static void funcOdd(int? i = null)
        {
            if (i != null)
            {
                write($"Odd {i}");
            }
            else
            {
                write("Odd");
            }
        }

        private static void funcEven(int? i = null)
        {
            if (i != null)
            {
                write($"Even {i}");
            }
            else
            {
                write("Even");
            }
        }

        private static void method5(int v, Action funcEven, Action funcOdd)
        {
            if (v % 2 == 0)
            {
                funcEven();
            }
            else
            {
                funcOdd();
            }
        }

        private static void method2(int v)
        {
            writeNewLine();

            for (int x = 0; x <= v; x++)
            {
                write(x);
            }
        }

        private static void writeNewLine()
        {
            Console.WriteLine();
        }

        private static void method1(int i)
        {
            if (i < 5)
            {
                write("Меньше 5");
            }
            else
            {
                write("Больше или равно 5");
            }
        }

        private static void method3(int i = 10)
        {
            if (i < 5)
            {
                write($"{i} Меньше 5");
            }
            else
            {
                write($"{i} Больше или равно 5");
            }
        }

        private static void method4(int i, int y = 5)
        {
            if (i < y)
            {
                write($"{i} Меньше {y}");
            }
            else
            {
                write($"{i} Больше или равно {y}");
            }
        }

        private static void write(string v)
        {
            Console.WriteLine(v);
        }

        private static void write(int v)
        {
            Console.WriteLine($"Value = {v}");
        }
    }
}
