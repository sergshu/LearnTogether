using System;

namespace Lesson12
{

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

        public new double Perimetr => Lenght1 * 2 + Lenght2 * 2;
    }
}
