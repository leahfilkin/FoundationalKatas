using System;
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

        public void Replace(Square squareToReplace, int adjacentMines, Field field)
        {
            field.Squares[squareToReplace.Coords.X][squareToReplace.Coords.Y].Piece = PieceNameOf(adjacentMines);
        }

        private static Piece PieceNameOf(int value)
        {
            return value switch
            {
                0 => Piece.Zero,
                1 => Piece.One,
                2 => Piece.Two,
                3 => Piece.Three,
                4 => Piece.Four,
                5 => Piece.Five,
                6 => Piece.Six,
                7 => Piece.Seven,
                8 => Piece.Eight,
                _ => throw new ArgumentException("Value outside of range. Only values from 0-8 are converted")
            };
        }
    }
}