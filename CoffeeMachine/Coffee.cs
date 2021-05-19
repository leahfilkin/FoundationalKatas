using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Coffee : Drink
    {
        public Coffee()
        {
        var description = DrinkType.Coffee.ToString();
        }

        public override double Cost()
        {
            return Menu.Prices[DrinkType.Coffee];
        }
        
        public override DrinkType GetDrinkType()
        {
            return DrinkType.Coffee;
        }
    }
}