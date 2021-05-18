using System.Collections.Generic;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public interface IOutput
    {
        public void DisplayOrderInformation(Ticket ticket);

        public void DisplayOutOfStockMessage(List<Ingredient> ingredient);
    }
}