using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Ticket
    {
        public double Total;
        public string Drink;

        public void GetDrinkName(Dictionary<string, string> instructions)
        {
            var drink = "";
            switch (instructions["drinkInitial"])
            {
                case "T":
                    Drink = "tea";
                    break;
                case "H":
                    Drink = "chocolate";
                    break;
                case "C":
                    Drink = "coffee";
                    break;
            }
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

        public Dictionary<string, string> ProvideDescriptorsForStringCommand(string ticketStringCommand)
        {
            var ticketBreakdown = ticketStringCommand.Split(":");
            return new Dictionary<string, string>()
            {
                ["drinkInitial"] = ticketBreakdown[0],
                ["sugars"] = ticketBreakdown[1],
                ["stick"] = ticketBreakdown[2]
            };
        }

        public void CalculateTotal()
        {
            switch (Drink)
            {
                case "coffee":
                    Total = 0.6;
                    break;
                case "tea":
                    Total = 0.4;
                    break;
                case "chocolate":
                    Total = 0.5;
                    break;
            }
        }
    }
}
    