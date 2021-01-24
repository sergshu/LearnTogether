using System;
using System.Threading.Tasks;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestEvent();
            test.NewSecond += (sender, e)=> { write($"New second {e} Lambda"); } ;
            test.NewSecond += Test_NewSecond;

            Task.Run(()=> test.Start());

            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();

            test.Stop();
        }

        private static void Test_NewSecond(object sender, int e)
        {
            write($"New second {e}");
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
