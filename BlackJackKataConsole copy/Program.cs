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
            var winChecker = new WinChecker();
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
                        //show them what card they got
                        Console.Write($"You draw {playersHand.theirCards.Last()}");
                        playerHandValue = playersHand.CalculateHandValue();
                        Console.WriteLine($"\nYou are currently at {playerHandValue}");
                        playersHand.PrintProgress(playersHand);
                    }
                }
                if (youArePlaying)
                {
                    // 'You are currently at {score}'
                    hasStarted = true;
                    playerHandValue = playersHand.CalculateHandValue();
                    if (playerHandValue > 21)
                    {
                        Console.WriteLine($"\nYou are currently at {playerHandValue}");
                        playersHand.PrintProgress(playersHand);
                        Console.WriteLine("\nBUST! Better luck next time!");
                        return;
                    }
                    Console.WriteLine($"\nYou are currently at {playerHandValue}");
                    playersHand.PrintProgress(playersHand);
                }
                // If stay, print Dealers score and hand ('dealer is' instead of 'you are')
                
                // Dealer draws until they get over 17, then stay unless they get a card low enough to get them closer
                // to 21
                youArePlaying = false;
            }
            var dealerHandValue = dealersHand.CalculateHandValue();
            var dealerHandMinimum = 17;
            var dealersFirstHand = true;
            while (dealerHandValue <= dealerHandMinimum)
            {
                if (!dealersFirstHand)
                {
                    dealersHand.theirCards.Add(deck.GetRandomCard());
                    //show them what card they got
                    Console.Write($"\nDealer draws {playersHand.theirCards.Last()} ");
                }
                dealersFirstHand = false;
                dealerHandValue = dealersHand.CalculateHandValue();
                Console.WriteLine($"\nDealer is at {dealerHandValue}");
                dealersHand.PrintProgress(dealersHand);
            } 
            winChecker.PrintOutcomeMessage(dealerHandValue, playerHandValue, dealersHand); 
            }
        }
    }

