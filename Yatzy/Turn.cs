using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Turn
    {

        private List<Die> Dice { get; }


        public Turn(IRandom random)
        {
            Dice = new List<Die>();
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
            var rerollDiceList = diceToReroll.Split(',').Select(int.Parse).ToList();
            foreach (var die in rerollDiceList)
            {
                Dice[die - 1].Roll();
            }
        }
        
        public int GetFace()
        {
            throw new NotImplementedException();
        }
        }
    }
