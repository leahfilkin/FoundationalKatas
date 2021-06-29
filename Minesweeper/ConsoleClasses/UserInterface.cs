using System;
using System.Collections.Generic;

namespace Minesweeper.ConsoleClasses
{
    public class UserInterface
    {
        public static List<List<string>> CollectFieldInputs()
        {
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
                    input[fieldCount-1].Add(line);
                }
            }
            return input;
        }
    }
}