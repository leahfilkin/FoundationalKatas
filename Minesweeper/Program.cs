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
            var input = UserInterface.CollectFieldInputs();
            Console.WriteLine(string.Join("\n", UserInterface.CompleteGame(input)));
        }
    }
}