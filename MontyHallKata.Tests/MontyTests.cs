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
            var random = new FakeRandom(new List<int>() {0,1,2});
            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors(random);
            var chosenDoor = contestant.ChooseDoor(random, doors);
            
            var incorrectDoor = monty.GetIncorrectDoor(doors, chosenDoor);
            
            Assert.NotEqual(chosenDoor, incorrectDoor);
        }
    }
}