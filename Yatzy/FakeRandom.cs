using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Tests
{
    public class FakeRandom : IRandom
    {
        private List<int> _nexts;
        public FakeRandom(List<int> nexts)
        {
            _nexts = nexts;
        }
        public int Next(int range)
        {
            var firstNext = _nexts.First();
            _nexts.RemoveAt(0);
            return firstNext;
        }
    }
}