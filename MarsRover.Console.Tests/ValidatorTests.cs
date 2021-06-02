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
            var point = new Point(5, 2);
            Assert.False(Validator.IsPositionValid(point, grid));
        }

        [Fact]
        public void ReturnTrueIfPositionFitsOnGrid()
        {
            var grid = new Grid(7);
            var point = new Point(5, 2);
            Assert.True(Validator.IsPositionValid(point, grid));
        }
        // check char array doesnt have any characters that dont indicate directions
    }
}