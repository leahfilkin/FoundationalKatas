using System.Collections.Generic;
using Minesweeper.ConsoleClasses;
using Xunit;

namespace Minesweeper.Tests
{
    public class OutputConverterTests
    {
        [Fact]
        public void ConvertsMineToAsterisk()
        {
            var field = new Field(3, 3, new List<Point> {new Point(0, 0)});
            field.PopulateWithAdjacentMineNumbers();

            var convertedOutput = StringOutput.ConvertPiecesToOutputNumbers(field);
            
            Assert.Equal('*', convertedOutput[0]);
        }
        
        [Fact]
        public void ConvertsZeroPieceTo0()
        {
            var field = new Field(3, 3, new List<Point> {new Point(0, 0)});
            field.PopulateWithAdjacentMineNumbers();

            var convertedOutput = StringOutput.ConvertPiecesToOutputNumbers(field);
            
            Assert.Equal('0', convertedOutput[2]);
        }
        
        [Fact]
        public void ConvertsOnePieceTo1()
        {
            var field = new Field(3, 3, new List<Point> {new Point(0, 0)});
            field.PopulateWithAdjacentMineNumbers();

            var convertedOutput = StringOutput.ConvertPiecesToOutputNumbers(field);
            
            Assert.Equal('1', convertedOutput[1]);
        }

        [Theory]
        [MemberData(nameof(OutputConverter))]
        public void ConvertsPiecesToCorrectNumberOrCharacter(OutputConverterData outputConverterData)
        {
            var field = new Field(outputConverterData.NumberOfRows, outputConverterData.NumberOfColumns, 
                outputConverterData.MinePoints);
            field.PopulateWithAdjacentMineNumbers();

            var convertedOutput = StringOutput.ConvertPiecesToOutputNumbers(field);
            
            Assert.Equal(outputConverterData.ExpectedOutput, convertedOutput);
        }

        [Theory]
        [MemberData(nameof(OutputConverter))]
        public void PutsNewlineCharacterAtEndOfEachLine(OutputConverterData outputConverterData)
        {
            var field = new Field(outputConverterData.NumberOfRows, outputConverterData.NumberOfColumns, 
                outputConverterData.MinePoints);
            field.PopulateWithAdjacentMineNumbers();

            var convertedOutput = StringOutput.ConvertPiecesToOutputNumbers(field);
            
            Assert.Equal(outputConverterData.ExpectedOutput, convertedOutput);
        }

        public class OutputConverterData
        {
            public List<Point> MinePoints;
            public int NumberOfRows;
            public int NumberOfColumns;
            public string ExpectedOutput;
        }

        public static IEnumerable<object[]> OutputConverter =>
            new TheoryData<OutputConverterData>
            {
                new OutputConverterData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                        new Point(2, 1),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    ExpectedOutput = "**1\n332\n1*1"
                },
                new OutputConverterData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                        new Point(2, 1)
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 5,
                    ExpectedOutput = "**100\n33200\n1*100"
                },
                new OutputConverterData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0, 2),
                        new Point(1, 0),
                        new Point(2, 1),
                    },
                    NumberOfRows = 4,
                    NumberOfColumns = 4,
                    ExpectedOutput = "*3*1\n*421\n2*10\n1110"
                },
                new OutputConverterData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0, 2),
                        new Point(1, 0),
                        new Point(1, 2),
                        new Point(2, 1),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    ExpectedOutput = "*4*\n*5*\n2*2"
                },
                new OutputConverterData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0, 2),
                        new Point(1, 0),
                        new Point(1, 2),
                        new Point(2, 0),
                        new Point(2, 1),
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    ExpectedOutput = "*4*\n*6*\n**2"
                },
                new OutputConverterData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0, 2),
                        new Point(1, 0),
                        new Point(1, 2),
                        new Point(2, 0),
                        new Point(2, 1),
                        new Point(2, 2)
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    ExpectedOutput = "*4*\n*7*\n***"
                },
                new OutputConverterData
                {
                    MinePoints = new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                        new Point(0, 2),
                        new Point(1, 0),
                        new Point(1, 2),
                        new Point(2, 0),
                        new Point(2, 1),
                        new Point(2, 2)
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    ExpectedOutput = "***\n*8*\n***"
                },
            };
    }
}