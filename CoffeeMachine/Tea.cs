using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Tea : Drink
    {
        public override double Cost()
        {
            return Menu.Prices[DrinkType.Tea];
        }

        public override string GetDescription()
        {
            _description = "tea";
            return _description;
        }

        public override DrinkType GetDrinkType()
        {
            return DrinkType.Tea;
        }
    }
}