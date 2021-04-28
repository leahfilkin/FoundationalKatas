using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class Simulator : ISimulator
    {
        private readonly Strategy _strategy;
        public List<int> Results { get; set; }

        private IRandom _random;


        public Simulator(Strategy strategy, IRandom random)
        {
            _strategy = strategy;
            _random = random;
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
                var game = new Game();
                Results.Add(game.PlayGame(_random, _strategy));
            }
        }
    }
}