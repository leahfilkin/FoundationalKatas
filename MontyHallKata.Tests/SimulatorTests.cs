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
        public void SimulatorShouldAggregateResults()
        {
            var random = new FakeRandom(new List<int>() {0,1,2,0,1,2,0,1,2,0});
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor, random);
            simulator.RunSimulation(10);
            Assert.Equal(10, simulator.Results.Count);
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
            var random = new FakeRandom(new List<int>() {0,0,0,0,0,0,0,0,0});
            var keepOriginalDoorSimulator = new Simulator(Strategy.KeepOriginalDoor, random);
            var changeDoorSimulator = new Simulator(Strategy.ChangeDoor, random);
            
            keepOriginalDoorSimulator.RunSimulation(3);
            changeDoorSimulator.RunSimulation(3);
            var keepResult = keepOriginalDoorSimulator.GetPercentage();
            var changeResult = changeDoorSimulator.GetPercentage();
            
            Assert.Equal(100, keepResult);
            Assert.Equal(0, changeResult);
            Assert.NotEqual(keepResult, changeResult);
        }
    }
}