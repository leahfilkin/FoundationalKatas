using System.Collections.Generic;

namespace CoffeeMachine
{
    public interface IReceiptRepository
    { 
        void Add(Receipt receipt);

        IList<Receipt> GetAll();
    }
}