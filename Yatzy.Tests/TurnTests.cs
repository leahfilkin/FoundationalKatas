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
            var originalFace = 1;
            var firstFace = 5;
            var secondFace = 4;
            var random = new FakeRandom(new List<int> {originalFace, firstFace, secondFace, 1, 2, 4, 5});
            var turn = new Turn(random);
            var diePlayerRerolls = "1,2";
            turn.RerollDie(diePlayerRerolls);
            Assert.Equal(originalFace, turn.GetFaceOfDie(turn.Dice[0]));
            Assert.Equal(firstFace, turn.GetFaceOfDie(turn.Dice[1]));
        }

        [Fact]
        public void PlayerPicksCategoryForTurn()
        {
            var categoryInput = "three of a kind";
            var random = new FakeRandom(new List<int> {3, 3, 3, 3, 4});
            var turn = new Turn(random);
            var userInput = new UserInput();
            Assert.Equal(Category.ThreeOfAKind, turn.GetCategory(categoryInput));
        }
    }
}