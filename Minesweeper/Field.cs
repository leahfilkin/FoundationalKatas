using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Enums;

namespace Minesweeper
{
    public class Field
    {
        public List<List<Square>> Squares { get; }

        public Field(int lines, int columns, List<Point> mineCoords)
        {
            Squares = new List<List<Square>>();
            for (var line = 0; line < lines; line++)
            {
                Squares.Add(new List<Square>());
                for (var column = 0; column < columns; column++)
                {
                    
                    Squares[line].Add(mineCoords.Any(mineCoord => mineCoord.Equals(new Point(line, column)))
                        ? new Square(Piece.Mine, line, column)
                        : new Square(Piece.NoMine, line, column));
                }
            }
        }

        public List<Square> GetAdjacentSquares(Square square)
        {
            var topLeft = Squares[square.Line - 1][square.Column - 1];
            var topMiddle = Squares[square.Line - 1][square.Column];
            var topRight = Squares[square.Line - 1][square.Column + 1];
            var middleLeft = Squares[square.Line][square.Column - 1];
            var middleRight = Squares[square.Line][square.Column + 1];
            var bottomLeft = Squares[square.Line + 1][square.Column - 1];
            var bottomMiddle = Squares[square.Line + 1][square.Column];
            var bottomRight = Squares[square.Line + 1][square.Column + 1];
            return new List<Square>
            {
                topLeft, topMiddle, topRight,
                middleLeft, middleRight,
                bottomLeft, bottomMiddle, bottomRight
            };
        }
    }
}