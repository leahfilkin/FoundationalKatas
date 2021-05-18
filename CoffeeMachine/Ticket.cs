using System;
using System.Text.RegularExpressions;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Ticket
    {
        private string _drinkInitial;
        public DrinkType DrinkType { get; private set; }
        public double Total { get; private set; }
        public int AmountOfSugars;

        private void GetDrinkName()
        {
            DrinkType = Menu.Drinks[_drinkInitial];
        }

        public void SeparateStringCommandIntoOrderDetails(string ticketStringCommand)
        {
            if (!new Regex(@"[C|H|T|O|Ch|Hh|Th]\:\d?\:0?$").IsMatch(ticketStringCommand))
            {
                throw new ArgumentException();
            }
            var ticketBreakdown = ticketStringCommand.Split(":");
            _drinkInitial = ticketBreakdown[0];
            GetDrinkName();
            AmountOfSugars = Convert.ToInt32(ticketBreakdown[1] == "" ? "0" : ticketBreakdown[1]);
            CalculateTotalTicketCost();
        }

        public void CalculateTotalTicketCost()
        {
            Total = Menu.Prices[DrinkType];
        }
    }
}
    