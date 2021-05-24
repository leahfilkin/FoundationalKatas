using System;
using CoffeeMachine.Report;
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
            Assert.Throws<ArgumentException>(() => ticket.ToOrderDetails(stringCommand));
        }
        
        [Fact]
        public void ReceiptShouldReflectTicketInformation()
        {
            var ticket = new Ticket();
            var stringCommand = "C::";
            ticket.ToOrderDetails(stringCommand);
            var drinkMaker = new DrinkMaker(ticket);
            var recipe = drinkMaker.GetRecipe(drinkMaker.Drink);
            
            drinkMaker.MakeDrink(recipe);
            
            var receipt = new Receipt(drinkMaker.Drink, drinkMaker.Drink.GetCost());
            
            Assert.Equal(1, receipt.NumberOfCoffeesSold);
        }
    }
}