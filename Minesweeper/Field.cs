using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using Minesweeper.Enums;

namespace Minesweeper
{
    public class Field
    {
        public List<List<Piece>> Squares { get; set; }

        public Field(int lines, int columns, IEnumerable<Point> mineCoords)
        {
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
            var rowsToCheck = Enumerable.Range(x - 1, 3);
            var columnsToCheck = Enumerable.Range(y - 1, 3);
            var coordsToCheck = rowsToCheck
                .SelectMany(line => columnsToCheck
                    .Select(column => new {Line = line, Column = column}));
            var coordsNotOnEdge = coordsToCheck
                .Where(coords => 
                    coords.Line >= 0 && coords.Line <= Squares.Count - 1 
                    && coords.Column >= 0 && coords.Column <= Squares[0].Count - 1);
            var adjacentCoords = coordsNotOnEdge
                .Where(coords => !(coords.Line == x && coords.Column == y));
            
            return
                adjacentCoords.Select(coords => Squares[coords.Line][coords.Column]).ToList();
        }

        public void PopulateWithAdjacentMineNumbers()
        {
            var squaresToCheck = Squares
                .Select((row, i) => row
                    .Select((square, j) => new {Line = i, Column = j, Piece = square}));
            Squares = squaresToCheck.Select((square) => square
                .Select(s => s.Piece == Piece.Mine ? Piece.Mine
                    : AdjacentMineCalculator.PieceNameOf(AdjacentMineCalculator.GetNumberOfAdjacentMines(
                        s.Line, s.Column, this))).ToList()).ToList();
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