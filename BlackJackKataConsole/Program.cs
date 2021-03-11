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

            // shuffle the deck 
            // random card function handles this
            var deck = new Deck();
            var playersHand = new Hand();
            var dealersHand = new Hand();
            var winChecker = new WinChecker();
            var dealer = new Dealer();
            playersHand = dealer.AddFirstCardsToHand(playersHand, deck, 2);
            dealersHand = dealer.AddFirstCardsToHand(dealersHand, deck, 2);
            var hasSeenFirstCards = false;
            var playerHandValue = 0;

            while (true)
            {
                // 'You are currently at {score}'
                playerHandValue = playersHand.CalculateHandValue();
                Console.WriteLine($"\nYou are currently at {playerHandValue}");
                playersHand.PrintProgress(playersHand);
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
                // add card to hand
                playersHand.theirCards.Add(deck.GetRandomCard());
                //show them what card they got
                Console.Write($"You draw {playersHand.theirCards.Last()}");
            }
            var dealerHandValue = dealersHand.CalculateHandValue();
            var dealerHandMinimum = 17;
            while (dealerHandValue <= dealerHandMinimum ||
                   dealerHandValue <= playerHandValue)
            {
                if (hasSeenFirstCards)
                {
                    dealersHand.theirCards.Add(deck.GetRandomCard());
                    //show them what card they got
                    Console.Write($"\nDealer draws {dealersHand.theirCards.Last()} ");
                }
                hasSeenFirstCards = true;
                dealerHandValue = dealersHand.CalculateHandValue();
                Console.WriteLine($"\nDealer is at {dealerHandValue}");
                dealersHand.PrintProgress(dealersHand);
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
            }
            winChecker.PrintOutcomeMessage(dealerHandValue, playerHandValue, dealersHand);
        }
    }
}

