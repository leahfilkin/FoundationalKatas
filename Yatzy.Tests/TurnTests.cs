using System.Linq;
using Xunit;

namespace Yatzy.Tests
{
    public class TurnTests
    {
        [Fact]
        public void RollsFiveDice()
        {
            var turn = new Turn();
            turn.MakeFirstRoll();
            
            Assert.Equal(5, turn.Dice.Count);
        }
    }
}