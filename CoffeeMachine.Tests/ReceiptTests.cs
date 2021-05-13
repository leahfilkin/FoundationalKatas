using System.Collections.Generic;
using CoffeeMachine.Enums;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReceiptTests
    {
        [Fact]
        public void ReceiptShouldBeGeneratedOnDemand()
        {
            var receipt = new Receipt(DrinkType.Chocolate, 0.6) {NumberOfChocolatesSold = 1};
            var receiptList = new List<Receipt>();
            var receiptRepository = new ReceiptRepository(receiptList);
            receiptRepository.Add(receipt);
            var receipts = receiptRepository.GetAll();
            Assert.Equal(1, receipts.Count);
        }
    }
}