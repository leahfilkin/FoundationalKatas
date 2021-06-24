using System.Collections.Generic;
using System.Linq;
using Minesweeper.Enums;
using Xunit;

namespace Minesweeper.Tests
{
    public class AdjacentMineCalculatorTests
    {
        [Fact]
        public void CalculateNumberOfAdjacentMinesToSquareInField()
        {
            var field = new Field(3,3, new List<Point> {new Point(0, 0)});
            var mines = field.GetMines();
            var squareToCheck = field.Squares[0][1];
            var adjacentMineCalculator = new AdjacentMineCalculator();
            var adjacentMines = adjacentMineCalculator.GetNumberOfAdjacentMines(squareToCheck, mines, field);
            Assert.Equal(1, adjacentMines);  
        }
    }
}