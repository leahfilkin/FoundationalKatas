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
                var ingredient = drinkMaker.GetOutOfStockIngredient();
                Output.DisplayOutOfStockMessage(ingredient);
            }
            else
            {
                drinkMaker.MakeDrink(ticket, recipe);
            }
        }
    }
}