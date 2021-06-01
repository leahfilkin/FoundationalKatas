using System;

namespace MarsRover
{
    public class Grid
    {
        public int Size;

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
        }
    }
}