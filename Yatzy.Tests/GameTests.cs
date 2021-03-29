using System;
using System.Collections.Generic;
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

        [Fact]
        public void PlayerReturnsScoreOnTurn()
        {
            var player = new Player();
            var score = player.TakeTurn();
            
            Assert.Equal(0, score);
        }
        
        
    }
}