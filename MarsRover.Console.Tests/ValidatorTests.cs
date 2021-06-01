using System;
using Xunit;

namespace MarsRover.Console.Tests
{
    public class ValidatorTests
    {
        [Fact]
        public void ReturnFalseIfPositionTooBigForGrid()
        {
            var grid = new Grid(3);
            Assert.False(Validator.IsStartingPositionValid("5,2", grid));
        }

        [Fact]
        public void ReturnTrueIfPositionFitsOnGrid()
        {
            var grid = new Grid(7);
            Assert.True(Validator.IsStartingPositionValid("5,2", grid));
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ThrowExceptionIfGridSizeIsInvalid(int gridSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Validator.IsGridSizeValid(gridSize));
        }

        // check char array doesnt have any characters that dont indicate directions
    }
}