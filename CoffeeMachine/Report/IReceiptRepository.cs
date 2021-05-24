using System.Collections.Generic;

namespace CoffeeMachine.Report
{
    public interface IReceiptRepository
    { 
        void Add(Receipt receipt);

        IList<Receipt> GetAll();
    }
}