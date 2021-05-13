using System;
using System.Linq;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Output
    {
        public static string ConvertDrinkNameToString(DrinkType drinkType)
        {
            var drinkString = "";
            switch (drinkType)
            {
                case DrinkType.Coffee:
                    drinkString = "coffee";
                    break;
                case DrinkType.Tea:
                    drinkString = "tea";
                    break;
                case DrinkType.Chocolate:
                    drinkString = "chocolate";
                    break;
                case DrinkType.OrangeJuice:
                    drinkString = "orange juice";
                    break;
                case DrinkType.ExtraHotCoffee:
                    drinkString = "extra hot coffee";
                    break;
                case DrinkType.ExtraHotTea:
                    drinkString = "extra hot tea";
                    break;
                case DrinkType.ExtraHotChocolate:
                    drinkString = "extra hot chocolate";
                    break;
            }
            return drinkString;
        }
        public static void DisplayOrderInformation(Ticket ticket, double moneyGiven)
        {
            var drinkName = ConvertDrinkNameToString(ticket.DrinkType);
            if (!(moneyGiven >= ticket.Total))
            {
                Console.WriteLine($"You haven't given the drink machine enough money. You are {ticket.Total - moneyGiven} short");
            }
            Console.WriteLine(string.Join(" ", new [] {"Drink maker makes 1", drinkName, ticket.GetSugarAndStickDescription()}
                .Where(x => x != "")));
        }
    }
}