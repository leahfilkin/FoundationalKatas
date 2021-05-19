using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Chocolate : Drink
    {
        public Chocolate()
        {
            var description = DrinkType.Chocolate.ToString();
        }
        public override double Cost()
        {
            return Menu.Prices[DrinkType.Chocolate];
        }

        public override DrinkType GetDrinkType()
        {
            return DrinkType.Chocolate;
        }

    }
}