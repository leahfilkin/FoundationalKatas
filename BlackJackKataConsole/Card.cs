using System;

namespace BlackJackKataConsole
{
    public class Card
    {
        private Suit _suit;
        private Rank _rank;
        
        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }

        public void PrintCard(Card card)
        {
            Console.WriteLine($"{_suit}, {_rank}");
        }
    }
}