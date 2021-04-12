using System;
using System.Collections.Generic;

namespace MontyHallKata
{
    public class Game
    {
        private bool _didWin;

        public void PlayGame()
        {
            var chosenDoor = 1;
            var winningDoor = 1;
            if (chosenDoor == winningDoor) 
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


        public object ChooseDoor(FakeRandom random)
        {
            throw new NotImplementedException();
        }
    }
}