using System;
using System.Linq;
using System.Threading;

namespace BlackJackKataConsole
{
    public class Game
    {
        private Hand _playersHand;
        private Hand _dealersHand;
        public int PlayerHandValue;
        public int DealerHandValue;
        

        public Game(Hand playersHand, Hand dealersHand)
        {
            _playersHand = playersHand;
            _dealersHand = dealersHand;
        }

        public void PlayersTurn(Deck deck)
        {
            while (true) 
            {
                PlayerHandValue = _playersHand.CalculateHandValue();
                Console.WriteLine($"\nYou are currently at {PlayerHandValue}");
                _playersHand.PrintProgress(_playersHand);
                if (PlayerHandValue > 21)
                {
                    Console.WriteLine("\nBUST! Better luck next time!");
                    return;
                }
                Console.Write("\nHit or stay? (Hit = 1, Stay = 0) ");
                var hitOrStay = Console.ReadLine();
                if (hitOrStay == "0")
                {
                    break;
                }
                _playersHand.theirCards.Add(deck.GetRandomCard());
                Console.Write($"You draw {_playersHand.theirCards.Last()}");
            }
        }

        public void DealersTurn(Dealer dealer, Deck deck)
        {
            var hasSeenFirstCards = false;
            DealerHandValue = _dealersHand.CalculateHandValue();
            while (dealer.ShouldHit(DealerHandValue, PlayerHandValue))
            {
                if (hasSeenFirstCards) 
                {
                    _dealersHand.theirCards.Add(deck.GetRandomCard());
                    Console.Write($"\nDealer draws {_dealersHand.theirCards.Last()} ");
                }
                hasSeenFirstCards = true;
                DealerHandValue = _dealersHand.CalculateHandValue();
                Console.WriteLine($"\nDealer is at {DealerHandValue}");
                _dealersHand.PrintProgress(_dealersHand);
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
            }
        }
    }
}