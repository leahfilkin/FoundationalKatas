using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public abstract class Drink
    {
        protected string _description;
        public readonly DrinkType DrinkType;

        public abstract string GetDescription();

        public abstract DrinkType GetDrinkType();

        public abstract double Cost();
    }
}