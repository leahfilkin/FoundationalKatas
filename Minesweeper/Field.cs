using Minesweeper.Enums;

namespace Minesweeper
{
    public class Field
    {
        public Piece[,] Squares { get; }

        public Field(int lines, int columns)
        {
            Squares = new Piece[lines,columns];
            for (var i = 0; i < lines; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Squares[i, j] = Piece.Mine;
                }
            }
        }
    }
}