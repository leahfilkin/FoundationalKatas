using System;
using System.Collections.Generic;
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
            var rows = new List<int>
            {
                x - 1,
                x,
                x + 1
            };
            var columns = new List<int>
            {
                y - 1,
                y,
                y + 1
            };

            return (from row in rows.Where(row => row >= 0 && row <= Squares.Count - 1) 
                from column in columns.Where(column => column >= 0 && column <= Squares[0].Count - 1) 
                where row != x || column != y select Squares[row][column]).ToList();
        }

        public void PopulateWithAdjacentMineNumbers()
        {
            Squares = (<List<Piece>) Squares
                .Select((row, i) => row
                    .Select((square, j) => square == Piece.Mine ? Piece.Mine :
                        AdjacentMineCalculator.PieceNameOf(AdjacentMineCalculator.GetNumberOfAdjacentMines(
                            i, j, this)))).ToList();
            
            // for (var i = 0; i < Squares.Count; i++)
            // {
            //     for (var j = 0; j < Squares[0].Count; j++)
            //     {
            //         if (Squares[i][j] == Piece.Mine) continue;
            //         var adjacentMines = AdjacentMineCalculator.GetNumberOfAdjacentMines(i, j, this);
            //         Replace(i, j, adjacentMines);
            //     }
            // }
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