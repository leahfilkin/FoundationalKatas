using System.Collections.Generic;
using Minesweeper.Enums;
using Xunit;

namespace Minesweeper.Tests
{
    public class MinesweeperTests
    {
        [Fact]
        public void ReturnsFieldInputsAsFieldType()
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
            var expectedResult = new List<List<List<Piece>>> {
                new List<List<Piece>>
                {
                    new List<Piece>
                    {
                        Piece.Mine,
                        Piece.Two,
                        Piece.One,
                        Piece.Zero,
                    },
                    new List<Piece>
                    {
                        Piece.Two,
                        Piece.Mine,
                        Piece.Two,
                        Piece.One,
                    },
                    new List<Piece>
                    {
                        Piece.One,
                        Piece.Two,
                        Piece.Mine,
                        Piece.Two,
                    },
                    new List<Piece>
                    {
                        Piece.Zero,
                        Piece.One,
                        Piece.Two,
                        Piece.Mine,
                    }
                }, 
                new List<List<Piece>>
                {
                    new List<Piece>
                    {
                        Piece.Mine,
                        Piece.Mine,
                        Piece.Mine,
                    },
                    new List<Piece>
                    {
                        Piece.Mine,
                        Piece.Eight,
                        Piece.Mine,
                    },
                    new List<Piece>
                    {
                        Piece.Mine,
                        Piece.Mine,
                        Piece.Mine,
                    }
                }
            };

            var fields = FieldBuilder.BuildFields(fieldInputs);
            
            Assert.Equal(expectedResult[0], fields[0].Squares);
            Assert.Equal(expectedResult[1], fields[1].Squares);

        }
    }
}