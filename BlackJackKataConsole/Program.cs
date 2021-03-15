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
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            var gameCreator = new GameCreator();
            var winChecker = new WinChecker();
            var game = gameCreator.SetUpGame(deck);
            game.PlayersTurn(deck);
            game.DealersTurn(dealer, deck);
            winChecker.DetermineWinnerAndPrintMessage(game);
        }
    }
}

