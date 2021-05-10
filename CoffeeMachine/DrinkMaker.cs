using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public string MakeDrink(Ticket ticket)
        {
            var sugarAndStickDescription = ticket.GetSugarAndStickDescription();
            return $"Drink maker makes 1 {ticket.DrinkName} with {sugarAndStickDescription}";
        }

        public bool CheckIfEnoughMoneyIsGivenForOrder(double moneyGiven, double ticketPrice)
        {
            return moneyGiven >= ticketPrice;
        }
    }
}