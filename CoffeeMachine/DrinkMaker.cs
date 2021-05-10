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
            ticket.GetDrinkName(ticketStringCommand);
            var sugarAndStickDescription = ticket.GetSugarAndStickDescription(ticketStringCommand);
            return $"Drink maker makes 1 {ticket.Drink} with {sugarAndStickDescription}";
        }

        public bool CheckIfEnoughMoneyIsGiven(double moneyGiven, double ticketPrice)
        {
            return moneyGiven >= ticketPrice;
        }

        public int CollectMoneyFromCustomer(double ticketPrice)
        {
            throw new NotImplementedException();
        }
    }
}