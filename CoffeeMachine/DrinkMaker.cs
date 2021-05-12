using System.Linq;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public string MakeDrink(Ticket ticket, double moneyGiven)
        {
            var drinkName = ConvertDrinkToString(ticket.Drink);
            if (!(moneyGiven >= ticket.Total))
            {
                return $"You haven't given the drink machine enough money. You are {ticket.Total - moneyGiven} short";
            }
            var sugarAndStickDescription = ticket.GetSugarAndStickDescription();
            var orderInformation = string.Join(" ", new [] 
                    {"Drink maker makes 1", drinkName, sugarAndStickDescription}
                .Where(x => x != ""));
            return orderInformation;
        }

        private static string ConvertDrinkToString(Drink drink)
        {
            var drinkString = "";
            switch (drink)
            {
                case Drink.Coffee:
                    drinkString = "coffee";
                    break;
                case Drink.Tea:
                    drinkString = "tea";
                    break;
                case Drink.Chocolate:
                    drinkString = "chocolate";
                    break;
                case Drink.OrangeJuice:
                    drinkString = "orange juice";
                    break;
                case Drink.ExtraHotCoffee:
                    drinkString = "extra hot coffee";
                    break;
                case Drink.ExtraHotTea:
                    drinkString = "extra hot tea";
                    break;
                case Drink.ExtraHotChocolate:
                    drinkString = "extra hot chocolate";
                    break;
            }
            return drinkString;
        }
    }
}