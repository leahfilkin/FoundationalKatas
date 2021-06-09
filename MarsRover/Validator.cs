using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Console
{
    public class Validator
    {
        public static bool IsPositionValid(Point point, Grid grid)
        {
            if (Math.Max(point.X, point.Y) > grid.Size)
            {
                throw new ArgumentException("Your coordinates cannot extend past the grid");
            }
            return true;
        }
    }
}