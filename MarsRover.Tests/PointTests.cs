using System;
using Xunit;

namespace MarsRover.Tests
{
    public class PointTests
    {
        [Fact]
        public void ThrowsExceptionIfCoordsAreNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Point(-1, -1));
        }
    }
}