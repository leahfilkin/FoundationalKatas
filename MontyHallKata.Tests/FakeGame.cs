using System.Linq;

namespace MontyHallKata.Tests
{
    public class FakeGame : IGame
    {
        public int PlayGame(IRandom random, Strategy strategy)
        {
            if (strategy == Strategy.ChangeDoor)
            {
                return 1;
            }
            return 0;
        }
    }
}