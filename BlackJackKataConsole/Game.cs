using System;
using System.Linq;
using System.Threading;

namespace BlackJackKataConsole
{
    public class Game
    {
        private Hand _playersHand = new Hand();
        private Hand _dealersHand = new Hand();
        public int PlayerHandValue = 0;
        public int DealerHandValue = 0;
        private Deck _deck = new Deck();
        private Dealer _dealer = new Dealer();

        public Game()
        {
            _playersHand = AddFirstCardsToHand(_playersHand, _deck, 2);
            _dealersHand = AddFirstCardsToHand(_dealersHand, _deck, 2);
            
        }

        public Hand AddFirstCardsToHand(Hand hand, Deck deck, int amountOfCards)
        {
            for (var i = 0; i < amountOfCards; i++)
            {
                hand.theirCards.Add(deck.GetRandomCard());
            }
            return hand;
        }
        public void ExecutePlayersTurn()
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
                _playersHand.theirCards.Add(_deck.GetRandomCard());
                Console.Write($"You draw {_playersHand.theirCards.Last()}");
            }
        }

        public void ExecuteDealersTurn()
        {
            var hasSeenFirstCards = false;
            do
            {
                if (hasSeenFirstCards)
                {
                    _dealersHand.theirCards.Add(_deck.GetRandomCard());
                    Console.Write($"\nDealer draws {_dealersHand.theirCards.Last()} ");
                }
                hasSeenFirstCards = true;
                DealerHandValue = _dealersHand.CalculateHandValue();
                Console.WriteLine($"\nDealer is at {DealerHandValue}");
                _dealersHand.PrintProgress(_dealersHand);
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
            } while (_dealer.ShouldHit(DealerHandValue, PlayerHandValue));
        }
    }
}