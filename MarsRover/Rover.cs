
namespace MarsRover
{
    public class Rover
    {
        private int _x;
        private int _y;
        private readonly char _direction;
        public Rover(int x, int y, char direction)
        {
            _x = x;
            _y = y;
            _direction = direction;
        }

        public string PositionToString()
        {
            return $"({_x},{_y})";
        }

        public string DirectionToString()
        {
            return _direction switch
            {
                'N' => "North",
                'S' => "South",
                'E' => "East",
                'W' => "West",
                _ => ""
            };
        }

        public void Move(char command)
        {
            _x -= 1;
        }
    }
}