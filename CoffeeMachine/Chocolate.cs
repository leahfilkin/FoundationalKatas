using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Chocolate : Drink
    {
        public Chocolate()
        {
            var _description = DrinkType.Chocolate.ToString();
        }
        public override double Cost()
        {
            return Menu.Prices[DrinkType.Chocolate];
        }
    }
}