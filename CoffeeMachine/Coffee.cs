using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Coffee : Drink
    {
        public override double Cost()
        {
            return Menu.Prices[DrinkType.Coffee];
        }

        public override string GetDescription()
        {
            _description = "coffee";
            return _description;
        }

        public override DrinkType GetDrinkType()
        {
            return DrinkType.Coffee;
        }
    }
}