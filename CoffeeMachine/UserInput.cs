using System;
using System.IO;

namespace CoffeeMachine
{
    public class UserInput
    {
        public string GetStringCommand()
        {
            Console.WriteLine("Enter string command: ");
            return Console.ReadLine();
        }

        public double GetMoneyFromCustomerForTicket()
        {
            Console.WriteLine("Give the drink machine money for your order: ");
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}