using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = new Struct(10, 20);
            
            var str2 = str1;
            str2.Val1 = 15;
            str2.Val2 = 25;

            write(str1);
            write(str2);

            write("Press Key");
            Console.ReadKey();
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

    public class StructClass
    {
        public int Val1 { get; set; }
        public int Val2 { get; set; }

        public StructClass(int v1, int v2)
        {
            Val1 = v1;
            Val2 = v2;
        }

        public override string ToString()
        {
            return $"Val1: {Val1} Val2: {Val1} Summ {Summ()}";
        }

        public int Summ()
        {
            return Val1 + Val2;
        }

        public int Summ1() => Val1 + Val2;
    }

    public struct Struct
    {
        public int Val1 { get; set; }
        public int Val2 { get; set; }

        public Struct(int v1, int v2)
        {
            Val1 = v1;
            Val2 = v2;
        }

        public override string ToString()
        {
            return $"Val1: {Val1} Val2: {Val1} Summ {Summ()}";
        }

        public int Summ()
        {
            return Val1 + Val2;
        }

        public int Summ1() => Val1 + Val2;
    }
}
