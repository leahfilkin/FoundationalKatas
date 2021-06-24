using System.Collections.Generic;
using System.Linq;
using Minesweeper.Enums;
using Xunit;

namespace Minesweeper
{
    public class AdjacentMineCalculator
    {
        public int GetNumberOfAdjacentMines(Square square, List<Square> mines, Field field)
        {
            return field.GetAdjacentSquares(square).Count(adjacentSquare => adjacentSquare.Piece == Piece.Mine);
        }
    }
}