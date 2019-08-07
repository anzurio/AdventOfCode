namespace AdventOfCode2018.Day10
{
    public sealed class Star
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int DX { get; private set; }
        public int DY { get; private set; }

        public Star(int x, int y, int dx, int dy)
        {
            X = x;
            Y = y;
            DX = dx;
            DY = dy;
        }

        public (int X, int Y) this[int dt] => (X + (dt * DX), Y + (dt * DY));
    }
}
