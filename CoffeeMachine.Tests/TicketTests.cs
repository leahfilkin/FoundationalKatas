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
            Assert.Throws<ArgumentException>(() => ticket.ToOrderDetails(stringCommand));
        }
        
        [Fact]
        public void ReceiptShouldReflectTicketInformation()
        {
            var ticket = new Ticket();
            var drinkMaker = new DrinkMaker(ticket);
            var stringCommand = "C::";
            ticket.ToOrderDetails(stringCommand);
            var recipe = drinkMaker.GetRecipe(drinkMaker.Drink);
            drinkMaker.MakeDrink(recipe);
            
            var receipt = new Receipt(drinkMaker.Drink.GetDrinkType(), drinkMaker.Drink.Cost());
            
            Assert.Equal(1, receipt.NumberOfCoffeesSold);
        }
    }
}