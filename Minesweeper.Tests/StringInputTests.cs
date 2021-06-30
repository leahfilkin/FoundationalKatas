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

        [Theory]
        [InlineData("fourx4")]
        [InlineData("4xfour")]
        public void ThrowsErrorIfDimensionsInputsAreNotIntegers(string dimensions)
        {
            var input = new List<string>
            {
                dimensions,
                "*...",
                "....",
                ".*..",
                "...."
            };

            Assert.Throws<ArgumentException>(() => StringInput.ConvertToField(input));
        }

        [Fact]
        public void ThrowErrorsIfNoXToSeparateLinesAndColumns()
        {
            var input = new List<string>
            {
                "44",
                "*...",
                "....",
                ".*..",
                "...."
            };

            Assert.Throws<ArgumentException>(() => StringInput.ConvertToField(input));
        }

        [Theory]
        [MemberData(nameof(GreaterThan100InputFields))]
        public void ThrowsErrorIfDimensionsGreaterThan100(GreaterThan100InputFieldsData greaterThan100InputFieldsData)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringInput.ConvertToField(greaterThan100InputFieldsData.FieldInput));
        }
        
        [Theory]
        [MemberData(nameof(MismatchedDimensionsInput))]
        public void ThrowsErrorIfInputFieldIsNotSameDimensionsAsInputtedDimensions(MismatchedDimensionsInputData mismatchedDimensionsInputData)
        {
            Assert.Throws<ArgumentException>(() => StringInput.ConvertToField(mismatchedDimensionsInputData.FieldInput));
        }

        [Theory]
        [MemberData(nameof(InputFields))]
        public void ConvertInputToFieldColumns(InputFieldsData inputFieldsData)
        {
            var columns = StringInput.GetColumns(inputFieldsData.FieldInput);

            Assert.Equal(inputFieldsData.NumberOfColumns, columns);
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

        public class MismatchedDimensionsInputData
        {
            public List<string> FieldInput;
        }

        public static IEnumerable<object[]> MismatchedDimensionsInput =>
            new TheoryData<MismatchedDimensionsInputData>
            {
                new MismatchedDimensionsInputData
                {
                    FieldInput = new List<string>
                    {
                        "9x9",
                        "*...***.*",
                        "*...***.*",
                        "*...***.*",
                    }
                },
                new MismatchedDimensionsInputData
                {
                    FieldInput = new List<string>
                    {
                        "5x5",
                        "***.",
                        "***.",
                        "***.",
                        "***.",
                        "***."
                    }
                }
            };

        public class GreaterThan100InputFieldsData
        {
            public List<string> FieldInput;
        }

        public static IEnumerable<object[]> GreaterThan100InputFields =>
            new TheoryData<GreaterThan100InputFieldsData>
            {
                new GreaterThan100InputFieldsData
                {
                    FieldInput =  new List<string>
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
                    }
                },
                new GreaterThan100InputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "4x104",
                        ".....*........*........*........*........*........*........*........*........*........*...****..*...****",
                        ".....*........*........*........*........*........*........*........*........*........*...****..*...****",
                        ".....*........*........*........*........*........*........*........*........*........*...****..*...****",
                        ".....*........*........*........*........*........*........*........*........*........*...****..*...****",
                    }
                }
                

            };
        
        
        
        

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