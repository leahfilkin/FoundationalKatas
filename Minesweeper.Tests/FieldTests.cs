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
        public void IsMadeUpOfSquares()
        {
            var field = new Field(1,1, new List<Point> {new Point(0,0)});
            Assert.Equal(typeof(List<List<Square>>), field.Squares.GetType());
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

        [Theory]
        [MemberData(nameof(MineCoords))]
        public void PutsMinesInCoordinatesGivenToIt(MineCoordsData mineCoordsData)
        {
            var field = new Field(4, 4, mineCoordsData.minesPassedToField);
            var squaresToCheckInField = new List<Square>();
            for (var i = 0; i < mineCoordsData.squaresXIndexes.Count; i++)
            {
                squaresToCheckInField.Add(field.Squares[mineCoordsData.squaresXIndexes[i]][mineCoordsData.squaresYIndexes[i]]);
            }
            Assert.True(squaresToCheckInField.All(piece => piece.Piece == Piece.Mine));
        }

        [Fact]
        public void ContainsBothMinesAndNonMinesInTheCorrectPlacesInOneField()
        {
            var field = new Field(2, 2, new List<Point> {new Point(0,0)});
            Assert.Equal(Piece.Mine, field.Squares[0][0].Piece);
            Assert.Equal(Piece.NoMine, field.Squares[1][1].Piece);
        }

        [Theory]
        [MemberData(nameof(AdjacentSquares))]
        public void CanFindAdjacentSquaresToAGivenSquare(AdjacentSquaresData adjacentSquaresData)
        {
            var field = 
                new Field(adjacentSquaresData.NumberOfRows, adjacentSquaresData.NumberOfColumns,
                new List<Point> {new Point(0,0)});
            var adjacentSquares = 
                field.GetAdjacentSquares(field.Squares[adjacentSquaresData.SquareXCoord][adjacentSquaresData.SquareYCoord]);
            Assert.Equal(adjacentSquaresData.ExpectedSquares,adjacentSquares);
        }

        [Fact]
        public void GetsListOfMines()
        {
            var expectedMines = new List<Square> {new Square(Piece.Mine, new Point(0, 0))};
            var field = new Field(3, 3, new List<Point> {new Point(0, 0)});
            var mines = field.GetMines();
            Assert.Equal(expectedMines, mines);
        }

        [Theory]
        [MemberData(nameof(ReplacingNoMines))]
        public void PopulateNoMinesWithNumberOfSurroundingMinesForWholeField(ReplacingNoMinesData replacingNoMinesData)
        {
            var field = new Field(replacingNoMinesData.NumberOfRows, replacingNoMinesData.NumberOfColumns, 
                replacingNoMinesData.ExpectedMinePoints);

            field.PopulateWithAdjacentMineNumbers();

            Assert.Equal(replacingNoMinesData.ExpectedSquares, field.Squares);

        }

        [Fact]
        public void FieldShouldThrowErrorIfLinesBiggerThan100()
        {
            Assert.Throws<ArgumentException>(
                () => new Field(101, 3, new List<Point> {new Point(0, 0)}));
        }
        
        public class ReplacingNoMinesData
        {
            public List<Point> ExpectedMinePoints;
            public int NumberOfRows;
            public int NumberOfColumns;
            public List<List<Square>> ExpectedSquares;

        }

        public static IEnumerable<object[]> ReplacingNoMines =>
            new TheoryData<ReplacingNoMinesData>
            {
                new ReplacingNoMinesData
                {
                    ExpectedMinePoints = new List<Point>
                    {
                        new Point(0, 0),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    
                    ExpectedSquares = new List<List<Square>>
                    {
                        new List<Square> 
                        {
                            new Square(Piece.Mine, new Point(0, 0)),
                            new Square(Piece.One, new Point(0, 1)),
                            new Square(Piece.Zero, new Point(0, 2)),  
                        },
                        new List<Square>
                        {
                            new Square(Piece.One, new Point(1, 0)),
                            new Square(Piece.One, new Point(1, 1)),
                            new Square(Piece.Zero, new Point(1, 2)),
                        },
                        new List<Square>
                        {
                            new Square(Piece.Zero, new Point(2, 0)),
                            new Square(Piece.Zero, new Point(2, 1)),
                            new Square(Piece.Zero, new Point(2, 2)),
                        }
                    }
                },
                new ReplacingNoMinesData
                {
                    ExpectedMinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0,1),
                        new Point(0,2),
                        new Point(1,0),
                        new Point(1,2),
                        new Point(2,0),
                        new Point(2,1),
                        new Point(2,2)
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    
                    ExpectedSquares = new List<List<Square>>
                    {
                        new List<Square> 
                        {
                            new Square(Piece.Mine, new Point(0, 0)),
                            new Square(Piece.Mine, new Point(0, 1)),
                            new Square(Piece.Mine, new Point(0, 2)),  
                        },
                        new List<Square>
                        {
                            new Square(Piece.Mine, new Point(1, 0)),
                            new Square(Piece.Eight, new Point(1, 1)),
                            new Square(Piece.Mine, new Point(1, 2)),
                        },
                        new List<Square>
                        {
                            new Square(Piece.Mine, new Point(2, 0)),
                            new Square(Piece.Mine, new Point(2, 1)),
                            new Square(Piece.Mine, new Point(2, 2)),
                        }
                    }
                },
                new ReplacingNoMinesData
                {
                    ExpectedMinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(1,2),
                        new Point(2,0),
                        new Point(2,1)
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    
                    ExpectedSquares = new List<List<Square>>
                    {
                        new List<Square> 
                        {
                            new Square(Piece.Mine, new Point(0, 0)),
                            new Square(Piece.Two, new Point(0, 1)),
                            new Square(Piece.One, new Point(0, 2)),  
                        },
                        new List<Square>
                        {
                            new Square(Piece.Three, new Point(1, 0)),
                            new Square(Piece.Four, new Point(1, 1)),
                            new Square(Piece.Mine, new Point(1, 2)),
                        },
                        new List<Square>
                        {
                            new Square(Piece.Mine, new Point(2, 0)),
                            new Square(Piece.Mine, new Point(2, 1)),
                            new Square(Piece.Two, new Point(2, 2)),
                        }
                    }
                },
            };

        public class AdjacentSquaresData
        {
            public List<Square> ExpectedSquares;
            public int NumberOfRows;
            public int NumberOfColumns;
            public int SquareXCoord;
            public int SquareYCoord;
            
        }
        
        public static IEnumerable<object[]> AdjacentSquares =>
            new TheoryData<AdjacentSquaresData>
            {
                new AdjacentSquaresData
                {   
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.NoMine, new Point(0,1)),
                        new Square(Piece.NoMine, new Point(1,0)),
                        new Square(Piece.NoMine, new Point(1,1)),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 0
                },
                new AdjacentSquaresData
                {   
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.Mine, new Point(0,0)),
                        new Square(Piece.NoMine, new Point(0,2)),
                        new Square(Piece.NoMine, new Point(1,0)),
                        new Square(Piece.NoMine, new Point(1,1)),
                        new Square(Piece.NoMine, new Point(1,2)),

                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 1
                },
                new AdjacentSquaresData
                {   
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.NoMine, new Point(0,1)),
                        new Square(Piece.NoMine, new Point(1,1)),
                        new Square(Piece.NoMine, new Point(1,2)),

                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 2
                },
                new AdjacentSquaresData
                {  
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.Mine, new Point(0,0)),
                        new Square(Piece.NoMine, new Point(0,1)),
                        new Square(Piece.NoMine, new Point(1,1)),
                        new Square(Piece.NoMine, new Point(2,0)),
                        new Square(Piece.NoMine, new Point(2,1)),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 1,
                    SquareYCoord = 0
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.Mine, new Point(0,0)),
                        new Square(Piece.NoMine, new Point(0,1)),
                        new Square(Piece.NoMine, new Point(0,2)),
                        new Square(Piece.NoMine, new Point(1,0)),
                        new Square(Piece.NoMine, new Point(1,2)),
                        new Square(Piece.NoMine, new Point(2,0)),
                        new Square(Piece.NoMine, new Point(2,1)),
                        new Square(Piece.NoMine, new Point(2,2)),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 1,
                    SquareYCoord = 1
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.NoMine, new Point(1,2)),
                        new Square(Piece.NoMine, new Point(1,3)),
                        new Square(Piece.NoMine, new Point(2,2)),
                        new Square(Piece.NoMine, new Point(3,2)),
                        new Square(Piece.NoMine, new Point(3,3)),
                    },
                    NumberOfRows = 5,
                    NumberOfColumns = 4,
                    SquareXCoord = 2,
                    SquareYCoord = 3
                },
                
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.NoMine, new Point(3,0)),
                        new Square(Piece.NoMine, new Point(3,1)),
                        new Square(Piece.NoMine, new Point(4,1)),
                    },
                    NumberOfRows = 5,
                    NumberOfColumns = 4,
                    SquareXCoord = 4,
                    SquareYCoord = 0
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.NoMine, new Point(8,7)),
                        new Square(Piece.NoMine, new Point(8,8)),
                        new Square(Piece.NoMine, new Point(8,9)),
                        new Square(Piece.NoMine, new Point(9,7)),
                        new Square(Piece.NoMine, new Point(9,9)),
                    },
                    NumberOfRows = 10,
                    NumberOfColumns = 13,
                    SquareXCoord = 9,
                    SquareYCoord = 8
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.NoMine, new Point(13,16)),
                        new Square(Piece.NoMine, new Point(13,17)),
                        new Square(Piece.NoMine, new Point(14,16)),
                    },
                    NumberOfRows = 15,
                    NumberOfColumns = 18,
                    SquareXCoord = 14,
                    SquareYCoord = 17
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Square>
                    {
                        new Square(Piece.NoMine, new Point(74,45)),
                        new Square(Piece.NoMine, new Point(74,46)),
                        new Square(Piece.NoMine, new Point(74,47)),
                        new Square(Piece.NoMine, new Point(75,45)),
                        new Square(Piece.NoMine, new Point(75,47)),
                        new Square(Piece.NoMine, new Point(76,45)),
                        new Square(Piece.NoMine, new Point(76,46)),
                        new Square(Piece.NoMine, new Point(76,47)),
                    },
                    NumberOfRows = 80,
                    NumberOfColumns = 100,
                    SquareXCoord = 75,
                    SquareYCoord = 46
                },
            };



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