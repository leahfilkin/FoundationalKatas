
using System;
using System.Collections.Generic;

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
                case Command.Back:
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
                case Command.Back:
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
                case Command.Back:
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
                case Command.Back:
                    nextPosition.Y = Position.Y + 1;
                    break;
            }

            return nextPosition;
        }

        public void Turn(Command command)
        {
            if (command == Command.Back || command == Command.Forward)
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
            };
        }

        private void TurnWhenFacingEast(Command command)
        {
            Direction = command switch
            {
                Command.Left => Direction.North,
                Command.Right => Direction.South,
            };
        }

        private void TurnWhenFacingSouth(Command command)
        {
            Direction = command switch
            {
                Command.Left => Direction.East,
                Command.Right => Direction.West,
            };
        }

        private void TurnWhenFacingNorth(Command command)
        {
            Direction = command switch
            {
                Command.Left => Direction.West,
                Command.Right => Direction.East,
            };
        }

        public void Move(Point nextPosition)
        {
            Position = nextPosition;
        }

        public static void CheckForObstacleAt(Point nextPosition, Grid grid)
        {
            if (grid.HasObstacleAt(nextPosition))
            {
                throw new ArgumentException($"There is an obstacle at ({nextPosition.X},{nextPosition.Y}). \n" +
                                            "The Rover cannot move further. The obstacle has been reported.");
            }
        }
    }
}