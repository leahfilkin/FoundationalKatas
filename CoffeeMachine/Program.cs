using System;

namespace CoffeeMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var userInput = new UserInput();
            var ticket = new Ticket();
            var drinkMaker = new DrinkMaker(ticket, 2,2);
            var output = new Output();
            var stringCommand = userInput.GetStringCommand();
            var notEnoughMoney = true;
            ticket.ToOrderDetails(stringCommand);
            while (notEnoughMoney)
            {
                var moneyGiven = userInput.GetMoneyFromCustomerForTicket();
                notEnoughMoney = drinkMaker.NotEnoughMoney(ticket.Drink.Cost(), moneyGiven);
            }
            var recipe = drinkMaker.GetRecipe(ticket.DrinkType);
            if (drinkMaker.IsOutOfIngredientsFor(recipe.DrinkType))
            {
                var ingredients = drinkMaker.GetOutOfStockIngredient();
                output.DisplayOutOfStockMessage(ingredients);
            }
            else
            {
                drinkMaker.MakeDrink(recipe);
                output.DisplayOrderInformation(ticket);
            }
        }
    }
}