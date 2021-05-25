using System.Collections.Generic;
using CoffeeMachine.Drinks;

namespace CoffeeMachine.Console
{
    public class UserInterface
    {
        public static void PrintOrderInformation(Drink drink)
        {
            System.Console.WriteLine(Output.CreateOrderInformation(drink));
        }

        public static void PrintOutOfStockMessage(List<Ingredient> ingredients)
        {
            System.Console.WriteLine
                (Output.CreateOutOfStockMessage(ingredients));
        }

        public static string GetStringCommand()
        {
            System.Console.WriteLine("Enter string command: ");
            return System.Console.ReadLine();
        }

        public static string AskForMoney()
        {
            System.Console.WriteLine("Give the drink machine money for your order: ");
            return System.Console.ReadLine();
        }
    }
}