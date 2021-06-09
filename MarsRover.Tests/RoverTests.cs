using System;
using MarsRover.Console;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        // [Fact]
        // public void ShouldHaveStartingCoords()
        // {
        //     var startingPosition = new Point(5, 3);
        //     var rover = new Rover(new Grid(), startingPosition,  Direction.North);
        //     Assert.Equal("(5,3)", rover.PositionToString());
        // }

        [Fact]
        public void ShouldHaveStartingDirection()
        {
            var startingPosition = new Point(1, 1);
            var rover = new Rover(new Grid(), startingPosition, Direction.North);
            Assert.Equal("North", rover.Direction.ToString());
        }

        [Theory]
        [InlineData(Direction.North, Command.Forward, "The rover has moved to (5,4)")]
        [InlineData(Direction.North, Command.Back, "The rover has moved to (5,6)")]
        [InlineData(Direction.South, Command.Forward, "The rover has moved to (5,6)")]
        [InlineData(Direction.South, Command.Back, "The rover has moved to (5,4)")]
        [InlineData(Direction.East, Command.Forward, "The rover has moved to (6,5)")]
        [InlineData(Direction.East, Command.Back, "The rover has moved to (4,5)")]
        [InlineData(Direction.West, Command.Forward, "The rover has moved to (4,5)")]
        [InlineData(Direction.West, Command.Back, "The rover has moved to (6,5)")]

        public void MoveToTheRightSpotFromDirectionDependingOnCommandGiven(Direction direction, Command command, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(), startingPosition, direction);
            var nextPosition = rover.CalculateNextPosition(command);
            var output = new Output();
            
            rover.Move(nextPosition);
            
            Assert.Equal(expected, output.PrintConfirmationOfMove(rover));
        }

        [Theory]
        [InlineData(Direction.North, "The rover has turned to face West")]
        [InlineData(Direction.South, "The rover has turned to face East")]
        [InlineData(Direction.West, "The rover has turned to face South")]
        [InlineData(Direction.East, "The rover has turned to face North")]

        public void TurnToLeft(Direction direction, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(), startingPosition, direction);
            var command = Command.Left;
            var output = new Output();

            rover.Turn(command);
            
            Assert.Equal(expected, output.PrintConfirmationOfTurn(rover));
        }

        [Theory]
        [InlineData(Direction.North, "The rover has turned to face East")]
        [InlineData(Direction.South, "The rover has turned to face West")]
        [InlineData(Direction.East, "The rover has turned to face South")]
        [InlineData(Direction.West, "The rover has turned to face North")]
        public void TurnToRight(Direction direction, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(), startingPosition, direction);
            var command = Command.Right;
            var output = new Output();

            rover.Turn(command);
            
            Assert.Equal(expected, output.PrintConfirmationOfTurn(rover));
        }
        
        [Theory]
        [InlineData(Direction.North, 0, 0, "(0,9)")]
        [InlineData(Direction.South, 3, 9, "(3,0)")]
        [InlineData(Direction.West, 0, 4, "(9,4)")]
        [InlineData(Direction.East, 9, 6, "(0,6)")]
        
        public void WrapWhenRoverMovesForwardOffEdge(Direction direction, int x, int y, string expected)
        {
            var startingPosition = new Point(x, y);
            var rover = new Rover(new Grid(), startingPosition, direction);
            var output = new Output();
            var nextPosition = rover.CalculateNextPosition(Command.Forward);
            
            rover.Move(nextPosition);
            
            Assert.Equal(expected, output.ToString(rover.Position));
        }

        [Fact]
        public void IdentifiesObstacleWhenItIsInRoversPath()
        {
            var startingPosition = new Point(0, 0);
            var grid = new Grid();
            var rover = new Rover(grid, startingPosition, Direction.South);
            var nextPosition = rover.CalculateNextPosition(Command.Forward);

            Assert.Throws<ArgumentException>(() => Rover.CheckForObstacleAt(nextPosition, grid));
        }

        [Fact]
        public void UpdatePositionAfterSuccessfulMove()
        {
            var rover = new Rover(new Grid(), new Point(5,5), Direction.North);
            var nextPosition = rover.CalculateNextPosition(Command.Forward);
            var output = new Output();
            
            rover.Move(nextPosition);
            
            Assert.Equal("The rover has moved to (5,4)", output.PrintConfirmationOfMove(rover));
        }

        // [Fact]
        // public void AcceptsMultipleCommands()
        // {
        //     var rover = new Rover(new Grid(), new Point(5,5), Direction.North);
        //     var actual = rover.Move(new [] {'f', 'l', 'f'});
        //     Assert.Equal("")
        //     
        // }

        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.South)]
        [InlineData(Direction.East)]
        [InlineData(Direction.West)]
        public void IfTurnArgumentNotValidThrowError(Direction direction)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(), startingPosition, direction);

            Assert.Throws<ArgumentException>(() => rover.Turn(Command.Forward));
        }
    }
}