using System;
using System.Text.RegularExpressions;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Ticket
    {
        public string DrinkInitial;
        public DrinkType DrinkType { get; private set; }
        
        public Drink Drink { get; set; }
   
        public int AmountOfSugars;

        private void GetDrinkName()
        {
            DrinkType = Menu.Drinks[DrinkInitial];
        }

        public void ToOrderDetails(string command)
        {
            if (!new Regex(@"[C|H|T|O|Ch|Hh|Th]\:\d?\:0?$").IsMatch(command))
            {
                throw new ArgumentException();
            }
            var ticketBreakdown = command.Split(":");
            DrinkInitial = ticketBreakdown[0];
            AmountOfSugars = Convert.ToInt32(ticketBreakdown[1] == "" ? "0" : ticketBreakdown[1]);
        }

        private Drink GetDrink()
        {
            Drink drink = new Coffee();
            switch (DrinkInitial)
            {
                case "C":
                    drink = new Coffee();
                    break;
                case "T":
                    drink = new Tea();
                    break;
                case "H":
                    drink = new Chocolate();
                    break;
                case "O":
                    drink = new OrangeJuice();
                    break;
                case "Ch":
                    drink = new ExtraHotDecorator(new Coffee());
                    break;
                case "Th":
                    drink = new ExtraHotDecorator(new Tea());
                    break;
                case "Hh":
                    drink = new ExtraHotDecorator(new Chocolate());
                    break;
            }
            return drink;
        }
    }
}
    