namespace CoffeeMachine.Drinks
{
    public abstract class Drink
    {
        protected string _description;
        public DrinkType DrinkType;
        protected double _cost;

        public abstract string GetDescription();

        public abstract DrinkType GetDrinkType();

        public abstract double GetCost();
    }
}