using System.Collections.Generic;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public interface IOutput
    {
        public void DisplayOrderInformation(Drink drink);

        public void DisplayOutOfStockMessage(List<Ingredient> ingredient);
    }
}