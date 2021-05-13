using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public interface EmailNotifier
    {
        void notifyMissingDrink(DrinkType drinkType);
    }
}