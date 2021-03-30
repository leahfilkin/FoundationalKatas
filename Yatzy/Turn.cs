using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Turn : IUserInput
    {

        public List<Die> Dice { get; set; }

        public Turn()
        {
            Dice = new List<Die>();
        }
        public void MakeFirstRoll()
        {
            Die die;
            for (var i = 0; i < 5; i++)
            {
                die = new Die(new Random());
                die.Roll();
                Dice.Add(die);
            }
        }

        public string GetDieToReroll()
        {
            throw new NotImplementedException();

        }

        string IUserInput.AskIfPlayerWillReroll()
        {
            throw new NotImplementedException();
        }


        public void RerollDie(string diceToReroll)
        {
            var rerollDiceList = diceToReroll.Split(',').Select(int.Parse).ToList();
            foreach (var die in rerollDiceList)
            {
                Dice[die-1].Roll();
            }
        }
    }
}