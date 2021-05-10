using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public string MakeDrink(Ticket ticket, double moneyGiven)
        {
            if (!(moneyGiven >= ticket.Total))
            {
                return $"You haven't given the drink machine enough money. You are {ticket.Total - moneyGiven} short";
            }
            var sugarAndStickDescription = ticket.GetSugarAndStickDescription();
            var orderInformation = string.Join(" ", new [] 
                    {"Drink maker makes 1", ticket.DrinkName, sugarAndStickDescription}
                .Where(x => x != ""));
            return orderInformation;
        }
    }
}