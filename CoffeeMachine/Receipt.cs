using CoffeeMachine.Enums;

namespace CoffeeMachine
{
    public class Receipt
    {
        public int NumberOfCoffeesSold { get; }
        public int NumberOfTeasSold { get; }
        public int NumberOfChocolatesSold { get; set; }
        public int NumberOfOrangeJuicesSold { get; }
        public double TotalMoneyEarned { get; set; }

        public Receipt(DrinkType drinkType, double total)
        {
            TotalMoneyEarned = total;
            switch (drinkType)
            {
                case DrinkType.Coffee:
                case DrinkType.ExtraHotCoffee:
                    NumberOfCoffeesSold += 1;
                    break;
                case DrinkType.Tea:
                case DrinkType.ExtraHotTea:
                    NumberOfTeasSold += 1;
                    break;
                case DrinkType.Chocolate:
                case DrinkType.ExtraHotChocolate:
                    NumberOfChocolatesSold += 1;
                    break;
                case DrinkType.OrangeJuice:
                    NumberOfOrangeJuicesSold += 1;
                    break;
            }
        }
    }
}