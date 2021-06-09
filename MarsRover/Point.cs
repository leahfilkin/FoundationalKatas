using System;

namespace MarsRover
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x),
                    "You cannot have a point that's co-ordinates are negative");
            }
            X = x;
            Y = y;
        }
    }
}