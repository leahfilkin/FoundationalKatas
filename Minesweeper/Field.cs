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

            var lineAbove = square.Line - 1;
            var lineBelow = square.Line + 1;
            var sameLine = square.Line;
            var columnToTheLeft = square.Column - 1;
            var columnToTheRight = square.Column + 1;
            var sameColumn = square.Column;

            var linesToCheck = new List<int>();
            var adjacentSquares = new List<Square>();
            
            if (square.Line > 0)
            {
                linesToCheck.Add(lineAbove);
            }
            
            linesToCheck.Add(sameLine);
            
            if (square.Line < Squares.Count - 1)
            {
                linesToCheck.Add(lineBelow);
            }

            foreach (var line in linesToCheck)
            {
                if (columnToTheLeft >= 0)
                {
                    adjacentSquares.Add(Squares[line][columnToTheLeft]);
                }
                if (line != sameLine)
                {
                    adjacentSquares.Add(Squares[line][sameColumn]);
                }
                if (columnToTheRight <= Squares[0].Count - 1)
                {
                    adjacentSquares.Add(Squares[line][columnToTheRight]);
                }
            }

            return adjacentSquares;


        }
    }
}