using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Interfaces;

namespace MarsRover
{
    public class Grid
    {
        public int Size { get; }
        public readonly List<Point> Obstacles;

        public Grid(IRandom random, int x = 10)
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
            Obstacles = new List<Point>();
            for(var i = 0; i < Size/2; i++) 
            {
                Obstacles.Add(new Point(random.Next(Size), random.Next(Size)));
            }
        }

        public bool HasObstacleAt(Point nextPosition)
        {
            return Obstacles.Any(obstacle => obstacle.X == nextPosition.X && obstacle.Y == nextPosition.Y);
        }
    }
}