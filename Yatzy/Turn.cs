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
        public int _rerollsPerformed;


        public Turn(IRandom random)
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

        public void ExecuteRerolls(Turn turn)
        {
            var printer = new Printer();
            var userInput = new UserInput();
            while (turn._rerollsPerformed < 3) //turn
            {
                var rerollAnswer = userInput.AskIfPlayerWillReroll();
                if (!rerollAnswer)
                {
                    break;
                }
                var dieToReroll = userInput.GetDieToReroll();
                turn.RerollDie(dieToReroll);
                printer.PrintDice(turn);
            }
        }

        public int GetFaceOfDie(Die die)
        {
            return die.Face;
        }

        public Category GetCategory(string categoryInput)
        {
            while (true)
            {
                var titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(categoryInput.ToLower());
                var withoutSpacesAndTitleCase = Regex.Replace(titleCase, @"\s+", "");
                return (Category) Enum.Parse(typeof(Category), withoutSpacesAndTitleCase);
            }
        }
    }
}
