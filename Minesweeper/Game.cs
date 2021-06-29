using System.Collections.Generic;
using Minesweeper.ConsoleClasses;

namespace Minesweeper
{
    public class Game
    {

        public static List<string> Complete(List<List<string>> input)
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