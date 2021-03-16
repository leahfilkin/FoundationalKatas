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
            var game = new Game();
            game.ExecutePlayersTurn();
            game.ExecuteDealersTurn();
            WinChecker.DisplayWinner(game);
        }
    }
}

