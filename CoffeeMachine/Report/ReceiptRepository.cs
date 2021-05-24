using System.Collections.Generic;

namespace CoffeeMachine.Report
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly List<Receipt> _receipts;
        public ReceiptRepository(List<Receipt> receipts)
        {
            _receipts = receipts;
        }
        public void Add(Receipt receipt)
        {
            _receipts.Add(receipt);
        }

        public IList<Receipt> GetAll()
        {
            return _receipts;
        }
    }
}