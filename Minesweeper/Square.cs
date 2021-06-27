using Minesweeper.Enums;

namespace Minesweeper
{
    public class Square
    {
        public Piece Piece;
        public Point Coords;

        public Square(Piece piece, Point coords)
        {
            Piece = piece;
            Coords = coords;
        }
        
        public override bool Equals(object obj)
        {
            return Piece == (obj as Square).Piece && Coords.X == (obj as Square).Coords.X && Coords.Y== (obj as Square).Coords.Y;
        }
        
    }
}