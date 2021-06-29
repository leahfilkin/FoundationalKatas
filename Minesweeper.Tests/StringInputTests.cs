using System;
using System.Collections.Generic;
using Minesweeper.ConsoleClasses;
using Xunit;

namespace Minesweeper.Tests
{
    public class StringInputTests
    {

        [Theory]
        [MemberData(nameof(InputFields))]
        public void ConvertInputToFieldLines(InputFieldsData inputFieldsData)
        {
            var lines = StringInput.GetLines(inputFieldsData.FieldInput);

            Assert.Equal(inputFieldsData.NumberOfLines, lines);
        }

        [Fact]
        public void LinesConverterThrowErrorIfNoXToSeperateLinesAndColumns()
        {
            var input = new List<string>
            {
                "44",
                "*...",
                "....",
                ".*..",
                "...."
            };

            Assert.Throws<ArgumentException>(() => StringInput.GetLines(input));
        }

        [Fact]
        public void LinesConverterThrowErrorIfLinesGreaterThan100()
        {
            var input = new List<string>
            {
                "101x4",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",                
                "....",
                "....",
                "....",
                "....",
                "....",
                "....",
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => StringInput.GetLines(input));
        }
        
        [Fact]
        public void ThrowsErrorIfInputFieldIsNotSameHeightAsInputLines()
        {
            var input = new List<string>
            {
                "4x4",
                "*..."
            };
            
            Assert.Throws<ArgumentException>(() => StringInput.GetLines(input));

        }

        [Theory]
        [MemberData(nameof(InputFields))]
        public void ConvertInputToFieldColumns(InputFieldsData inputFieldsData)
        {
            var lines = StringInput.GetColumns(inputFieldsData.FieldInput);

            Assert.Equal(inputFieldsData.NumberOfColumns, lines);
        }

        [Fact]
        public void ColumnsConverterThrowErrorIfNoXToSeperateLinesAndColumns()
        {
            var input = new List<string>
            {
                "44",
                "*...",
                "....",
                ".*..",
                "...."
            };

            Assert.Throws<ArgumentException>(() => StringInput.GetColumns(input));
        }

        [Fact]
        public void ColumnsConverterThrowErrorIfLinesGreaterThan100()
        {
            var input = new List<string>
            {
                "4x104"
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => StringInput.GetColumns(input));
        }

        [Fact]
        public void ConvertsAsterisksToMines()
        {
            var input = new List<string>
            {
                "4x4",
                "*...",
                "....",
                ".*..",
                "...."

            };

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
            var input = new List<string>
            {
                "4x4",
                "*...",
                "....",
                ".*..",
                "...."
            };
            var expectedField = new Field(4, 4, new List<Point>
            {
                new Point(0, 0),
                new Point(2, 1)
            });

            var actualField =
                StringInput.ConvertToField(input);

            Assert.Equal(expectedField.Squares, actualField.Squares);
        }

        public class InputFieldsData
        {
            public List<string> FieldInput;
            public int NumberOfLines;
            public int NumberOfColumns;

        }

        public static IEnumerable<object[]> InputFields =>
            new TheoryData<InputFieldsData>
            {
                new InputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "4x4",
                        "*...",
                        "....",
                        ".*..",
                        "...."
                    },
                    NumberOfLines = 4,
                    NumberOfColumns = 4,
                },
                new InputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "3x5",
                        "**...",
                        ".....",
                        ".*..."
                    },
                    NumberOfLines = 3,
                    NumberOfColumns = 5,
                },
                new InputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "13x5",
                        "**...",
                        ".....",
                        ".*...",
                        ".....",
                        ".....",
                        ".....",
                        ".....",
                        ".....",
                        ".....",
                        ".....",
                        ".....",
                        ".....",
                        "....."
                    },
                    NumberOfLines = 13,
                    NumberOfColumns = 5,
                }
            };
    }
}