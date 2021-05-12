namespace CoffeeMachine
{
    public class Receipt
    {
        public int NumberOfCoffeesSold { get; set; }
        public int NumberOfTeasSold { get; set; }
        public int NumberOfChocolatesSold { get; set; }
        public int NumberOfOrangeJuicesSold { get; set; }
        public double TotalMoneyEarned { get; set; }

        public Receipt(Drink drink, double total)
        {
            TotalMoneyEarned = total;
            switch (drink)
            {
                case Drink.Coffee:
                case Drink.ExtraHotCoffee:
                    NumberOfCoffeesSold += 1;
                    break;
                case Drink.Tea:
                case Drink.ExtraHotTea:
                    NumberOfTeasSold += 1;
                    break;
                case Drink.Chocolate:
                case Drink.ExtraHotChocolate:
                    NumberOfChocolatesSold += 1;
                    break;
                case Drink.OrangeJuice:
                    NumberOfOrangeJuicesSold += 1;
                    break;
            }
        }
    }
}