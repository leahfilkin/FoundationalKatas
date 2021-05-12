using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Menu
    {
        public Dictionary<string, Drink> Drinks { get; }
        public Dictionary<Drink, double> Prices { get; }
        public List<Drink> HotDrinks { get; }

        public Menu()
        {
            Drinks = new Dictionary<string, Drink>()
            {
                {"C", Drink.Coffee},
                {"T", Drink.Tea},
                {"O", Drink.OrangeJuice},
                {"H", Drink.Chocolate},
                {"Ch", Drink.ExtraHotCoffee},
                {"Hh", Drink.ExtraHotChocolate},
                {"Th", Drink.ExtraHotTea}
            };
            Prices = new Dictionary<Drink, double>()
            {
                {Drink.Coffee, 0.6},
                {Drink.Tea, 0.4},
                {Drink.Chocolate, 0.5},
                {Drink.OrangeJuice, 0.6},
                {Drink.ExtraHotCoffee, 0.6},
                {Drink.ExtraHotChocolate, 0.5},
                {Drink.ExtraHotTea, 0.4}
            };
            HotDrinks = new List<Drink>()
            {
                Drink.Coffee,
                Drink.Tea,
                Drink.Chocolate,
                Drink.ExtraHotCoffee,
                Drink.ExtraHotChocolate,
                Drink.ExtraHotTea
            };
        }
    }
}
