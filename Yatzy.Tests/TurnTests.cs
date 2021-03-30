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
            var diePlayerRerolls = "1";
            var originalFace = 4;
            var updatedFace = 6;
            var firstDie = new Die(new FakeRandom(new List<int> {originalFace, updatedFace}));
            turn.Dice = new List<Die> {firstDie};
            turn.Dice[0].Roll();
            turn.RerollDie(diePlayerRerolls);
            
            Assert.Equal(updatedFace, turn.Dice[0].Face);
        }

        [Fact]
        public void AllowForMultipleRerollsAtOnce()
        {
            var turn = new Turn();
            var diePlayerRerolls = "1,2";
            var originalFaceOfFirst = 6;
            var originalFaceOfSecond = 3;
            var updatedFaceOfFirst = 4;
            var updatedFaceOfSecond = 5;
            var firstDie = new Die(new FakeRandom(new List<int> {originalFaceOfFirst, updatedFaceOfFirst}));
            var secondDie = new Die(new FakeRandom(new List<int> {originalFaceOfSecond, updatedFaceOfSecond}));
            turn.Dice = new List<Die> {firstDie, secondDie};
            turn.Dice[0].Roll();
            turn.Dice[1].Roll();
            turn.RerollDie(diePlayerRerolls);
            Assert.Equal(updatedFaceOfFirst, turn.Dice[0].Face);
            Assert.Equal(updatedFaceOfSecond, turn.Dice[1].Face);



            

        }
    }
}