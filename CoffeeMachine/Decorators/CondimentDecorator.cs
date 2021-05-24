using CoffeeMachine.Drinks;

namespace CoffeeMachine.Decorators
{
    public abstract class CondimentDecorator : Drink
    {
        public abstract override double GetCost();
        public abstract override DrinkType GetDrinkType();

    }
}