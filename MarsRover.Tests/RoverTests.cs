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
            Assert.Equal("(5,3)", rover.Position.ToString());
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
            var grid = new Grid(new FakeRandom(new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}));
            var rover = new Rover(grid, startingPosition, direction);
            var commands = new List<Command> {command};
            rover.Navigate(commands, grid);
            
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
            var grid = new Grid(new FakeRandom(new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}));
            var rover = new Rover(grid, startingPosition, direction);
            var commands = new List<Command> {Command.Left};

            rover.Navigate(commands, grid);
            
            Assert.Equal(expected, Output.ConfirmTurn(rover, Command.Left));
        }

        [Theory]
        [InlineData(Direction.North, "The rover has turned Right to face East")]
        [InlineData(Direction.South, "The rover has turned Right to face West")]
        [InlineData(Direction.East, "The rover has turned Right to face South")]
        [InlineData(Direction.West, "The rover has turned Right to face North")]
        public void TurnToRight(Direction direction, string expected)
        {
            var startingPosition = new Point(5, 5);
            var grid = new Grid(new FakeRandom(new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}));
            var rover = new Rover(grid, startingPosition, direction);
            var commands = new List<Command> {Command.Right};

            rover.Navigate(commands, grid);
            
            Assert.Equal(expected, Output.ConfirmTurn(rover, Command.Right));
        }
        
        [Theory]
        [InlineData(Direction.North, 0, 0, "(0,9)")]
        [InlineData(Direction.South, 3, 9, "(3,0)")]
        [InlineData(Direction.West, 0, 4, "(9,4)")]
        [InlineData(Direction.East, 9, 6, "(0,6)")]
        
        public void WrapWhenRoverMovesForwardOffEdge(Direction direction, int x, int y, string expected)
        {
            var startingPosition = new Point(x, y);
            var grid = new Grid(new FakeRandom(new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}));
            var rover = new Rover(grid, startingPosition, direction);
            var commands = new List<Command> {Command.Forward};
            
            rover.Navigate(commands, grid);
            
            Assert.Equal(expected, rover.Position.ToString());
        }

        [Fact]
        public void ReturnsTrueIfObstacleInRoversNextPosition()
        {
            var grid = new Grid(new FakeRandom(new List<int> {0, 1, 0, 0, 0, 0, 0, 0, 0, 0}));
            var nextPosition = new Point(0, 1);

            Assert.True(grid.HasObstacleAt(nextPosition));

        }

        [Fact]
        public void AcceptsMultipleCommands()
        {
            var grid = new Grid(new FakeRandom(new List<int> {0,0,0,0,0,0,0,0,0,0}));
            var rover = new Rover(grid, new Point(5,5), Direction.North);
            var commands = new List<Command> {Command.Forward, Command.Right, Command.Forward};
            
            rover.Navigate(commands, grid);
            
            Assert.Equal("(6,4)", rover.Position.ToString());

        }
    }
}