using System;
using System.Collections.Generic;
using MarsRover.Console;
using MarsRover.Enums;

namespace MarsRover
{
    public class Rover
    {
        public Point Position { get; private set; }
        public Direction Direction { get; private set; }
        private readonly Grid _grid;
        public Rover(Grid grid, Point position, Direction direction)
        {
            _grid = grid;
            Position = position;
            Direction = direction;
        }

        public Point CalculateNextPosition(Command command)
        {
            var nextPosition = Position;
            
            switch (Direction)
            {
                case Direction.North:
                    nextPosition = GetNextPositionWhenFacingNorth(command);
                    break;
                case Direction.South:
                    nextPosition = GetNextPositionWhenFacingSouth(command);
                    break;
                case Direction.East:
                    nextPosition = GetNextPositionWhenFacingEast(command);
                    break;
                case Direction.West:
                    nextPosition = GetNextPositionWhenFacingWest(command);
                    break;
            }
            return nextPosition;
        }

        private Point GetNextPositionWhenFacingWest(Command command)
        {
            var nextPosition = Position;
            switch (command)
            {
                case Command.Forward:
                    if (Position.X == 0)
                    {
                        nextPosition.X = _grid.Size - 1;
                    }
                    else
                    {
                        nextPosition.X = Position.X - 1;
                    }
                    break;
                case Command.Backward:
                    nextPosition.X = Position.X + 1;
                    break;
            }

            return nextPosition;
        }

        private Point GetNextPositionWhenFacingEast(Command command)
        {
            var nextPosition = Position;
            switch (command)
            {
                case Command.Forward:
                    if (Position.X == _grid.Size - 1)
                    {
                        nextPosition.X = 0;
                    }
                    else
                    {
                        nextPosition.X = Position.X + 1;
                    }
                    break;
                case Command.Backward:
                    nextPosition.X = Position.X - 1;
                    break;
            }
            return nextPosition;
        }

        private Point GetNextPositionWhenFacingSouth(Command command)
        {
            var nextPosition = Position;
            switch (command)
            {
                case Command.Forward:
                    if (Position.Y == _grid.Size - 1)
                    {
                        nextPosition.Y = 0;
                    }
                    else
                    {
                        nextPosition.Y = Position.Y + 1;
                    }
                    break;
                case Command.Backward:
                    nextPosition.Y = Position.Y - 1;
                    break;
            }

            return nextPosition;
        }

        private Point GetNextPositionWhenFacingNorth(Command command)
        {
            var nextPosition = Position;
            switch (command)
            {
                case Command.Forward:
                    if (Position.Y == 0)
                    {
                        nextPosition.Y = _grid.Size - 1;
                    }
                    else
                    {
                        nextPosition.Y = Position.Y - 1;
                    }
                    break;
                case Command.Backward:
                    nextPosition.Y = Position.Y + 1;
                    break;
            }

            return nextPosition;
        }

        private void Turn(Command command)
        {
            if (command == Command.Backward || command == Command.Forward)
                throw new ArgumentException("Rover can only turn left and right.");
            switch (Direction)
            {
                case Direction.North:
                    TurnWhenFacingNorth(command);
                    break;
                case Direction.South:
                    TurnWhenFacingSouth(command);
                    break;
                case Direction.East:
                    TurnWhenFacingEast(command);
                    break;
                case Direction.West:
                    TurnWhenFacingWest(command);
                    break;
            }
        }

        private void TurnWhenFacingWest(Command command)
        {
            Direction = command switch
            {
                Command.Left => Direction.South,
                Command.Right => Direction.North,
                _ => Direction
            };
        }

        private void TurnWhenFacingEast(Command command)
        {
            Direction = command switch
            {
                Command.Left => Direction.North,
                Command.Right => Direction.South,
                _ => Direction
            };
        }

        private void TurnWhenFacingSouth(Command command)
        {
            Direction = command switch
            {
                Command.Left => Direction.East,
                Command.Right => Direction.West,
                _ => Direction
            };
        }

        private void TurnWhenFacingNorth(Command command)
        {
            Direction = command switch
            {
                Command.Left => Direction.West,
                Command.Right => Direction.East,
                _ => Direction
            };
        }

        private void Move(Point nextPosition)
        {
            Position = nextPosition;
        }

        public List<string> Navigate(IEnumerable<Command> commands, Grid grid)
        {
            var navigationHistory = new List<string>();
            foreach (var command in commands)
            {
                if (command == Command.Forward || command == Command.Backward)
                {
                    var nextPosition = CalculateNextPosition(command);
                    if (grid.HasObstacleAt(nextPosition))
                    {
                        System.Console.WriteLine($"There is an obstacle at ({nextPosition.X},{nextPosition.Y}). \n" +
                                                    "The Rover cannot move further. The obstacle has been reported.");
                        break;
                    }                    
                    Move(nextPosition);
                    navigationHistory.Add($"The rover has moved {command.ToString()} to {Position}");

                }
                else
                {
                    Turn(command);
                    navigationHistory.Add($"The rover has turned {command.ToString()} to face {Direction.ToString()}");
                }

            }

            return navigationHistory;

        }
    }
}