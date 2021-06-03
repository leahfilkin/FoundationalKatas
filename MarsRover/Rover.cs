
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private readonly Point _position;
        private char _direction;
        public Rover(Point point, char direction)
        {
            _position = point;
            _direction = direction;
        }

        public string PositionToString()
        {
            return $"({_position.X},{_position.Y})";
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
                    if (_position.X == 0)
                    {
                        _position.X = new Grid().Size - 1;
                    }
                    break;
                case 'b':
                    _position.X += 1;
                    break;
            }
        }

        private void MoveWhenFacingEast(char command)
        {
            switch (command)
            {
                case 'f':
                    if (_position.X == new Grid().Size - 1)
                    {
                        _position.X = 0;
                    }
                    break;
                case 'b':
                    _position.X -= 1;
                    break;
            }
        }

        private void MoveWhenFacingSouth(char command)
        {
            switch (command)
            {
                case 'f':
                    if (_position.Y == new Grid().Size - 1)
                    {
                        _position.Y = 0;
                    }
                    break;
                case 'b':
                    _position.Y -= 1;
                    break;
            }
        }

        private void MoveWhenFacingNorth(char command)
        {
            switch (command)
            {
                case 'f':
                    if (_position.Y == 0)
                    {
                        _position.Y = new Grid().Size - 1;
                    }
                    else
                    {
                        _position.Y -= 1;
                    }
                    break;
                case 'b':
                    _position.Y += 1;
                    break;
            }
        }

        public void Turn(char command)
        {
            switch (_direction)
            {
                case 'N':
                    TurnWhenFacingNorth(command);
                    break;
                case 'S':
                    TurnWhenFacingSouth(command);
                    break;
                case 'E':
                    TurnWhenFacingEast(command);
                    break;
                case 'W':
                    TurnWhenFacingWest(command);
                    break;
            };
        }

        private void TurnWhenFacingWest(char command)
        {
            _direction = command switch
            {
                'l' => 'S',
                'r' => 'N',
                _ => _direction
            };
        }

        private void TurnWhenFacingEast(char command)
        {
            _direction = command switch
            {
                'l' => 'N',
                'r' => 'S',
                _ => _direction
            };
        }

        private void TurnWhenFacingSouth(char command)
        {
            _direction = command switch
            {
                'l' => 'E',
                'r' => 'W',
                _ => _direction
            };
        }

        private void TurnWhenFacingNorth(char command)
        {
            _direction = command switch
            {
                'l' => 'W',
                'r' => 'E',
                _ => _direction
            };
        }

        public bool ObserveObstacles(Grid grid)
        {
            if (grid.Obstacles.SelectMany(obstacle => obstacle)
                .Any(coordinate => coordinate == _position.X - 1 
                                   || coordinate == _position.X + 1
                                   || coordinate == _position.Y - 1
                                   || coordinate == _position.Y + 1))
            {
                return true;
            }
            return false;
        }
    }
}