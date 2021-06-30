using System;
using System.Linq;
using Minesweeper.Enums;

namespace Minesweeper
{
    public static class AdjacentMineCalculator
    {
        public static int GetNumberOfAdjacentMines(int x, int y, Field field)
        {
            return field.GetAdjacentSquares(x, y).Count(adjacentSquare => adjacentSquare == Piece.Mine);
        }

        public static Piece PieceNameOf(int value)
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