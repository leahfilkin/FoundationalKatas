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
        [InlineData(new [] {1, 1, 3, 4, 5}, 2)]
        [InlineData(new [] {2, 2, 3, 4, 5}, 0)]
        public void OnesShouldReturnSumOfOnes(int[] dice, int expected)
        {
            var score = YatzyScorer.CalculateScore(dice, Category.Ones);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new[] {2, 2, 3, 4, 5}, 4)]
        [InlineData(new[] {1, 3, 3, 4, 5}, 0)]
        public void TwosShouldReturnSumOfTwos(int[] dice, int expected)
        {
            var score = YatzyScorer.CalculateScore(dice, Category.Twos);
            
            Assert.Equal(expected, score);
        }
        
        [Theory]
        [InlineData(new[] {1, 2, 3, 3, 5}, 6)]
        [InlineData(new[] {1, 2, 2, 4, 5}, 0)]
        public void ThreesShouldReturnSumOfThrees(int[] dice, int expected)
        {
            var score = YatzyScorer.CalculateScore(dice, Category.Threes);
            
            Assert.Equal(expected, score);
        }
        
        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 4}, 8)]
        [InlineData(new[] {1, 2, 3, 3, 5}, 0)]
        public void FoursShouldReturnSumOfFours(int[] dice, int expected)
        {
            var score = YatzyScorer.CalculateScore(dice, Category.Fours);
            
            Assert.Equal(expected, score);
        }
        
        [Theory]
        [InlineData(new[] {1, 2, 5, 5, 5}, 15)]
        [InlineData(new[] {1, 2, 3, 4, 1}, 0)]
        public void FivesShouldReturnSumOfFives(int[] dice, int expected)
        {
            var score = YatzyScorer.CalculateScore(dice, Category.Fives);
            
            Assert.Equal(expected, score);
        }
        
        [Theory]
        [InlineData(new[] {6, 6, 3, 6, 4}, 18)]
        [InlineData(new[] {1, 2, 3, 4, 1}, 0)]
        public void SixesShouldReturnSumOfSixes(int[] dice, int expected)
        {
            var score = YatzyScorer.CalculateScore(dice, Category.Sixes);
            
            Assert.Equal(expected, score);
        }
    }
}
