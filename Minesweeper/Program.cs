using System;
using System.Collections.Generic;
using Minesweeper.ConsoleClasses;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Field(3, 3, 
                new List<Point> {new Point(0,0), new Point(1,1), new Point(2,2)});
            field.PopulateWithAdjacentMineNumbers();
            var outputConverter = new StringOutput();
            var convertedOutput = outputConverter.ConvertField(field);
            Console.WriteLine(convertedOutput);
        }
    }
}