using System.Collections.Generic;
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

        [Fact]
        public void GivenIndexRerollDie()
        {
            var turn = new Turn();
            var indexOfDiePlayerRerolls = 0;
            var originalFace = 4;
            var updatedFace = 6;
            var firstDie = new Die(new FakeRandom(new List<int> {originalFace, updatedFace}));
            turn.Dice = new List<Die> {firstDie};
            turn.RerollDie(indexOfDiePlayerRerolls);
            
            Assert.Equal(updatedFace, turn.Dice[indexOfDiePlayerRerolls].Face);


        }
    }
}