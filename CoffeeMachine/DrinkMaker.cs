using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
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

        public void MakeDrink(Ticket ticket, Recipe recipe)
        {   
            DeductIngredients(recipe);
        }

        public List<Ingredient> GetOutOfStockIngredient()
        {
            var ingredients = new List<Ingredient>();
            if (MilkLeft == 0)
            {
                ingredients.Add(Ingredient.Milk);
            }
            else
            {
                ingredients.Add(Ingredient.Water);
            }
            return ingredients;
        }

        public void DeductIngredients(Recipe recipe)
        {
            MilkLeft -= recipe.MilkNeeded;
            WaterLeft -= recipe.WaterNeeded;
        }

        public Recipe GetRecipe(DrinkType drinkType)
        {
            return new Recipe(drinkType);
        }

        public bool IsOutOfIngredientsFor(DrinkType drinkType)
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