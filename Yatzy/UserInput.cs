using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class UserInput
    {
        public string GetDieToReroll()
        {
            while (true)
            {
                Console.WriteLine(
                        "Please input which dice you would like to reroll, seperated by commas. E.g. 1,4,5 to reroll the first, fourth and fifth dice");
                var rerollString = Console.ReadLine();
                if (rerollString != "")
                {
                    return rerollString;
                }
                Console.WriteLine("You haven't entered your dice in the correct format");
            }
        }

        public bool AskIfPlayerWillReroll()
        {
            var possibleAnswers = new List<char>() {'Y', 'N', 'y', 'n'}; 
            while (true)
            {
                Console.WriteLine("Would you like to reroll any dice? Input Y for yes, N for no");
                var keyPressed = Console.ReadKey(true).Key;
                while (keyPressed == ConsoleKey.Y || 
                         keyPressed == ConsoleKey.N)
                {
                    return (keyPressed == ConsoleKey.Y);
                }
                Console.WriteLine("Incorrect input. Please input a Y or N");
            }
        }

        public string AskPlayerForCategory(Turn turn, List<Category> categoriesLeft)
        {
            while (true)
            {
                Console.WriteLine("Which category would you like to use?");
                var category = Console.ReadLine();
                try
                {
                    turn.GetCategory(category, categoriesLeft);
                    return category;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("You have input an incorrect category. Make sure you type it with spaces and you have no typos.");
                }
            }
        }
    }
}