namespace Lesson11
{

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
}
