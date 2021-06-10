using System;
using Xunit;

namespace MarsRover.Console.Tests
{
    public class ValidatorTests
    {
        [Fact]
        public void ThrowsExceptionIfPositionTooBigForGrid()
        {
            var grid = new Grid(new Random(), 3);
            var point = new Point(5, 2);
            Assert.Throws<ArgumentException>( () => Validator.CheckIfPositionIsValid(point, grid));
        }

        [Fact]
        public void ReturnTrueIfPositionFitsOnGrid()
        {
            var grid = new Grid(new Random(), 7);
            var point = new Point(5, 2);
            Assert.True(Validator.CheckIfPositionIsValid(point, grid));
        }
    }
}