using System;

namespace CoffeeMachine.Console
{
    public static class Validator
    {
        public static void CheckPayment(double cost)
        {
            var moneyInput = UserInterface.AskForMoney();
            if (!double.TryParse(moneyInput, out var validMoney))
            {
                System.Console.WriteLine(
                    "You inputted money incorrectly. Please enter your money only using digits and the . symbol");
                CheckPayment(cost);
            }
            if (validMoney >= cost) return; //move to kata logic
            System.Console.WriteLine(
                $"You haven't given the drink machine enough money. You are {cost - validMoney} short");
            CheckPayment(cost);
        }

        public static void CheckStock(Recipe recipe, DrinkMaker drinkMaker)
        {
            if (!drinkMaker.IsOutOfIngredientsFor(recipe)) return; //move to kata logic & write test
            var ingredients = drinkMaker.GetOutOfStockIngredients(); //move to kata logic
            UserInterface.PrintOutOfStockMessage(ingredients);
            Environment.Exit(0);
        }
    }
}