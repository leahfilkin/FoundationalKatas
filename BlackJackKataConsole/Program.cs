using System;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;

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
            // give two cards to player
            // give two cards to dealer
            var amountOfCardsFirstHand = 2;
            for (var i = 0; i < amountOfCardsFirstHand; i++)
            {
                playersHand.theirCards.Add(deck.GetRandomCard());
                dealersHand.theirCards.Add(deck.GetRandomCard());
            }
            var hitOrStay = "1";
            var hasStarted = false;                
            var youArePlaying = true;
            var playerHandValue = 0;
            while (hitOrStay == "1") 
            {
                if (hasStarted)
                {
                    // Ask to hit or stay
                    Console.Write("\nHit or stay? (Hit = 1, Stay = 0) ");
                    hitOrStay = Console.ReadLine();
                    // If hit, 
                    if (hitOrStay == "1")
                    {
                        // add card to hand
                        playersHand.theirCards.Add(deck.GetRandomCard());
                        var lastCard = playersHand.theirCards.Last();
                        //show them what card they got
                        Console.Write($"You draw ");
                        playersHand.CalculateHandValue();
                        lastCard.PrintCard();
                    }
                    if (hitOrStay == "0")
                    {
                        youArePlaying = false;
                        var dealerHandValue = dealersHand.CalculateHandValue();
                        var dealerHandMinimum = 17;
                        var dealersFirstHand = true;
                        while (dealerHandValue <= dealerHandMinimum)
                        {
                            if (!dealersFirstHand)
                            {
                                dealersHand.theirCards.Add(deck.GetRandomCard());
                                var lastCard = playersHand.theirCards.Last();
                                //show them what card they got
                                Console.Write($"\nDealer draws ");
                                lastCard.PrintCard();
                            }
                            dealersFirstHand = false;
                            dealerHandValue = dealersHand.CalculateHandValue();
                            dealersHand.PrintDealerProgress(dealersHand, dealerHandValue);
                        }
                        if (dealerHandValue == playerHandValue)
                        {
                            Console.WriteLine("\nPUSH! Dealer and player tied!");
                            return;
                        }
                        if (dealerHandValue == 21)
                        {
                            Console.WriteLine("]\nBLACKJACK! Dealer wins!");
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
                        dealersHand.PrintDealerProgress(dealersHand, dealerHandValue);
                        Console.WriteLine("\nThe dealer bet you! Better luck next time!");


                    }
                }
                if (youArePlaying)
                {
                    // 'You are currently at {score}'
                    hasStarted = true;
                    playerHandValue = playersHand.CalculateHandValue();
                    if (playerHandValue > 21)
                    {
                        playersHand.PrintPlayerProgress(playersHand, playerHandValue);
                        Console.WriteLine("\nBUST! Better luck next time!");
                        return;
                    }
                    playersHand.PrintPlayerProgress(playersHand, playerHandValue);
                }
                // If stay, print Dealers score and hand ('dealer is' instead of 'you are')
                
                // Dealer draws until they get over 17, then stay unless they get a card low enough to get them closer
                // to 21
            }
        }
    }
}
