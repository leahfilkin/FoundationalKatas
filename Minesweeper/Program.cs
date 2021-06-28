using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Minesweeper.ConsoleClasses;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper! Please enter in as many fields as you want. \n" +
                              "You need to input your field like so: \n" +
                              "AxB = your field width and height, followed by \n" +
                              "The field, with * for mines and . for safe spots");
            string line;
            var input = new List<List<string>>();
            var fieldCount = 0;
            while ((line = Console.ReadLine()) != null && line != "" && line != "00") {
                if (Char.IsDigit(line[0]))
                {
                    input.Add(new List<string> {line});
                    fieldCount++;
                }
                else
                {
                    input[fieldCount].Add(line);
                }
            }
            
            Console.WriteLine(string.Join("\n", input));

            var field = new Field(3, 3, 
                new List<Point> {new Point(0,0), new Point(1,1), new Point(2,2)});
            field.PopulateWithAdjacentMineNumbers();
            var outputConverter = new StringOutput();
            var convertedOutput = outputConverter.ConvertField(field);
            Console.WriteLine(convertedOutput);
        }
    }
}