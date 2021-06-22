using Minesweeper.Enums;

namespace Minesweeper
{
    public class Square
    {
        public Piece Piece;
        public int Line;
        public int Column;

        public Square(Piece piece, int line, int column)
        {
            Piece = piece;
            Line = line;
            Column = column;
        }
        
        public override bool Equals(object obj)
        {
            return Piece == (obj as Square).Piece && Line == (obj as Square).Line && Column== (obj as Square).Column;
        }
    }
}