using System;

namespace MarsRover
{
    public class Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x),
                    "You cannot have a point that's co-ordinates are negative");
            }
            X = x;
            Y = y;
            
        }
    }
}