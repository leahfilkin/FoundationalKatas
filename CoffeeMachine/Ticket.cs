using System;
using System.Text.RegularExpressions;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Ticket
    {
        public string DrinkInitial;
        
        public int AmountOfSugars;

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
    }
}
    