using CoffeeMachine.Drinks;

namespace CoffeeMachine.Decorators
{
    public class SugarDecorator : CondimentDecorator
    {
        private Drink _drink;
        private int _amount;

        public SugarDecorator(Drink drink, int amountOfSugars)
        {
            _drink = drink;
            _amount = amountOfSugars;
        }
        
        public override string GetDescription()
        {
            return _amount switch
            {
                0 => _drink.GetDescription() + " with no sugar",
                1 => _drink.GetDescription() + $" with {_amount} sugar and a stick",
                _ => _drink.GetDescription() + $" with {_amount} sugars and a stick"
            };
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