using System;
using System.Linq;
using Minesweeper.Enums;

namespace Minesweeper.ConsoleClasses
{
    public class StringOutput
    {
        public static string ConvertPiecesToOutputNumbers(Field field)
        {
           return string.Join("\n",field.Squares.Select(
                   line => string.Join("",line.Select(
                    square => square switch
                        {
                            Piece.Zero => "0",
                            Piece.One => "1",
                            Piece.Two => "2",
                            Piece.Three => "3",
                            Piece.Four => "4",
                            Piece.Five => "5",
                            Piece.Six => "6",
                            Piece.Seven => "7",
                            Piece.Eight => "8",
                            Piece.Mine => "*",
                            _ => throw new ArgumentOutOfRangeException()
                        })))
                );
        }
    }
}