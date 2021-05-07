using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public string DeliverOrderInformation(string ticketString)
        {
            
            var ticketBreakdown = ticketString.Split(":");
            var instructions = new Dictionary<string, string>()
            {
                ["drinkInitial"] = ticketBreakdown[0],
                ["sugars"] = ticketBreakdown[1],
                ["stick"] = ticketBreakdown[2]
            };
            var ticketInstance = new Ticket();
            var drink = ticketInstance.GetDrinkName(instructions);
            var sugarAndStickDescription = ticketInstance.GetSugarAndStickDescription(instructions);
            return $"Drink maker makes 1 {drink} with {sugarAndStickDescription}";
        }
    }
}