using System.Collections.Generic;
using Minesweeper.Enums;
using Xunit;

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
        public void ContainsMinesAndNonMinesInTheCorrectPlacesInOneField()
        {
            var field = new Field(2, 2, new List<Point> {new Point(0,0)});
            Assert.Equal(Piece.Mine, field.Squares[0][0]);
            Assert.Equal(Piece.NoMine, field.Squares[1][1]);
        }

        [Theory]
        [MemberData(nameof(AdjacentSquares))]
        public void CanFindAdjacentSquaresToAGivenSquare(AdjacentSquaresData adjacentSquaresData)
        {
            var field = 
                new Field(adjacentSquaresData.NumberOfRows, adjacentSquaresData.NumberOfColumns,
                new List<Point> {new Point(0,0)});
            var adjacentSquares = 
                field.GetAdjacentSquares(adjacentSquaresData.Line,adjacentSquaresData.Column);
            Assert.Equal(adjacentSquaresData.ExpectedSquares,adjacentSquares);
        }

        [Theory]
        [MemberData(nameof(ReplacingNoMines))]
        public void ReplaceNoMinesWithNumberOfSurroundingMinesForWholeField(ReplacingNoMinesData replacingNoMinesData)
        {
            var field = new Field(replacingNoMinesData.NumberOfRows, replacingNoMinesData.NumberOfColumns, 
                replacingNoMinesData.MinePoints);

            field.PopulateWithAdjacentMineNumbers();

            Assert.Equal(replacingNoMinesData.ExpectedSquares, field.Squares);

        }

        public class ReplacingNoMinesData
        {
            public List<Point> MinePoints;
            public int NumberOfRows;
            public int NumberOfColumns;
            public List<List<Piece>> ExpectedSquares;

        }

        public static IEnumerable<object[]> ReplacingNoMines =>
            new TheoryData<ReplacingNoMinesData>
            {
                new ReplacingNoMinesData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    
                    ExpectedSquares = new List<List<Piece>>
                    {
                        new List<Piece> 
                        {
                            Piece.Mine,
                            Piece.One,
                            Piece.Zero  
                        },
                        new List<Piece>
                        {
                            Piece.One, 
                            Piece.One, 
                            Piece.Zero, 
                        },
                        new List<Piece>
                        {
                            Piece.Zero,
                            Piece.Zero,
                            Piece.Zero
                        }
                    }
                },
                new ReplacingNoMinesData
                {
                    MinePoints = new List<Point>
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
                    
                    ExpectedSquares = new List<List<Piece>>
                    {
                        new List<Piece> 
                        {
                            Piece.Mine,
                            Piece.Mine,
                            Piece.Mine
                        },
                        new List<Piece>
                        {
                            Piece.Mine,
                            Piece.Eight,
                            Piece.Mine
                        },
                        new List<Piece>
                        {
                            Piece.Mine,
                            Piece.Mine,
                            Piece.Mine
                        }
                    }
                },
                new ReplacingNoMinesData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(1,2),
                        new Point(2,0),
                        new Point(2,1)
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    
                    ExpectedSquares = new List<List<Piece>>
                    {
                        new List<Piece> 
                        {
                            Piece.Mine, 
                            Piece.Two,
                            Piece.One  
                        },
                        new List<Piece>
                        {
                            Piece.Three,
                            Piece.Four,
                            Piece.Mine,
                        },
                        new List<Piece>
                        {
                            Piece.Mine,
                            Piece.Mine,
                            Piece.Two
                        }
                    }
                },
            };

        public class AdjacentSquaresData
        {
            public List<Piece> ExpectedSquares;
            public int NumberOfRows;
            public int NumberOfColumns;
            public int Line;
            public int Column;
            
        }
        
        public static IEnumerable<object[]> AdjacentSquares =>
            new TheoryData<AdjacentSquaresData>
            {
                new AdjacentSquaresData
                {   
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 0,
                    Column = 0
                },
                new AdjacentSquaresData
                {   
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.Mine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine

                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 0,
                    Column = 1
                },
                new AdjacentSquaresData
                {   
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine

                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 0,
                    Column = 2
                },
                new AdjacentSquaresData
                {  
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.Mine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 1,
                    Column = 0
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.Mine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 1,
                    Column = 1
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine
                    },
                    NumberOfRows = 5,
                    NumberOfColumns = 4,
                    Line = 2,
                    Column = 3
                },
                
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                    },
                    NumberOfRows = 5,
                    NumberOfColumns = 4,
                    Line = 4,
                    Column = 0
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                    },
                    NumberOfRows = 10,
                    NumberOfColumns = 13,
                    Line = 9,
                    Column = 8
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                    },
                    NumberOfRows = 15,
                    NumberOfColumns = 18,
                    Line = 14,
                    Column = 17
                },
                new AdjacentSquaresData
                {
                    ExpectedSquares = new List<Piece>
                    {
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                        Piece.NoMine,
                    },
                    NumberOfRows = 80,
                    NumberOfColumns = 100,
                    Line = 75,
                    Column = 46
                }
            };
    }
}