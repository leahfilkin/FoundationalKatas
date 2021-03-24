using System;
using Xunit;

namespace Yatzy.Tests
{
    public class YatzyTests
    {
        [Fact]
        public void ChanceShouldReturnSumOfDice()
        {
            int[] dice = {1, 2, 3, 4, 5};
            var score = YatzyScorer.CalculateScore(dice, Category.Chance);

            Assert.Equal(15, score);
        }

        [Theory]
        [InlineData(new [] { 0, 2, 3, 4, 5 })]
        [InlineData(new [] { 1, 2, 3, 4, 7 })]
        [InlineData(new [] { 1, 2, 3, 4 })]
        [InlineData(new [] { 1, 2, 3, 4, 5, 6 })]

        public void CalculateShouldThrowForInvalidArguments(int[] dice)
        {
            Assert.Throws<ArgumentException>(() => YatzyScorer.CalculateScore(dice, Category.Chance));
        }

        [Theory]
        [InlineData(new [] {1, 1, 1, 1, 1}, 50)]
        [InlineData(new [] {1, 1, 1, 2, 1}, 0)]
        public void YatzyShouldReturnCorrectScore(int[] dice, int expected)
        {
            var score = YatzyScorer.CalculateScore(dice, Category.Yatzy);
            
            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new [] {1, 1, 3, 4, 5})]
        public void OnesShouldReturnSumOfOnes(int[] dice)
        {
            var score = YatzyScorer.CalculateScore(dice, Category.Ones);

            Assert.Equal(2, score);
        }
    }
}
