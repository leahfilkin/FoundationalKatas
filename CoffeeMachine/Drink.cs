using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public abstract class Drink
    {
        private readonly string _description;
        public readonly DrinkType DrinkType;

        public string GetDescription()
        {
            return _description;
        }

        public abstract DrinkType GetDrinkType();

        public abstract double Cost();
    }
}