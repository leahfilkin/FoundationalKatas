using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class TicketTests
    {
        [Theory]
        [InlineData("A::")]
        [InlineData("C::1")]
        [InlineData("Hh:Hh:")]
        [InlineData("")]
        [InlineData("::")]
        public void TicketShouldNotAcceptStringCommandsThatDontMatchPossibilities(string stringCommand)
        {
            var ticket = new Ticket();
            Assert.Throws<ArgumentException>(() => ticket.SeparateStringCommandIntoOrderDetails(stringCommand));
        }
        
        [Fact]
        public void ReceiptShouldMatchTicketThatItHasBeenCreatedFrom()
        {
            var drinkMaker = new DrinkMaker();
            var ticket = new Ticket();
            var stringCommand = "C::";
            ticket.SeparateStringCommandIntoOrderDetails(stringCommand);
            drinkMaker.MakeDrink(ticket, 5);
            var receipt = new Receipt(ticket.DrinkType, ticket.Total);
            Assert.Equal(1, receipt.NumberOfCoffeesSold);
        }
    }
}