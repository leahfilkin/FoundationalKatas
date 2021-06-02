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

        [Fact]
        public void EndWestWhenTurningLeftFromNorth()
        {
            var rover = new Rover(5, 5, 'N');
            rover.Turn('l');
            Assert.Equal("West",rover.DirectionToString());
        }
        
    }
}