using System;

namespace CoffeeMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var userInput = new UserInput();
            var ticket = new Ticket();
            var drinkMaker = new DrinkMaker(2,2);
            var output = new Output();
            var stringCommand = userInput.GetStringCommand();
            var notEnoughMoney = true;
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            ticket.CalculateTotalTicketCost();
            while (notEnoughMoney)
            {
                var moneyGiven = userInput.GetMoneyFromCustomerForTicket();
                notEnoughMoney = drinkMaker.NotEnoughMoney(ticket.Total, moneyGiven);
            }
            var recipe = drinkMaker.GetRecipe(ticket.DrinkType);
            if (drinkMaker.IsOutOfIngredientsFor(recipe.DrinkType))
            {
                var ingredients = drinkMaker.GetOutOfStockIngredient();
                output.DisplayOutOfStockMessage(ingredients);
            }
            else
            {
                drinkMaker.MakeDrink(ticket, recipe);
                output.DisplayOrderInformation(ticket);
            }
        }
    }
}