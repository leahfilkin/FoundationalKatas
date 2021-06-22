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
        public void IsMadeUpOfPieces()
        {
            var field = new Field(1,1, new List<Point> {new Point(0,0)});
            Assert.Equal(typeof(List<List<Piece>>), field.Squares.GetType());
        }

        [Theory]
        [InlineData(4,4)]
        [InlineData(3,5)]
        public void DimensionsOfFieldAreBasedOnLinesAndColumnsInput(int lines, int columns)
        {
            var field = new Field(lines, columns, new List<Point> {new Point(0,0)});
            Assert.Equal(lines, field.Squares.Count);
            Assert.Equal(columns, field.Squares[0].Count);
        }

        [Fact]
        public void SquaresDefaultsToNoMines()
        {
            var field = new Field(2, 2, new List<Point> {new Point(0,0)});
            var hasNoMine = field.Squares.Any(line => line.Contains(Piece.NoMine));
            Assert.True(hasNoMine);
        }

        [Theory]
        [MemberData(nameof(MineCoords))]
        public void PutsMinesInCoordinatesGivenToIt(MineCoordsData mineCoordsData)
        {
            var field = new Field(4, 4, mineCoordsData.minesPassedToField);
            var squaresToCheckInField = new List<Piece>();
            for (var i = 0; i < mineCoordsData.squaresXIndexes.Count; i++)
            {
                squaresToCheckInField.Add(field.Squares[mineCoordsData.squaresXIndexes[i]][mineCoordsData.squaresYIndexes[i]]);
            }
            Assert.True(squaresToCheckInField.All(piece => piece == Piece.Mine));
        }

        [Fact]
        public void ContainsBothMinesAndNonMinesInTheCorrectPlacesInOneField()
        {
            var field = new Field(2, 2, new List<Point> {new Point(0,0)});
            Assert.Equal(Piece.Mine, field.Squares[0][0]);
            Assert.Equal(Piece.NoMine, field.Squares[1][1]);
        }
        
        public class MineCoordsData
        {
            public List<Point> minesPassedToField;
            public List<int> squaresXIndexes;
            public List<int> squaresYIndexes;
        }
        
        public static IEnumerable<object[]> MineCoords =>
            new TheoryData<MineCoordsData>
            {
                new MineCoordsData
                {
                    minesPassedToField = new List<Point> {new Point(0,0)},
                    squaresXIndexes = new List<int> {0},
                    squaresYIndexes = new List<int> {0}

                },
                new MineCoordsData
                {
                    minesPassedToField = new List<Point> {new Point(1,2), new Point(3,2)},
                    squaresXIndexes = new List<int> {1,3},
                    squaresYIndexes = new List<int> {2,2}
                },
                new MineCoordsData
                {
                    minesPassedToField = new List<Point> {new Point(0,0), new Point(3,3), new Point(3,1)},
                    squaresXIndexes = new List<int> {0,3,3},
                    squaresYIndexes = new List<int> {0,3,1}
                },
            };
    }
}