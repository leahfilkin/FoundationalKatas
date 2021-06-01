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
        
        [Fact]
        public void ThrowExceptionIfGridSizeIsNegative()
        {
            var gridSize = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => Validator.IsGridSizeValid(gridSize));
        }

        [Fact]
        public void ThrowExceptionIfGridSizeIs0()
        {
            var gridSize = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => Validator.IsGridSizeValid(gridSize));
        }


        // check char array doesnt have any characters that dont indicate directions
    }
}