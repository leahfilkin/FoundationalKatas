using System;
using Minesweeper.ConsoleClasses;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper! Please enter in as many fields as you want. \n" +
                              "You need to input your fields like so: \n" +
                              "AxB = your field width and height, followed by \n" +
                              "The field, with * for mines and . for safe spots\n" +
                              "Please make sure the field dimensions match what you put at the top.\n" +
                              "You can put as many fields as you like. To finish, press 00 and enter. ");
            var input = UserInterface.CollectFieldInputs();
            var inputFields = Minesweeper.BuildFields(input);
            var filledOutFields = StringOutput.DisplayFields(inputFields);
            Console.WriteLine(string.Join("\n", filledOutFields));
        }
    }
}