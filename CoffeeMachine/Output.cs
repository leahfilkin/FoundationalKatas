using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.Drinks;

namespace CoffeeMachine
{
    public class Output
    {

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

        public static string CreateOrderInformation(Drink drink)
        {
            return string.Join(" ", new [] {"Drink maker makes 1", drink.GetDescription()});
        }

        public static string CreateOutOfStockMessage(List<Ingredient> ingredients)
        {
            var stringIngredients = ToString(ingredients);
            return $"We don't have enough {string.Join(" or ", stringIngredients)} to make your order. The company has been notified.";
        }
    }
}