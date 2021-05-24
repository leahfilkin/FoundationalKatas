using System;
using CoffeeMachine.Drinks;

namespace CoffeeMachine.Report
{
    public class Receipt
    {
        public int NumberOfCoffeesSold { get; }
        public int NumberOfTeasSold { get; }
        public int NumberOfChocolatesSold { get; set; }
        public int NumberOfOrangeJuicesSold { get; }
        public double TotalMoneyEarned { get; set; }

        public Receipt(Drink drink, double total)
        {
            drink.GetDrinkType();
            TotalMoneyEarned = total;
            switch (drink.DrinkType)
            {
                case DrinkType.Coffee:
                    NumberOfCoffeesSold += 1;
                    break;
                case DrinkType.Tea:
                    NumberOfTeasSold += 1;
                    break;
                case DrinkType.Chocolate:
                    NumberOfChocolatesSold += 1;
                    break;
                case DrinkType.OrangeJuice:
                    NumberOfOrangeJuicesSold += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}