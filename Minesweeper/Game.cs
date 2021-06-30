using System.Collections.Generic;
using Minesweeper.ConsoleClasses;

namespace Minesweeper
{
    public static class Game
    {

        public static List<string> Complete(List<List<string>> multipleFieldsInput)
        {
            var output = new List<string>();
            for (var fieldInput = 0; fieldInput < multipleFieldsInput.Count; fieldInput++)
            {
                var field = StringInput.ConvertToField(multipleFieldsInput[fieldInput]);
                field.PopulateWithAdjacentMineNumbers();
                output.Add($"Field #{fieldInput+1}:\n" + StringOutput.ConvertPiecesToOutputNumbers(field));
            }
            return output;
        }
        
    }
    
}