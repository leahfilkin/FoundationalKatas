using System.Collections.Generic;

namespace KataABC2
{
    public class Block
    {        
        private readonly char _letterOne;
        private readonly char _letterTwo;

        public Block(char letterOne, char letterTwo)
        {
            _letterOne = letterOne;
            _letterTwo = letterTwo;
        }

        public string CreateBlock()
        {
            return ($"({_letterOne} {_letterTwo})");
        }
    }
}