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
            var player = new Player();
            var turn = new Turn(new Random(), player);
            turn.MakeFirstRoll();
            
            Assert.Equal(5, turn.Dice.Count);
        }

        [Fact]
        public void AllowForMultipleRerollsAtOnce()
        {
            var originalFace = 1;
            var firstFace = 5;
            var secondFace = 4;
            var player = new Player();
            var random = new FakeRandom(new List<int> {originalFace, firstFace, secondFace, 1, 2, 4, 5});
            var turn = new Turn(random, player);
            var diePlayerRerolls = "1,2";
            turn.RerollDie(diePlayerRerolls);
            Assert.Equal(originalFace, turn.GetFaceOfDie(turn.Dice[0]));
            Assert.Equal(firstFace, turn.GetFaceOfDie(turn.Dice[1]));
        }

        [Fact]
        public void PlayerPicksCategoryForTurn()
        {
            var categoryInput = "three of a kind";
            var player = new Player();
            var random = new FakeRandom(new List<int> {3, 3, 3, 3, 4});
            var turn = new Turn(random, player);
            Assert.Equal(Category.ThreeOfAKind, turn.GetCategory(categoryInput, player.CategoriesLeft));
        }
        
        [Fact]
        public void ShouldConvertDiceListToEnumerable()
        {
            var random = new FakeRandom(new List<int> {3, 3, 3, 3, 4});
            var player = new Player();
            var turn = new Turn(random, player);
            turn.MakeFirstRoll();
            var yatzyScorer = new YatzyScorer();
            var diceFaces = yatzyScorer.CountFaceValues(turn.Dice);
            Assert.Equal(16, diceFaces.Sum());
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 1, 4}, 9)]
        [InlineData(new[] {6, 3, 3, 6, 4}, 0)]
        [InlineData(new[] {6, 3, 3, 3, 3}, 9)]
        public void PlayerCantReuseCategories(int[] dice, int expected)
        {
            var player = new Player();
            var random = new FakeRandom(new List<int> {3, 3, 3, 3, 4});
            var turn = new Turn(random, player);
            turn.MakeFirstRoll();
            var yatzyScorer = new YatzyScorer();
            var diceFaces = yatzyScorer.CountFaceValues(turn.Dice);
            var score = YatzyScorer.CalculateScore(dice, Category.ThreeOfAKind);
            player.RemoveUsedCategory(Category.ThreeOfAKind);
            bool categoryHasBeenRemoved = !player.CategoriesLeft.Contains(Category.ThreeOfAKind);
            Assert.True(categoryHasBeenRemoved);
        }
        
    }
}