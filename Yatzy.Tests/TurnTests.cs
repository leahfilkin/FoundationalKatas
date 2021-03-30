using System;
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
            var turn = new Turn(new Random());
            turn.MakeFirstRoll();
            
            Assert.Equal(5, turn.Dice.Count);
        }

        [Fact]
        public void AllowForMultipleRerollsAtOnce()
        {
            var firstFace = 6;
            var secondFace = 4;
            var random = new FakeRandom(new List<int> {firstFace, secondFace});
            var turn = new Turn(random);
            var diePlayerRerolls = "1,2";
            turn.RerollDie(diePlayerRerolls);
            Assert.Equal(firstFace, turn.Dice[0].GetFace());
            Assert.Equal(secondFace, turn.Dice[1].GetFace());
        }
    }
}