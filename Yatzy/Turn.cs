using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Turn
    {

        public List<Die> Dice { get; private set; }

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
    }
}