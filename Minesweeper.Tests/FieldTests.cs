using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Enums;
using Xunit;
using Xunit.Abstractions;

namespace Minesweeper.Tests
{
    public class FieldTests
    {
        [Fact]
        public void FieldIsMadeUpOfPieces()
        {
            var field = new Field(1,1, new Point(0,0));
            Assert.Equal(typeof(List<List<Piece>>), field.Squares.GetType());
        }

        [Theory]
        [InlineData(4,4)]
        [InlineData(3,5)]
        public void DimensionsOfFieldAreBasedOnLinesAndColumnsInput(int lines, int columns)
        {
            var field = new Field(lines, columns, new Point(0,0));
            Assert.Equal(lines, field.Squares.Count);
            Assert.Equal(columns, field.Squares[0].Count);
        }

        [Fact]
        public void SquaresDefaultsToNoMines()
        {
            var field = new Field(2, 2, new Point(0,0));
            var hasNoMine = field.Squares.Any(line => line.Contains(Piece.NoMine));
            Assert.True(hasNoMine);
        }

        [Fact]
        public void FieldPutsMineInCoordinatesGivenToIt()
        {
            var field = new Field(2, 2, new Point(0, 0));
            Assert.Equal(Piece.Mine, field.Squares[0][0]);
        }
        
        
        
        
    }
}