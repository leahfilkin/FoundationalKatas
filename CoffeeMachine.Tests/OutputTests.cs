using Xunit;

namespace CoffeeMachine.Tests
{
    public class OutputTests
    {
        [Theory]
        [InlineData(0,0, "We don't have enough milk or water to make your order. The company has been notified.")]
        [InlineData(3,0, "We don't have enough water to make your order. The company has been notified." )]
        [InlineData(0,3, "We don't have enough milk to make your order. The company has been notified.")]
        public void OutputPrintsErrorWhenNotEnoughIngredientsForDrink(int milkLeft, int waterLeft, string expectedErrorMessage)
        {
            var ticket = new Ticket();
            var drinkMaker = new DrinkMaker(ticket, milkLeft, waterLeft);
            ticket.ToOrderDetails("C::");
            var ingredient = drinkMaker.GetOutOfStockIngredients();
            var output = new Output();

            var actualErrorMessage = Output.CreateOutOfStockMessage(ingredient);
            
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }
    }
}