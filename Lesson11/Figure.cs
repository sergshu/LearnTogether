namespace Lesson11
{
    abstract class Figure : IPerimetr
    {
        public int Lenght1 { get; set; }
        public int Lenght2 { get; set; }

        public decimal Area { get => GetArea(); }

        protected abstract decimal GetArea();
        public abstract double GetDiagonal();

        public double Perimetr { get; }
    }
}
