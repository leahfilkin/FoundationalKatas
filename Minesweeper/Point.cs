using System;

namespace Minesweeper
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("You cannot have a point that's co-ordinates are negative");
            }

            X = x;
            Y = y;
        }
        
        public override string ToString()
        {
            return $"({X},{Y})";
        }
        
        public override bool Equals(object o)
        {
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            return o is Point otherPoint && X == otherPoint.X && Y == otherPoint.Y;
        }
        
        public override int GetHashCode()
        {
            return (X << 2) ^ Y;
        }
    }
    
    
}