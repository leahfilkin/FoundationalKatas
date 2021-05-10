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
            Assert.Throws<ArgumentException>(() => ticket.SeperateStringCommandIntoOrderDetails(stringCommand));
        }
    }
}