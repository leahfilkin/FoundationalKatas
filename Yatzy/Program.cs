using System;

namespace Yatzy
{
    public class Program
    {
        static public void Main(String[] args)
        {
            var random = new Random();
            var turn = new Turn(random);
            var userInput = new UserInput();
            var printer = new Printer();
            Console.WriteLine("Welcome to Yatzy!");
            turn.MakeFirstRoll();
            printer.PrintDice(turn);
            turn.ExecuteRerolls(turn);
            var category = userInput.AskPlayerForCategory(turn);
            var categoryEnum = turn.GetCategory(category);
            Console.WriteLine(categoryEnum);

        }
    }
}