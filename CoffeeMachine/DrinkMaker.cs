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
        public Ticket Ticket { get; }
        
        public Drink Drink { get; set; }

        public DrinkMaker(Ticket ticket, int milkLeft = 10, int waterLeft = 10)
        {
            Ticket = ticket;
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
        }

        public Drink MakeDrink(Recipe recipe)
        {
            GetDrink();
            AddSugars();
            DeductIngredients(recipe);
            return Drink;
        }

        private void AddSugars()
        {
            if (Ticket.AmountOfSugars > 0)
            {
                Drink = new SugarDecorator(Drink, Ticket.AmountOfSugars);
            }
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