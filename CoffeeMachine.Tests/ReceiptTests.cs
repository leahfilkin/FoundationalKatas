using System.Collections.Generic;
using CoffeeMachine.Drinks;
using CoffeeMachine.Report;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReceiptTests
    {
        [Fact]
        public void ReceiptShouldBeGeneratedOnDemand() //intergration test
        {
            var receipt = new Receipt(new Chocolate(), 0.6) {NumberOfChocolatesSold = 1};
            var receiptList = new List<Receipt>();
            var receiptRepository = new ReceiptRepository(receiptList);
            receiptRepository.Add(receipt);
            
            var receipts = receiptRepository.GetAll();
            
            Assert.Equal(1, receipts.Count);
        }
    }
}