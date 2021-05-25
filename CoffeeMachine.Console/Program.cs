namespace CoffeeMachine.Console
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var ticket = new Ticket();
            var stringCommand = UserInterface.GetStringCommand();
            ticket.ToOrderDetails(stringCommand);
            var drinkMaker = new DrinkMaker(ticket);
            Validator.CheckPayment(drinkMaker.Drink.GetCost());
            var recipe = drinkMaker.GetRecipe(drinkMaker.Drink);
            Validator.CheckStock(recipe, drinkMaker);
            drinkMaker.MakeDrink(recipe);
            UserInterface.PrintOrderInformation(drinkMaker.Drink);
        }
    }
}