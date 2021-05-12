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
                new Receipt(Drink.Chocolate, 0.6)
                {
                    NumberOfChocolatesSold = 1,
                    TotalMoneyEarned = 0.6
                }
            };
        }
        
        [Fact]
        public void ReportShouldBeAbleToAggregateMultipleTickets()
        {
            var stringCommands = new List<string>()
            {
                "C::",
                "O::",
                "T:1:0"
            };
            var receiptRepository = new ReceiptRepository(new List<Receipt>());
            foreach (var t in stringCommands)
            {
                var drinkMaker = new DrinkMaker();
                var ticket = new Ticket();
                ticket.SeparateStringCommandIntoOrderDetails(t);
                drinkMaker.MakeDrink(ticket, 5);
                var receipt = new Receipt(ticket.Drink, ticket.Total);
                receiptRepository.Add(receipt);
            }
            var report = new Report(receiptRepository);
            report.CalculateTotals();
            Assert.Equal(1.6, report.ReportDetails["Total Money Earned"]);
        }
    }
}