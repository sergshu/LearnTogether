namespace Lesson11
{
    class Square : Rectangle
    {
        public Square(int v) : base(v, v)
        {
        }

        public override string ToString()
        {
            return $"Square Area={Area} Diagonal={GetDiagonal()}";
        }
    }
}
