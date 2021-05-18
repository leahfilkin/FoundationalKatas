using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class OrangeJuice : Drink
    {
        public OrangeJuice()
        {
            var _description = DrinkType.OrangeJuice.ToString();
        }
        public override double Cost()
        {
            return Menu.Prices[DrinkType.OrangeJuice];
        }
    }
}