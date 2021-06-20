using Minesweeper.Enums;

namespace Minesweeper
{
    public class Field
    {
        public Piece[,] Squares { get; set; }

        public Field()
        {
            Squares = new Piece[1,1];
            for (var i = 0; i < 1; i++)
            {
                for (var j = 0; j < 1; j++)
                {
                    Squares[i, j] = Piece.Mine;
                }
            }
        }
    }
}