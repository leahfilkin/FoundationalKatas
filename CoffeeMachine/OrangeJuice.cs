using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class OrangeJuice : Drink
    {
        public override double Cost()
        {
            return Menu.Prices[DrinkType.OrangeJuice];
        }

        public override string GetDescription()
        {
            _description = "orange juice";
            return _description;
        }

        public override DrinkType GetDrinkType()
        {
            return DrinkType.OrangeJuice;
        }
    }
}