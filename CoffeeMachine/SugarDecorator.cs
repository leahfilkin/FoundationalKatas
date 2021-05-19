using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class SugarDecorator : CondimentDecorator
    {
        private readonly Drink _drink;
        private readonly int _amount;

        public SugarDecorator(Drink drink, int amountOfSugars)
        {
            _drink = drink;
            _amount = amountOfSugars;
        }
        
        public override string GetDescription()
        {
            if (_amount > 1)
            {
                return _drink.GetDescription() + $"with {_amount} sugars and a stick";
            }
            return _drink.GetDescription() + $"with {_amount} sugar and a stick";
        }

        public override DrinkType GetDrinkType()
        {
            return _drink.DrinkType;
        }

        public override double Cost()
        {
            return _drink.Cost();
        }
    }
}