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
        public void DrinkMakerReturnsCorrectStringBasedOnTicket(string ticket, string expected)
        {
            var drinkMaker = new DrinkMaker();
            var actual = drinkMaker.DeliverOrderInformation(ticket);
            Assert.Equal(expected, actual);
        }
    }
}