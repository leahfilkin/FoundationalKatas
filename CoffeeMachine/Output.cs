using System;
using System.IO;
using System.Linq;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Output : IOutput
    {
        public static string ToString(DrinkType drinkType)
        {
            var drinkString = drinkType switch
            {
                DrinkType.Coffee => "coffee",
                DrinkType.Tea => "tea",
                DrinkType.Chocolate => "chocolate",
                DrinkType.OrangeJuice => "orange juice",
                DrinkType.ExtraHotCoffee => "extra hot coffee",
                DrinkType.ExtraHotTea => "extra hot tea",
                DrinkType.ExtraHotChocolate => "extra hot chocolate",
                _ => ""
            };
            return drinkString;
        }

        private static string ToString(Ingredient ingredient)
        {
            var stringIngredient = ingredient switch
            {
                Ingredient.Milk => "milk",
                Ingredient.Water => "water",
                _ => ""
            };
            return stringIngredient;
        }

        public void DisplayOrderInformation(Ticket ticket)
        {
            var drinkName = ToString(ticket.DrinkType);
            Console.WriteLine(string.Join(" ", new [] {"Drink maker makes 1", drinkName, GetSugarAndStickDescription(ticket)}
                .Where(x => x != "")));
        }

        public static void DisplayOutOfStockMessage(Ingredient ingredient)
        {
            var stringIngredient = ToString(ingredient);   
            Console.WriteLine($"We don't have enough {stringIngredient} to make your order. The company has been notified");
        }

        public static string GetSugarAndStickDescription(Ticket ticket)
        {
            var sugarAndStickDescription = "";
            switch (Convert.ToInt32(ticket.AmountOfSugars))
            {
                case 0:
                    if (ticket.DrinkType != DrinkType.OrangeJuice)
                    {
                        sugarAndStickDescription = "with no sugar";
                    }
                    break;
                case 1:
                    sugarAndStickDescription = $"with {ticket.AmountOfSugars} sugar and a stick";
                    break;
                default:
                    sugarAndStickDescription = $"with {ticket.AmountOfSugars} sugars and a stick";
                    break;
            }
            return sugarAndStickDescription;
        }
    }
}