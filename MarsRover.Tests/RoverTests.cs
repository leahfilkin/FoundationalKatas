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
            Assert.Equal("(5,3)", rover.GetPosition());
        }

        [Fact]
        public void ShouldHaveStartingDirection()
        {
            var rover = new Rover(1, 1, 'N');
            Assert.Equal("North", rover.GetDirection());
        }
    }
}