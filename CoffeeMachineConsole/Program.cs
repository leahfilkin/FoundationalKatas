namespace CoffeeMachine.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticket = new Ticket();
            var drinkMaker = new DrinkMaker(ticket, 2,2);
            var stringCommand = UserInterface.GetStringCommand();
            var notEnoughMoney = true;
            ticket.ToOrderDetails(stringCommand);
            while (notEnoughMoney)
            {
                var moneyGiven = UserInterface.GetMoneyFromCustomerForTicket();
                notEnoughMoney = drinkMaker.NotEnoughMoney(moneyGiven);
            }
            var recipe = drinkMaker.GetRecipe(drinkMaker.Drink);
            if (drinkMaker.IsOutOfIngredientsFor(recipe))
            {
                var ingredients = drinkMaker.GetOutOfStockIngredients();
                UserInterface.PrintOutOfStockMessage(ingredients);
            }
            else
            {
                drinkMaker.MakeDrink(recipe);
                UserInterface.PrintOrderInformation(drinkMaker.Drink);
            }
            
        }
    }
}