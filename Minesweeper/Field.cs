using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Enums;

namespace Minesweeper
{
    public class Field
    {
        public List<List<Piece>> Squares { get; }

        public Field(int lines, int columns, List<Point> mineCoords)
        {
            Squares = new List<List<Piece>>();
            for (var line = 0; line < lines; line++)
            {
                Squares.Add(new List<Piece>());
                for (var column = 0; column < columns; column++)
                {
                    
                    Squares[line].Add(mineCoords.Any(mineCoord => mineCoord.Equals(new Point(line, column)))
                        ? Piece.Mine
                        : Piece.NoMine);
                }
            }
        }
    }
}