using System;
using System.Collections.Generic;
using MarsRover.Console;
using MarsRover.Enums;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Fact]
        public void ShouldHaveStartingCoords()
        {
            var startingPosition = new Point(5, 3);
            var rover = new Rover(new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0})), startingPosition,  Direction.North);
            Assert.Equal("(5,3)", Output.ToString(rover.Position));
        }

        [Fact]
        public void ShouldHaveStartingDirection()
        {
            var startingPosition = new Point(1, 1);
            var rover = new Rover(new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0})), startingPosition, Direction.North);
            Assert.Equal("North", rover.Direction.ToString());
        }

        [Theory]
        [InlineData(Direction.North, Command.Forward, "The rover has moved Forward to (5,4)")]
        [InlineData(Direction.North, Command.Backward, "The rover has moved Backward to (5,6)")]
        [InlineData(Direction.South, Command.Forward, "The rover has moved Forward to (5,6)")]
        [InlineData(Direction.South, Command.Backward, "The rover has moved Backward to (5,4)")]
        [InlineData(Direction.East, Command.Forward, "The rover has moved Forward to (6,5)")]
        [InlineData(Direction.East, Command.Backward, "The rover has moved Backward to (4,5)")]
        [InlineData(Direction.West, Command.Forward, "The rover has moved Forward to (4,5)")]
        [InlineData(Direction.West, Command.Backward, "The rover has moved Backward to (6,5)")]

        public void MoveToTheRightSpotFromDirectionDependingOnCommandGiven(Direction direction, Command command, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0})), startingPosition, direction);
            var nextPosition = rover.CalculateNextPosition(command);
            
            rover.Move(nextPosition);
            
            Assert.Equal(expected, Output.ConfirmMove(rover, command));
        }

        [Theory]
        [InlineData(Direction.North, "The rover has turned Left to face West")]
        [InlineData(Direction.South, "The rover has turned Left to face East")]
        [InlineData(Direction.West, "The rover has turned Left to face South")]
        [InlineData(Direction.East, "The rover has turned Left to face North")]

        public void TurnToLeft(Direction direction, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0})), startingPosition, direction);
            var command = Command.Left;

            rover.Turn(command);
            
            Assert.Equal(expected, Output.ConfirmTurn(rover, command));
        }

        [Theory]
        [InlineData(Direction.North, "The rover has turned Right to face East")]
        [InlineData(Direction.South, "The rover has turned Right to face West")]
        [InlineData(Direction.East, "The rover has turned Right to face South")]
        [InlineData(Direction.West, "The rover has turned Right to face North")]
        public void TurnToRight(Direction direction, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0})), startingPosition, direction);
            var command = Command.Right;

            rover.Turn(command);
            
            Assert.Equal(expected, Output.ConfirmTurn(rover, command));
        }
        
        [Theory]
        [InlineData(Direction.North, 0, 0, "(0,9)")]
        [InlineData(Direction.South, 3, 9, "(3,0)")]
        [InlineData(Direction.West, 0, 4, "(9,4)")]
        [InlineData(Direction.East, 9, 6, "(0,6)")]
        
        public void WrapWhenRoverMovesForwardOffEdge(Direction direction, int x, int y, string expected)
        {
            var startingPosition = new Point(x, y);
            var rover = new Rover(new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0})), startingPosition, direction);
            var nextPosition = rover.CalculateNextPosition(Command.Forward);
            
            rover.Move(nextPosition);
            
            Assert.Equal(expected, Output.ToString(rover.Position));
        }

        [Fact]
        public void IdentifiesObstacleWhenItIsInRoversPath()
        {
            var startingPosition = new Point(0, 0);
            var grid = new Grid(new FakeRandom(new List<int> {0,1,0,0,0,0,0,0,0,0}));
            var rover = new Rover(grid, startingPosition, Direction.South);
            var nextPosition = rover.CalculateNextPosition(Command.Forward);

            Assert.Throws<ArgumentException>(() => Rover.CheckForObstacleAt(nextPosition, grid));
        }

        [Fact]
        public void UpdatePositionAfterSuccessfulMove()
        {
            var rover = new Rover(new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0})), new Point(5,5), Direction.North);
            var nextPosition = rover.CalculateNextPosition(Command.Forward);

            rover.Move(nextPosition);
            
            Assert.Equal("The rover has moved Forward to (5,4)", Output.ConfirmMove(rover, Command.Forward));
        }

        [Fact]
        public void AcceptsMultipleCommands()
        {
            var grid = new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0}));
            var rover = new Rover(grid, new Point(5,5), Direction.North);
            var commands = new List<Command> {Command.Forward, Command.Right, Command.Forward};
            
            rover.Navigate(commands, grid);
            
            Assert.Equal("(6,4)", Output.ToString(rover.Position));

        }

        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.South)]
        [InlineData(Direction.East)]
        [InlineData(Direction.West)]
        public void IfTurnArgumentNotValidThrowError(Direction direction)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0})), startingPosition, direction);

            Assert.Throws<ArgumentException>(() => rover.Turn(Command.Forward));
        }
    }
}