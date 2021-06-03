using System;
using Xunit;

namespace MarsRover.Tests
{
    public class GridTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-50)]
        public void ThrowExceptionIfGridSizeIsInvalid(int gridSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(gridSize));
        }

        [Fact]
        public void HasObstacles()
        {
            var grid = new Grid();

            Assert.NotEmpty(grid.Obstacles);
        }
    }
}