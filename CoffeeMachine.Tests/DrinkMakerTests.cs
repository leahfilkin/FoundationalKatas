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
            var actual = drinkMaker.MakeDrink(ticket, 5);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.2)]
        [InlineData(0.4)]
        public void DrinkMakerShouldReturnMessageWithMissingMoneyAmountIfMoneyIsTooShort(double moneyGiven)
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            ticket.SeperateStringCommandIntoOrderDetails("C:1:0");
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
            ticket.SeperateStringCommandIntoOrderDetails(stringCommand);
            var actual = drinkMaker.MakeDrink(ticket, 5);
            Assert.Equal(expected, actual);
        }
        
    }
    
}