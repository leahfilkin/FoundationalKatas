using System;
using System.Linq;

namespace Yatzy
{
    public class Program
    {
        static public void Main(String[] args)
        {
            Console.WriteLine("Welcome to Yatzy!");
            var random = new Random();
            var printer = new Printer();
            var userInput = new UserInput();
            var player = new Player();
            var yatzyScorer = new YatzyScorer();
            var score = 0;
            while (player.CategoriesLeft.Any())
            {
                Console.WriteLine("New turn!");
                var turn = new Turn(random, player);
                turn.MakeFirstRoll();
                printer.PrintDice(turn);
                turn.ExecuteRerolls();
                printer.PrintCategoriesLeft(player);
                var category = userInput.AskPlayerForCategory(turn, player.CategoriesLeft);
                var categoryEnum = turn.GetCategory(category, player.CategoriesLeft);
                var faceValues = yatzyScorer.CountFaceValues(turn.Dice);
                score += YatzyScorer.CalculateScore(faceValues, categoryEnum);
                Console.WriteLine($"Your current score is {score}");
            }
            Console.WriteLine($"Your final score is {score}");
        }
    }
}