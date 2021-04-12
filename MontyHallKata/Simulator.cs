using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class Simulator
    {

        public double CalculateResults(List<int> results)
        {
            return results.Sum() / results.Count * 100;
        }
        
        
    }
}