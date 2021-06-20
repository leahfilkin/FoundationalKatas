using System;
using Minesweeper.Enums;
using Xunit;

namespace Minesweeper.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FieldIsMadeUpOfPieces()
        {
            var field = new Field();
            Assert.IsType<Piece[,]>(field.Squares);
        }
    }
}