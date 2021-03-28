using Xunit;

namespace Yatzy.Tests
{
    public class GameTests
    {
        [Fact]
        public void PlayingGameReturnsScore()
        {
            var game = new Game();
            var score = game.PlayGame();

            Assert.Equal(0, score);
        }
    }
}