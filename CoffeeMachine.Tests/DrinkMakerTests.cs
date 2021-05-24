using CoffeeMachine.Drinks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerTests
    {
        [Theory]
        [InlineData("T:1:0", "Drink maker makes 1 tea with 1 sugar and a stick")]
        [InlineData("H::", "Drink maker makes 1 chocolate with no sugar")]
        [InlineData("C:2:0","Drink maker makes 1 coffee with 2 sugars and a stick")]
        [InlineData("O::", "Drink maker makes 1 orange juice")]
        [InlineData("Hh:1:0", "Drink maker makes 1 extra hot chocolate with 1 sugar and a stick")]
        [InlineData("Ch::", "Drink maker makes 1 extra hot coffee with no sugar")]
        [InlineData("Th:2:0", "Drink maker makes 1 extra hot tea with 2 sugars and a stick")]
        public void CommandReturnsCorrectInfoMessages(string stringCommand, string expected)
        {
            var ticket = new Ticket();
            ticket.ToOrderDetails(stringCommand);
            var drinkMaker = new DrinkMaker(ticket,1, 1);
            var recipe = drinkMaker.GetRecipe(drinkMaker.Drink);
            drinkMaker.MakeDrink(recipe);
            var output = new Output();
            
            var actual = Output.CreateOrderInformation(drinkMaker.Drink);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.2, "C:1:0")]
        [InlineData(0.4, "O::")]
        public void DrinkMakerShouldReturnFalseIfMoneyIsTooShort(double moneyGiven, string stringCommand)
        {
            var ticket = new Ticket();
            ticket.ToOrderDetails(stringCommand);
            var drinkMaker = new DrinkMaker(ticket);
            var notEnoughMoney = drinkMaker.NotEnoughMoney(moneyGiven);
            Assert.True(notEnoughMoney);
        }

        [Theory]
        [InlineData("C::", 2)]
        [InlineData("O::", 3)]
        public void DrinkMakerUsesIngredientsBasedOnTicket(string stringCommand, int expected)
        {
            var milkLeft = 3;
            var waterLeft = 3;
            var ticket = new Ticket();
            ticket.ToOrderDetails(stringCommand);
            var drinkMaker = new DrinkMaker(ticket, milkLeft, waterLeft);
            var recipe = drinkMaker.GetRecipe(drinkMaker.Drink);
            
            drinkMaker.MakeDrink(recipe);
            
            Assert.Equal(expected, drinkMaker.MilkLeft);
            Assert.Equal(expected, drinkMaker.WaterLeft);
        }

        [Fact]
        public void MakesTea()
        {
            var ticket = new Ticket();
            var drinkMaker = new DrinkMaker(ticket);
            ticket.ToOrderDetails("T::");
            var recipe = drinkMaker.GetRecipe(drinkMaker.Drink);
            
            var tea = drinkMaker.MakeDrink(recipe);
            
            Assert.IsType<DrinkType>(tea.DrinkType);
        }
    }
    
}