using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Recipe
    {
        private readonly DrinkType _drinkType;
        public int MilkNeeded;
        public int WaterNeeded;

        public Recipe(DrinkType drinkType)
        {
            _drinkType = drinkType;
            CalculateIngredientsNeededToMakeDrink();
        }

        private void CalculateIngredientsNeededToMakeDrink()
        {
            if (_drinkType != DrinkType.OrangeJuice)
            {
                MilkNeeded = 1;
                WaterNeeded = 1;
            }
        }
    }
}