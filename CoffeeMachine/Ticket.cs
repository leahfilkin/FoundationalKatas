using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Ticket
    {
        public string DrinkInitial;
        public string DrinkName;
        public double Total;
        public int AmountOfSugars;
        public int Stick;
        

        public void GetDrinkName()
        {
            switch (DrinkInitial)
            {
                case "T":
                    DrinkName = "tea";
                    break;
                case "H":
                    DrinkName = "chocolate";
                    break;
                case "C":
                    DrinkName = "coffee";
                    break;
            }
        }

        public string GetSugarAndStickDescription()
        {
            var sugarAndStickDescription = "";
            switch (Convert.ToInt32(AmountOfSugars))
            {
                case 0:
                    sugarAndStickDescription = "no sugar - and therefore no stick";
                    break;
                case 1:
                    sugarAndStickDescription = $"{AmountOfSugars} sugar and a stick";
                    break;
                case 2:
                    sugarAndStickDescription = $"{AmountOfSugars} sugars and a stick";
                    break;
            }
            return sugarAndStickDescription;
        }

        public void SeperateStringCommandIntoOrderDetails(string ticketStringCommand)
        {
            var ticketBreakdown = ticketStringCommand.Split(":");
            DrinkInitial = ticketBreakdown[0];
            GetDrinkName();
            AmountOfSugars = Convert.ToInt32(ticketBreakdown[1] == "" ? "0" : ticketBreakdown[1]);
            Stick = Convert.ToInt32(ticketBreakdown[2] == "" ? "0" : ticketBreakdown[2]);
        }

        public void CalculateTotalCostBasedOnDrink()
        {
            switch (DrinkName)
            {
                case "coffee":
                    Total = 0.6;
                    break;
                case "tea":
                    Total = 0.4;
                    break;
                case "chocolate":
                    Total = 0.5;
                    break;
            }
        }
    }
}
    