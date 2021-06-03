using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Grid
    {
        public int Size { get; }
        public List<Point> Obstacles;

        public Grid(int x = 10)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x),
                    "You cannot have a grid that's size is negative");
            }

            if (x == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x),
                    "You cannot have a grid that's size is 0");
            }
            Size = x;
            Obstacles = new List<Point>() {new Point(0, 1)};
        }
    }
}