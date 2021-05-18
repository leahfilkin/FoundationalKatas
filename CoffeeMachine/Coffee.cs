using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Coffee : Drink
    {
        public Coffee()
        {
        var _description = DrinkType.Coffee.ToString();
        }

        public override double Cost()
        {
            return Menu.Prices[DrinkType.Coffee];
        }
    }
}