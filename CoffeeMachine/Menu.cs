using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Menu
    {
        public Dictionary<string, string> Drinks { get; }
        public Dictionary<string, double> Prices { get; }

        public Menu()
        {
            Drinks = new Dictionary<string, string>()
            {
                {"C", "coffee"},
                {"T", "tea"},
                {"O", "orange juice"},
                {"H", "chocolate"},
                {"Ch", "extra hot coffee"},
                {"Hh", "extra hot chocolate"},
                {"Th", "extra hot tea"}
            };
            Prices = new Dictionary<string, double>()
            {
                {"coffee", 0.6},
                {"tea", 0.4},
                {"chocolate", 0.5},
                {"orange juice", 0.6},
                {"extra hot coffee", 0.6},
                {"extra hot chocolate", 0.5},
                {"extra hot tea", 0.4}
            };
        }
    }
}