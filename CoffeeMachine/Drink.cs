using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public abstract class Drink
    {
        private readonly string _description = DrinkType.UnknownDrink.ToString();

        public string GetDescription()
        {
            return _description;
        }

        public abstract double Cost();
    }
}