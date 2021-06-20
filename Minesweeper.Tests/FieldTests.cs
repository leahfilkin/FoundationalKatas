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
            var field = new Field(1,1);
            Assert.IsType<Piece[,]>(field.Squares);
        }

        [Fact]
        public void DimensionsOfFieldAreBasedOnLinesAndColumnsInput()
        {
            var field = new Field(4, 4);
            Assert.Equal(4, field.Squares.GetLength(0));
            Assert.Equal(4, field.Squares.GetLength(1));
        }
    }
}