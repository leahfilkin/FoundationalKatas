using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Console
{
    public class Validator
    {

        public static bool IsStartingPositionValid(string position, Grid grid)
        {
            var coords = Array.ConvertAll(position.Split(","), int.Parse);
            return coords.All(axis => axis <= grid.Size);
        }

        public static object AreInstructionsValid(char[] instructions)
        {
            throw new NotImplementedException();
        }

        public static bool IsGridSizeValid(int gridSize)
        {
            if (gridSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gridSize),
                    "You cannot have a grid that's size is negative");
            }

            if (gridSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gridSize),
                    "You cannot have a grid that's size is 0");            }
            return true;
        }
    }
}