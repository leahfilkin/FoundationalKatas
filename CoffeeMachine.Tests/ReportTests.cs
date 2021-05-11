using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReportTests
    {
        [Theory]
        [MemberData(nameof(ReceiptData))]
        public void ReportShouldCalculateTotalsCorrectly(Receipt receipt)
        {
            var receiptList = new List<Receipt>();
            var receiptRepository = new ReceiptRepository(receiptList);
            receiptRepository.Add(receipt);
            var report = new Report(receiptRepository);
            report.CalculateTotals();
            Assert.Equal("0,0,1,0,0.6", string.Join(",", report.ReportDetails.Values));
        }

        public static IEnumerable<object[]> ReceiptData()
        {
            yield return new object[]
            {
                new Receipt()
                {
                    NumberOfChocolatesSold = 1,
                    TotalMoneyEarned = 0.6
                }
            };
        }
    }
}