using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CoffeeMachine
{
    public class Ticket
    {
        private string _drinkInitial;
        public string DrinkName { get; private set; }
        public double Total { get; private set; }
        public int AmountOfSugars;

        public void GetDrinkName()
        {
            var menu = new Menu();
            DrinkName = menu.Drinks[_drinkInitial];
        }

        public string GetSugarAndStickDescription()
        {
            var sugarAndStickDescription = "";
            switch (Convert.ToInt32(AmountOfSugars))
            {
                case 0:
                    if (DrinkName != "orange juice")
                    {
                        sugarAndStickDescription = "with no sugar - and therefore no stick";
                    }
                    break;
                case 1:
                    sugarAndStickDescription = $"with {AmountOfSugars} sugar and a stick";
                    break;
                default:
                    sugarAndStickDescription = $"with {AmountOfSugars} sugars and a stick";
                    break;
            }
            return sugarAndStickDescription;
        }

        public void SeperateStringCommandIntoOrderDetails(string ticketStringCommand)
        {
            if (!new Regex(@"[C|H|T|O|Ch|Hh|Th]\:\d?\:0?$").IsMatch(ticketStringCommand))
            {
                throw new ArgumentException();
            }
            var ticketBreakdown = ticketStringCommand.Split(":");
            _drinkInitial = ticketBreakdown[0];
            GetDrinkName();
            AmountOfSugars = Convert.ToInt32(ticketBreakdown[1] == "" ? "0" : ticketBreakdown[1]);
        }

        public void CalculateTotalCostBasedOnDrink()
        {
            var menu = new Menu();
            Total = menu.Prices[DrinkName];
        }
    }
}
    