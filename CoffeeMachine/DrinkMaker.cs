using System;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public int MilkLeft { get; private set; }
        public int WaterLeft { get; private set; }
        public DrinkMaker(int milkLeft = 10, int waterLeft = 10)
        {
            MilkLeft = milkLeft;
            WaterLeft = waterLeft;
        }
        public void MakeDrink(Ticket ticket)
        {
            var recipe = GetRecipe(ticket.DrinkType);
            if (IsOutOfIngredientsFor(recipe.DrinkType))
            {
                var ingredient = GetOutOfStockIngredient();
                Output.DisplayOutOfStockMessage(ingredient);
            }
            else
            {
                DeductIngredients(recipe);
                Output.DisplayOrderInformation(ticket);
            }
        }

        private Ingredient GetOutOfStockIngredient()
        {
            if (MilkLeft == 0)
            {
                return Ingredient.Milk;
            }
            return Ingredient.Water;
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

        private bool IsOutOfIngredientsFor(DrinkType drinkType)
        {
            var recipe = GetRecipe(drinkType);
            if (MilkLeft < recipe.MilkNeeded || WaterLeft < recipe.WaterNeeded)
            {
                return true;
            }
            return false;
        }

        public bool NotEnoughMoney(double total, double moneyGiven)
        {
            if (moneyGiven >= total)
            {
                return false;
            }
            Console.WriteLine($"You haven't given the drink machine enough money. You are {total - moneyGiven} short");
            return true;
        }
    }
}