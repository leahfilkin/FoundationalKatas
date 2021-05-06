using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class UserInput
    {
        public List<string> GetOrder()
        {
            var order = new List<string>();
            var possibleDrinks = new List<string>() {"tea", "chocolate", "coffee"};
            Console.WriteLine("Please tell us what you would like to order. You can choose from:" +
                              "\nCoffee, Tea, Chocolate" +
                              "\nPlease type what drink you would like:");
            var drink = Console.ReadLine();
            Console.WriteLine("Would you like any sugar? Please type either 1 or 2 for your sugar amount, " +
                              "or if you don't want any sugar, simply press enter.");
            var sugars = Console.ReadLine();
            order.Add(drink.ToLower());
            order.Add(sugars);
            return order;
        }
    }
}