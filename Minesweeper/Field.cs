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
            if (lines > 100 || columns > 100)
            {
                throw new ArgumentException("You cannot have a field with lines or columns greater than 100");
            }
            Squares = new List<List<Square>>();
            for (var line = 0; line < lines; line++)
            {
                Squares.Add(new List<Square>());
                for (var column = 0; column < columns; column++)
                {

                    Squares[line].Add(mineCoords.Any(mineCoord => mineCoord.Equals(new Point(line, column)))
                        ? new Square(Piece.Mine, new Point(line, column))
                        : new Square(Piece.NoMine, new Point(line, column)));
                }
            }
        }

        public List<Square> GetAdjacentSquares(Square square)
        {

            var lineAbove = square.Coords.X - 1;
            var lineBelow = square.Coords.X + 1;
            var sameLine = square.Coords.X;
            var columnToTheLeft = square.Coords.Y - 1;
            var columnToTheRight = square.Coords.Y + 1;
            var sameColumn = square.Coords.Y;

            var linesToCheck = new List<int>();
            var adjacentSquares = new List<Square>();
            
            if (square.Coords.X > 0)
            {
                linesToCheck.Add(lineAbove);
            }
            
            linesToCheck.Add(sameLine);
            
            if (square.Coords.X < Squares.Count - 1)
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

        public List<Square> GetMines()
        {
            var mines = new List<Square>();
            foreach (var line in Squares)
            {
                mines.AddRange(line.Where(square => square.Piece == Piece.Mine));
            }

            return mines;
        }

        public void PopulateWithAdjacentMineNumbers()
        {
            var mines = GetMines();
            var adjacentMineCalculator = new AdjacentMineCalculator();

            foreach (var line in Squares)
            {
                foreach (var square in line)
                {
                    if (mines.Contains(square)) continue;
                    var adjacentMines = adjacentMineCalculator.GetNumberOfAdjacentMines(square, mines, this);
                    adjacentMineCalculator.Replace(square, adjacentMines, this);
                }
            }
        }
    }
}