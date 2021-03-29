using System;

namespace Yatzy
{
    public class Die : IRollable
    {
        private IRandom _random;
        public int Face { get; private set; } 

        public Die(IRandom random)
        {
            _random = random;
        }
        public void Roll()
        {
            Face = _random.Next(6);
        }
    }
}