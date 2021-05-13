using System.Linq;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class DrinkMaker : IBeverageQuantityChecker
    {
        public int MilkLeft { get; private set; }
        public int WaterLeft { get; private set; }
        public DrinkMaker(int milkLeft = 10, int waterLeft = 10)
        {
            MilkLeft = milkLeft;
            WaterLeft = waterLeft;
        }
        public void MakeDrink(Ticket ticket, double moneyGiven)
        {
            var recipe = GetRecipe(ticket.DrinkType);
            DeductIngredients(recipe);
            
        }

        private void DeductIngredients(Recipe recipe)
        {
            MilkLeft -= recipe.MilkNeeded;
            WaterLeft -= recipe.WaterNeeded;
        }

        private Recipe GetRecipe(DrinkType drinkType)
        {
             return new Recipe(drinkType);
        }
        

        public bool IsEmpty(DrinkType drinkType)
        {
            throw new System.NotImplementedException();
        }
    }
}