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
            var stringInput = new StringInput();
            
            var lines = stringInput.GetLines(input);
            
            Assert.Equal(expectedLines, lines);
        }

        [Fact]
        public void LinesConverterThrowErrorIfNoXToSeperateLinesAndColumns()
        {
            var stringInput = new StringInput();
            var input = "44\n*...\n....\n.*..\n....";
            
            Assert.Throws<ArgumentException>(() => stringInput.GetLines(input));
        }

        [Fact]
        public void LinesConverterThrowErrorIfLinesGreaterThan100()
        {
            var stringInput = new StringInput();
            var input = "101x4\n*...";
            
            Assert.Throws<ArgumentOutOfRangeException>(() => stringInput.GetLines(input));
        }

        [Fact]
        public void ConvertInputToFieldColumns()
        {
            var stringInput = new StringInput();
            var input = "4x4\n*...\n....\n.*..\n....";
            
            var lines = stringInput.GetColumns(input);
            
            Assert.Equal(4, lines);
        }
        
        [Fact]
        public void ColumnsConverterThrowErrorIfNoXToSeperateLinesAndColumns()
        {
            var stringInput = new StringInput();
            var input = "44\n*...\n....\n.*..\n....";
            
            Assert.Throws<ArgumentException>(() => stringInput.GetColumns(input));
        }

        [Fact]
        public void ColumnsConverterThrowErrorIfLinesGreaterThan100()
        {
            var stringInput = new StringInput();
            var input = "4x104\n*...";
            
            Assert.Throws<ArgumentOutOfRangeException>(() => stringInput.GetColumns(input));
        }

        [Fact]
        public void ConvertsAsterisksToMines()
        {
            var stringInput = new StringInput();
            var input = "4x4\n*...\n....\n.*..\n....";
            var expectedMines = new List<Point>
            {
                new Point(0, 0),
                new Point(2, 1)
            };
            
            var mines = stringInput.GetMines(input);
            
            Assert.Equal(expectedMines, mines);
        }

        [Fact]
        public void CreatesFieldObjectFromMinesLinesAndColumnsGivenByOtherConvertingMethods()
        {
            var stringInput = new StringInput();
            var input = "4x4\n*...\n....\n.*..\n....";
            var expectedField = new Field(4,4, new List<Point>
            {
                new Point(0, 0),
                new Point(2, 1)
            });

            var actualField = stringInput.ConvertToField(input);
            
            Assert.Equal(expectedField.Squares, actualField.Squares);
        }

        // [Fact]
        // public void SplitFieldsInputIntoListOfFields()
        // {
        //     var stringInput = new StringInput();
        //     var input = "4x4\n*...\n....\n.*..\n....\n3x5\n**...\n..... \n.*...";
        //     var expectedFields = new List<Field>
        //     {
        //         new Field(4, 4, new List<Point>
        //         {
        //             new Point(0,0),
        //             new Point(2,1)
        //         }),
        //         new Field(3,5, new List<Point>
        //         {
        //             new Point(0,0),
        //             new Point(0,1),
        //             new Point(2,1)
        //         })
        //     };
        //     
        //     var fields = stringInput.SeperateIntoFields(input);
        //     
        //     Assert.Equal(expectedFields, fields);
        // }
    }
}