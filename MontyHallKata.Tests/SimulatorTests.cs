using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MontyHallKata.Tests
{
    public class SimulatorTests
    {
        [Fact]
        public void SimulatorShouldReturnResult()
        {
            var random = new FakeRandom(new List<int>() {0,1,2});
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor, random)
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
            var actual = simulator.GetPercentage();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void SimulatorResultsCountShouldBeTheSameAsTheNumberOfSimulationsRun()
        {
            var randomList = new List<int>();
            var amountOfRuns = 10;
            for (var i = 0; i < amountOfRuns; i++)
            {
                randomList.Add(0);
                randomList.Add(1);
                randomList.Add(2);
            }
            var random = new FakeRandom(randomList);
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor, random);
            simulator.RunSimulation(amountOfRuns);
            Assert.Equal(amountOfRuns, simulator.Results.Count);
        }
        
        [Theory]
        [InlineData(new []{1,0,0}, 33.3)]
        [InlineData(new []{0,0,0}, 0)]
        [InlineData(new []{1,1,1}, 100)]
        public void SimulatorShouldCalculateWinPercentageAccurately(int[] results, double expected)
        {
            var random = new FakeRandom(new List<int>() {0,1,2});
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor, random) {Results = results.ToList()};
            var result = simulator.GetPercentage();
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void SimulatorScoresStrategiesDifferently()
        {
            var amountOfRuns = 3;
            var random = new Random();
            var keepOriginalDoorSimulator = new Simulator(Strategy.KeepOriginalDoor, random);
            var changeDoorSimulator = new Simulator(Strategy.ChangeDoor, random);
            keepOriginalDoorSimulator.RunSimulation(amountOfRuns);
            changeDoorSimulator.RunSimulation(amountOfRuns);
            var keepResult = keepOriginalDoorSimulator.GetPercentage();
            var changeResult = changeDoorSimulator.GetPercentage();
            
            Assert.Equal(0, keepResult);
            Assert.Equal(100, changeResult);
            Assert.NotEqual(keepResult, changeResult);
        }
    }
}