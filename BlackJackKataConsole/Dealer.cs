using System;
using System.Collections.Generic;

namespace BlackJackKataConsole
{
    public class Dealer
    {
        public Hand AddFirstCardsToHand(Hand hand, Deck deck, int amountOfCards)
        {
            for (var i = 0; i < amountOfCards; i++)
            {
                hand.theirCards.Add(deck.GetRandomCard());
            }
            return hand;
        }
    }
}