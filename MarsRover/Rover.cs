using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        private int _x;
        private int _y;
        private char _direction;
        public Rover(int x, int y, char direction)
        {
            _x = x;
            _y = y;
            _direction = direction;
        }

        public string GetPosition()
        {
            return $"({_x},{_y})";
        }

        public IEnumerable<char> GetDirection()
        {
            return _direction switch
            {
                'N' => "North",
                'S' => "South",
                'E' => "East",
                'W' => "West"
            };
        }
    }
}