using System;
using System.Collections.Generic;
using Minesweeper.ConsoleClasses;
using Xunit;

namespace Minesweeper.Tests
{
    public class StringInputTests
    {
        [Theory]
        [InlineData("4x4\n*...\n....\n.*..\n....", 4)]
        [InlineData("3x5\n**...\n..... \n.*...", 3)]
        [InlineData("13x5\n**...\n..... \n.*...\n....." +
                    "\n.....\n.....\n.....\n.....\n....." +
                    "\n.....\n.....\n.....\n.....", 13)]
        public void ConvertInputToFieldLines(string input, int expectedLines)
        {
            var lines = StringInput.GetLines(input);
            
            Assert.Equal(expectedLines, lines);
        }

        [Fact]
        public void LinesConverterThrowErrorIfNoXToSeperateLinesAndColumns()
        {
            var input = "44\n*...\n....\n.*..\n....";
            
            Assert.Throws<ArgumentException>(() => StringInput.GetLines(input));
        }

        [Fact]
        public void LinesConverterThrowErrorIfLinesGreaterThan100()
        {
            var input = "101x4\n*...";
            
            Assert.Throws<ArgumentOutOfRangeException>(() => StringInput.GetLines(input));
        }

        [Fact]
        public void ConvertInputToFieldColumns()
        {
            var input = "4x4\n*...\n....\n.*..\n....";
            
            var lines = StringInput.GetColumns(input);
            
            Assert.Equal(4, lines);
        }
        
        [Fact]
        public void ColumnsConverterThrowErrorIfNoXToSeperateLinesAndColumns()
        {
            var input = "44\n*...\n....\n.*..\n....";
            
            Assert.Throws<ArgumentException>(() => StringInput.GetColumns(input));
        }

        [Fact]
        public void ColumnsConverterThrowErrorIfLinesGreaterThan100()
        {
            var input = "4x104\n*...";
            
            Assert.Throws<ArgumentOutOfRangeException>(() => StringInput.GetColumns(input));
        }

        [Fact]
        public void ConvertsAsterisksToMines()
        {
            var input = "4x4\n*...\n....\n.*..\n....";
            var expectedMines = new List<Point>
            {
                new Point(0, 0),
                new Point(2, 1)
            };
            
            var mines = StringInput.GetMines(input);
            
            Assert.Equal(expectedMines, mines);
        }

        [Fact]
        public void CreatesFieldObjectFromMinesLinesAndColumnsGivenByOtherConvertingMethods()
        {
            var input = "4x4\n*...\n....\n.*..\n....";
            var expectedField = new Field(4,4, new List<Point>
            {
                new Point(0, 0),
                new Point(2, 1)
            });

            var actualField = StringInput.ConvertToField(input);
            
            Assert.Equal(expectedField.Squares, actualField.Squares);
        }
    }
}