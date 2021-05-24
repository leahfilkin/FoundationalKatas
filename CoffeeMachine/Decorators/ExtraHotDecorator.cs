using CoffeeMachine.Drinks;

namespace CoffeeMachine.Decorators
{
    public class ExtraHotDecorator : CondimentDecorator
    {
        private readonly Drink _drink;

        public ExtraHotDecorator(Drink drink)
        {
            _drink = drink;
        }
        
        public override string GetDescription()
        {
                return "extra hot " + _drink.GetDescription();
        }

        public override DrinkType GetDrinkType()
        {
            return _drink.DrinkType;
        }

        public override double GetCost()
        {
            return _drink.GetCost();
        }
    }
}