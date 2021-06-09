using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        public int Size { get; }
        public readonly List<Point> Obstacles;

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

        public bool HasObstacleAt(Point nextPosition)
        {
            return Obstacles.Any(obstacle => obstacle.X == nextPosition.X && obstacle.Y == nextPosition.Y);
        }
    }
}