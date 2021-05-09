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
            var stringCommandWithDescriptors = ticket.ProvideDescriptorsForStringCommand(stringCommand);
            var actual = drinkMaker.DescribeOrderToCustomer(stringCommandWithDescriptors);
            Assert.Equal(expected, actual);
        }
    }
}