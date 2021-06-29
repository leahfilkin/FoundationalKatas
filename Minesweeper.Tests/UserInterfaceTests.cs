using System.Collections.Generic;
using Minesweeper.ConsoleClasses;
using Xunit;

namespace Minesweeper.Tests
{
    public class UserInterfaceTests
    {
        [Fact]
        public void ReturnsFieldInputsAsCompletedFieldsWithAdjacentMineNumbers()
        {
            var fieldInputs = new List<List<string>>
            {
                new List<string>
                {
                    "4x4",
                    "*...",
                    ".*..",
                    "..*.",
                    "...*"
                },
                new List<string>
                {
                    "3x3",
                    "***",
                    "*.*",
                    "***"
                }
            };
            var expectedResult = new List<string>
            {
                "Field #1:\n*210\n2*21\n12*2\n012*",
                "Field #2:\n***\n*8*\n***"
            };
            var fieldsFilledOut = UserInterface.CompleteGame(fieldInputs);
            Assert.Equal(expectedResult, fieldsFilledOut);

        }
    }
}