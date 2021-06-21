using System.Collections.Generic;
using Minesweeper.Enums;

namespace Minesweeper
{
    public class Field
    {
        public List<List<Piece>> Squares { get; }

        public Field(int lines, int columns, Point minePoint)
        {
            Squares = new List<List<Piece>>();
            for (var yCoord = 0; yCoord < lines; yCoord++)
            {
                Squares.Add(new List<Piece>());
                for (var xCoord = 0; xCoord < columns; xCoord++)
                {
                    if (yCoord == minePoint.Y && xCoord == minePoint.X)
                    {
                        Squares[yCoord].Add(Piece.Mine);
                    }
                    else
                    {
                        Squares[yCoord].Add(Piece.NoMine);
                    }
                }
            }
        }
    }
}