using System.Collections.Generic;
using MarsRover.Console;
using MarsRover.Enums;
using Xunit;

namespace MarsRover.Tests
{
    public class OutputTests
    {
        [Theory]
        [MemberData(nameof(CompletedMovesData), nameof(ResultingString))]
        public void DisplaysCompletedMoves(List<Command> commands, string expected)
        {
            var grid = new Grid(new FakeRandom(new List<int>() {0}));
            var startingPosition = new Point(5, 5);
            var rover = new Rover(grid, startingPosition, Direction.North);

            var navigationHistory = rover.Navigate(commands, grid);

            var outputHistory = Output.GetNavigationHistory(navigationHistory);

            Assert.Equal(expected, outputHistory);
        }

        public static IEnumerable<object[]> ResultingString()
        {
            yield return new object[]
            {
                new List<string>
                {
                    "The rover has moved Forward to (5,4)"
                }
            };
            yield return new object[]
            {
                new List<string>
                {
                    "The rover has moved Forward to (5,4)\nThe rover has turned Left to face West"
                }
            };
            yield return new object[]
            {
                new List<string>
                {
                    "The rover has turned Left to face West\nThe rover has moved Backward to (6,5)\nThe rover has turned Right to face North"
                }
            };
            yield return new object[]
            {
                new List<string>
                {
                    "The rover has turned Left to face West\nThe rover has moved Forward to (4,5)\nThe rover has turned Right to face North\nThe rover has moved Backward to (4,4)"
                }
            };
        }

        public static IEnumerable<object[]> CompletedMovesData()
        {
            yield return new object[]
            {
                new List<Command>
                {
                    Command.Forward
                }
            };
            yield return new object[]
            {
                new List<Command>
                {
                    Command.Forward,
                    Command.Left
                }
            };
            yield return new object[]
            {
                new List<Command>
                {
                    Command.Left,
                    Command.Backward,
                    Command.Right
                }
            };
            yield return new object[]
            {
                Command.Left,
                Command.Forward,
                Command.Right,
                Command.Backward
            };
        }

        
        public void DisplaysMultipleCompletedMoves()
        {
            var grid = new Grid(new FakeRandom(new List<int>() {0}));
            var startingPosition = new Point(5, 5);
            var rover = new Rover(grid, startingPosition, Direction.North);
            var commands = new List<Command>{Command.Forward, Command.Left};

            var navigationHistory = rover.Navigate(commands, grid);

            var outputHistory = Output.GetNavigationHistory(navigationHistory);

            Assert.Equal("The rover has moved Forward to (5,4)\nThe rover has turned Left to face West", outputHistory);
        }
    }
}