using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public string MakeDrink(Ticket ticket, double moneyGiven)
        {
            if (moneyGiven >= ticket.Total)
            {
                var sugarAndStickDescription = ticket.GetSugarAndStickDescription();
                return $"Drink maker makes 1 {ticket.DrinkName} with {sugarAndStickDescription}";
            }
            return $"You haven't given the drink machine enough money. You are {ticket.Total - moneyGiven} short";
        }
    }
}