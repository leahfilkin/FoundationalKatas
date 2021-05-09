using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public string DescribeOrderToCustomer(Dictionary<string, string> ticketStringCommand)
        {
            var ticket = new Ticket();
            var drink = ticket.GetDrinkName(ticketStringCommand);
            var sugarAndStickDescription = ticket.GetSugarAndStickDescription(ticketStringCommand);
            return $"Drink maker makes 1 {drink} with {sugarAndStickDescription}";
        }
    }
}