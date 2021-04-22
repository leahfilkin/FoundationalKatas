using System.Collections.Generic;
using Xunit;

namespace MontyHallKata.Tests
{
    public class MontyTests
    {
        [Fact]
        public void MontyOpensDoorThatIsNotContestants()
        {
            var monty = new Monty();
            var random = new FakeRandom(new List<int>() {1,2,3});
            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();
            var contestantDoor = contestant.ChooseDoor(random, doors);
            
            var incorrectDoor = monty.GetIncorrectDoor(doors);
            
            Assert.NotEqual(contestantDoor, incorrectDoor);
        }
    }
}