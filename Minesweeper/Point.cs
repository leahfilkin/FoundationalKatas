using System;

namespace Minesweeper
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("You cannot have a point that's co-ordinates are negative");
            }

            // if (x > 10 || y > 10)
            // {
            //     throw new ArgumentException("You cannot have a point that's co-ordinates are larger than the field.");
            // }
            
            X = x;
            Y = y;
        }
        
        public override string ToString()
        {
            return $"({X},{Y})";
        }
        
        public bool Equals(Point givenPoint)
        {
            return X == givenPoint.X && Y == givenPoint.Y;

        }
    }
    
    
}