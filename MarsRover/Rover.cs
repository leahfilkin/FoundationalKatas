
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
            switch (_direction)
            {
                case 'N':
                    MoveWhenFacingNorth(command);
                    break;
                case 'S':
                    MoveWhenFacingSouth(command);
                    break;
                case 'E':
                    MoveWhenFacingEast(command);
                    break;
                case 'W':
                    MoveWhenFacingWest(command);
                    break;
            }
        }

        private void MoveWhenFacingWest(char command)
        {
            switch (command)
            {
                case 'f':
                    _x -= 1;
                    break;
                case 'b':
                    _x += 1;
                    break;
            }
        }

        private void MoveWhenFacingEast(char command)
        {
            switch (command)
            {
                case 'f':
                    _x += 1;
                    break;
                case 'b':
                    _x -= 1;
                    break;
            }
        }

        private void MoveWhenFacingSouth(char command)
        {
            switch (command)
            {
                case 'f':
                    _y += 1;
                    break;
                case 'b':
                    _y -= 1;
                    break;
            }
        }

        private void MoveWhenFacingNorth(char command)
        {
            switch (command)
            {
                case 'f':
                    _y -= 1;
                    break;
                case 'b':
                    _y += 1;
                    break;
            }
        }

        public void Turn(char command)
        {
            if (_direction == 'N')
            {
                _direction = 'W';
            }

            if (_direction == 'S')
            {
                _direction = 'E';
            }
        }
    }
}