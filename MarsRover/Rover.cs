using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private Point _position;
        private char _direction;
        private readonly Grid _grid;
        public Rover(Grid grid, Point position, char direction)
        {
            _grid = grid;
            _position = position;
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

        public Point GetNextPosition(char command)
        {
            var nextPosition = _position;
            switch (_direction)
            {
                case 'N':
                    nextPosition = GetNextPositionWhenFacingNorth(command);
                    break;
                case 'S':
                    nextPosition = GetNextPositionWhenFacingSouth(command);
                    break;
                case 'E':
                    nextPosition = GetNextPositionWhenFacingEast(command);
                    break;
                case 'W':
                    nextPosition = GetNextPositionWhenFacingWest(command);
                    break;
            }
            return nextPosition;
        }

        private Point GetNextPositionWhenFacingWest(char command)
        {
            var nextPosition = _position;
            switch (command)
            {
                case 'f':
                    if (_position.X == 0)
                    {
                        nextPosition.X = _grid.Size - 1;
                    }
                    else
                    {
                        nextPosition.X = _position.X - 1;
                    }
                    break;
                case 'b':
                    nextPosition.X = _position.X + 1;
                    break;
            }

            return nextPosition;
        }

        private Point GetNextPositionWhenFacingEast(char command)
        {
            var nextPosition = _position;
            switch (command)
            {
                case 'f':
                    if (_position.X == _grid.Size - 1)
                    {
                        nextPosition.X = 0;
                    }
                    else
                    {
                        nextPosition.X = _position.X + 1;
                    }
                    break;
                case 'b':
                    nextPosition.X = _position.X - 1;
                    break;
            }
            return nextPosition;
        }

        private Point GetNextPositionWhenFacingSouth(char command)
        {
            var nextPosition = _position;
            switch (command)
            {
                case 'f':
                    if (_position.Y == _grid.Size - 1)
                    {
                        nextPosition.Y = 0;
                    }
                    else
                    {
                        nextPosition.Y = _position.Y + 1;
                    }
                    break;
                case 'b':
                    nextPosition.Y = _position.Y - 1;
                    break;
            }

            return nextPosition;
        }

        private Point GetNextPositionWhenFacingNorth(char command)
        {
            var nextPosition = _position;
            switch (command)
            {
                case 'f':
                    if (_position.Y == 0)
                    {
                        nextPosition.Y = _grid.Size - 1;
                    }
                    else
                    {
                        nextPosition.Y = _position.Y - 1;
                    }
                    break;
                case 'b':
                    nextPosition.Y = _position.Y + 1;
                    break;
            }

            return nextPosition;
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


        public string Move(char command)
        {
            var nextPosition = GetNextPosition(command);
            if (_grid.HasObstacleAt(nextPosition))
            {
                return GetObstacleInformation(nextPosition);
            }
            _position = nextPosition;
            return $"The rover has moved to {PositionToString()}";
        }

        private string GetObstacleInformation(Point nextPosition)
        {
            return $"There is an obstacle at ({nextPosition.X}, {nextPosition.Y}. \n" +
                   "The Rover cannot move further. The obstacle has been reported.";
        }
    }
}