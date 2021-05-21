using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class FakeOutput : IOutput
    {
        public string OutputString = "";
        public void DisplayOrderInformation(Drink drink)
        {
            OutputString = "Drink maker makes 1 " + drink.GetDescription();
        }

        public void DisplayOutOfStockMessage(List<Ingredient> ingredients)
        {
            var stringIngredients = Output.ToString(ingredients);   
            OutputString = $"We don't have enough {string.Join(" or ", stringIngredients)} to make your order. The company has been notified";
        }

    }
}