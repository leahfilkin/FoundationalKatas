using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Minesweeper.ConsoleClasses
{
    public static class StringInput
    {
        public static int GetLines(string input)
        {
            if (input.IndexOf('x') == -1)
            {
                throw new ArgumentException("You must specify LINESxCOLUMNS, with an x between");
            }
            if (int.TryParse(input.Substring(0, input.IndexOf('x')), out var lines))
            {
                if (lines > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(lines), "You cannot have a field that has more than 100 lines");
                }
            }
            return lines;
        }

        public static int GetColumns(string input)
        {
            if (input.IndexOf('x') == -1)
            {
                throw new ArgumentException("You must specify LINESxCOLUMNS, with an x between");
            }

            if (int.TryParse(input.Substring(input.IndexOf('x') + 1,
                input.IndexOf('\n') - 1 - input.IndexOf('x')), out var columns))
            {
                if (columns > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(columns), "You cannot have a field that has more than 100 columns");
                }
            }

            return columns;
        }

        public static List<Point> GetMines(string input)
        {
            var mines = new List<Point>();
            var inputWithoutDimensions = input.Substring(input.IndexOf('\n') + 1);
            var inputSeperatedIntoRows = inputWithoutDimensions.Split('\n').ToList();
            for (var i = 0; i < GetLines(input); i++)
            {
                for (var j = 0; j < GetColumns(input); j++)
                {
                    if (inputSeperatedIntoRows[i][j] == '*')
                    {
                        mines.Add(new Point(i,j));
                    }
                }
            }

            return mines;
        }

        public static Field ConvertToField(string input)
        {
            var lines = GetLines(input);
            var columns = GetColumns(input);
            var mines = GetMines(input);
            return new Field(lines, columns, mines);
        }
    }
}