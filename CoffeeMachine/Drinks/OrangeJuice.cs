namespace CoffeeMachine.Drinks
{
    public class OrangeJuice : Drink
    {
        public override double GetCost()
        {
            _cost = 0.6;
            return _cost;
        }

        public override string GetDescription()
        {
            _description = "orange juice";
            return _description;
        }

        public override DrinkType GetDrinkType()
        {
            DrinkType = DrinkType.OrangeJuice;
            return DrinkType;
        }
    }
}