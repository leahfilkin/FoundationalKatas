using System;

namespace MarsRover.Console
{
    public static class Validator
    {
        public static bool CheckIfPositionIsValid(Point point, Grid grid)
        {
            if (Math.Max(point.X, point.Y) > grid.Size)
            {
                throw new ArgumentException("Your coordinates cannot extend past the grid");
            }
            return true;
        }
    }
}