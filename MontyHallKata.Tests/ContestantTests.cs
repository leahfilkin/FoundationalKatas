using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;
using Moq;

namespace MontyHallKata.Tests
{
    public class ContestantTests
    {
        private readonly Mock<IContestant> contestantMoq = new Mock<IContestant>();
        private readonly Mock<IRandom> randomMoq = new Mock<IRandom>();
        
        [Fact]
        public void ContestantChoiceReturnsTheDoorTheyChose()
        {
            var doorGenerator = new DoorGenerator();
            var random = new FakeRandom(new List<int>() {0,1,2});
            var doors = doorGenerator.GenerateDoors(random);
            var contestant = new Contestant();
            var result = contestant.ChooseDoor(random, doors);
            
            Assert.Equal(doors[1], result);
        }
        
        [Fact]
        public void ContestantChoosesDoorAtRandom()
        {
            var random = new FakeRandom(new List<int>() {0,1,2});
            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors(random);

            var choice1 = contestant.ChooseDoor(random, doors);
            var choice2 = contestant.ChooseDoor(random, doors);
            
            Assert.Equal(doors[1], choice1);
            Assert.Equal(doors[2], choice2);
        }

        [Fact]
        public void ContestantUsesRandomNumberBasedOnDoorCount()
        {   
            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var random = new Random();
            var doors = doorGenerator.GenerateDoors(random);
            randomMoq.Setup(x => x.Next(doors.Count)).Returns<int>(range => 0);
            var chosenDoor = contestant.ChooseDoor(randomMoq.Object, doors);
            Assert.Equal(doors[0], chosenDoor);
        }
        
    }
}