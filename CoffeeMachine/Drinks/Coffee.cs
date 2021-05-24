namespace CoffeeMachine.Drinks
{
    public class Coffee : Drink
    {
        public override double GetCost()
        {
            _cost = 0.6;
            return _cost;
        }

        public override string GetDescription()
        {
            _description = "coffee";
            return _description;
        }

        public override DrinkType GetDrinkType()
        {
            DrinkType = DrinkType.Coffee;
            return DrinkType;
        }
    }
}