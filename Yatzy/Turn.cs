using System;
using System.Collections.Generic;

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


        public void RerollDie(int playerRerolls)
        {
            throw new NotImplementedException();
        }
    }
}