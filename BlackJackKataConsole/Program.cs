using System;

namespace BlackJackKataConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BlackJack!");
            
            // shuffle the deck 
            // give two cards to player
            Player player = new Player();
            Deck deck = new Deck();
            var card1 = deck.GetRandomCard();
            var card2 = deck.GetRandomCard(); 
            // give two cards to dealer

            // 'You are currently at {score}'
            // with the hand {hand} 

            // Ask to hit or stay

            // If hit, add card to hand and repeat previous two steps

            // If stay, print Dealers score and hand ('dealer is' instead of 'you are')

            // Dealer draws until they get over 17, then stay unless they get a card low enough to get them closer
            // to 21


        }
    }
}
