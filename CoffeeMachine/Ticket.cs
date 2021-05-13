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
        private int _amountOfSugars;

        private void GetDrinkName()
        {
            var menu = new Menu();
            DrinkType = menu.Drinks[_drinkInitial];
        }

        public string GetSugarAndStickDescription()
        {
            var menu = new Menu();
            var sugarAndStickDescription = "";
            switch (Convert.ToInt32(_amountOfSugars))
            {
                case 0:
                    if (menu.HotDrinks.Contains(DrinkType))
                    {
                        sugarAndStickDescription = "with no sugar";
                    }
                    break;
                case 1:
                    sugarAndStickDescription = $"with {_amountOfSugars} sugar and a stick";
                    break;
                default:
                    sugarAndStickDescription = $"with {_amountOfSugars} sugars and a stick";
                    break;
            }
            return sugarAndStickDescription;
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
            _amountOfSugars = Convert.ToInt32(ticketBreakdown[1] == "" ? "0" : ticketBreakdown[1]);
            CalculateTotalCostBasedOnDrink();
        }

        public void CalculateTotalCostBasedOnDrink()
        {
            var menu = new Menu();
            Total = menu.Prices[DrinkType];
        }
    }
}
    