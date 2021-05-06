using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public string DeliverOrderInformation(string ticket)
        {
            
            var ticketInfo = ticket.Split(":");
            var instructions = new Dictionary<string, string>()
            {
                ["drinkInitial"] = ticketInfo[0],
                ["sugars"] = ticketInfo[1],
                ["stick"] = ticketInfo[2]
            };
            var drink = "";
            switch (instructions["drinkInitial"])
            {
                case "T":
                    drink = "tea";
                    break;
                case "H":
                    drink = "chocolate";
                    break;
                case "C" :
                    drink = "coffee";
                    break;
            }
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
            return $"Drink maker makes 1 {drink} with {sugarAndStickDescription}";
        }
    }
}