using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class Game
    {
        private bool _didWin;

        public void PlayGame(IRandom random, Strategy strategy)
        {
            var doorGenerator = new DoorGenerator();
            var contestant = new Contestant();
            var monty = new Monty();

            var doors = doorGenerator.GenerateDoors(); 
            Door chosenDoor = contestant.ChooseDoor(random, doors);
            var doorsLeftToChoose = doors;
            var incorrectDoor = monty.GetIncorrectDoor(doors);
            if (strategy == Strategy.ChangeDoor)
            {
                doorsLeftToChoose.Remove(chosenDoor);
                doorsLeftToChoose.Remove(incorrectDoor);
                chosenDoor = doorsLeftToChoose.First();
            }
            if (chosenDoor.HasPrize) 
            {
                _didWin = true;
            }
            else _didWin = false;
        }

        public int GetResult()
        {
           if (_didWin)
           {
               return 1;
           }
           return 0;
        }
    }
}