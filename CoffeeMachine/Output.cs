using System;
using System.Linq;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Output
    {
        public static string ToString(DrinkType drinkType)
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

        public static string ToString(Ingredient ingredient)
        {
            var stringIngredient = "";
            switch (ingredient)
            {
                case Ingredient.Milk:
                    stringIngredient = "milk";
                    break;
                case Ingredient.Water:
                    stringIngredient = "water";
                    break;
            }
            return stringIngredient;
        }

        public static void DisplayOrderInformation(Ticket ticket)
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
            var menu = new Menu();
            var sugarAndStickDescription = "";
            switch (Convert.ToInt32(ticket.AmountOfSugars))
            {
                case 0:
                    if (menu.HotDrinks.Contains(ticket.DrinkType))
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