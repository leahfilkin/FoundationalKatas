using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

        public static List<string> ToString(List<Ingredient> ingredients)
        {
            return ingredients.Select(ingredient => ingredient switch
                {
                    Ingredient.Milk => "milk",
                    Ingredient.Water => "water",
                    _ => ""
                })
                .ToList();
        }

        public void DisplayOrderInformation(Drink drink)
        {
            Console.WriteLine(string.Join(" ", new [] {"Drink maker makes 1", drink.GetDescription()}));
        }

        public void DisplayOutOfStockMessage(List<Ingredient> ingredients)
        {
            var stringIngredients = ToString(ingredients);
            Console.WriteLine($"We don't have enough {string.Join(" or ", stringIngredients)} to make your order. The company has been notified");
        }
    }
}