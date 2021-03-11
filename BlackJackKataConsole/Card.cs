using System;

namespace BlackJackKataConsole
{
    public class Card
    {
        public readonly Suit Suit;
        public readonly Rank Rank;
        
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        
        public override string ToString()
        {
            return $"[{Rank} of {Suit}]";
        }
    }
}