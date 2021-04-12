using System.Collections.Generic;

namespace MontyHallKata
{
    public class Game
    {
        private bool _didWin;
        private List<Door> _doors;

        public Game(List<Door> doors)
        {
            _doors = doors;
        }
        
        public void PlayGame()
        {
            _didWin = true;
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