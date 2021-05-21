using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Recipe
    {
        public readonly Drink Drink;
        public int MilkNeeded;
        public int WaterNeeded;

        public Recipe(Drink drink)
        {
            Drink = drink;
            CalculateIngredientsNeededToMakeDrink();
        }

        private void CalculateIngredientsNeededToMakeDrink()
        {
            if (!(Drink is OrangeJuice))
            {
                MilkNeeded = 1;
                WaterNeeded = 1;
            }
        }
    }
}