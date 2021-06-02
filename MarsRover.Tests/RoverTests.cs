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
        [InlineData('N', 'f', "(4,5)")]
        [InlineData('N', 'b', "(6,5)")]
        [InlineData('S', 'f', "(6,5)")]
        [InlineData('S', 'b', "(4,5)")]


        public void RoverShouldMoveToTheRightSpotDependingOnDirectionAndCommandGiven(char direction, char command, string expected)
        {
            var rover = new Rover(5,5, direction);
            rover.Move(command);
            Assert.Equal(expected, rover.PositionToString());
        }
    }
}