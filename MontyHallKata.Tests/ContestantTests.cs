using System.Collections.Generic;
using Xunit;

namespace MontyHallKata.Tests
{
    public class ContestantTests
    {
        [Fact]
        public void ContestantChoiceReturnsSameDoor()
        {
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();
            var contestant = new Contestant();
            var random = new FakeRandom(new List<int>() {0,1,2});
            var result = contestant.ChooseDoor(random, doors);
            
            Assert.Equal(doors[0], result);
        }
        
        [Fact]
        public void ContestantChoosesDoorAtRandom()
        {
            var random = new FakeRandom(new List<int>() {0,1,2});
            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();

            var choice1 = contestant.ChooseDoor(random, doors);
            var choice2 = contestant.ChooseDoor(random, doors);
            
            Assert.Equal(doors[0], choice1);
            Assert.Equal(doors[1], choice2);
        }

        [Fact]
        public void ContestantUsesRandomNumberBasedOnDoorCount()
        {
            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();
            var random = new MockRandom(doors.Count);
            contestant.ChooseDoor(random, doors);
        }
    }
}