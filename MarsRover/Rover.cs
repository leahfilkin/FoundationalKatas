using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private readonly Point _position;
        private char _direction;
        private readonly Grid _grid;
        private Point _nextPosition;
        public Rover(Grid grid, Point position, char direction)
        {
            _grid = grid;
            _position = position;
            _direction = direction;
            _nextPosition = _position;
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

        public void GetNextPosition(char command)
        {
            switch (_direction)
            {
                case 'N':
                    GetNextPositionWhenFacingNorth(command);
                    break;
                case 'S':
                    GetNextPositionWhenFacingSouth(command);
                    break;
                case 'E':
                    GetNextPositionWhenFacingEast(command);
                    break;
                case 'W':
                    GetNextPositionWhenFacingWest(command);
                    break;
            }
        }

        private void GetNextPositionWhenFacingWest(char command)
        {
            switch (command)
            {
                case 'f':
                    if (_position.X == 0)
                    {
                        _nextPosition.X = _grid.Size - 1;
                    }
                    else
                    {
                        _nextPosition.X = _position.X -= 1;
                    }
                        break;
                case 'b':
                    _nextPosition.X = _position.X += 1;
                    break;
            }
        }

        private void GetNextPositionWhenFacingEast(char command)
        {
            switch (command)
            {
                case 'f':
                    if (_position.X == _grid.Size - 1)
                    {
                        _nextPosition.X = 0;
                    }
                    else
                    {
                        _nextPosition.X = _position.X += 1;
                    }
                    break;
                case 'b':
                    _nextPosition.X = _position.X -= 1;
                    break;
            }
            
        }

        private void GetNextPositionWhenFacingSouth(char command)
        {
            switch (command)
            {
                case 'f':
                    if (_position.Y == _grid.Size - 1)
                    {
                        _nextPosition.Y = 0;
                    }
                    else
                    {
                        _nextPosition.Y = _position.Y += 1;
                    }
                    break;
                case 'b':
                    _nextPosition.Y = _position.Y -= 1;
                    break;
            }
        }

        private void GetNextPositionWhenFacingNorth(char command)
        {
            switch (command)
            {
                case 'f':
                    if (_position.Y == 0)
                    {
                        _nextPosition.Y = _grid.Size - 1;
                    }
                    else
                    {
                        _nextPosition.Y = _position.Y -= 1;
                    }
                    break;
                case 'b':
                    _nextPosition.Y = _position.Y += 1;
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
            }
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
        
        public bool ObserveObstacle()
        {
            return _grid.Obstacles.Any(obstacle => obstacle.X == _nextPosition.X && obstacle.Y == _nextPosition.Y);
        }
    }
}