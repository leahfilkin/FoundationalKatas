using System;
using System.Collections.Generic;

namespace BlackJackKataConsole
{
    public class Dealer
    {
        const int DealerHandMinimum = 17;

        public bool ShouldHit(int DealerHandValue, int PlayerHandValue)
        {
            return DealerHandValue <= DealerHandMinimum ||
                    DealerHandValue <= PlayerHandValue;
        }
    }
}