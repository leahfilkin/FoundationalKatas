using System;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Fact]
        public void ShouldHaveStartingCoords()
        {
            var rover = new Rover(5, 3, 'N');
            Assert.Equal("(5,3)", rover.PositionToString());
        }

        [Fact]
        public void ShouldHaveStartingDirection()
        {
            var rover = new Rover(1, 1, 'N');
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

        public void MoveToTheRightSpotDependingOnDirectionAndCommandGiven(char direction, char command, string expected)
        {
            var rover = new Rover(5,5, direction);
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
            var rover = new Rover(5, 5, direction);
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
            var rover = new Rover(5, 5, direction);
            rover.Turn('r');
            Assert.Equal(expected, rover.DirectionToString());
        }
        
    }
}