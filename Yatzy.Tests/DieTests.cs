using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class DieTests
    {
        [Fact]
        public void RollReturnsRandomNumber()
        {
            var firstRoll = 1;
            var secondRoll = 2;
            var die = new Die(new FakeRandom(new List<int>{firstRoll, secondRoll}));
            die.Roll();
            Assert.Equal(firstRoll, die.Face);
            die.Roll();
            Assert.Equal(secondRoll, die.Face);
        }
    }
}