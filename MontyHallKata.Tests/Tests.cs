using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MontyHallKata.Tests
{
    public class Tests
    {

        [Fact]
        public void SimulatorShouldReturnResult()
        {
            var simulator = new Simulator();
            var results = new List<int>() {1, 1, 1, 1, 1};
            var expected = 100;
            var actual = simulator.CalculateResults(results);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IfDoorHasPrizeReturnTrue()
        {
            var door = new Door(true);

            Assert.True(door.HasPrize);
        }

        [Fact]
        public void GameHasThreeDoors()
        {
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();
            
            Assert.Equal(3, doors.Count);
        }

        [Fact]
        public void OnlyOneDoorHasPrize()
        {
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();
            Assert.Single(doors.Where(door => door.HasPrize));
        }

        [Fact]
        public void ContestantChoiceReturnsSameDoor()
        {
            var contestant = new Contestant();
            var result = contestant.ChooseDoor();
            
            Assert.Equal(1, result);
        }

        [Fact]
        public void SimulatorShouldAppendEachResultToList()
        {
            var simulator = new Simulator();
            
        }
    }
}