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

        private IGame _game;


        public Simulator(Strategy strategy, IRandom random, IGame game)
        {
            _strategy = strategy;
            _random = random;
            Results = new List<int>();
            _game = game;
        }
        
        public double GetPercentage()
        {
            return Math.Round(Convert.ToDouble(Results.Sum()) / Results.Count * 100, 1 );
        }

        public void RunSimulation(int amountOfRuns)
        {
            for (var i = 0; i < amountOfRuns; i++)
            {
                Results.Add(_game.Play(_random, _strategy));
            }
        }
    }
}