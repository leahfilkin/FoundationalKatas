using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Ticket
    {
        public object GetDrinkName(Dictionary<string, string> instructions)
        {
            var drink = "";
            switch (instructions["drinkInitial"])
            {
                case "T":
                    drink = "tea";
                    break;
                case "H":
                    drink = "chocolate";
                    break;
                case "C":
                    drink = "coffee";
                    break;
            }

            return drink;
        }

        public string GetSugarAndStickDescription(Dictionary<string, string> instructions)
        {
            var sugarAndStickDescription = "";
            switch (Convert.ToInt32(instructions["sugars"] == "" ? "0" : instructions["sugars"]))
            {
                case 0:
                    sugarAndStickDescription = "no sugar - and therefore no stick";
                    break;
                case 1:
                    sugarAndStickDescription = $"{instructions["sugars"]} sugar and a stick";
                    break;
                case 2:
                    sugarAndStickDescription = $"{instructions["sugars"]} sugars and a stick";
                    break;
            }

            return sugarAndStickDescription;
        }

        public Dictionary<string, string> ProvideDescriptorsForStringCommand(string ticketInstructions)
        {
            var ticketBreakdown = ticketInstructions.Split(":");
            return new Dictionary<string, string>()
            {
                ["drinkInitial"] = ticketBreakdown[0],
                ["sugars"] = ticketBreakdown[1],
                ["stick"] = ticketBreakdown[2]
            };
        }
    }
}
    