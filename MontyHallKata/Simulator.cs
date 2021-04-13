using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class Simulator
    
    {
        public List<int> Results { get; set; }
        

        public Simulator()
        {
            Results = new List<int>();
        }
        
        public double CalculateResults()
        {
            return Results.Sum() / Results.Count * 100;
        }

        public void CollectGameResults(int amountOfRuns)
        {
            for (var i = 0; i < amountOfRuns; i++)
            {
                var game = new Game();
                game.PlayGame();
                Results.Add(game.GetResult());
            }
        }
    }
}