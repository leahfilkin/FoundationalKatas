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
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor)
            {
                Results = new List<int>()
                {
                    1,
                    1,
                    1,
                    1,
                    1
                }
            };
            var expected = 100;
            var actual = simulator.CalculateResults();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IfDoorHasPrizeReturnTrue()
        {
            var door = new Door(true, true);

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
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();
            var contestant = new Contestant();
            var random = new FakeRandom(new List<int>() {1,2,3});
            var result = contestant.ChooseDoor(random, doors);
            
            Assert.Equal(doors[0], result);
        }

        [Fact]
        public void SimulatorShouldAppendEachResultToList()
        {
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor);
            simulator.CollectGameResults(10);
            Assert.Equal(10, simulator.Results.Count);
        }

        [Fact]
        public void ContestantChoosesDoorAtRandom()
        {
            var random = new FakeRandom(new List<int>() {1,2,3});
            var contestant = new Contestant();
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();

            var choice1 = contestant.ChooseDoor(random, doors);
            var choice2 = contestant.ChooseDoor(random, doors);
            
            Assert.Equal(doors[0], choice1);
            Assert.Equal(doors[1], choice2);
        }

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

        [Theory]
        [InlineData(new []{1,0,0}, 33.3)]
        [InlineData(new []{0,0,0}, 0)]
        [InlineData(new []{1,1,1}, 100)]
        public void CalculateResultShouldReturnCorrectPercentage(int[] results, double expected)
        {
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor) {Results = results.ToList()};
            var result = simulator.CalculateResults();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SimulatorScoresStrategiesDifferently()
        {
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var changeDoor = Strategy.ChangeDoor;
            var keepOriginalDoorSimulator = new FakeSimulator(keepOriginalDoor);
            var changeDoorSimulator = new FakeSimulator(changeDoor);
            
            keepOriginalDoorSimulator.CollectGameResults(3);
            changeDoorSimulator.CollectGameResults(3);
            var keepResult = keepOriginalDoorSimulator.CalculateResults();
            var changeResult = changeDoorSimulator.CalculateResults();
            
            Assert.Equal(100, keepResult);
            Assert.Equal(0, changeResult);
            Assert.NotEqual(keepResult, changeResult);
        }
    }
}