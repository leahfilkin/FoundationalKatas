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
        [InlineData("O::", "Drink maker makes 1 orange juice")]
        [InlineData("Hh:1:0", "Drink maker makes 1 extra hot chocolate with 1 sugar and a stick")]
        [InlineData("Ch::", "Drink maker makes 1 extra hot coffee with no sugar")]
        [InlineData("Th:2:0", "Drink maker makes 1 extra hot tea with 2 sugars and a stick")]
        public void StringCommandReturnsCorrectInfoMessages(string stringCommand, string expected)
        {
            var ticket = new Ticket();
            var drinkMaker = new DrinkMaker(0,0);
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            var recipe = drinkMaker.GetRecipe(ticket.DrinkType);
            drinkMaker.DeductIngredients(recipe);
            var fakeOutput = new FakeOutput();
            
            fakeOutput.DisplayOrderInformation(ticket);
            
            Assert.Equal(expected, fakeOutput.OutputString);
        }

        [Theory]
        [InlineData(0.2, "C:1:0")]
        [InlineData(0.4, "O::")]
        public void DrinkMakerShouldReturnFalseIfMoneyIsTooShort(double moneyGiven, string stringCommand)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            ticket.CalculateTotalTicketCost();
            var notEnoughMoney = drinkMaker.NotEnoughMoney(ticket.Total, moneyGiven);
            Assert.True(notEnoughMoney);
        }

        [Fact]
        public void DrinkMakerHasOneLessMilkAndWaterAfterMakingCoffee()
        {
            var milkLeft = 3;
            var waterLeft = 3;
            var drinkMaker = new DrinkMaker(milkLeft, waterLeft);
            var ticket = new Ticket();
            ticket.SeparateStringCommandIntoOrderDetails("C::");
            var recipe = drinkMaker.GetRecipe(ticket.DrinkType);
            
            drinkMaker.MakeDrink(ticket, recipe);
            
            Assert.Equal(2, drinkMaker.MilkLeft);
            Assert.Equal(2, drinkMaker.WaterLeft);
        }

        // [Theory]
        // [InlineData("C::", 2)]
        // [InlineData("O::", 3)]
        // public void DrinkMakerUsesIngredientsBasedOnTicket(string stringCommand, int expected)
        // {
        //     var milkLeft = 3;
        //     var waterLeft = 3;
        //     var drinkMaker = new DrinkMaker(milkLeft, waterLeft);
        //     var ticket = new Ticket();
        //     ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
        //     
        //     var message = drinkMaker.MakeDrink(ticket, 5);
        //     
        //     Assert.Equal(expected, drinkMaker.MilkLeft);
        //     Assert.Equal(expected, drinkMaker.WaterLeft);
        // }
        //
        // [Fact]
        // public void DrinkMakerRunsOutOfMilk_PrintsError()
        // {
        //     var expectedErrorMessage = "There is a shortage in milk. We have notified the manager.";
        //     var milkLeft = 0;
        //     var waterLeft = 3;
        //     var drinkMaker = new DrinkMaker(milkLeft, waterLeft);
        //     var ticket = new Ticket();
        //     ticket.SeparateStringCommandIntoOrderDetails("C::");
        //
        //     var actualErrorMessage = drinkMaker.MakeDrink(ticket, 4);
        //     
        //     Assert.Equal(expectedErrorMessage, actualErrorMessage);
        //
        // }
        
    }
    
}