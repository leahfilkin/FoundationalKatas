using System;
using System.Collections.Generic;

namespace BlackJackKataConsole
{
    public class WinChecker
    {
        public static void DisplayWinner(Game game)
        {
            if (game.DealerHandValue == game.PlayerHandValue) Console.WriteLine("\nPUSH! Dealer and player tied!"); 
            if (game.DealerHandValue == 21) Console.WriteLine("\nBLACKJACK! Dealer wins!"); 
            if (game.DealerHandValue > 21) Console.WriteLine("\nDealer is bust! You win!");
            if (game.DealerHandValue < game.PlayerHandValue) Console.WriteLine("\nYou bet the dealer!");
            if (game.DealerHandValue > game.PlayerHandValue && game.DealerHandValue < 21)
            {
                Console.WriteLine("\nThe dealer bet you! Better luck next time!");
            }
        }
    }
}