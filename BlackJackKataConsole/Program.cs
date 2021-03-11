using System;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BlackJackKataConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BlackJack!");
            var deck = new Deck();
            var playersHand = new Hand();
            var dealersHand = new Hand();
            var winChecker = new WinChecker();
            var dealer = new Dealer();
            // dealer uses deck's "GetRandomCard()" to find two random cards, adds those cards to both the 
            // player and dealer hands. Amount of starting cards can be changed
            playersHand = dealer.AddFirstCardsToHand(playersHand, deck, 2);
            dealersHand = dealer.AddFirstCardsToHand(dealersHand, deck, 2);
            // if the dealer hasn't seen their first cards, we don't want them to draw. The act of drawing a card
            // depends on this variable becoming true
            var hasSeenFirstCards = false;
            var playerHandValue = 0;

            while (true) // this will always loop until a change in hitOrStay causes a break
            {
                playerHandValue = playersHand.CalculateHandValue();
                Console.WriteLine($"\nYou are currently at {playerHandValue}");
                // Prints "with the hand"....
                playersHand.PrintProgress(playersHand);
                // If their cards > 21 then they've gone bust, so the program must end
                if (playerHandValue > 21)
                {
                    Console.WriteLine("\nBUST! Better luck next time!");
                    return;
                }
                // Ask to hit or stay
                Console.Write("\nHit or stay? (Hit = 1, Stay = 0) ");
                var hitOrStay = Console.ReadLine();
                if (hitOrStay == "0")
                {
                    break;
                }
                // add another card to their hand
                playersHand.theirCards.Add(deck.GetRandomCard());
                // show them what card they got amongst their others
                Console.Write($"You draw {playersHand.theirCards.Last()}");
            }
            // if we have exited the loop then it must be the dealers turn, as player has chosen to stay
            var dealerHandValue = dealersHand.CalculateHandValue();
            // the dealer cant stay if they're over 17
            var dealerHandMinimum = 17;
            // in order for the dealer to win, they must keep hitting while they're under 17
            // they also need to keep hitting if they have a lesser count than the player
                // since they will lose whether they stay or not
            while (dealerHandValue <= dealerHandMinimum ||
                   dealerHandValue <= playerHandValue)
            {
                // dont draw if they havent seen their first two cards
                if (hasSeenFirstCards) 
                {
                    dealersHand.theirCards.Add(deck.GetRandomCard());
                    Console.Write($"\nDealer draws {dealersHand.theirCards.Last()} ");
                }
                hasSeenFirstCards = true;
                dealerHandValue = dealersHand.CalculateHandValue();
                Console.WriteLine($"\nDealer is at {dealerHandValue}");
                dealersHand.PrintProgress(dealersHand);
                // dealers hand comes out in increments 
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
            }
            // based on the dealers hand at the end of the loop, check for a win and print the appropriate message
            winChecker.PrintOutcomeMessage(dealerHandValue, playerHandValue, dealersHand);
        }
    }
}

