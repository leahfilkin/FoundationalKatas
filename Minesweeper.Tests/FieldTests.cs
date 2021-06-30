using System;
using System.Collections.Generic;
using System.Linq;
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

        [Theory]
        [MemberData(nameof(MineCoords))]
        public void PutsMinesInCoordinatesGivenToIt(MineCoordsData mineCoordsData)
        {
            var field = new Field(4, 4, mineCoordsData.MinesPassedToField);
            var squaresToCheckInField = new List<List<int>>();
            for (var i = 0; i < mineCoordsData.SquaresXIndexes.Count; i++)
            {
                squaresToCheckInField.Add(new List<int>
                {
                    mineCoordsData.SquaresXIndexes[i], 
                    mineCoordsData.SquaresYIndexes[i]
                });
            }
            Assert.True(squaresToCheckInField.All(piece => field.Squares[piece[0]][piece[1]] == Piece.Mine));
        }

        [Fact]
        public void ContainsBothMinesAndNonMinesInTheCorrectPlacesInOneField()
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
                field.GetAdjacentSquares(adjacentSquaresData.SquareXCoord,adjacentSquaresData.SquareYCoord);
            Assert.Equal(adjacentSquaresData.ExpectedSquares,adjacentSquares);
        }

        [Theory]
        [MemberData(nameof(ReplacingNoMines))]
        public void ShouldReplaceNoMinesWithNumberOfSurroundingMinesForWholeField(ReplacingNoMinesData replacingNoMinesData)
        {
            var field = new Field(replacingNoMinesData.NumberOfRows, replacingNoMinesData.NumberOfColumns, 
                replacingNoMinesData.MinePoints);

            field.PopulateWithAdjacentMineNumbers();

            Assert.Equal(replacingNoMinesData.ExpectedSquares, field.Squares);

        }

        [Fact]
        public void ShouldThrowErrorIfLinesBiggerThan100()
        {
            Assert.Throws<ArgumentException>(
                () => new Field(101, 3, new List<Point> {new Point(0, 0)}));
        }
        
        [Theory]
        [MemberData(nameof(AdjacentMines))]
        public void ShouldReplaceSquareWithNumberOfAdjacentMines(AdjacentMineData adjacentMineData)
        {
            var field = new Field(adjacentMineData.NumberOfRows, adjacentMineData.NumberOfColumns, 
                adjacentMineData.MinePoints);
            var adjacentMines = AdjacentMineCalculator.GetNumberOfAdjacentMines(adjacentMineData.SquareXCoord, adjacentMineData.SquareYCoord, field);
            
            field.Replace(adjacentMineData.SquareXCoord, adjacentMineData.SquareYCoord, adjacentMines);
            
            Assert.Equal(adjacentMineData.ExpectedPiece, field.Squares[adjacentMineData.SquareXCoord][adjacentMineData.SquareYCoord]);
        }

        [Fact]
        public void IfNumberOfAdjacentMinesOutsideOfExpectedValuesThrowError()
        {
            var field = new Field(3, 3, 
                new List<Point> {new Point(0,0)});
            
            Assert.Throws<ArgumentException>
                ( () => field.Replace(0, 1, 9));
        }
        
        [Theory]
        [MemberData(nameof(AdjacentMines))]
        public void ReplacesSquareWithNumberOfAdjacentMines(AdjacentMineData adjacentMineData)
        {
            var field = new Field(adjacentMineData.NumberOfRows, adjacentMineData.NumberOfColumns, 
                adjacentMineData.MinePoints);
            var adjacentMines = AdjacentMineCalculator.GetNumberOfAdjacentMines(adjacentMineData.SquareXCoord, adjacentMineData.SquareYCoord, field);
            
            field.Replace(adjacentMineData.SquareXCoord, adjacentMineData.SquareYCoord, adjacentMines);
            
            Assert.Equal(adjacentMineData.ExpectedPiece, field.Squares[adjacentMineData.SquareXCoord][adjacentMineData.SquareYCoord]);
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
            public int SquareXCoord;
            public int SquareYCoord;
            
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
                    SquareXCoord = 0,
                    SquareYCoord = 0
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
                    SquareXCoord = 0,
                    SquareYCoord = 1
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
                    SquareXCoord = 0,
                    SquareYCoord = 2
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
                    SquareXCoord = 1,
                    SquareYCoord = 0
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
                    SquareXCoord = 1,
                    SquareYCoord = 1
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
                    SquareXCoord = 2,
                    SquareYCoord = 3
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
                    SquareXCoord = 4,
                    SquareYCoord = 0
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
                    SquareXCoord = 9,
                    SquareYCoord = 8
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
                    SquareXCoord = 14,
                    SquareYCoord = 17
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
                    SquareXCoord = 75,
                    SquareYCoord = 46
                },
            };



        public class MineCoordsData
        {
            public List<Point> MinesPassedToField;
            public List<int> SquaresXIndexes;
            public List<int> SquaresYIndexes;
        }
        
        public static IEnumerable<object[]> MineCoords =>
            new TheoryData<MineCoordsData>
            {
                new MineCoordsData
                {
                    MinesPassedToField = new List<Point> {new Point(0,0)},
                    SquaresXIndexes = new List<int> {0},
                    SquaresYIndexes = new List<int> {0}

                },
                new MineCoordsData
                {
                    MinesPassedToField = new List<Point> {new Point(1,2), new Point(3,2)},
                    SquaresXIndexes = new List<int> {1,3},
                    SquaresYIndexes = new List<int> {2,2}
                },
                new MineCoordsData
                {
                    MinesPassedToField = new List<Point> {new Point(0,0), new Point(3,3), new Point(3,1)},
                    SquaresXIndexes = new List<int> {0,3,3},
                    SquaresYIndexes = new List<int> {0,3,1}
                },
            };
        
        public class AdjacentMineData
        {
            public List<Point> MinePoints;
            public int NumberOfRows;
            public int NumberOfColumns;
            public int SquareXCoord;
            public int SquareYCoord;
            public Piece ExpectedPiece;
            public int MineCount;

        }

        public static IEnumerable<object[]> AdjacentMines =>
            new TheoryData<AdjacentMineData>
            {
                new AdjacentMineData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(1, 2),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 0,
                    MineCount = 0,
                    ExpectedPiece = Piece.Zero
                },
                new AdjacentMineData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 1,
                    MineCount = 1,
                    ExpectedPiece = Piece.One

                },
                new AdjacentMineData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0,1)
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 1,
                    SquareYCoord = 0,
                    MineCount = 2,
                    ExpectedPiece = Piece.Two

                },
                new AdjacentMineData
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
                    SquareXCoord = 1,
                    SquareYCoord = 1,
                    MineCount = 8,
                    ExpectedPiece = Piece.Eight

                },
                new AdjacentMineData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0,1),
                        new Point(1,0),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 0,
                    MineCount = 2,
                    ExpectedPiece = Piece.Two

                },
                new AdjacentMineData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(15,27),
                        new Point(13,25),
                        new Point(1,1),
                    },
                    NumberOfRows = 30,
                    NumberOfColumns = 46,
                    SquareXCoord = 14,
                    SquareYCoord = 26,
                    MineCount = 2,
                    ExpectedPiece = Piece.Two

                },
                
            };
    }
}