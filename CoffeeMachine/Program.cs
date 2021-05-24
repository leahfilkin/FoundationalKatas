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
                notEnoughMoney = drinkMaker.NotEnoughMoney(moneyGiven);
            }
            var recipe = drinkMaker.GetRecipe(drinkMaker.Drink);
            if (drinkMaker.IsOutOfIngredientsFor(recipe))
            {
                var ingredients = drinkMaker.GetOutOfStockIngredients();
                Output.CreateOutOfStockMessage(ingredients);
            }
            else
            {
                drinkMaker.MakeDrink(recipe);
                Output.CreateOrderInformation(drinkMaker.Drink);
            }
        }
    }
}