using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReportTests
    {
        [Fact]
        public void ReportShouldCalculateAmountOfDrinksBoughtPerDrink()
        {
            var receipt = new Receipt{NumberOfChocolatesSold = 1};
            var receiptList = new List<Receipt>();
            var receiptRepository = new ReceiptRepository(receiptList);
            receiptRepository.Add(receipt);
            var report = new Report(receiptRepository);
            report.CalculateNumberOfDrinksSold();
            Assert.Equal("0,0,1,0,0", string.Join(",",report.ReportDetails.Values));
        }
    }
}