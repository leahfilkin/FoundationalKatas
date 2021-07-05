using System;
using System.Collections.Generic;
using Minesweeper.ConsoleClasses;
using Xunit;

namespace Minesweeper.Tests.ConsoleClasses
{
    public class StringInputTests
    {

        [Theory]
        [MemberData(nameof(InputFields))]
        public void ConvertInputToFieldDimensions(InputFieldsData inputFieldsData)
        {
            var lines = StringInput.GetLines(inputFieldsData.FieldInput);
            var columns = StringInput.GetColumns(inputFieldsData.FieldInput);

            Assert.Equal(inputFieldsData.NumberOfLines, lines);
            Assert.Equal(inputFieldsData.NumberOfColumns, columns);

        }


        [Theory]
        [MemberData(nameof(IncorrectInputFields))]
        public void ThrowErrorsIfInvalidInputGiven(IncorrectInputFieldsData incorrectInputFieldsData)
        {
            Assert.Throws<ArgumentException>(() => StringInput.ConvertToField(incorrectInputFieldsData.FieldInput));
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
        
        

        public class IncorrectInputFieldsData
        {
            public List<string> FieldInput;
        }

        public static IEnumerable<object[]> IncorrectInputFields =>
            new TheoryData<IncorrectInputFieldsData>
            {
                new IncorrectInputFieldsData
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
                new IncorrectInputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "4x104",
                        ".....*........*........*........*........*........*........*........*........*........*...****..*...****",
                        ".....*........*........*........*........*........*........*........*........*........*...****..*...****",
                        ".....*........*........*........*........*........*........*........*........*........*...****..*...****",
                        ".....*........*........*........*........*........*........*........*........*........*...****..*...****",
                    }
                },
                new IncorrectInputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "5x5",
                        "***..",
                        "***..",
                        "***.",
                        "***..",
                        "***.."
                    }
                },
                new IncorrectInputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "9x9",
                        "*...***.*",
                        "*...***.*",
                        "*...***.*",
                    }
                },
                new IncorrectInputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "fourx4",
                        "*...",
                        "....",
                        ".*..",
                        "...."
                    }
                },
                new IncorrectInputFieldsData
                {
                    FieldInput = new List<string>
                    {
                        "4xfour",
                        "*...",
                        "....",
                        ".*..",
                        "...."
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