using System.Collections.Generic;
using Xunit;

namespace Minesweeper.Tests
{
    public class AdjacentMineCalculatorTests
    {
        [Theory]
        [MemberData(nameof(AdjacentMines))]
        public void CalculateNumberOfAdjacentMinesToSquareInField(AdjacentMineData adjacentMineData)
        {
            var field = new Field(adjacentMineData.NumberOfRows, adjacentMineData.NumberOfColumns, 
                adjacentMineData.ExpectedMinePoints);
            var mines = field.GetMines();
            var squareToCheck = field.Squares[adjacentMineData.SquareXCoord][adjacentMineData.SquareYCoord];
            
            var adjacentMines = AdjacentMineCalculator.GetNumberOfAdjacentMines(adjacentMineData.SquareXCoord, adjacentMineData.SquareYCoord, field);
            
            Assert.Equal(adjacentMineData.ExpectedMineCount, adjacentMines);
        }
        
        public class AdjacentMineData
        {
            public List<Point> ExpectedMinePoints;
            public int NumberOfRows;
            public int NumberOfColumns;
            public int SquareXCoord;
            public int SquareYCoord;
            public int ExpectedMineCount;

        }

        public static IEnumerable<object[]> AdjacentMines =>
            new TheoryData<AdjacentMineData>
            {
                new AdjacentMineData
                {
                    ExpectedMinePoints = new List<Point>
                    {
                        new Point(1, 2),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 0,
                    ExpectedMineCount = 0,
                },
                new AdjacentMineData
                {
                    ExpectedMinePoints = new List<Point>
                    {
                        new Point(0, 0),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 1,
                    ExpectedMineCount = 1,
                },
                new AdjacentMineData
                {
                    ExpectedMinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0,1)
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 1,
                    SquareYCoord = 0,
                    ExpectedMineCount = 2,
                },
                new AdjacentMineData
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
                    SquareXCoord = 1,
                    SquareYCoord = 1,
                    ExpectedMineCount = 8,
                },
                new AdjacentMineData
                {
                    ExpectedMinePoints = new List<Point>
                    {
                        new Point(0,1),
                        new Point(1,0),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    SquareXCoord = 0,
                    SquareYCoord = 0,
                    ExpectedMineCount = 2,
                },
                new AdjacentMineData
                {
                    ExpectedMinePoints = new List<Point>
                    {
                        new Point(15,27),
                        new Point(13,25),
                        new Point(1,1),
                    },
                    NumberOfRows = 30,
                    NumberOfColumns = 46,
                    SquareXCoord = 14,
                    SquareYCoord = 26,
                    ExpectedMineCount = 2,
                },
                
            };
    }
}