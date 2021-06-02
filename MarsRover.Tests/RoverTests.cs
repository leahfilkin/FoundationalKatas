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

        [Fact]
        public void RoverShouldMoveForward()
        {
            var rover = new Rover(2, 1, 'N');
            var command = 'f';
            rover.Move(command);
            Assert.Equal("(1,1)", rover.PositionToString());
        }

        [Fact]
        public void RoverShouldMoveBackward()
        {
            var rover = new Rover(2, 1, 'N');
            var command = 'b';
            rover.Move(command);
            Assert.Equal("(3,1)", rover.PositionToString());
        }
    }
}