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

            if (!int.TryParse(input[0].Substring(0, input[0].IndexOf('x')), out var lines))
            {
                throw new ArgumentException(
                    "You must write the amount of lines you want in integer format");
            }
                        
            if (lines > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(lines), "You cannot have a field that has more than 100 lines");
            }
            
            if (input.Count - 1 != lines)
            {
                throw new ArgumentException(
                    "The field you entered must be the same dimensions as the lines you specified");
            }

            return lines;
        }

        public static int GetColumns(List<string> input)
        {
            if (input[0].IndexOf('x') == -1)
            {
                throw new ArgumentException("You must specify LINESxCOLUMNS in the first line, with an x between");
            }

            if (!int.TryParse(input[0].Substring(input[0].IndexOf('x') + 1), out var columns))
            {
                throw new ArgumentException(
                    "You must write the amount of columns you want in integer format");
            }
            
            if (columns > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(columns), "You cannot have a field that has more than 100 columns");
            }
            
            if (input[^1].Length != columns)
            {
                throw new ArgumentException(
                    "The field you entered must be the same dimensions as the columns you specified");
            }

            return columns;
        }

        public static List<Point> GetMines(List<string> input)
        {
            var mines = new List<Point>();
            for (var i = 1; i < input.Count; i++)
            {
                for (var j = 0; j < input[1].Length; j++)
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