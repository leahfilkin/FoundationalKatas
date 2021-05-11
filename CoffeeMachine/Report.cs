using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Report
    {
        private IReceiptRepository _receiptRepository;
        public Dictionary<string, double> ReportDetails;
        public Report(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
            ReportDetails = new Dictionary<string, double>()
            {
                {"Number of Coffees Sold", 0},
                {"Number of Teas Sold", 0},
                {"Number of Chocolates Sold", 0},
                {"Number of Orange Juices Sold", 0},
                {"Total Money Earned", 0},
            };
        }

        public void CalculateTotals()
        {
            var receipts = _receiptRepository.GetAll();
            foreach (var receipt in receipts)
            {
                ReportDetails["Number of Coffees Sold"] += receipt.NumberOfCoffeesSold;
                ReportDetails["Number of Teas Sold"] += receipt.NumberOfTeasSold;
                ReportDetails["Number of Chocolates Sold"] += receipt.NumberOfChocolatesSold;
                ReportDetails["Number of Orange Juices Sold"] += receipt.NumberOfOrangeJuicesSold;
                ReportDetails["Total Money Earned"] += receipt.TotalMoneyEarned;
            }
        }

        public void CalculateTotalMoneyEarned()
        {
            throw new System.NotImplementedException();
        }
    }
}