using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Tuple<int, decimal>(10, 21.333m);

            var t2 = func();
            
            t2.First = 11;
            t2.Second = 33m;

            write(t2);
            var par1 = 1;
            var t3 = (par1,2,3,4,5,6,7,8,"9",10m);

#if DEBUG
            write("DEBUG");
#endif

#if TEST
            write("TEST");
#endif
            write("t3");
            write(t3);
            write(t3.Item10);
            t3.Item10 = 0.1m;
            write(t3.Item10);

            write("Press Any Key");
            Console.ReadKey();
        }

        private static (int First, decimal Second) func()
        {
            return (10, 22m);
        }

        #region Console Write
        private static void writeNewLine()
        {
            Console.WriteLine();
        }

        private static void write(object v)
        {
            Console.WriteLine(v.ToString());
        }
        #endregion
    }
}
