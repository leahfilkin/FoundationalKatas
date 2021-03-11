using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackKataConsole
{
    public class Hand : IEnumerable
    {
        public List<Card> theirCards = new List<Card>();
        
        public Hand()
        {
        }

        public int CalculateHandValue()
        {   
            var handValue = 0;
            foreach (Card card in theirCards)
            {
                handValue += (int) card._rank;
                if (card._rank == Rank.Ace)
                {
                }
            }
            if (handValue > 21 && theirCards.Any(x => x._rank == Rank.Ace))
            {
                handValue -= 10; //Take away the 11 ace and make it 1 instead
            }
            return handValue;
        }
        

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
        public void PrintDealerProgress(Hand dealersHand, int dealerHandValue)
        {
            Console.WriteLine($"\nDealer is at {dealerHandValue}");
            Console.Write($"With the hand ");
            foreach (Card card in dealersHand.theirCards)
            {
                dealersHand.CalculateHandValue();
                card.PrintCard();
            }
        }
        public void PrintPlayerProgress(Hand playersHand, int playerHandValue)
        {
            Console.WriteLine($"\nYou are currently at {playerHandValue}");
            Console.Write($"With the hand ");
            foreach (Card card in playersHand.theirCards)
            {
                playersHand.CalculateHandValue();
                card.PrintCard();
            }
        }
    }
}