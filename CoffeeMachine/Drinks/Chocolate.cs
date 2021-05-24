namespace CoffeeMachine.Drinks
{
    public class Chocolate : Drink
    {
        public override double GetCost()
        {
            _cost = 0.5;
            return _cost;
        }

        public override string GetDescription()
        {
            _description = "chocolate";
            return _description;
        }

        public override DrinkType GetDrinkType()
        {
            DrinkType = DrinkType.Chocolate;
            return DrinkType;
        }

    }
}