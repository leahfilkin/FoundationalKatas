using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public interface IBeverageQuantityChecker
    {
        public bool IsEmpty(DrinkType drinkType);
    }
}