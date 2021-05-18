using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Tea : Drink
    {
        public Tea()
        {
            var _description = DrinkType.Tea.ToString();
        }
        public override double Cost()
        {
            return Menu.Prices[DrinkType.Tea];
        }
    }
}