using System;

namespace Yatzy
{
    public class Printer
    {
        public void PrintDice(Turn turn)
        {
            Console.Write("Your dice are: ");
            Console.WriteLine($"{String.Join(" ", turn.Dice)}");
        }

        public void PrintCategoriesLeft(Player player)
        {
            Console.WriteLine($"Your categories left are: ");
        }
    }
}