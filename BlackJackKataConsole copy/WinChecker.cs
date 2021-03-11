using System;
using System.Collections.Generic;

namespace BlackJackKataConsole
{
    public class WinChecker
    {
        public void PrintOutcomeMessage(int dealerHandValue, int playerHandValue, Hand dealersHand)
        {
            if (dealerHandValue == playerHandValue)
            {
                Console.WriteLine("\nPUSH! Dealer and player tied!");
                return;
            }
            if (dealerHandValue == 21)
            {
                Console.WriteLine("\nBLACKJACK! Dealer wins!");
                return;
            }
            if (dealerHandValue > 21)
            {
                Console.WriteLine("\nDealer is bust! You win!");
                return;
            }
            if (dealerHandValue < playerHandValue)
            {
                Console.WriteLine("\nYou bet the dealer!");
                return;
            }
            Console.WriteLine($"\nDealer is at {dealerHandValue}");
            dealersHand.PrintProgress(dealersHand);
            Console.WriteLine("\nThe dealer bet you! Better luck next time!");
        }
    }
}