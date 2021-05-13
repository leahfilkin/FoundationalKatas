using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Recipe
    {
        public readonly DrinkType DrinkType;
        public int MilkNeeded;
        public int WaterNeeded;

        public Recipe(DrinkType drinkType)
        {
            DrinkType = drinkType;
            CalculateIngredientsNeededToMakeDrink();
        }

        private void CalculateIngredientsNeededToMakeDrink()
        {
            if (DrinkType != DrinkType.OrangeJuice)
            {
                MilkNeeded = 1;
                WaterNeeded = 1;
            }
        }
    }
}