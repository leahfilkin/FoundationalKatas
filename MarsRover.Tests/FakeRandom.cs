using System.Collections.Generic;
using System.Linq;
using MarsRover.Interfaces;

namespace MarsRover.Tests
{
    public class FakeRandom : IRandom
    {
        private readonly List<int> _nexts;
        public FakeRandom(List<int> nexts)
        {
            _nexts = nexts;
        }
        public int Next(int range)
        {
            var firstNext = _nexts.First();
            _nexts.RemoveAt(0);
            _nexts.Add(firstNext);
            return firstNext;
        }
    }
}