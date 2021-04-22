using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class Simulator : ISimulator
    
    {
        private readonly Strategy _strategy;
        public List<int> Results { get; set; }


        public Simulator(Strategy strategy)
        {
            _strategy = strategy;
            Results = new List<int>();
        }
        
        public double GetPercentage()
        {
            return Math.Round(Convert.ToDouble(Results.Sum()) / Results.Count * 100, 1 );
        }

        public void RunSimulation(int amountOfRuns)
        {
            for (var i = 0; i < amountOfRuns; i++)
            {
                var random = new Random();
                var game = new Game();
                game.PlayGame(random, _strategy);
                Results.Add(game.GetResult());
            }
        }
        
        
    }
}