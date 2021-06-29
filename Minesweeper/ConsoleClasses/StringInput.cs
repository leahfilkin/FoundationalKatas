using System;
using System.Collections.Generic;

namespace Minesweeper.ConsoleClasses
{
    public static class StringInput
    {
        public static int GetLines(List<string> input)
        {
            if (input[0].IndexOf('x') == -1)
            {
                throw new ArgumentException("You must specify LINESxCOLUMNS in the first line, with an x between");
            }

            if (!int.TryParse(input[0].Substring(0, input[0].IndexOf('x')), out var lines)) return lines;
            
            if (lines > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(lines), "You cannot have a field that has more than 100 lines");
            }
            return lines;
        }

        public static int GetColumns(List<string> input)
        {
            if (input[0].IndexOf('x') == -1)
            {
                throw new ArgumentException("You must specify LINESxCOLUMNS in the first line, with an x between");
            }

            if (!int.TryParse(input[0].Substring(input[0].IndexOf('x') + 1), out var columns)) return columns;
            if (columns > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(columns), "You cannot have a field that has more than 100 columns");
            }

            return columns;
        }

        public static List<Point> GetMines(List<string> input)
        {
            var lines = GetLines(input);
            var columns = GetColumns(input);

            var mines = new List<Point>();
            for (var i = 1; i < lines; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (input[i][j] == '*')
                    {
                        mines.Add(new Point(i-1,j));
                    }
                }
            }

            return mines;
        }

        public static Field ConvertToField(List<string> input)
        {
            var lines = GetLines(input);
            var columns = GetColumns(input);
            var mines = GetMines(input);
            return new Field(lines, columns, mines);
        }
    }
}