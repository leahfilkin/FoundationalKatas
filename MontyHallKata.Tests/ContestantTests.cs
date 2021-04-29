using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;
using Moq;

namespace MontyHallKata.Tests
{
    public class ContestantTests
    {
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
            var randomMoqDoorGenerator = new Mock<IRandom>();
                randomMoqDoorGenerator.Setup(x => x.Next(3))
                .Returns(0);
            
            var randomMoqChoice1 = new Mock<IRandom>();
                randomMoqChoice1.Setup(x => x.Next(3))
                .Returns(1);
            
            var randomMoqChoice2 = new Mock<IRandom>();
            randomMoqChoice2.Setup(x => x.Next(3))
                .Returns(2);

            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors(randomMoqDoorGenerator.Object);

            var choice1 = contestant.ChooseDoor(randomMoqChoice1.Object, doors);
            var choice2 = contestant.ChooseDoor(randomMoqChoice2.Object, doors);
            
            Assert.Equal(doors[1], choice1);
            Assert.Equal(doors[2], choice2);
        }

        [Fact]
        public void ContestantUsesRandomNumberBasedOnDoorCount()
        {           
            var randomMoq = new Mock<IRandom>();
            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var random = new Random();
            var doors = doorGenerator.GenerateDoors(random);
            var chosenDoor = contestant.ChooseDoor(randomMoq.Object, doors); 
            randomMoq.Verify(x => x.Next(It.Is<int>(argument => doors.Count == argument)));
        }
    }
}