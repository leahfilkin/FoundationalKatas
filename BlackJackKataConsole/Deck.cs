using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJackKataConsole
{
    public class Deck
    {
        private List<Card> cards;
        public Deck()
        {
            cards = new List<Card>();
            var suits = Enum.GetValues(typeof(Suit));
            var ranks = Enum.GetValues(typeof(Rank));
            foreach (Suit suit in suits)
            {
                foreach (Rank rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }
        
        public Card GetRandomCard()
        {
            var random = new Random();
            var randomIndex = random.Next(cards.Count);
            var cardToReturn = cards[randomIndex];
            cards.Remove(cards[randomIndex]);
            return cardToReturn;
        }
    }
}