
using System;

namespace RomanNumerals
{
    public static class RomanNumeral
    {
        public static string Convert(int i)
        {
            if (i <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Number must be greater than zero");
            }
            var result = ConvertTens(i);
            var one = i % 10;

            result += one switch
            {
                1 => "I",
                2 => "II",
                3 => "III",
                4 => "IV",
                5 => "V",
                6 => "VI",
                7 => "VII",
                8 => "VIII",
                9 => "IX",
                10 => "X",
                _ => ""
            };

            return result;
        }

        private static string ConvertTens(int i)
        {
            var amountOfTens = i / 10;
            var tens = "";
            for (int x = 0; x < amountOfTens; x++)
            {
                tens += "X";
            }
            return tens;
        }
    }
}