using System;
using Xunit;
using Xunit.Sdk;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Fact]
        public void ShouldHaveStartingCoords()
        {
            var startingPosition = new Point(5, 3);
            var rover = new Rover(new Grid(), startingPosition,  'N');
            Assert.Equal("(5,3)", rover.PositionToString());
        }

        [Fact]
        public void ShouldHaveStartingDirection()
        {
            var startingPosition = new Point(1, 1);
            var rover = new Rover(new Grid(), startingPosition, 'N');
            Assert.Equal("North", rover.DirectionToString());
        }

        [Theory]
        [InlineData('N', 'f', "(5,4)")]
        [InlineData('N', 'b', "(5,6)")]
        [InlineData('S', 'f', "(5,6)")]
        [InlineData('S', 'b', "(5,4)")]
        [InlineData('E', 'f', "(6,5)")]
        [InlineData('E', 'b', "(4,5)")]
        [InlineData('W', 'f', "(4,5)")]
        [InlineData('W', 'b', "(6,5)")]

        public void MoveToTheRightSpotFromDirectionDependingOnCommandGiven(char direction, char command, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(), startingPosition, direction);
            rover.Move(command);
            Assert.Equal(expected, rover.PositionToString());
        }

        [Theory]
        [InlineData('N', "West")]
        [InlineData('S', "East")]
        [InlineData('W', "South")]
        [InlineData('E', "North")]

        public void TurnToLeft(char direction, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(), startingPosition, direction);
            rover.Turn('l');
            Assert.Equal(expected,rover.DirectionToString());
        }

        [Theory]
        [InlineData('N', "East")]
        [InlineData('S', "West")]
        [InlineData('E', "South")]
        [InlineData('W', "North")]
        public void TurnToRight(char direction, string expected)
        {
            var startingPosition = new Point(5, 5);
            var rover = new Rover(new Grid(), startingPosition, direction);
            rover.Turn('r');
            Assert.Equal(expected, rover.DirectionToString());
        }
        
        [Theory]
        [InlineData('N', 0, 0, "(0,9)")]
        [InlineData('S', 3, 9, "(3,0)")]
        [InlineData('W', 0, 4, "(9,4)")]
        [InlineData('E', 9, 6, "(0,6)")]
        
        public void WrapWhenRoverMovesForwardOffEdge(char direction, int x, int y, string expected)
        {
            var startingPosition = new Point(x, y);
            var rover = new Rover(new Grid(), startingPosition, direction);
            rover.Move('f');
            Assert.Equal(expected, rover.PositionToString());
        }

        [Fact]
        public void IdentifiesObstacleWhenItIsInRoversPath()
        {
            var startingPosition = new Point(0, 0);
            var rover = new Rover(new Grid(), startingPosition, 'S');
            rover.GetNextPosition('f');
            Assert.True(rover.ObserveObstacle());
        }

        [Fact]
        public void UpdatePositionAfterSuccessfulMove()
        {
            var rover = new Rover(new Grid(), new Point(5,5), 'N');
            rover.Move('f');
            Assert.Equal("(5,4)", rover.PositionToString());


        }
    }
}