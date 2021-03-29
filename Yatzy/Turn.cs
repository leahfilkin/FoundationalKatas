using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Turn
    {

        public List<int> Dice { get; private set; } 
        public void MakeFirstRoll()
        {
            var die = new Die(new Random());
            die.Roll();
            Dice.Add(die.Face);
        }
    }
}