using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerTests
    {
        [Theory]
        [InlineData("T:1:0", "Drink maker makes 1 tea with 1 sugar and a stick")]
        [InlineData("H::", "Drink maker makes 1 chocolate with no sugar")]
        [InlineData("C:2:0","Drink maker makes 1 coffee with 2 sugars and a stick")]
        public void DrinkMakerReturnsOrderInformationBasedOnTicket(string stringCommand, string expected)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            var actual = drinkMaker.MakeDrink(ticket, 5);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.2, "C:1:0")]
        [InlineData(0.4, "O::")]
        public void DrinkMakerShouldReturnMessageWithMissingMoneyAmountIfMoneyIsTooShort(double moneyGiven, string stringCommand)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            ticket.CalculateTotalCostBasedOnDrink();
            var expected = $"You haven't given the drink machine enough money. You are {ticket.Total - moneyGiven} short";
            var actual = drinkMaker.MakeDrink(ticket, moneyGiven);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("O::", "Drink maker makes 1 orange juice")]
        public void DrinkMakerReturnsOrderInformationForOrangeJuice(string stringCommand, string expected)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            var actual = drinkMaker.MakeDrink(ticket, 5);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hh:1:0", "Drink maker makes 1 extra hot chocolate with 1 sugar and a stick")]
        [InlineData("Ch::", "Drink maker makes 1 extra hot coffee with no sugar")]
        [InlineData("Th:2:0", "Drink maker makes 1 extra hot tea with 2 sugars and a stick")]
        public void DrinkMakerShouldAcceptExtraHotOptionForHotDrinks(string stringCommand, string expected)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            var actual = drinkMaker.MakeDrink(ticket, 5);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void DrinkMakerHasOneLessMilkAndWaterAfterMakingCoffee()
        {
            var milkLeft = 3;
            var waterLeft = 3;
            var drinkMaker = new DrinkMaker(milkLeft, waterLeft);
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails("C::");
            
            var message = drinkMaker.MakeDrink(ticket, 5);
            
            Assert.Equal(2, drinkMaker.MilkLeft);
            Assert.Equal(2, drinkMaker.WaterLeft);
        }

        [Theory]
        [InlineData("C::", 2)]
        [InlineData("O::", 3)]
        public void DrinkMakerUsesIngredientsBasedOnTicket(string stringCommand, int expected)
        {
            var milkLeft = 3;
            var waterLeft = 3;
            var drinkMaker = new DrinkMaker(milkLeft, waterLeft);
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            
            var message = drinkMaker.MakeDrink(ticket, 5);
            
            Assert.Equal(expected, drinkMaker.MilkLeft);
            Assert.Equal(expected, drinkMaker.WaterLeft);
        }

        [Fact]
        public void DrinkMakerRunsOutOfMilk_PrintsError()
        {
            var expectedErrorMessage = "There is a shortage in milk. We have notified the manager.";
            var milkLeft = 0;
            var waterLeft = 3;
            var drinkMaker = new DrinkMaker(milkLeft, waterLeft);
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails("C::");

            var actualErrorMessage = drinkMaker.MakeDrink(ticket, 4);
            
            Assert.Equal(expectedErrorMessage, actualErrorMessage);

        }
        
    }
    
}