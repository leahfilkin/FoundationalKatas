using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Enums;

namespace Minesweeper.ConsoleClasses
{
    public class OutputConverter
    {
        public List<string> ConvertFieldToCharacters(Field field)
        {
            var outputField = new List<string>();
            foreach (var square in field.Squares.SelectMany(line => line))
            {
                switch (square.Piece)
                {
                    case Piece.Zero:
                        outputField.Add("0");
                        break;
                    case Piece.One:
                        outputField.Add("1");
                        break;
                    case Piece.Two:
                        outputField.Add("2");
                        break;
                    case Piece.Three:
                        outputField.Add("3");
                        break;
                    case Piece.Four:
                        outputField.Add("4");
                        break;
                    case Piece.Five:
                        outputField.Add("5");
                        break;
                    case Piece.Six:
                        outputField.Add("6");
                        break;
                    case Piece.Seven:
                        outputField.Add("7");
                        break;
                    case Piece.Eight:
                        outputField.Add("8");
                        break;
                    case Piece.Mine:
                        outputField.Add("*");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return outputField;
        }
    }
}