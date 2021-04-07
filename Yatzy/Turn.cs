using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yatzy
{
    public class Turn
    {

        public List<Die> Dice { get; }
        private int _rerollsPerformed;


        public Turn(IRandom random, Player player)
        {
            Dice = new List<Die>();
            _rerollsPerformed = 0;
            for (var i = 0; i < 5; i++)
            {
                Die die = new Die(random);
                Dice.Add(die);
            }
        }
        
        public void MakeFirstRoll()
        {
            foreach (var die in Dice)
            {
                die.Roll();
            }
        }
        public void RerollDie(string diceToReroll)
        {
            var rerollDiceList = diceToReroll.Split(',').Select(int.Parse).ToList(); //move to user input
            foreach (var die in rerollDiceList)
            {
                Dice[die - 1].Roll();
            }
            _rerollsPerformed += 1;
        }

        public void ExecuteRerolls()
        {
            var printer = new Printer();
            var userInput = new UserInput();
            while (CanReroll())
            {
                var dieToReroll = userInput.GetDieToReroll();
                RerollDie(dieToReroll);
                printer.PrintDice(this);
            }
        }

        public bool CanReroll()
        {
            var userInput = new UserInput();
            while (_rerollsPerformed < 3)
            {
                var rerollAnswer = userInput.AskIfPlayerWillReroll();
                if (!rerollAnswer)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public int GetFaceOfDie(Die die)
        {
            return die.Face;
        }

        public Category GetCategory(string categoryInput, List<Category> categoriesLeft)
        {
            var userInput = new UserInput();
            var withoutSpacesAndTitleCase = "";
            while (true)
            {
                var titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(categoryInput.ToLower());
                withoutSpacesAndTitleCase = Regex.Replace(titleCase, @"\s+", "");
                if (categoriesLeft.Contains((Category) Enum.Parse(typeof(Category), withoutSpacesAndTitleCase)))
                {
                    break;
                }
                Console.WriteLine("You have already used this category. Please choose another");
                categoryInput = userInput.AskPlayerForCategory(this, categoriesLeft);
            }
            return (Category) Enum.Parse(typeof(Category), withoutSpacesAndTitleCase);
        }
    }
}
