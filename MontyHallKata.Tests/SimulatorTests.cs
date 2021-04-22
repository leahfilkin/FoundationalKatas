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
            var actual = simulator.GetPercentage();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void SimulatorShouldAppendEachResultToList()
        {
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor);
            simulator.RunSimulation(10);
            Assert.Equal(10, simulator.Results.Count);
        }
        
        [Theory]
        [InlineData(new []{1,0,0}, 33.3)]
        [InlineData(new []{0,0,0}, 0)]
        [InlineData(new []{1,1,1}, 100)]
        public void CalculateResultShouldReturnCorrectPercentage(int[] results, double expected)
        {
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var simulator = new Simulator(keepOriginalDoor) {Results = results.ToList()};
            var result = simulator.GetPercentage();
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void SimulatorScoresStrategiesDifferently()
        {
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var changeDoor = Strategy.ChangeDoor;
            var keepOriginalDoorSimulator = new FakeSimulator(keepOriginalDoor);
            var changeDoorSimulator = new FakeSimulator(changeDoor);
            
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