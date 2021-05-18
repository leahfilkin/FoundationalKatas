using System.Collections.Generic;
using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Menu
    {
        public static Dictionary<string, DrinkType> Drinks { get; set; }
        public static Dictionary<DrinkType, double> Prices { get; set; }
        public static List<DrinkType> HotDrinks { get; set; }

        public List<Ingredient> Ingredients { get; }

        public Menu()
        {
            Drinks = new Dictionary<string, DrinkType>
            {
                {"C", DrinkType.Coffee},
                {"T", DrinkType.Tea},
                {"O", DrinkType.OrangeJuice},
                {"H", DrinkType.Chocolate},
                {"Ch", DrinkType.ExtraHotCoffee},
                {"Hh", DrinkType.ExtraHotChocolate},
                {"Th", DrinkType.ExtraHotTea}
            };
            Prices = new Dictionary<DrinkType, double>
            {
                {DrinkType.Coffee, 0.6},
                {DrinkType.Tea, 0.4},
                {DrinkType.Chocolate, 0.5},
                {DrinkType.OrangeJuice, 0.6},
                {DrinkType.ExtraHotCoffee, 0.6},
                {DrinkType.ExtraHotChocolate, 0.5},
                {DrinkType.ExtraHotTea, 0.4}
            };
            HotDrinks = new List<DrinkType>
            {
                DrinkType.Coffee,
                DrinkType.Tea,
                DrinkType.Chocolate,
                DrinkType.ExtraHotCoffee,
                DrinkType.ExtraHotChocolate,
                DrinkType.ExtraHotTea
            };
            Ingredients = new List<Ingredient>
            {
                {Ingredient.Milk},
                {Ingredient.Water}
            };
        }
    }
}
