using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerTests
    {
        [Theory]
        [InlineData("T:1:0", "Drink maker makes 1 tea with 1 sugar and a stick")]
        [InlineData("H::", "Drink maker makes 1 chocolate with no sugar - and therefore no stick")]
        [InlineData("C:2:0","Drink maker makes 1 coffee with 2 sugars and a stick")]
        public void DrinkMakerReturnsOrderInformationBasedOnTicket(string stringCommand, string expected)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeperateStringCommandIntoOrderDetails(stringCommand);
            var actual = drinkMaker.MakeDrink(ticket);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("T:1:0", 0.4)]
        [InlineData("H::", 0.7)]
        [InlineData("C:2:0", 5.0)]
        public void DrinkMakerShouldReturnTrueIfEnoughMoneyIsGiven(string stringCommand, double moneyGiven)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeperateStringCommandIntoOrderDetails(stringCommand);
            ticket.CalculateTotalCostBasedOnDrink();
            var canMakeDrink = drinkMaker.CheckIfEnoughMoneyIsGivenForOrder(moneyGiven, ticket.Total);
            Assert.True(canMakeDrink);
        }

        [Theory]
        [InlineData("T:1:0", 0.3)]
        [InlineData("H::", 0.49)]
        [InlineData("C:2:0", 0.1)]
        public void DrinkMakerShouldReturnFalseIfNotEnoughMoneyIsGiven(string stringCommand, double moneyGiven)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeperateStringCommandIntoOrderDetails(stringCommand);
            ticket.CalculateTotalCostBasedOnDrink();
            var canMakeDrink = drinkMaker.CheckIfEnoughMoneyIsGivenForOrder(moneyGiven, ticket.Total);
            Assert.False(canMakeDrink);
        }
    }
}