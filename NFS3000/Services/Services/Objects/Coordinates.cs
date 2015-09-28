using System;

namespace Services.Services.Objects
{
    public struct Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;
        public override string ToString()
        {
            return String.Format("X:{0}, Y:{1}",X,Y);
        }
    }
}
