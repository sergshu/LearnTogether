namespace Lesson11
{
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
}
