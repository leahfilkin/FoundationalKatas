using System;

namespace BlackJackKataConsole
{
    public class Card
    {
        public Suit _suit;
        public Rank _rank;
        
        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }

        public void PrintCard()
        {
            Console.Write($"[{_rank} of {_suit}] ");
        }
    }
}