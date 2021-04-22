using System.Xml.Linq;
using Xunit;

namespace MontyHallKata
{
    public class MockRandom : IRandom
    {
        private int _expected;
        public MockRandom(int expected)
        {
            _expected = expected;
        }
        public int Next(int range)
        {
            Assert.Equal(_expected, range);
            return 0;
        }
    }
}