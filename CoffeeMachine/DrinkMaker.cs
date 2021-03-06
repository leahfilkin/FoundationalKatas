using System;
using System.Collections.Generic;
using CoffeeMachine.Decorators;
using CoffeeMachine.Drinks;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public int MilkLeft { get; private set; }
        public int WaterLeft { get; private set; }
        public Ticket Ticket { get; }
        
        public Drink Drink { get; set; }

        public DrinkMaker(Ticket ticket, int milkLeft = 10, int waterLeft = 10)
        {
            Ticket = ticket;
            GetDrink();
            MilkLeft = milkLeft;
            WaterLeft = waterLeft;
        }

        private void GetDrink()
        {
            Drink baseDrink = new Coffee();
            switch (Ticket.DrinkInitial)
            {
                case "C":
                    Drink = new Coffee();
                    break;
                case "T":
                    Drink = new Tea();
                    break;
                case "H":
                    Drink = new Chocolate();
                    break;
                case "O":
                    Drink = new OrangeJuice();
                    break;
                case "Ch":
                    baseDrink = new Coffee();
                    Drink = new ExtraHotDecorator(baseDrink);
                    break;
                case "Th":
                    baseDrink = new Tea();
                    Drink = new ExtraHotDecorator(baseDrink);
                    break;
                case "Hh":
                    baseDrink = new Chocolate();
                    Drink = new ExtraHotDecorator(baseDrink);
                    break;
            }
            var myDrink = Drink;
        }

        public Drink MakeDrink(Recipe recipe)
        {
            AddSugars();
            DeductIngredients(recipe);
            return Drink;
        }

        private void AddSugars()
        {
            if (!(Drink is OrangeJuice))
            {
                Drink = new SugarDecorator(Drink, Ticket.AmountOfSugars);
            }
        }

        public List<Ingredient> GetOutOfStockIngredients()
        {
            var ingredients = new List<Ingredient>();
            if (MilkLeft == 0)
            {
                ingredients.Add(Ingredient.Milk);
            }
            if (WaterLeft == 0)
            {
                ingredients.Add(Ingredient.Water);
            }
            return ingredients;
        }

        private void DeductIngredients(Recipe recipe)
        {
            if (!(Drink is OrangeJuice))
            {
                MilkLeft -= recipe.MilkNeeded;
                WaterLeft -= recipe.WaterNeeded;
            }
        }

        public Recipe GetRecipe(Drink drink)
        {
            return new Recipe(drink);
        }

        public bool IsOutOfIngredientsFor(Recipe recipe)
        {
            if (MilkLeft < recipe.MilkNeeded || WaterLeft < recipe.WaterNeeded)
            {
                return true;
            }
            return false;
        }
    }
}