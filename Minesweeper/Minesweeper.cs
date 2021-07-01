using System.Collections.Generic;
using System.Linq;
using Minesweeper.ConsoleClasses;

namespace Minesweeper
{
    public static class Minesweeper
    {

        public static List<Field> BuildFields(List<List<string>> multipleFieldsInput)
        {
            var fields = new List<Field>();
            foreach (var field in multipleFieldsInput.Select(StringInput.ConvertToField))
            {
                field.PopulateWithAdjacentMineNumbers();
                fields.Add(field);
            }
            return fields;
        }
    }
    
}