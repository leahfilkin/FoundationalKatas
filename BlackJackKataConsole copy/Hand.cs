using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackKataConsole
{
    public class Hand
    {
        public List<Card> theirCards = new List<Card>();
        
        public int CalculateHandValue()
        {   
            var handValue = 0;
            foreach (Card card in theirCards)
            {
                handValue += (int) card.Rank;
            }
            if (handValue > 21 && theirCards.Any(x => x.Rank == Rank.Ace))
            {
                handValue -= 10; //Take away the 11 ace and make it 1 instead
            }
            
            return handValue;
        }
        
        public void PrintProgress(Hand hand)
        {
            Console.WriteLine($"With the hand {String.Join(" ", hand.theirCards)}");
        }
    }
}