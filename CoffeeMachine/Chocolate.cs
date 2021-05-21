using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Chocolate : Drink
    {
        public override double Cost()
        {
            return Menu.Prices[DrinkType.Chocolate];
        }

        public override string GetDescription()
        {
            _description = "chocolate";
            return _description;
        }

        public override DrinkType GetDrinkType()
        {
            return DrinkType.Chocolate;
        }

    }
}