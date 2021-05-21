using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public abstract class CondimentDecorator : Drink
    {
        public abstract override double Cost();
        public abstract override DrinkType GetDrinkType();

    }
}