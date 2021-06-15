using System.Collections;
using System.Collections.Generic;
using MarsRover.Console;
using MarsRover.Enums;
using Xunit;

namespace MarsRover.Tests
{
    public class TestData
    {
        public List<Command> Commands;
        public string Result;
    }
    public class OutputTests
    {
        public static IEnumerable<object[]> CommandResultData =>
            new TheoryData<TestData>
            {
                new TestData
                {
                    Commands = new List<Command> {Command.Forward},
                    Result = "The rover has moved Forward to (5,4)"

                },
                new TestData
                {
                    Commands = new List<Command> {Command.Forward, Command.Left},
                    Result = "The rover has moved Forward to (5,4)\nThe rover has turned Left to face West"

                },
                new TestData
                {
                    Commands = new List<Command>{Command.Left, Command.Backward, Command.Right},
                    Result =
                        "The rover has turned Left to face West\nThe rover has moved Backward to (6,5)\nThe rover has turned Right to face North"
                },
                new TestData
                {
                    Commands = new List<Command> {Command.Left, Command.Forward, Command.Right, Command.Backward},
                    Result = "The rover has turned Left to face West\nThe rover has moved Forward to (4,5)\nThe rover has turned Right to face North\nThe rover has moved Backward to (4,6)"
                }
            };
        
        [Theory]
        [MemberData(nameof(CommandResultData))]
        public void DisplaysCompletedMoves(TestData testData)
        {
            var grid = new Grid(new FakeRandom(new List<int>() {0}));
            var startingPosition = new Point(5, 5);
            var rover = new Rover(grid, startingPosition, Direction.North);

            var navigationHistory = rover.Navigate(testData.Commands, grid);

            var outputHistory = Output.GetNavigationHistory(navigationHistory);

            Assert.Equal(testData.Result, outputHistory);
        }
    }
}