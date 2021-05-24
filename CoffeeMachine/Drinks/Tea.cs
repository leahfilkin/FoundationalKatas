namespace CoffeeMachine.Drinks
{
    public class Tea : Drink
    {
        public override double GetCost()
        {
            _cost = 0.4;
            return _cost;
        }

        public override string GetDescription()
        {
            _description = "tea";
            return _description;
        }

        public override DrinkType GetDrinkType()
        {
            DrinkType = DrinkType.Tea;
            return DrinkType;
        }
    }
}