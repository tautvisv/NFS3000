using System;
using System.Collections;

namespace Services.Services.Objects
{
    [Serializable]
    public class Coordinates : IEquatable<Coordinates>
    {
        public Coordinates()
        {
        }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;
        public bool Equals(Coordinates other)
        {
            if (other != null && other.X == X && other.Y == Y)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return String.Format("X:{0}, Y:{1}",X,Y);
        }

        public static Coordinates operator +(Coordinates c1, Coordinates c2)
        {
            return new Coordinates(c1.X + c2.X, c1.Y + c2.Y);
        }
    }
}
