using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Sand { Weight = 1.5m, WeightType = WeightType.T };
            var s2 = new Sand { Weight = 2.3m, WeightType = WeightType.G };
           
            write(s1);
            write(s2);

            if (s1 == s2)
            {
                Console.WriteLine("S1 EQ S2");
            }

            if(s1 != s2)
            {
                Console.WriteLine("S1 not EQ S2");
            }

            var s3 = s1 + s2;

            write(s3);

            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
        }

        private static void write(Sand ss)
        {
            Console.WriteLine($"Sand Weight {ss.Weight} {ss.WeightType}");
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

    class Sand
    {
        public decimal Weight { get; set; }

        public WeightType WeightType { get; set; }

        public static bool operator == (Sand op1, Sand op2)
        {
            return op1.getWeightKg() == op2.getWeightKg();
        }

        public static bool operator != (Sand op1, Sand op2)
        {
            return op1.getWeightKg() != op2.getWeightKg();
        }

        public static Sand operator + (Sand op1, Sand op2)
        {
            return new Sand { Weight = op1.getWeightKg() + op2.getWeightKg(), WeightType = WeightType.Kg };
        }

        private decimal getWeightKg()
        {
            switch(this.WeightType)
            {
                case WeightType.G: return this.Weight / 1000m;
                case WeightType.Kg: return this.Weight;
                case WeightType.T: return this.Weight * 1000m;
                default: throw new NotImplementedException();
            }
        }
    }

    public enum WeightType
    {
        Kg,
        G,
        T,
    }


}
