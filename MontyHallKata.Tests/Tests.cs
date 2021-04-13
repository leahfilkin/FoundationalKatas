using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace MontyHallKata.Tests
{
    public class Tests
    {

        [Fact]
        public void SimulatorShouldReturnResult()
        {
            var simulator = new Simulator();
            simulator.Results = new List<int>() {1, 1, 1, 1, 1};
            var expected = 100;
            var actual = simulator.CalculateResults();
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
            var random = new FakeRandom(new List<int>() {1,2,3});
            var result = contestant.ChooseDoor(random);
            
            Assert.Equal(1, result);
        }

        [Fact]
        public void SimulatorShouldAppendEachResultToList()
        {
            var simulator = new Simulator();
            simulator.CollectGameResults(10);
            Assert.Equal(10, simulator.Results.Count);
        }

        [Fact]
        public void ContestantChoosesDoorAtRandom()
        {
            var random = new FakeRandom(new List<int>() {1,2,3});
            var contestant = new Contestant();

            var choice1 = contestant.ChooseDoor(random);
            var choice2 = contestant.ChooseDoor(random);
            
            Assert.Equal(1, choice1);
            Assert.Equal(2, choice2);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(1,2)]
        public void MontyOpensDoorThatIsNotContestants(int contestantDoor, int winningDoor)
        {
            var monty = new Monty();
            var incorrectDoor = monty.GetIncorrectDoor(contestantDoor, winningDoor);
            Assert.NotEqual(contestantDoor, incorrectDoor);
        }
    }
}