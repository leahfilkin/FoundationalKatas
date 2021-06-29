using System;
using System.Collections.Generic;
using System.Linq;

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

        public static List<string> CompleteGame(List<List<string>> input)
        {
            var output = new List<string>();
            for (var i = 0; i < input.Count; i++)
            {
                var field = StringInput.ConvertToField(string.Join("\n", input[i]));
                field.PopulateWithAdjacentMineNumbers();
                output.Add($"Field #{i+1}:\n" + StringOutput.ConvertPiecesToOutputNumbers(field));
            }
            return output;
        }
        
    }
    
}