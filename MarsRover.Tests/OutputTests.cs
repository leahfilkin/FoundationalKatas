using System.Collections.Generic;
using MarsRover.Console;
using MarsRover.Enums;
using Xunit;

namespace MarsRover.Tests
{
    public class OutputTests
    {
        [Fact]
        public void DisplaysCompletedMove()
        {
            var grid = new Grid(new FakeRandom(new List<int>() {0}));
            var startingPosition = new Point(5, 5);
            var rover = new Rover(grid, startingPosition, Direction.North);
            var commands = new List<Command>{Command.Forward};

            var navigationHistory = rover.Navigate(commands, grid);

            var outputHistory = Output.GetNavigationHistory(navigationHistory);

            Assert.Equal("The rover has moved Forward to (5,4)", outputHistory);

        }
        
    }
}