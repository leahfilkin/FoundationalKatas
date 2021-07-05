using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.ConsoleClasses
{
    public static class StringInput
    {
        public static int GetLines(List<string> input)
        {
            return Convert.ToInt32(input[0].Substring(0, input[0].IndexOf('x')));
        }

        public static int GetColumns(List<string> input)
        {
            return Convert.ToInt32(input[0].Substring(input[0].IndexOf('x') + 1));
        }

        public static List<Point> GetMines(List<string> input)
        {
            return input
                .Where(line => input[0] != line)
                .SelectMany((row, i) => row
                    .Select((square, j) => new Point(i,j))
                    .Where(point => input[point.X+1][point.Y] == '*'))
                .ToList();
        }

        public static Field ConvertToField(List<string> input)
        {
            Validate(input);
            var lines = GetLines(input);
            var columns = GetColumns(input);
            var mines = GetMines(input);
            return new Field(lines, columns, mines);
        }

        private static void Validate(List<string> input)
        {
            CheckForXBetweenDimensions(input);
            var linesInput = GetLinesInput(input);
            var columnsInput = GetColumnsInput(input);
            CheckDimensionsAreIntegers(linesInput, columnsInput);
            CheckDimensionsAreNotOver100(linesInput, columnsInput);
            CheckDimensionsMatchField(input, linesInput, columnsInput);
        }
        
        private static string GetColumnsInput(List<string> input)
        {
            return input[0].Substring(0, input[0].IndexOf('x'));
        }

        private static string GetLinesInput(List<string> input)
        {
            return input[0].Substring(input[0].IndexOf('x') + 1);
        }

        private static void CheckDimensionsMatchField(List<string> input, string linesInput, string columnsInput)
        {
            if (input.Count -1 != Convert.ToInt32(linesInput))
            {
                throw new ArgumentException(
                    "The field you entered must be the same dimensions as the lines you specified");
            }
            
            if (input[^1].Length != Convert.ToInt32(columnsInput))
            {
                throw new ArgumentException(
                    "The field you entered must be the same dimensions as the columns you specified");
            }
        }

        private static void CheckDimensionsAreNotOver100(string linesInput, string columnsInput)
        {
            if (Convert.ToInt32(linesInput) > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(linesInput), "You cannot have a field that has more than 100 lines");
            }
            if (Convert.ToInt32(columnsInput) > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(columnsInput), "You cannot have a field that has more than 100 columns");
            }
        }

        private static void CheckDimensionsAreIntegers(string linesInput, string columnsInput)
        {
            if (!int.TryParse(linesInput, out _)
            || !int.TryParse(columnsInput, out _))
            {
                throw new ArgumentException(
                    "You must write your dimensions in in integer format");
            }
        }

        private static void CheckForXBetweenDimensions(List<string> input)
        {
            if (input[0].IndexOf('x') == -1)
            {
                throw new ArgumentException("You must specify LINESxCOLUMNS in the first line, with an x between");
            }
        }
    }
}