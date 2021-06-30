using System;
using System.Collections.Generic;
using Minesweeper.Enums;

namespace Minesweeper
{
    public class Field
    {
        public List<List<Piece>> Squares { get; }

        public Field(int lines, int columns, IEnumerable<Point> mineCoords)
        {
            if (lines > 100 || columns > 100)
            {
                throw new ArgumentException("You cannot have a field with lines or columns greater than 100");
            }
            Squares = new List<List<Piece>>();
            for (var line = 0; line < lines; line++)
            {
                Squares.Add(new List<Piece>());
                for (var column = 0; column < columns; column++)
                {
                    Squares[line].Add(Piece.NoMine);
                }
            }
            foreach (var mine in mineCoords)
            {
                Squares[mine.X][mine.Y] = Piece.Mine;
            }
        }

        public List<Piece> GetAdjacentSquares(int x, int y)
        {

            var lineAbove = x - 1;
            var lineBelow = x + 1;
            var sameLine = x;
            var columnToTheLeft = y - 1;
            var columnToTheRight = y + 1;
            var sameColumn = y;

            var linesToCheck = new List<int>();
            var adjacentSquares = new List<Piece>();
            
            if (x > 0)
            {
                linesToCheck.Add(lineAbove);
            }
            
            linesToCheck.Add(sameLine);
            
            if (x < Squares.Count - 1)
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

        public void PopulateWithAdjacentMineNumbers()
        {
            for (var i = 0; i < Squares.Count; i++)
            {
                for (var j = 0; j < Squares[0].Count; j++)
                {
                    if (Squares[i][j] == Piece.Mine) continue;
                    var adjacentMines = AdjacentMineCalculator.GetNumberOfAdjacentMines(i, j, this);
                    Replace(i, j, adjacentMines);
                }
            }
        }
        
        public void Replace(int xToReplace, int yToReplace, int adjacentMines)
        {
            Squares[xToReplace][yToReplace] = AdjacentMineCalculator.PieceNameOf(adjacentMines);
        }
        
        public override bool Equals(object o)
        {
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            return o is Field otherField && Squares == otherField.Squares;
        }

        public override int GetHashCode()
        {
            return (Squares != null ? Squares.GetHashCode() : 0);
        }
    }
}